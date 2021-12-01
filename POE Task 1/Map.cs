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
        enemies = new List<Enemy>();

        goldamount = goldam;



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
    // Updated map making that includes mages and Gold.
    void mapmaking(int EnemyNumb, int Goldy)
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


        for (int g = 0; g < Goldy; g++)
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
        //Enemy Move in game design.
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

                    Gamemap.Mapcell[Gamemap.Enemyguy.tiley, Gamemap.Enemyguy.tilex - 1] = Gamemap.Enemyguy;

                    break;

                case 4:
                    Gamemap.Mapcell[Gamemap.Enemyguy.tiley, Gamemap.Enemyguy.tilex].symbolval = " ";

                    Gamemap.Mapcell[Gamemap.Enemyguy.tiley, Gamemap.Enemyguy.tilex + 1] = Gamemap.Enemyguy;

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
}
