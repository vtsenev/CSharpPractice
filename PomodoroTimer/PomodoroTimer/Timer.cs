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

        public Timer(string state)
        {
            this.secondsPassed = 0;
            this.state = state;
            switch (state)
            {
                case "pomodoro": timeLeft = CalculateTimeLeft(POMODORO_LENGTH_IN_MINUTES); break;
                case "short break": timeLeft = CalculateTimeLeft(SHORT_BREAK_LENGTH_IN_MINUTES); break;
                case "long break": timeLeft = CalculateTimeLeft(LONG_BREAK_LENGTH_IN_MINUTES); break;
                default: throw new ArgumentException("Wrong type of Timer.");
            }
        }

        public void IncrementSecondsByOne()
        {
            secondsPassed++;
            timeLeft -= secondsPassed;
        }

        public bool isTimeOver()
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

        public string State
        {
            get { return this.state; }
        }

        private int CalculateTimeLeft(int minutesToGo)
        {
            int secondsLeft = minutesToGo * 60;
            return secondsLeft;
        }
    }
}
