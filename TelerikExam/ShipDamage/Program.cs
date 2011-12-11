using System;

namespace ShipDamage
{
    class Program
    {

        static int h, sx1, sx2, sy1, sy2;

        static void Main(string[] args)
        {
            // read ship coordinates
            string input = Console.ReadLine();
            sx1 = int.Parse(input);
            input = Console.ReadLine();
            sy1 = int.Parse(input);
            input = Console.ReadLine();
            sx2 = int.Parse(input);
            input = Console.ReadLine();
            sy2 = int.Parse(input);
            // read line h vertical offset
            input = Console.ReadLine();
            h = int.Parse(input);
            // read catapult c1 coordinates
            input = Console.ReadLine();
            int cx1 = int.Parse(input);
            input = Console.ReadLine();
            int cy1 = int.Parse(input);
            // read catapult c2 coordinates
            input = Console.ReadLine();
            int cx2 = int.Parse(input);
            input = Console.ReadLine();
            int cy2 = int.Parse(input);
            // read catapult c3 coordinates
            input = Console.ReadLine();
            int cx3 = int.Parse(input);
            input = Console.ReadLine();
            int cy3 = int.Parse(input);

            int dmg1 = CalcDamage(cx1, cy1);
            int dmg2 = CalcDamage(cx2, cy2);
            int dmg3 = CalcDamage(cx3, cy3);

            int totalDamage = dmg1 + dmg2 + dmg3;
            Console.WriteLine("{0}%", totalDamage);
        }

        static int CalcDamage(int cx, int cy)
        {
            int damage = 0;
            // y coordinate of where catapult hits
            int y = (h - cy) + h;

            if (sx1 < sx2)
            {
                int temp = sx1;
                sx1 = sx2;
                sx2 = temp;
            }

            if (sy1 < sy2)
            {
                int temp = sy1;
                sy1 = sy2;
                sy2 = temp;
            }

            // catapult hits the internal body of the ship
            if (cx > sx2 && y > sy2 && cx < sx1 && y < sy1)
            {
                damage = 100;
                return damage;
            }
            // catapult hits side1
            if (cx < sx1 && cx > sx2 && y == sy2)
            {
                damage = 50;
                return damage;
            }
            // catapult hits side2
            if (cx < sx1 && cx > sx2 && y == sy1)
            {
                damage = 50;
                return damage;
            }
            // catapult hits side3
            if (cx == sx2 && y < sy1 && y > sy2)
            {
                damage = 50;
                return damage;
            }
            // catapult hits side4
            if (cx == sx1 && y < sy1 && y > sy2)
            {
                damage = 50;
                return damage;
            }
            // catapult hits corner1
            if (cx == sx1 && y == sy1)
            {
                damage = 25;
                return damage;
            }
            // catapult hits corner2
            if (cx == sx2 && y == sy2)
            {
                damage = 25;
                return damage;
            }
            // catapult hits corner3
            if (cx == sx2 && y == sy1)
            {
                damage = 25;
                return damage;
            }
            // catapult hits corner4
            if (cx == sx1 && y == sy2)
            {
                damage = 25;
                return damage;
            }

            return damage;
        }
    }
}
