using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PomodoroTimer
{
    class Timer
    {
        public const int POMODORO_LENGTH_IN_MINUTES = 25;
        public const int SHORT_BREAK_LENGTH_IN_MINUTES = 5;
        public const int LONG_BREAK_LENGTH_IN_MINUTES = 15;
        private int secondsPassed;
        private string state;
        private int timeLeft;
        private int totalTime;

        public Timer(string state)
        {
            this.secondsPassed = 0;
            this.state = state;
            switch (state)
            {
                case "pomodoro": totalTime = CalculateTimeLeft(POMODORO_LENGTH_IN_MINUTES); timeLeft = totalTime; break;
                case "short break": totalTime = CalculateTimeLeft(SHORT_BREAK_LENGTH_IN_MINUTES); timeLeft = totalTime; break;
                case "long break": totalTime = CalculateTimeLeft(LONG_BREAK_LENGTH_IN_MINUTES); timeLeft = totalTime; break;
                default: throw new ArgumentException("Wrong type of Timer.");
            }
        }

        public void IncrementSecondsByOne()
        {
            secondsPassed++;
            timeLeft = totalTime - secondsPassed;
        }

        public bool IsTimeOver()
        {
            if (timeLeft == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int SecondsPassed
        {
            get { return this.secondsPassed; }
        }

        public int TimeLeft
        {
            get { return this.timeLeft; }
        }

        public string State
        {
            get { return this.state; }
        }

        public int TotalTime
        {
            get { return this.totalTime; }
        }

        private int CalculateTimeLeft(int minutesToGo)
        {
            int secondsLeft = minutesToGo * 60;
            return secondsLeft;
        }
    }
}
