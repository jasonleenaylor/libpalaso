using System;
using Palaso.Progress;
using Palaso.UI.WindowsForms.Progress.Commands;

namespace Palaso.UI.WindowsForms.Progress
{
	public class ProgressDialogProgressState : ProgressState
	{
		private readonly ProgressDialogHandler _progressHandler;

		public ProgressDialogProgressState(ProgressDialogHandler _progressHandler): base()
		{
			this._progressHandler = _progressHandler;
			//System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			if (_progressHandler != null)
			{
				_progressHandler.Cancelled += new EventHandler(_progressHandler_Cancelled);
			}
		}


		void _progressHandler_Cancelled(object sender, EventArgs e)
		{
			Cancel = true;
		}

		/// <summary>
		/// How much the task is done
		/// </summary>
		public override int NumberOfStepsCompleted
		{
			get
			{
				return base.NumberOfStepsCompleted;
			}
			set
			{
				base.NumberOfStepsCompleted = value;
				_progressHandler.UpdateProgress(NumberOfStepsCompleted);
			}
		}

		/// <summary>
		/// a label which describes what we are busy doing
		/// </summary>
		public override string StatusLabel
		{
			get
			{
				return base.StatusLabel;
			}

			set
			{
				base.StatusLabel = value;
				_progressHandler.UpdateStatus1(value);
			}
		}

		public override int TotalNumberOfSteps
		{
			get
			{
				return base.TotalNumberOfSteps;
			}
			set
			{
				base.TotalNumberOfSteps = value;
				_progressHandler.InitializeProgress(0, value);
			}
		}

	}
}