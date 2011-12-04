using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RocksGame
{
    class BadGuy : Actor
    {
        int speed;
        string name;
        string clearName = " ";
        ConsoleColor color;

        public BadGuy(int speed, string name, ConsoleColor color, int x, int y)
        {
            this.name = name;
            this.speed = speed;
            this.color = color;
            this.posX = x;
            this.posY = y;
            oldY = posY;
            oldX = posX;
            for (int i = 1; i <= name.Length; i++)
                clearName += " ";
        }

        public override void update()
        {
            if (posX == GameWorld.dwarf.getPosX() && posY + speed == GameWorld.dwarf.getPosY())
            {
                GameWorld.isRunning = false;
                Console.Clear();
                Console.WriteLine("Game Over!!!");
                return;
            }
            if (posY + speed > 24)
            {
                GameWorld.actorsToBeDeleted.Add(this);
                oldY = posY;
                return;
            }
            oldY = posY;
            posY += speed;
        }

        public override void render()
        {
            Console.SetCursorPosition(oldX, oldY);
            Console.Write(clearName);
            Console.SetCursorPosition(posX, posY);
            Console.ForegroundColor = color;
            Console.Write(name);
            Console.ResetColor();
        }
    }
}
