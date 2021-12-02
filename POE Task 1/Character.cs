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



       
        protected void position(int x, int y)
        {
            tilex = x;
            tiley = y;
        }
        
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
       
        public virtual void attack(Character Target)
        {
            Target.HP -= Damage;
        }
        
        private int distanceto(int target, int charpos)
        {
            int distance;
            distance = target - charpos;
            return distance;

        }
        
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


       
        public abstract Movement returnmove(Movement move = 0);


       

        public void move(Movement direction)
        {
            switch (direction)
            {
                case Movement.NoMovement:
                    break;
                case Movement.Up:
                    tiley = tiley - 1;
                    break;

            }
        }
        public abstract override string ToString();
        
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
