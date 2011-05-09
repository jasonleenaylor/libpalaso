using System;
using System.Collections.Generic;
using System.Linq;
using Palaso.Code;

namespace Palaso.WritingSystems
{
	public class WritingSystemRepositoryBase : IWritingSystemRepository
	{

		private readonly Dictionary<string, WritingSystemDefinition> _writingSystems;
		private readonly Dictionary<string, DateTime> _writingSystemsToIgnore;

		public event WritingSystemIdChangedEventHandler WritingSystemIdChanged;

		/// <summary>
		/// Use the default repository
		/// </summary>
		public WritingSystemRepositoryBase()
		{
			_writingSystems = new Dictionary<string, WritingSystemDefinition>(StringComparer.OrdinalIgnoreCase);
			_writingSystemsToIgnore = new Dictionary<string, DateTime>(StringComparer.OrdinalIgnoreCase);
			//_sharedStore = LdmlSharedWritingSystemRepository.Singleton;
		}

		[Obsolete("Deprecated: use AllWritingSystems instead")]
		public IEnumerable<WritingSystemDefinition> WritingSystemDefinitions
		{
			get { return AllWritingSystems; }
		}

		protected IDictionary<string, DateTime> WritingSystemsToIgnore
		{
			get
			{
				return _writingSystemsToIgnore;
			}
		}

		virtual public WritingSystemDefinition CreateNew()
		{
			var retval = new WritingSystemDefinition();
			return retval;
		}

		virtual protected LdmlAdaptor CreateLdmlAdaptor()
		{
			return new LdmlAdaptor();
		}

		virtual public void Remove(string identifier)
		{
			if (identifier == null)
			{
				throw new ArgumentNullException("identifier");
			}
			if (!_writingSystems.ContainsKey(identifier))
			{
				throw new ArgumentOutOfRangeException("identifier");
			}
			// Delete from us
			//??? Do we really delete or just mark for deletion?
			_writingSystems.Remove(identifier);
			_writingSystemsToIgnore.Remove(identifier);
			//TODO: Could call the shared store to advise that one has been removed.
			//TODO: This may be useful if writing systems were reference counted.
		}

		virtual public void LastChecked(string identifier, DateTime dateModified)
		{
			if (_writingSystemsToIgnore.ContainsKey(identifier))
			{
				_writingSystemsToIgnore[identifier] = dateModified;
			}
			else
			{
				_writingSystemsToIgnore.Add(identifier, dateModified);
			}
		}

		protected void Clear()
		{
			_writingSystems.Clear();
		}

		public WritingSystemDefinition MakeDuplicate(WritingSystemDefinition definition)
		{
			if (definition == null)
			{
				throw new ArgumentNullException("definition");
			}
			return definition.Clone();
		}

		[Obsolete("Deprecated: use Contains instead")]
		public bool Exists(string identifier)
		{
			return Contains(identifier);
		}

		public bool Contains(string identifier)
		{
			return _writingSystems.ContainsKey(identifier);
		}

		public virtual void Set(WritingSystemDefinition ws)
		{
			if (ws == null)
			{
				throw new ArgumentNullException("ws");
			}
			string newID = (!String.IsNullOrEmpty(ws.RFC5646)) ? ws.RFC5646 : "unknown";
			if (_writingSystems.ContainsKey(newID) && newID != ws.StoreID)
			{
				throw new ArgumentException(String.Format("Unable to store writing system '{0}' because this id already exists.  Please change this writing system before storing.", newID));
			}
			//??? How do we update
			//??? Is it sufficient to just set it, or can we not change the reference in case someone else has it too
			//??? i.e. Do we need a ws.Copy(WritingSystemDefinition)?
			if (!String.IsNullOrEmpty(ws.StoreID) && _writingSystems.ContainsKey(ws.StoreID))
			{
				_writingSystems.Remove(ws.StoreID);
			}
			if (WritingSystemIdChanged != null)
			{
				WritingSystemIdChanged(this, new WritingSystemIdChangedEventArgs(ws.StoreID, newID));
			}



			ws.StoreID = newID;
			_writingSystems[ws.StoreID] = ws;
		}

		public string GetNewStoreIDWhenSet(WritingSystemDefinition ws)
		{
			if (ws == null)
			{
				throw new ArgumentNullException("ws");
			}
			return (!String.IsNullOrEmpty(ws.RFC5646)) ? ws.RFC5646 : "unknown";
		}

		public bool CanSet(WritingSystemDefinition ws)
		{
			if (ws == null)
			{
				return false;
			}
			string newID = (!String.IsNullOrEmpty(ws.RFC5646)) ? ws.RFC5646 : "unknown";
			return newID == ws.StoreID || !_writingSystems.ContainsKey(newID);
		}

		public WritingSystemDefinition Get(string identifier)
		{
			if (identifier == null)
			{
				throw new ArgumentNullException("identifier");
			}
			if (!_writingSystems.ContainsKey(identifier))
			{
				throw new ArgumentOutOfRangeException("identifier", String.Format("Writing system id '{0}' does not exist.", identifier));
			}
			return _writingSystems[identifier];
		}

		public int Count
		{
			get
			{
				return _writingSystems.Count;
			}
		}

		virtual public void Save()
		{
		}

		virtual protected void OnChangeNotifySharedStore(WritingSystemDefinition ws)
		{
			DateTime lastDateModified;
			if (_writingSystemsToIgnore.TryGetValue(ws.Id, out lastDateModified) && ws.DateModified > lastDateModified)
				_writingSystemsToIgnore.Remove(ws.Id);
		}

		virtual protected void OnRemoveNotifySharedStore()
		{
		}

		virtual public IEnumerable<WritingSystemDefinition> WritingSystemsNewerIn(IEnumerable<WritingSystemDefinition> rhs)
		{
			if (rhs == null)
			{
				throw new ArgumentNullException("rhs");
			}
			var newerWritingSystems = new List<WritingSystemDefinition>();
			foreach (var ws in rhs)
			{
				Guard.AgainstNull(ws, "ws in rhs");
				if (_writingSystems.ContainsKey(ws.RFC5646))
				{
					DateTime lastDateModified;
					if ((!_writingSystemsToIgnore.TryGetValue(ws.RFC5646, out lastDateModified) || ws.DateModified > lastDateModified)
						&& (ws.DateModified > _writingSystems[ws.RFC5646].DateModified))
					{
						newerWritingSystems.Add(ws.Clone());
					}
				}
			}
			return newerWritingSystems;
		}

		public IEnumerable<WritingSystemDefinition> AllWritingSystems
		{
			get
			{
				return _writingSystems.Values;
			}
		}

		public IEnumerable<WritingSystemDefinition> TextWritingSystems
		{
			get { return _writingSystems.Values.Where(ws => !ws.IsVoice); }
		}

		public IEnumerable<WritingSystemDefinition> VoiceWritingSystems
		{
			get { return _writingSystems.Values.Where(ws => ws.IsVoice); }
		}

		public virtual void OnWritingSystemIDChange(WritingSystemDefinition ws, string oldId)
		{
			_writingSystems[ws.Id] = ws;
			_writingSystems.Remove(oldId);
		}

		public IEnumerable<string> FilterForTextIds(IEnumerable<string> idsToFilter)
		{
			return TextWritingSystems.Where(ws => idsToFilter.Contains(ws.Id)).Select(ws => ws.Id);
		}
	}

	public class WritingSystemIdChangedEventArgs : EventArgs
	{
		public WritingSystemIdChangedEventArgs(string oldId, string newId)
		{
			OldId = oldId;
			NewId = newId;
		}
		public string OldId { get; private set; }
		public string NewId { get; private set; }
	}
}
