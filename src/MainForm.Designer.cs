namespace strava_cz_bruteforce_default_login
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CanteenList = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RefreshCanteensButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CanteenList
            // 
            this.CanteenList.FormattingEnabled = true;
            this.CanteenList.Location = new System.Drawing.Point(12, 39);
            this.CanteenList.Name = "CanteenList";
            this.CanteenList.Size = new System.Drawing.Size(423, 184);
            this.CanteenList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Available canteens:";
            // 
            // RefreshCanteensButton
            // 
            this.RefreshCanteensButton.Location = new System.Drawing.Point(344, 5);
            this.RefreshCanteensButton.Name = "RefreshCanteensButton";
            this.RefreshCanteensButton.Size = new System.Drawing.Size(91, 23);
            this.RefreshCanteensButton.TabIndex = 2;
            this.RefreshCanteensButton.Text = "Refresh list";
            this.RefreshCanteensButton.UseVisualStyleBackColor = true;
            this.RefreshCanteensButton.Click += new System.EventHandler(this.RefreshCanteensButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "(check canteens you want to test agains)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RefreshCanteensButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CanteenList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proof of concept";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckedListBox CanteenList;
        private Label label1;
        private Button RefreshCanteensButton;
        private Label label2;
    }
}