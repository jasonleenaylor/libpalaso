using System;
using System.Drawing;
using System.Windows.Forms;
using Palaso.WritingSystems;

namespace Palaso.UI.WritingSystems
{
	public partial class WSListDialog : Form
	{
		public WSListDialog()
		{
			InitializeComponent();
			MinimumSize = new Size(ClientSize.Width, 200);
			MaximumSize = new Size(ClientSize.Width, 2000);
		}


		private void _okButton_Click(object sender, EventArgs e)
		{
			_writingSystemListControl.SaveChangesToWSFiles();
			this.Close();
		}

		private void WSListDialog_Load(object sender, EventArgs e)
		{
			LdmlInFolderWritingSystemRepository repository = new LdmlInFolderWritingSystemRepository();

			_writingSystemListControl.LoadFromRepository(repository);
		}

		private void _cancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}