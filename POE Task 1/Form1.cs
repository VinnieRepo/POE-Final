using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POE_Task_1
{

    public partial class Form1 : Form
    {   //Base Class for Tiles



        public Form1()
        {
            InitializeComponent();
        }






        private void Form1_Load(object sender, EventArgs e)
        {



        }

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



            //Tiletype and Enumerator


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



        // Default values class

        public class defaults : tile
        {
            public defaults(int tilex, int tiley, string symbolval, Tiletypes tiletype) : base(tilex, tiley, symbolval, tiletype)
            {
            }


        }
        //Obstacles Classs
        public class obstacles : defaults
        {
            public obstacles(int tilex, int tiley, string symbolval, Tiletypes tiletype) : base(tilex, tiley, symbolval, tiletype)
            {
            }
        }

        // Empty Tiles class.
        public class emptyTiles : defaults
        {
            public emptyTiles(int tilex, int tiley, string symbolval, Tiletypes tiletype) : base(tilex, tiley, symbolval, tiletype)
            {
            }
        }
        // Base class for characters
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
            private bool CheckRange(int target, int charpos)
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
        }
        //Enemy Class
        public abstract class Enemy : Character
        {
            protected Enemy(int tilex, int tiley, string symbolval, Tiletypes tiletype, int hp, int maxhp, int damage) : base(tilex, tiley, symbolval, tiletype, hp, maxhp, damage)
            {
                this.damage = damage;
                this.hp = hp;
                this.maxhp = maxhp;

            }

            //Enemy Constructor

           
            public override string ToString()
            {
                string Stats = GetType().Name + "\n";
                Stats += "at [" + tilex.ToString() + "," + tiley.ToString() + "] \n";
                Stats += HP.ToString() + "HP \n;";
                Stats += "{" + Damage.ToString() + "}";
                return Stats;
            }


        }
        // Goblin Subclass
        public class Goblin : Enemy
        {    //Constructor
            public Goblin(int tilex, int tiley, string symbolval, Tiletypes tiletype, int hp, int maxhp, int damage) : base(tilex, tiley, symbolval, tiletype, hp, maxhp, damage)
            {
            }

            //random movement
            public override Movement returnmove(Movement move = Movement.Up)
            {
                Random r = new Random();
                int num = r.Next(4);
                return (Movement)num;
            }
        }
        //Hero Subclass
        public class Hero : Character
        {
            public Hero(int tilex, int tiley, string symbolval, Tiletypes tiletype, int hp, int maxhp, int damage) : base(tilex, tiley, symbolval, tiletype, hp, maxhp, damage)
            {
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
                    + "HP: " + HP + "/" + MAXHP + "\r\n" + "Damage:" + "(" + Damage + ")\r\n" + "[" + tilex + ',' + tiley + "]";
            }
        }
        //Attempt at the map creating class, this is where i hit my snag.
        public class Map
        {


            Random mappy = new Random();

            // Mapfiller


            private tile[,] mapcell;
            public tile[,] Mapcell
            {
                get { return mapcell; }
                set { mapcell = value; }
            }

            private Hero playerguy;
            public Hero Playerguy
            {
                get { return playerguy; }
                set { playerguy = value; }
            }

            private List<Enemy> enemies;

            public List<Enemy> enemycount
            {
                get { return enemies; }
                set { enemies = value; }
            }
            private int mapwidth;
            public int Mapwidth
            {
                get { return mapwidth; }
                set { mapwidth = value; }
            }
            private int mapheight;
            public int Mapheight
            {
                get { return mapheight; }
                set { mapheight = value; }
            }
            private Enemy Enemyguy;

            public Enemy enemyguy
            {
                get { return Enemyguy; }
                set { Enemyguy = value; }
            }

            public Map(int enemycount, int minheight, int maxheight, int minwidth, int maxwidth)
            {




                Mapheight = mappy.Next(minheight, maxheight);
                Mapwidth = mappy.Next(minwidth, maxwidth);
                Mapcell = new tile[mapwidth, mapheight];
                enemies = new List<Enemy>();

                mapmaking(enemycount);




            }


            void Create(tile.Tiletypes Tiletype, int x = 0, int y = 0)
            {
                switch (Tiletype)
                {
                    case tile.Tiletypes.Barrier:
                        obstacles NewBarrier = new obstacles(x, y, " X ", Tiletype);
                        Mapcell[x, y] = NewBarrier;
                        break;

                    case tile.Tiletypes.Empty:
                        emptyTiles NewEmpty = new emptyTiles(x, y, " ", Tiletype);
                        Mapcell[x, y] = NewEmpty;
                        break;

                    case tile.Tiletypes.Hero:
                        int Herox = mappy.Next(0, mapwidth);
                        int Heroy = mappy.Next(0, mapheight);



                        while (Mapcell[Herox, Heroy].tiletype != tile.Tiletypes.Empty)
                        {
                            Herox = mappy.Next(0, mapwidth);
                            Heroy = mappy.Next(0, mapheight);
                        }

                        Hero NewHero = new Hero(Herox, Heroy, "H", Tiletype, 100, 100, 10);
                        playerguy = NewHero;
                        Mapcell[Herox, Heroy] = NewHero;
                        break;

                    case tile.Tiletypes.Enemy:
                        int Enemyx = mappy.Next(0, mapwidth);
                        int Enemyy = mappy.Next(0, mapheight);

                        while (Mapcell[Enemyx, Enemyy].tiletype != tile.Tiletypes.Empty)
                        {
                            Enemyx = mappy.Next(0, mapwidth);
                            Enemyy = mappy.Next(0, mapheight);
                        }
                        Goblin NewEnemy = new Goblin(Enemyx, Enemyy, "G", Tiletype, 100, 100, 10);
                        enemycount.Add(NewEnemy);
                        enemyguy = NewEnemy;
                        Mapcell[Enemyx, Enemyy] = NewEnemy;

                        break;


                    case tile.Tiletypes.Gold:
                        break;

                }
            }

            public override string ToString()
            {
                string MapString = "";
                for (int y = 0; y < Mapwidth; y++)
                {
                    for (int x = 0; x < Mapwidth; x++)
                    {
                        MapString += Mapcell[x, y].symbolval;

                    }
                    MapString += "\n";
                }
                return MapString;
            }

            void mapmaking(int EnemyNumb)
            {

                for (int y = 0; y < Mapheight; y++)
                {
                    for (int x = 0; x < Mapwidth; x++)
                    {
                        if (x == 0 || x == Mapwidth || y == 0 || y == Mapheight - 1)
                        {
                            Create(tile.Tiletypes.Barrier, x, y);
                        }
                        else
                        {
                            Create(tile.Tiletypes.Empty, x, y);
                        }

                    }

                }
                Create(tile.Tiletypes.Hero);

                for (int e = 0; e < EnemyNumb; e++)
                {
                    Create(tile.Tiletypes.Enemy);
                }
            }

            ///  New Task 2 Functions  \\\
            ///                        \\\


            // Item Class\\
            public abstract class Item : tile
            {
                public Item(int tilex, int tiley, string symbolval, Tiletypes tiletype) : base(tilex, tiley, symbolval, tiletype)
                {
                }

                public override string ToString()
                {    string thisItem = symbolval; 
                    return thisItem;
                }
                

                
            }
            //Gold Class\\
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

            public class GameEngine
        {
            private Map gamemap;

            public Map Gamemap
            {
                get { return gamemap; }
                set { gamemap = value; }
            }

            public GameEngine()
            {
                Gamemap = new Map(5, 10, 10, 10, 10);
            }


            public void CharacterMove(tile.Movement direction)
            {

                switch (direction)
                {
                    case tile.Movement.Up:
                        Gamemap.Mapcell[Gamemap.Playerguy.tiley, Gamemap.Playerguy.tilex].symbolval = " ";

                        Gamemap.Mapcell[Gamemap.Playerguy.tiley - 1, Gamemap.Playerguy.tilex] = Gamemap.Playerguy;
                        




                        break;
                    case tile.Movement.Down:
                        Gamemap.Playerguy.tiley = Gamemap.Playerguy.tiley + 1;
                        break;
                    case tile.Movement.Left:
                        Gamemap.Playerguy.tilex = Gamemap.Playerguy.tilex - 1;
                        break;
                    case tile.Movement.Right:
                        Gamemap.Playerguy.tilex = Gamemap.Playerguy.tilex + 1;
                        break;

                }

            }
        }

        GameEngine Start = new GameEngine();

        private void StartButton_Click_1(object sender, EventArgs e)
        {

            
            
            MapLabel.Text = Start.Gamemap.ToString();
            CharacterLabel.Text = Start.Gamemap.Playerguy.ToString();
            EnemyLabel.Text = Start.Gamemap.enemyguy.ToString();
           


        }

        private void UpButton_Click_1(object sender, EventArgs e)
        {   
           
            Start.CharacterMove(tile.Movement.Up);
            MapLabel.Text = Start.Gamemap.ToString();

        }
    } }
