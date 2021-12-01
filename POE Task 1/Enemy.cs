using System;
using System.Collections.Generic;
using System.Text;

namespace POE_Task_1
{
    public abstract class Enemy : Character
    {
        protected Enemy(int tilex, int tiley, string symbolval, Tiletypes tiletype, int hp, int maxhp, int damage) : base(tilex, tiley, symbolval, tiletype, hp, maxhp, damage)
        {
            this.damage = damage;
            this.hp = hp;
            this.maxhp = maxhp;



        }
        public abstract bool CheckingRange(int target, int charpos);





        public override string ToString()
        {
            string Stats = GetType().Name + "\n";
            Stats += "at [" + tilex.ToString() + "," + tiley.ToString() + "] \n";
            Stats += HP.ToString() + "HP \n";
            Stats += "Damage:{" + Damage.ToString() + "}";
            return Stats;
        }


    }
}

