using System;
using System.Collections.Generic;
using System.Text;

namespace POE_Task_1
{
    public class obstacles : defaults
    {
        public obstacles(int tilex, int tiley, string symbolval, Tiletypes tiletype) : base(tilex, tiley, symbolval, tiletype)
        {
            tiletype = Tiletypes.Barrier;
        }
    }
}
