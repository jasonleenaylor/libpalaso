namespace EmailTest
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this._keymanTestBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this._keyman6TestBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.WritingSystemPickerButton = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this._probWithExitButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			//
			// button1
			//
			this.button1.Location = new System.Drawing.Point(34, 38);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(226, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Problem Notification with once per session";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			//
			// button2
			//
			this.button2.Location = new System.Drawing.Point(34, 121);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(144, 23);
			this.button2.TabIndex = 0;
			this.button2.Text = "Yellow Box Dialog";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			//
			// button3
			//
			this.button3.Location = new System.Drawing.Point(34, 161);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(144, 23);
			this.button3.TabIndex = 0;
			this.button3.Text = "Green Box Dialog";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			//
			// _keymanTestBox
			//
			this._keymanTestBox.Location = new System.Drawing.Point(155, 379);
			this._keymanTestBox.Name = "_keymanTestBox";
			this._keymanTestBox.Size = new System.Drawing.Size(100, 20);
			this._keymanTestBox.TabIndex = 1;
			this._keymanTestBox.Enter += new System.EventHandler(this._keyman7TestBox_Enter);
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(23, 379);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(126, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "First Keyman 7 keyboard:";
			//
			// _keyman6TestBox
			//
			this._keyman6TestBox.Location = new System.Drawing.Point(155, 406);
			this._keyman6TestBox.Name = "_keyman6TestBox";
			this._keyman6TestBox.Size = new System.Drawing.Size(100, 20);
			this._keyman6TestBox.TabIndex = 1;
			this._keyman6TestBox.Enter += new System.EventHandler(this._keyman6TestBox_Enter);
			//
			// label2
			//
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(23, 409);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(126, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "First Keyman 6 keyboard:";
			//
			// button4
			//
			this.button4.Location = new System.Drawing.Point(34, 226);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(226, 23);
			this.button4.TabIndex = 0;
			this.button4.Text = "NonFatal Exception with once per session policy";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.OnExceptionWithPolicyClick);
			//
			// button5
			//
			this.button5.Location = new System.Drawing.Point(34, 265);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(226, 23);
			this.button5.TabIndex = 0;
			this.button5.Text = "NonFatal MessageWithStack";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.OnNonFatalMessageWithStack);
			//
			// button6
			//
			this.button6.Location = new System.Drawing.Point(34, 305);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(226, 23);
			this.button6.TabIndex = 0;
			this.button6.Text = "Email Attachment";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			//
			// WritingSystemPickerButton
			//
			this.WritingSystemPickerButton.Location = new System.Drawing.Point(34, 335);
			this.WritingSystemPickerButton.Name = "WritingSystemPickerButton";
			this.WritingSystemPickerButton.Size = new System.Drawing.Size(221, 23);
			this.WritingSystemPickerButton.TabIndex = 3;
			this.WritingSystemPickerButton.Text = "Writing System Picker";
			this.WritingSystemPickerButton.UseVisualStyleBackColor = true;
			this.WritingSystemPickerButton.Click += new System.EventHandler(this.WritingSystemPickerButton_Click);
			//
			// button7
			//
			this.button7.Location = new System.Drawing.Point(34, 67);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(226, 23);
			this.button7.TabIndex = 0;
			this.button7.Text = "Really long Notification";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			//
			// _probWithExitButton
			//
			this._probWithExitButton.Location = new System.Drawing.Point(266, 38);
			this._probWithExitButton.Name = "_probWithExitButton";
			this._probWithExitButton.Size = new System.Drawing.Size(226, 23);
			this._probWithExitButton.TabIndex = 0;
			this._probWithExitButton.Text = "Problem Notification with Alternate Button";
			this._probWithExitButton.UseVisualStyleBackColor = true;
			this._probWithExitButton.Click += new System.EventHandler(this._probWithExitButton_Click);
			//
			// Form1
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(505, 480);
			this.Controls.Add(this.WritingSystemPickerButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this._keyman6TestBox);
			this.Controls.Add(this._keymanTestBox);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button7);
			this.Controls.Add(this._probWithExitButton);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox _keymanTestBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox _keyman6TestBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button WritingSystemPickerButton;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button _probWithExitButton;
	}
}
