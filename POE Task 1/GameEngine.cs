using System;
using System.Collections.Generic;
using System.Text;

namespace POE_Task_1
{
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
                    Gamemap.Mapcell[Gamemap.enemyguy.tiley, Gamemap.enemyguy.tilex].symbolval = " ";

                    Gamemap.Mapcell[Gamemap.enemyguy.tiley - 1, Gamemap.enemyguy.tilex] = Gamemap.enemyguy;

                    break;

                case 2:
                    Gamemap.Mapcell[Gamemap.enemyguy.tiley, Gamemap.enemyguy.tilex].symbolval = " ";

                    Gamemap.Mapcell[Gamemap.enemyguy.tiley + 1, Gamemap.enemyguy.tilex] = Gamemap.enemyguy;

                    break;

                case 3:
                    Gamemap.Mapcell[Gamemap.enemyguy.tiley, Gamemap.enemyguy.tilex].symbolval = " ";

                    Gamemap.Mapcell[Gamemap.enemyguy.tiley, Gamemap.enemyguy.tilex - 1] = Gamemap.enemyguy;

                    break;

                case 4:
                    Gamemap.Mapcell[Gamemap.enemyguy.tiley, Gamemap.enemyguy.tilex].symbolval = " ";

                    Gamemap.Mapcell[Gamemap.enemyguy.tiley, Gamemap.enemyguy.tilex + 1] = Gamemap.enemyguy;

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

