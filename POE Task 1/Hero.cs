using System;
using System.Collections.Generic;
using System.Text;

namespace POE_Task_1
{
    public class Hero : Character
    {
        public Hero(int tilex, int tiley, string symbolval, Tiletypes tiletype, int hp, int maxhp, int damage) : base(tilex, tiley, symbolval, tiletype, hp, maxhp, damage)
        {
            goldpurse = 0;
        }

        //Movement
        public override Movement returnmove(Movement move)
        {
            return (Movement)move;
        }
        //Tostring overrider
        public override string ToString()
        {
            return "Player Stats \r\n"
                + "HP: " + HP + "/" + MAXHP + "\r\n" + "Damage:" + "(" + Damage + ")\r\n" + "[" + tilex + ',' + tiley + "]" + "\r\n" + "Gold Amount:" + goldpurse;
        }
    }
}
