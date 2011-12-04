using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RocksGame
{
    class GameWorld
    {
        public static List<Actor> actors = new List<Actor>();
        public static List<Actor> actorsToBeDeleted = new List<Actor>();
        public static Dwarf dwarf;
        public static bool isRunning;
        public static char[] NAMES = {'^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';'};
        public static String[] colorNames = ConsoleColor.GetNames(typeof(ConsoleColor));
    }
}
