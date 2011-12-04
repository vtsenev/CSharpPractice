using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RocksGame
{
    class Dwarf : Actor
    {
        public Dwarf(int x, int y)
        {
            posX = oldX = x;
            posY = oldY = y;
        }

        public int getPosX()
        {
            return posX;
        }

        public int getPosY()
        {
            return posY;
        }

        public override void update()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                if (pressedKey.Key == ConsoleKey.RightArrow)
                    if (posX != 75)
                    {
                        oldX = posX;
                        posX++;
                    }
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                    if (posX != 1)
                    {
                        oldX = posX;
                        posX--;
                    }
            }
        }

        public override void render()
        {
            Console.SetCursorPosition(oldX, oldY);
            Console.Write("   ");
            Console.SetCursorPosition(posX, posY);
            Console.Write("(0)");
        }
    }
}
