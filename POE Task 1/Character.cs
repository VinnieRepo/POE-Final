using System;
using System.Collections.Generic;
using System.Text;

namespace POE_Task_1
{
    public abstract class Character : tile
    {
        protected int HP;
        public int hp
        {
            get { return HP; }
            set { HP = value; }
        }
        protected int MAXHP;
        public int maxhp
        {
            get { return MAXHP; }
            set { MAXHP = value; }
        }
        protected int Damage;
        public int damage
        {
            get { return Damage; }
            set { Damage = value; }
        }
        // Task 2 Gold Purse and Constuctor
        private int Goldpurse;
        public int goldpurse
        {
            get { return Goldpurse; }
            set { Goldpurse = value; }
        }

        private List<tile> vision;



        public List<tile> Vision
        {
            get { return vision; }
            set { vision = value; }
        }
        protected Character(int tilex, int tiley, string symbolval, Tiletypes tiletype, int hp, int maxhp, int damage) : base(tilex, tiley, symbolval, tiletype)
        {
            this.symbolval = symbolval;
            this.hp = hp;
            this.maxhp = maxhp;
            this.damage = damage;

            vision = new List<tile>();
        }



        //Position of the character.
        protected void position(int x, int y)
        {
            tilex = x;
            tiley = y;
        }
        // Death check.
        public bool isdead(int value)
        {
            if (value == 1)
            {
                return true;
            }

            else
            {
                return false;
            }

        }
        //Attack method to be filled in later.
        public virtual void attack(Character Target)
        {
            Target.HP -= Damage;
        }
        //Distance Calc
        private int distanceto(int target, int charpos)
        {
            int distance;
            distance = target - charpos;
            return distance;

        }
        //Range check
        public bool CheckRange(int target, int charpos)
        {
            int distance = distanceto(target, charpos);
            if (distance <= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //return move to be overridden
        public abstract Movement returnmove(Movement move = 0);


        //Tostring to be overridden.
        public abstract override string ToString();
        // Task 2 Pickup Item Class
        public void pickupitem(char i)
        {
            if (i == 'g')
            {
                Random GoldAmount = new Random();
                int amount = GoldAmount.Next(1, 100);
                goldpurse = goldpurse + amount;
            }
        }
    }
}
