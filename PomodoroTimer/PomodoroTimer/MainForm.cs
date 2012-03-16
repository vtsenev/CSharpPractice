using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace PomodoroTimer
{
    public partial class MainForm : Form
    {
        private string currentState = "none";
        private int pomodoroCount = 0;
        private Timer currentTimer;

        public MainForm()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            switch (currentState)
            {
                case "none": StartPomodoro(); break;
                case "paused pomodoro": ContinuePomodoro(); break;
                case "paused break": ContinueBreak(); break;
                case "pomodoro running": break;
                case "break running": break;
                default: throw new ArgumentException("Wrong state: {0}.", currentState);
            }
            StartBtn.Enabled = false;
            PauseBtn.Enabled = true;
        }

        private void StartPomodoro()
        {
            SecondsTimer.Start();
            currentTimer = new Timer("pomodoro");
            currentState = "pomodoro running";
            UpdateLabelsAndProgressBar();
        }

        private void ContinuePomodoro()
        {
            SecondsTimer.Start();
            currentState = "pomodoro running";
            UpdateLabelsAndProgressBar();
        }

        private void ContinueBreak()
        {
            SecondsTimer.Start();
            currentState = "break running";
            UpdateLabelsAndProgressBar();
        }

        private void StartBreak()
        {
            SecondsTimer.Start();
            if (pomodoroCount % 4 == 0)
            {
                StartLongBreak();
            }
            else
            {
                StartShortBreak();
            }
            currentState = "break running";
            UpdateLabelsAndProgressBar();
        }

        private void StartShortBreak()
        {
            currentTimer = new Timer("short break");
        }

        private void StartLongBreak()
        {
            currentTimer = new Timer("long break");
        }

        private void SecondsTimer_Tick(object sender, EventArgs e)
        {
            currentTimer.IncrementSecondsByOne();
            UpdateLabelsAndProgressBar();
            if (currentTimer.IsTimeOver())
            {
                DoTransition();
            }
        }

        private void DoTransition()
        {
            SoundPlayer alertPlayer = new SoundPlayer(@"C:\WINDOWS\Media\tada.wav");
            alertPlayer.Play();
            ProgressPomodoro.Value = 0;
            ProgressLabel.Text = "0 %";
            switch (currentState)
            {
                case "pomodoro running":
                    pomodoroCount++;
                    StartBreak();
                    break;
                case "break running":
                    StartPomodoro();
                    break;
                default: throw new ArgumentException("Wrong state: {0}.", currentState);
            }
        }

        private void UpdateLabelsAndProgressBar()
        {
            PomodoroCountLabel.Text = "Pomodoros done: " + pomodoroCount.ToString();
            switch (currentState)
            {
                case "pomodoro running":
                    StatusLabel.Text = "Status: " + currentState;
                    int minutes = currentTimer.TimeLeft / 60;
                    int seconds = currentTimer.TimeLeft % 60;
                    CountDownLabel.Text = String.Format("{0:00}:{1:00}",  minutes, seconds);
                    UpdateProgressBarWithOnePercent(currentTimer.TotalTime / 100);
                    break;
                case "break running":
                    StatusLabel.Text = "Status: " + currentTimer.State;
                    minutes = currentTimer.TimeLeft / 60;
                    seconds = currentTimer.TimeLeft % 60;
                    CountDownLabel.Text = String.Format("{0:00}:{1:00}", minutes, seconds);
                    UpdateProgressBarWithOnePercent(currentTimer.TotalTime / 100);
                    ProgressLabel.Text = ProgressPomodoro.Value.ToString() + " %";
                    break;
                case "paused pomodoro":
                case "paused break":
                    StatusLabel.Text = "Status: " + currentState;
                    break;
                case "none":
                    StatusLabel.Text = "Status: " + currentState;
                    ProgressPomodoro.Value = 0;
                    ProgressLabel.Text = "0 %";
                    CountDownLabel.Text = "00:00";
                    PomodoroCountLabel.Text = "Pomodoros done: 0";
                    break;
                default: throw new ArgumentException("Wrong state: {0}.", currentState);
            }
        }

        private void UpdateProgressBarWithOnePercent(int onePercentInSeconds)
        {
            if (currentTimer.SecondsPassed % onePercentInSeconds == 0 && currentTimer.SecondsPassed != 0)
            {
                ProgressPomodoro.Value++;
                ProgressLabel.Text = ProgressPomodoro.Value.ToString() + " %";
            }
        }

        private void PauseBtn_Click(object sender, EventArgs e)
        {
            SecondsTimer.Stop();
            switch (currentState)
            {
                case "pomodoro running": currentState = "paused pomodoro"; break;
                case "break running": currentState = "paused break"; break;
                case "paused pomodoro": break;
                case "paused break": break;
                default: throw new ArgumentException("Wrong state: {0}.", currentState);
            }
            UpdateLabelsAndProgressBar();
            PauseBtn.Enabled = false;
            StartBtn.Enabled = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateLabelsAndProgressBar();
            PauseBtn.Enabled = false;
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            SecondsTimer.Stop();
            pomodoroCount = 0;
            currentState = "none";
            UpdateLabelsAndProgressBar();
            StartBtn.Enabled = true;
            PauseBtn.Enabled = false;
        }
    }
}
