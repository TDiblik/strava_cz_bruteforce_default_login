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
            this.StartingNumberSelector = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FinalNumberSelector = new System.Windows.Forms.NumericUpDown();
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.LogViewer = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ExecutionProgress = new System.Windows.Forms.ProgressBar();
            this.ShouldSaveAccountsWithDefaultPassword = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.StartingNumberSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FinalNumberSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // CanteenList
            // 
            this.CanteenList.FormattingEnabled = true;
            this.CanteenList.Location = new System.Drawing.Point(12, 39);
            this.CanteenList.Name = "CanteenList";
            this.CanteenList.Size = new System.Drawing.Size(480, 184);
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
            this.RefreshCanteensButton.Location = new System.Drawing.Point(401, 5);
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
            // StartingNumberSelector
            // 
            this.StartingNumberSelector.Location = new System.Drawing.Point(12, 277);
            this.StartingNumberSelector.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.StartingNumberSelector.Name = "StartingNumberSelector";
            this.StartingNumberSelector.Size = new System.Drawing.Size(108, 23);
            this.StartingNumberSelector.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Start from number:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(142, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Finish with number:";
            // 
            // FinalNumberSelector
            // 
            this.FinalNumberSelector.Location = new System.Drawing.Point(142, 277);
            this.FinalNumberSelector.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.FinalNumberSelector.Name = "FinalNumberSelector";
            this.FinalNumberSelector.Size = new System.Drawing.Size(108, 23);
            this.FinalNumberSelector.TabIndex = 6;
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Location = new System.Drawing.Point(12, 317);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(480, 32);
            this.ExecuteButton.TabIndex = 8;
            this.ExecuteButton.Text = "Execute";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // LogViewer
            // 
            this.LogViewer.Location = new System.Drawing.Point(12, 418);
            this.LogViewer.Name = "LogViewer";
            this.LogViewer.Size = new System.Drawing.Size(480, 231);
            this.LogViewer.TabIndex = 9;
            this.LogViewer.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 400);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Log:";
            // 
            // ExecutionProgress
            // 
            this.ExecutionProgress.Location = new System.Drawing.Point(12, 355);
            this.ExecutionProgress.Name = "ExecutionProgress";
            this.ExecutionProgress.Size = new System.Drawing.Size(480, 23);
            this.ExecutionProgress.Step = 1;
            this.ExecutionProgress.TabIndex = 11;
            // 
            // ShouldSaveAccountsWithDefaultPassword
            // 
            this.ShouldSaveAccountsWithDefaultPassword.AutoSize = true;
            this.ShouldSaveAccountsWithDefaultPassword.Location = new System.Drawing.Point(267, 278);
            this.ShouldSaveAccountsWithDefaultPassword.Name = "ShouldSaveAccountsWithDefaultPassword";
            this.ShouldSaveAccountsWithDefaultPassword.Size = new System.Drawing.Size(225, 19);
            this.ShouldSaveAccountsWithDefaultPassword.TabIndex = 12;
            this.ShouldSaveAccountsWithDefaultPassword.Text = "Save accounts with default passwords";
            this.ShouldSaveAccountsWithDefaultPassword.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 661);
            this.Controls.Add(this.ShouldSaveAccountsWithDefaultPassword);
            this.Controls.Add(this.ExecutionProgress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LogViewer);
            this.Controls.Add(this.ExecuteButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FinalNumberSelector);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.StartingNumberSelector);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RefreshCanteensButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CanteenList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proof of concept";
            ((System.ComponentModel.ISupportInitialize)(this.StartingNumberSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FinalNumberSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckedListBox CanteenList;
        private Label label1;
        private Button RefreshCanteensButton;
        private Label label2;
        private NumericUpDown StartingNumberSelector;
        private Label label3;
        private Label label4;
        private NumericUpDown FinalNumberSelector;
        private Button ExecuteButton;
        private RichTextBox LogViewer;
        private Label label5;
        private ProgressBar ExecutionProgress;
        private CheckBox ShouldSaveAccountsWithDefaultPassword;
    }
}