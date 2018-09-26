using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevPOE2ndAttempt
{
    [Serializable]
    public class FactoryBuilding : Building
    {

        public int UnitToProduce
        {
            get { return unittoproduce; }
            set { unittoproduce = value; }
        }

        public int GameTickPerProduction
        {
            get { return gametickperproduction; }
            set { gametickperproduction = value; }
        }

        public int SpawnPoint
        {
            get { return spawnpoint; }
            set { spawnpoint = value; }
        }


        public int Xpos
        {
            get { return xpos; }
            set { xpos = value; }
        }

        public int Ypos
        {
            get { return ypos; }
            set { ypos = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public int Faction
        {
            get { return faction; }
            set { faction = value; }
        }

        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }



        public FactoryBuilding(int xpos, int ypos, int health, int faction, string symbol, int utp, int gtpp, int sp)
        {
            Xpos = xpos;
            Ypos = ypos;
            Health = health;
            Faction = faction;
            Symbol = symbol;
            unittoproduce = utp;
            gametickperproduction = gtpp;
            spawnpoint = sp;
            

        }

        public override bool isDestroyed()
        {
            return false;
        }

        public override string ToString()
        {
            return "symbol " + symbol + "\r\n Xpos:" + Xpos + "\r\n Ypos :" + Ypos;
        }

        public override int generateRes()
        {
            return generateRes();
        }
    }
}
