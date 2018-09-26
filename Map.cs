using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GameDevPOE2ndAttempt
{
    [Serializable]
    class Map
    {
        private Unit[] units;
        Random R = new Random();

        public Unit[] Units
        {
            get { return units; }
            set { units = value; }
        }

        private Building[] building;

        public  Building[] buildings
        {
            get { return building; }
            set { building = value; }
        }



        public Map(int maxx, int maxy, int numUnits, int numBuilding)
        {
            building = new Building[numBuilding];
            units = new Unit[numUnits];
            for (int i = 0; i < numUnits / 3; i++)
            {


                MeleeUnit M = new MeleeUnit(R.Next(0, maxx),
                                            R.Next(0, maxy),
                                            50,
                                            15,
                                            1,
                                            1,
                                            i % 2,
                                            "M",
                                            "Warrior");
                Units[i] = M;


            }

            for (int j = numUnits / 2; j < numUnits; j++)
            {
                RangesUnit r = new RangesUnit(R.Next(0, maxx),
                                              R.Next(0, maxy),
                                              50,
                                              10,
                                              1,
                                              3,
                                              j % 2,
                                              "R",
                                              "Archer");
                Units[j] = r;

            }

            for (int m = 0 ; m < numUnits / 2; m++)
            {
                Grubs g = new Grubs(R.Next(0, maxx),
                                              R.Next(0, maxy),
                                              100,
                                              7,
                                              1,
                                              2,
                                              m % 2,
                                              "G",
                                              "grubs");
                Units[m] = g;

            }

            //for (int n = 0; n < numUnits / 2; n++)
            //{
            //    deadshot ds = new deadshot(R.Next(0, maxx),
            //                                  R.Next(0, maxy),
            //                                  15,
            //                                  25,
            //                                  1,
            //                                  4,
            //                                  n % 2,
            //                                  "DS",
            //                                  "DeadShot");
            //    Units[n] = ds;

            //}

            //for (int k = numBuilding / 2; k < numBuilding; k++)
            //{
            //    ResourceBuilding rb = new ResourceBuilding(R.Next(0, maxx),
            //                                  R.Next(0, maxy),
            //                                  1000,
            //                                  k % 2,
            //                                  "ResourceBuilding");
            //    building[k] = rb;
            //}

            //for (int l = numBuilding / 2; l < numBuilding; l++)
            //{
            //    FactoryBuilding fb = new FactoryBuilding(R.Next(0, maxx),
            //                                  R.Next(0, maxy),
            //                                  1000,
            //                                  l % 2,
            //                                  "FactoryBuilding");
            //    building[l] = fb;
            //}

        }

    }
}

    
 
