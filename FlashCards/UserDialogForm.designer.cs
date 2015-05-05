namespace FlashCards
{
    partial class UserDialogForm
    {
        //!  <summary>
        //!  Required designer variable.
        //!  </summary>
        private System.ComponentModel.IContainer components = null;

        //!  <summary>
        //!  Clean up any resources being used.
        //!  </summary>
        //!  <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        //!  <summary>
        //!  Required method for Designer support - do not modify
        //!  the contents of this method with the code editor.
        //!  </summary>
        private void InitializeComponent()
        {
            this.UserTextBox = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UserTextBox
            // 
            this.UserTextBox.Location = new System.Drawing.Point(19, 41);
            this.UserTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UserTextBox.Name = "UserTextBox";
            this.UserTextBox.Size = new System.Drawing.Size(158, 20);
            this.UserTextBox.TabIndex = 0;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(16, 16);
            this.Label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(74, 13);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Who are you?";
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(195, 40);
            this.OKButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(56, 21);
            this.OKButton.TabIndex = 3;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // UserDialogForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 124);
            this.ControlBox = false;
            this.Controls.Add(this.UserTextBox);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.OKButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserDialogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //!  <summary>
        //!  Required designer variable.
        //!  </summary>
        public System.Windows.Forms.TextBox UserTextBox;

        //!  <summary>
        //!  Required designer variable.
        //!  </summary>
        internal System.Windows.Forms.Label Label1;

        //!  <summary>
        //!  Required designer variable.
        //!  </summary>
        internal System.Windows.Forms.Button OKButton;
    }
}