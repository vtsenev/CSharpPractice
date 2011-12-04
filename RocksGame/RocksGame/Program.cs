using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RocksGame
{
    class Program
    {
        GameWorld gameworld;
        const int SLEEPTIME = 150;
        Random r = new Random();
        long loop = 0;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.drawBorders();
            p.init();
            p.gameLoop();
        }

        void gameLoop()
        {
            while (GameWorld.isRunning)
            {
                //process();
                update();
                render();
                Thread.Sleep(SLEEPTIME);
            }
        }

        void init()
        {
            Dwarf dwarf = new Dwarf(40, 22);
            GameWorld.dwarf = dwarf;
            GameWorld.actors.Add(dwarf);
            GameWorld.isRunning = true;
        }

        BadGuy generateBadGuy()
        {
            int speed = r.Next(1, 2);
            int size = r.Next(1, 3);
            string symbol = new string(GameWorld.NAMES[r.Next(0, GameWorld.NAMES.Length - 1)], 1);
            string name = "";
            for (int i = 1; i <= size; i++)
                name += symbol;

            string colorName = GameWorld.colorNames[r.Next(0, GameWorld.colorNames.Length - 1)];
            ConsoleColor color = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), colorName);
            if (color == ConsoleColor.Black)
                color = ConsoleColor.White;

            BadGuy badguy = new BadGuy(speed, name, color, r.Next(1, 75), 1);
            return badguy;
        }

        void render()
        {
            //Console.Clear();
            //drawBorders();
            foreach (Actor actor in GameWorld.actors)
                actor.render();
        }

        void drawBorders()
        {
            string horizontalLine = "-";
            string verticalLine = "+";
            for (int i = 0; i < 80; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write(horizontalLine);
                //Console.SetCursorPosition(i, 23);
                //Console.Write(horizontalLine);
            }
            for (int i = 1; i < 23; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(verticalLine);
                Console.SetCursorPosition(79, i);
                Console.Write(verticalLine);
            }
        }

        void update()
        {
            foreach (Actor actor in GameWorld.actors)
                actor.update();
            foreach (Actor actor in GameWorld.actorsToBeDeleted)
                GameWorld.actors.Remove(actor);
            GameWorld.actorsToBeDeleted.Clear();
            loop++;
            if (loop % 16 == 0)
                GameWorld.actors.Add(generateBadGuy());
        }

    }
}
