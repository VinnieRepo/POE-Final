using System;
using System.Collections.Generic;
using System.Text;

namespace POE_Task_1
{
    public class Mage : Enemy
    {
        int Magex;
        int Magey;
        public Mage(int tilex, int tiley, string symbolval, Tiletypes tiletype, int hp, int maxhp, int damage) : base(tilex, tiley, symbolval, tiletype, hp, maxhp, damage)
        {
            Magex = tilex;
            Magey = tiley;
            tiletype = Tiletypes.Mage;
        }
        public override Movement returnmove(Movement move = Movement.Up)
        {

            int num = 5;
            return (Movement)num;
        }

        //Mage range check for all 8 Directions
        public override bool CheckingRange(int targetx, int targety)
        {
            if (targetx == Magex + 1 || targety == Magey + 1 || targetx == Magex - 1 || targety == Magey - 1)
            {
                return true;
            }
            else if (targetx == Magex + 1 && targety == Magey + 1 || targetx == Magex - 1 && targety == Magey - 1 || targetx == Magex - 1 && targety == Magey + 1 || targetx == Magex + 1 && targety == Magey - 1)
            {
                return true;
            }

            else return false;



        }

    }
}
