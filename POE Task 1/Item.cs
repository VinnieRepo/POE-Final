using System;
using System.Collections.Generic;
using System.Text;

namespace POE_Task_1
{
    public abstract class Item : tile
    {
        private List<Item> itemsarray;
        public List<Item> ItemsArray
        {
            get { return itemsarray; ; }
            set { itemsarray = value; }
        }
        public Item(int tilex, int tiley, string symbolval, Tiletypes tiletype) : base(tilex, tiley, symbolval, tiletype)
        {
        }

        public override string ToString()
        {
            string thisItem = symbolval;
            return thisItem;
        }




    }
}
