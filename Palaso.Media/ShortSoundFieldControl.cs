﻿using System;
using System.IO;
using System.Windows.Forms;

namespace Palaso.Media
{
	public partial class ShortSoundFieldControl : UserControl
	{
		private  AudioRecorder _recorder;
		private string _path;
		private string _deleteButtonInstructions = "Delete this recording.";

		public event EventHandler SoundRecorded;
		public event EventHandler SoundDeleted;

		public ShortSoundFieldControl()
		{
			InitializeComponent();
			_recordButton.Bounds = _playButton.Bounds;//put it on top
			_hint.Left = _recordButton.Right + 5;
			_poorMansWaveform.Left = _hint.Left;
			_hint.Text = "";
		}



		public string Path
		{
			get { return _path; }
			set
			{
				_path = value;
				_recorder = new AudioRecorder(Path);
				toolTip1.SetToolTip(_deleteButton, _deleteButtonInstructions +"\r\n"+_path);
				_timer.Enabled = true;
			}
		}


		private void UpdateScreen()
		{
			bool exists = File.Exists(Path);
			bool mouseIsWithin = Parent.RectangleToScreen(Bounds).Contains(MousePosition);
			_recordButton.Enabled = _deleteButton.Enabled = mouseIsWithin;
			_playButton.Enabled = mouseIsWithin && !_recorder.IsPlaying;
			_recordButton.FlatAppearance.BorderSize = mouseIsWithin ? 1 : 0;

			_playButton.Visible = mouseIsWithin && exists && (_recorder.IsPlaying || _recorder.CanPlay);
			 _deleteButton.Visible = mouseIsWithin && exists;

			 bool mouseOverDeleteButton = RectangleToScreen(_deleteButton.Bounds).Contains(MousePosition);
			 _deleteButton.FlatAppearance.BorderSize = mouseOverDeleteButton ? 1 : 0;

			 bool mouseOverPlayButton = RectangleToScreen(_playButton.Bounds).Contains(MousePosition);
			 _playButton.FlatAppearance.BorderSize = mouseOverPlayButton ? 1 : 0;

			_poorMansWaveform.Visible = exists;
			_recordButton.Visible = !exists;


		}

//        private void _stopButton_Click(object sender, EventArgs e)
//        {
//            if(_recorder.IsRecording)
//            {
//                _recorder.StopRecording();
//            }
//            else
//            {
//                _recorder.StopPlaying();
//            }
//            UpdateScreen();
//        }

		private void timer1_Tick(object sender, EventArgs e)
		{
			UpdateScreen();
		}

		private void OnDeleteClick(object sender, EventArgs e)
		{
			if(File.Exists(_path))
			{
				File.Delete(_path);
				UpdateScreen();
				if (SoundDeleted != null)
				{
					SoundDeleted.Invoke(this, null);
				}
			}
		}

		private void OnRecordDown(object sender, MouseEventArgs e)
		{
			if (File.Exists(Path))
				File.Delete(Path);

			_recorder.StartRecording();
			UpdateScreen();

		}

		private void OnRecordUp(object sender, MouseEventArgs e)
		{
			try
			{
				_recorder.StopRecording();
			}
			catch(Exception)
			{
				//swallow it review: initial reason is that they didn't hold it down long enough, could detect and give message
			}

			if(_recorder.LastRecordingMilliseconds < 500 && File.Exists(_path))
			{
				File.Delete(_path);
				_hint.Text = "Hold down the record button while talking.";
			}
			else
			{
				_hint.Text = "";
			}
			UpdateScreen();
			if(SoundRecorded!=null)
			{
				SoundRecorded.Invoke(this, null);
			}
		}

		private void OnClickPlay(object sender, MouseEventArgs e)
		{
			_recorder.Play();
			UpdateScreen();
		}

		private void ShortSoundFieldControl_MouseEnter(object sender, EventArgs e)
		{
//            var pt = MousePosition;
//            bool b = Parent.RectangleToScreen(Bounds).Contains(pt);
//            UpdateScreen();
		}

	}
}