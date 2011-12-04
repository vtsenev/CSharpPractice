using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RocksGame
{
    public abstract class Actor
    {
        protected int posX;
        protected int posY;
        protected int oldX;
        protected int oldY;

        public abstract void update();

        public abstract void render();
    }
}
