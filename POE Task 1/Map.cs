using System;
using System.Collections.Generic;
using System.Text;

namespace POE_Task_1
{
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

        private Enemy[] enemies;

        public Enemy[] enemylist
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
        private Goblin Enemyguy;

        public Goblin enemyguy
        {
            get { return Enemyguy; }
            set { Enemyguy = value; }
        }
        //Item Array and Gold for Task 2\\
        private Item[] Itemholder;
        public Item[] itemholder
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

        public Map(int enemycount, int minheight, int maxheight, int minwidth, int maxwidth, int goldam)
        {


            Random mappy = new Random();

            Mapheight = mappy.Next(minheight, maxheight);
            Mapwidth = mappy.Next(minwidth, maxwidth);
            Mapcell = new tile[mapwidth, mapheight];
            

            goldamount = goldam;


            emptymapmaking();
            mapmaking(enemycount, goldamount);




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
                        
                       
                    }


                    else if (enemtype == 1)
                    {
                        Goblin NewEnemy = new Goblin(Enemyx, Enemyy, "G", Tiletype, 10, 10, 1);
                        
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

        public void emptymapmaking()
        {
           
                for (int Y = 0; Y < Mapheight; Y++)
                {
                    for (int X = 0; X < Mapwidth; X++)
                    {
                        if (X == 0 || Y == 0 || X == Mapwidth - 1 || Y == Mapheight - 1)
                        {
                           mapcell[Y, X] = new obstacles(X, Y, "X",tile.Tiletypes.Barrier);
                        }
                        else
                        {
                            mapcell[Y, X] = new emptyTiles(X, Y, " ", tile.Tiletypes.Empty);
                        }
                    }
                }
            
        }
        // Updated map making that includes mages and Gold.
        public void mapmaking(int EnemyNumb, int Goldy)
        {

            CreateRevised(tile.Tiletypes.Hero);
            Mapcell[playerguy.tilex, playerguy.tiley] = playerguy;

            for (int e = 0; e < EnemyNumb; e++)
            {
                CreateRevised(tile.Tiletypes.Goblin);
                enemylist[e] = enemyguy;
                Mapcell[enemyguy.tiley, enemyguy.tilex] = enemyguy;
            }


            for (int g = 0; g < Goldy; g++)
            {
                CreateRevised(tile.Tiletypes.Gold);
            }
        }


        public tile CreateRevised(tile.Tiletypes type)// This creates a Unique X and Y loction for every object for the map
        {
            Random mappy = new Random();
            int UniqueY = mappy.Next(1, Mapwidth - 1);
            int UniqueX = mappy.Next(1, Mapheight - 1);
            tile ReturnType = null;
            int goldRand = mappy.Next(1, 5);
            

            while (mapcell[UniqueY, UniqueX].tiletype != tile.Tiletypes.Empty)
            {
                UniqueY = mappy.Next(1, Mapheight - 1);
                UniqueX = mappy.Next(1, Mapwidth - 1);
            }

            if (type == tile.Tiletypes.Hero)
            {
                ReturnType = new Hero(UniqueX, UniqueY," H ", tile.Tiletypes.Hero,10,10,10);
                playerguy = (Hero)ReturnType;

            }
            else if (type == tile.Tiletypes.Goblin)
            {
                ReturnType = new Goblin(UniqueX, UniqueY," G ", tile.Tiletypes.Goblin, 10, 10, 10);
                enemyguy = (Goblin)ReturnType;
            }
            else if (type == tile.Tiletypes.Gold)
            {
                ReturnType = new gold(UniqueX, UniqueY," O " , tile.Tiletypes.Gold);
            }
            else if (type == tile.Tiletypes.Mage)
            {
                ReturnType = new Mage(UniqueX, UniqueY," M " , tile.Tiletypes.Mage, 10, 10, 10);
            }
          
           
            else
            {
                ReturnType = null;
            }
            return ReturnType;
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


        
    }
}
