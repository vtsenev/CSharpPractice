namespace PomodoroTimer
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.CloseBtn = new System.Windows.Forms.Button();
            this.ProgressPomodoro = new System.Windows.Forms.ProgressBar();
            this.StartBtn = new System.Windows.Forms.Button();
            this.PauseBtn = new System.Windows.Forms.Button();
            this.PomodoroCountLabel = new System.Windows.Forms.Label();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.SecondsTimer = new System.Windows.Forms.Timer(this.components);
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.CountDownLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CloseBtn
            // 
            resources.ApplyResources(this.CloseBtn, "CloseBtn");
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // ProgressPomodoro
            // 
            resources.ApplyResources(this.ProgressPomodoro, "ProgressPomodoro");
            this.ProgressPomodoro.Name = "ProgressPomodoro";
            this.ProgressPomodoro.Step = 4;
            // 
            // StartBtn
            // 
            resources.ApplyResources(this.StartBtn, "StartBtn");
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // PauseBtn
            // 
            resources.ApplyResources(this.PauseBtn, "PauseBtn");
            this.PauseBtn.Name = "PauseBtn";
            this.PauseBtn.UseVisualStyleBackColor = true;
            this.PauseBtn.Click += new System.EventHandler(this.PauseBtn_Click);
            // 
            // PomodoroCountLabel
            // 
            resources.ApplyResources(this.PomodoroCountLabel, "PomodoroCountLabel");
            this.PomodoroCountLabel.Name = "PomodoroCountLabel";
            // 
            // ResetBtn
            // 
            resources.ApplyResources(this.ResetBtn, "ResetBtn");
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.UseVisualStyleBackColor = true;
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // SecondsTimer
            // 
            this.SecondsTimer.Interval = 1000;
            this.SecondsTimer.Tick += new System.EventHandler(this.SecondsTimer_Tick);
            // 
            // ProgressLabel
            // 
            resources.ApplyResources(this.ProgressLabel, "ProgressLabel");
            this.ProgressLabel.Name = "ProgressLabel";
            // 
            // StatusLabel
            // 
            resources.ApplyResources(this.StatusLabel, "StatusLabel");
            this.StatusLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.StatusLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.StatusLabel.Name = "StatusLabel";
            // 
            // CountDownLabel
            // 
            resources.ApplyResources(this.CountDownLabel, "CountDownLabel");
            this.CountDownLabel.Name = "CountDownLabel";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CountDownLabel);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.ProgressLabel);
            this.Controls.Add(this.ResetBtn);
            this.Controls.Add(this.PomodoroCountLabel);
            this.Controls.Add(this.PauseBtn);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.ProgressPomodoro);
            this.Controls.Add(this.CloseBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.ProgressBar ProgressPomodoro;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Button PauseBtn;
        private System.Windows.Forms.Label PomodoroCountLabel;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.Timer SecondsTimer;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label CountDownLabel;
    }
}

