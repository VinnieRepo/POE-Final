﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace POE_Task_1
{
 
    public partial class Form1 : Form
    {   



        public Form1()
        {
            InitializeComponent();
        }



        


        private void Form1_Load(object sender, EventArgs e)
        {



        }
        [Serializable]
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
        [Serializable]
        public class defaults : tile
        {
            public defaults(int tilex, int tiley, string symbolval, Tiletypes tiletype) : base(tilex, tiley, symbolval, tiletype)
            {
            }


        }
        //Obstacles Classs
        [Serializable]
        public class obstacles : defaults
        {
            public obstacles(int tilex, int tiley, string symbolval, Tiletypes tiletype) : base(tilex, tiley, symbolval, tiletype)
            {
            }
        }

        // Empty Tiles class.
        [Serializable]
        public class emptyTiles : defaults
        {
            public emptyTiles(int tilex, int tiley, string symbolval, Tiletypes tiletype) : base(tilex, tiley, symbolval, tiletype)
            {
            }
        }
        // Base class for characters
        [Serializable]
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
            public void pickupitem (char i)
            {
                if(i == 'g')
                {
                    Random GoldAmount = new Random();
                    int amount = GoldAmount.Next(1, 100);
                    goldpurse = goldpurse + amount;
                }
            }
        }
        //Enemy Class
        [Serializable]
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
        // Goblin Subclass
        [Serializable]
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
            public override bool CheckingRange(int target, int charpos)
            {
                int distance = target = charpos;
                if (distance <= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


        }
        //Hero Subclass
        [Serializable]
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
                    + "HP: " + HP + "/" + MAXHP + "\r\n" + "Damage:" + "(" + Damage + ")\r\n" + "[" + tilex + ',' + tiley + "]" +"\r\n"+"Gold Amount:"+ goldpurse;
            }
        }
        
        [Serializable]
        public class Map
        {


            

          


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
            //Item Array and Gold for Task 2\\
            private Item[] Itemholder;
            public  Item[] itemholder
            {
                get { return Itemholder; }
                set { Itemholder = value; }
            }

            private int GoldAmount;
            public int goldamount
            {
                get { return GoldAmount; }
                set { GoldAmount = value; }
            }

            public Map(int enemycount, int minheight, int maxheight, int minwidth, int maxwidth,int goldam)
            {


                Random mappy = new Random();

                Mapheight = mappy.Next(minheight, maxheight);
                Mapwidth = mappy.Next(minwidth, maxwidth);
                Mapcell = new tile[mapwidth, mapheight];
                enemies = new List<Enemy>();

                goldamount = goldam;
                


                mapmaking(enemycount,goldamount);




            }


            void Create(tile.Tiletypes Tiletype, int x = 0, int y = 0)
            {
                Random mappy = new Random();
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

                        Hero NewHero = new Hero(Herox, Heroy, "H", Tiletype, 10, 10, 10);
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

                        // New Randomized enemy for Task 2\\
                        int enemtype = mappy.Next(0, 3);
                        if (enemtype == 2)
                        {
                            Mage NewMage = new Mage(Enemyx, Enemyy, "M", Tiletype, 15, 15, 5);
                            enemies.Add(NewMage);
                            enemyguy = NewMage;
                            Mapcell[Enemyx, Enemyy] = NewMage;
                             enemtype = mappy.Next(1, 2);
                        }


                        else if (enemtype == 1)
                        {
                            Goblin NewEnemy = new Goblin(Enemyx, Enemyy, "G", Tiletype, 10, 10, 1);
                            enemies.Add(NewEnemy);
                            enemyguy = NewEnemy;
                            Mapcell[Enemyx, Enemyy] = NewEnemy;
                            enemtype = mappy.Next(1, 3);
                        }

                        else enemtype = mappy.Next(1, 3);





                        break;


                    case tile.Tiletypes.Gold:

                        int goldx = mappy.Next(0, mapwidth);
                        int goldy = mappy.Next(0, mapheight);

                        while (Mapcell[goldx, goldy].tiletype != tile.Tiletypes.Empty)
                        {
                            goldx = mappy.Next(0, mapwidth);
                            goldy = mappy.Next(0, mapheight);
                        }

                        gold Gold = new gold(goldx, goldy, "O", Tiletype);
                        Mapcell[goldx, goldy] = Gold;










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
                    MapString += System.Environment.NewLine;
                }
                return MapString;
            }

            void mapmaking(int EnemyNumb, int Goldy)
            {

                for (int y = 0; y < Mapheight; y++)
                {
                    for (int x = 0; x < Mapwidth ; x++)
                    {
                        if (x == 0 || x == Mapwidth|| y == 0 || y == Mapheight - 1)
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


                for (int g = 0; g < Goldy ; g++)
                {
                    Create(tile.Tiletypes.Gold);
                }
            }



            ///  New Task 2 Functions  \\\
            ///                        \\\


            // Item Class\\
            [Serializable]
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
            //Gold Class\\
            [Serializable]
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
            // Mage Enemy Class\\
            [Serializable]
            public class Mage : Enemy
            {
                int Magex;
                int Magey;
                public Mage(int tilex, int tiley, string symbolval, Tiletypes tiletype, int hp, int maxhp, int damage) : base(tilex, tiley, symbolval, tiletype, hp, maxhp, damage)
                {
                    Magex = tilex;
                    Magey = tiley;
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

            //Item Position Check
            public string GetItemAtPosition(int x, int y)
            {
                if (Mapcell[x, y].symbolval == "O" || Mapcell[x, y].symbolval == "I")
                {
                    return "Item";
                }
                else return null;
            }


            [Serializable]
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
                    Gamemap = new Map(5, 10, 10, 10, 10, 5);
                }

                public void Enemymove()
                {
                    Random randomizer = new Random();

                    int whichway = randomizer.Next(1, 5);

                    switch (whichway)
                    {
                        case 1:
                            Gamemap.Mapcell[Gamemap.Enemyguy.tiley, Gamemap.Enemyguy.tilex].symbolval = " ";

                            Gamemap.Mapcell[Gamemap.Enemyguy.tiley - 1, Gamemap.Enemyguy.tilex] = Gamemap.Enemyguy;

                            break;

                        case 2:
                            Gamemap.Mapcell[Gamemap.Enemyguy.tiley, Gamemap.Enemyguy.tilex].symbolval = " ";

                            Gamemap.Mapcell[Gamemap.Enemyguy.tiley + 1, Gamemap.Enemyguy.tilex] = Gamemap.Enemyguy;

                            break;

                        case 3:
                            Gamemap.Mapcell[Gamemap.Enemyguy.tiley, Gamemap.Enemyguy.tilex].symbolval = " ";

                            Gamemap.Mapcell[Gamemap.Enemyguy.tiley , Gamemap.Enemyguy.tilex - 1] = Gamemap.Enemyguy;

                            break;

                        case 4:
                            Gamemap.Mapcell[Gamemap.Enemyguy.tiley, Gamemap.Enemyguy.tilex].symbolval = " ";

                            Gamemap.Mapcell[Gamemap.Enemyguy.tiley , Gamemap.Enemyguy.tilex + 1] = Gamemap.Enemyguy;

                            break;


                    }

                    
                }
                public void CharacterMove(tile.Movement direction)
                {
                    
                    // Updated Movement for Gold Aqusition
                    switch (direction)
                    {
                        case tile.Movement.Up:

                            if (Gamemap.Mapcell[Gamemap.Playerguy.tiley - 1, Gamemap.Playerguy.tilex].symbolval == "O")
                            {
                                Gamemap.GetItemAtPosition(Gamemap.Playerguy.tiley - 1, Gamemap.Playerguy.tilex);
                                Gamemap.Playerguy.pickupitem('g');

                                Gamemap.Mapcell[Gamemap.Playerguy.tiley, Gamemap.Playerguy.tilex].symbolval = " ";

                                Gamemap.Mapcell[Gamemap.Playerguy.tiley - 1, Gamemap.Playerguy.tilex] = Gamemap.Playerguy;
                            }
                            else
                            {
                                Gamemap.Mapcell[Gamemap.Playerguy.tiley, Gamemap.Playerguy.tilex].symbolval = " ";

                                Gamemap.Mapcell[Gamemap.Playerguy.tiley - 1, Gamemap.Playerguy.tilex] = Gamemap.Playerguy;
                            }
                            

                           

                            break;

                        case tile.Movement.Down:
                            if (Gamemap.Mapcell[Gamemap.Playerguy.tiley + 1, Gamemap.Playerguy.tilex].symbolval == "O")
                            {
                                Gamemap.GetItemAtPosition(Gamemap.Playerguy.tiley + 1, Gamemap.Playerguy.tilex);
                                Gamemap.Playerguy.pickupitem('g');

                                Gamemap.Mapcell[Gamemap.Playerguy.tiley, Gamemap.Playerguy.tilex].symbolval = " ";
                                Gamemap.Mapcell[Gamemap.Playerguy.tiley + 1, Gamemap.Playerguy.tilex] = Gamemap.Playerguy;

                            }

                            else
                            {
                                Gamemap.Mapcell[Gamemap.Playerguy.tiley, Gamemap.Playerguy.tilex].symbolval = " ";
                                Gamemap.Mapcell[Gamemap.Playerguy.tiley + 1, Gamemap.Playerguy.tilex] = Gamemap.Playerguy;
                            }


                            break;

                        case tile.Movement.Left:
                            if (Gamemap.Mapcell[Gamemap.Playerguy.tiley, Gamemap.Playerguy.tilex - 1].symbolval == "O")
                            {
                                Gamemap.GetItemAtPosition(Gamemap.Playerguy.tiley, Gamemap.Playerguy.tilex - 1);
                                Gamemap.Playerguy.pickupitem('g');

                                Gamemap.Mapcell[Gamemap.Playerguy.tiley, Gamemap.Playerguy.tilex].symbolval = " ";

                                Gamemap.Mapcell[Gamemap.Playerguy.tiley, Gamemap.Playerguy.tilex - 1] = Gamemap.Playerguy;
                            }

                            else
                            {
                                Gamemap.Mapcell[Gamemap.Playerguy.tiley, Gamemap.Playerguy.tilex].symbolval = " ";
                                Gamemap.Mapcell[Gamemap.Playerguy.tiley, Gamemap.Playerguy.tilex - 1] = Gamemap.Playerguy;
                            }
                            
                            break;

                        case tile.Movement.Right:

                            if (Gamemap.Mapcell[Gamemap.Playerguy.tiley, Gamemap.Playerguy.tilex + 1].symbolval == "O")
                            {
                                Gamemap.GetItemAtPosition(Gamemap.Playerguy.tiley, Gamemap.Playerguy.tilex + 1);
                                Gamemap.Playerguy.pickupitem('g');

                                Gamemap.Mapcell[Gamemap.Playerguy.tiley, Gamemap.Playerguy.tilex].symbolval = " ";

                                Gamemap.Mapcell[Gamemap.Playerguy.tiley, Gamemap.Playerguy.tilex + 1] = Gamemap.Playerguy;
                            }

                            else
                            {
                                Gamemap.Mapcell[Gamemap.Playerguy.tiley, Gamemap.Playerguy.tilex].symbolval = " ";


                                Gamemap.Mapcell[Gamemap.Playerguy.tiley, Gamemap.Playerguy.tilex + 1] = Gamemap.Playerguy;
                            }
                            break;

                    }

                }
            }

            
        }
        Map.GameEngine Start = new Map.GameEngine();

      

        
        private void StartButton_Click(object sender, EventArgs e)
        {
            MapHolderBox.Text = Start.Gamemap.ToString();
            CharacterLabel.Text = Start.Gamemap.Playerguy.ToString();
            EnemyLabel.Text = Start.Gamemap.enemyguy.ToString();
        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            Start.CharacterMove(tile.Movement.Up);
            Start.Enemymove();
            MapLabel.Text = Start.Gamemap.ToString();

        }

        private void RightButton_Click(object sender, EventArgs e)
        {
            Start.CharacterMove(tile.Movement.Right);
            Start.Enemymove();
            MapLabel.Text = Start.Gamemap.ToString();
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            Start.CharacterMove(tile.Movement.Down);
            Start.Enemymove();
            MapLabel.Text = Start.Gamemap.ToString();
        }

        private void LeftButton_Click(object sender, EventArgs e)
        {
            Start.CharacterMove(tile.Movement.Left);
            Start.Enemymove();
            MapLabel.Text = Start.Gamemap.ToString();
        }

        // saveSystem try, it keeps snagging because it cant save a random rumber.
        public static class saveSystem
        {
            public static void SaveEverything(Map.GameEngine Savings)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                string path = @"C:\Users\rampa\OneDrive\Documents" + "/Saves.sav";
                FileStream stream = new FileStream(path,FileMode.Create);

                Map.GameEngine data = new Map.GameEngine();

                formatter.Serialize(stream, data);
                stream.Close();

                
                
            }

            public static Map.GameEngine LoadData()
            {
                string path = @"C:\Users\rampa\OneDrive\Documents" + "/Saves.sav";
                if (File.Exists(path))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    FileStream stream = new FileStream(path, FileMode.Open);

                    Map.GameEngine savings = formatter.Deserialize(stream) as Map.GameEngine;
                    stream.Close();
                    return savings;

                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("No Save file detected in"+path);
                    return null;
                }
            }

        }
        private void SaveButton_Click(object sender, EventArgs e)
        {    
            saveSystem.SaveEverything(Start);
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            Map.GameEngine data = saveSystem.LoadData();

            Start.Gamemap.Mapcell = data.Gamemap.Mapcell;

            MapHolderBox.Text = Start.Gamemap.ToString();
            CharacterLabel.Text = Start.Gamemap.Playerguy.ToString();
            EnemyLabel.Text = Start.Gamemap.enemyguy.ToString();


        }
    }
}
