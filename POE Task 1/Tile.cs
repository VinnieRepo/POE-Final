using System;
using System.Collections.Generic;
using System.Text;

namespace POE_Task_1
{
    
        public abstract class tile


        {
            protected int X;
            public int tilex
            {
                get { return X; }
                set { X = value; }
            }
            protected int Y;
            public int tiley
            {
                get { return Y; }
                set { Y = value; }
            }
            protected string tilesymbol;

            public string symbolval
            {
                get { return tilesymbol; }
                set { tilesymbol = value; }

            }
        public enum Tiletypes
        {
            Hero,
            Enemy,
            Empty,
            Gold,
            Weapon,
            Barrier,
        }
        protected Tiletypes Tiletype;

        public Tiletypes tiletype
        {
            get { return Tiletype; }
            set { Tiletype = value; }
        }

        public enum Movement
        { Up, Down, Left, Right, NoMovement };

        protected Movement moving;

        public Movement Moving
        {
            get { return moving; }
            set { moving = value; }
        }

        protected tile(int tilex, int tiley, string symbolval, Tiletypes tiletype)
        {
            this.tilex = tilex;
            this.tiley = tiley;
            this.symbolval = symbolval;
            this.tiletype = tiletype;
        }

    }
}
    
