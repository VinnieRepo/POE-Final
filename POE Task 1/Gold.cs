using System;
using System.Collections.Generic;
using System.Text;

namespace POE_Task_1
{
    public class gold : Item
    {
        public gold(int tilex, int tiley, string symbolval, Tiletypes tiletype) : base(tilex, tiley, symbolval, tiletype)
        {

        }

        private int GoldAmount;

        public int goldamount
        {
            get { return GoldAmount; }
            set { GoldAmount = value; }
        }

        private Random goldrandom = new Random();

        public void goldvalues(int x, int y)
        {
            tilex = x;
            tiley = y;
            goldamount = goldrandom.Next(1, 5);


        }
    }
}
