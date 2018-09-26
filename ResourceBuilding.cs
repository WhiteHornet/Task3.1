using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevPOE2ndAttempt
{
    [Serializable]
    public class ResourceBuilding : Building
    {

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

        private string restype;

        public string ResType 
        {
            get { return restype; }
            set { restype = value; }
        }

        public int ResPerGametick
        {
            get { return respergametick; }
            set { respergametick = value; }
        }

        public int ResRemaining
        {
            get { return resremaining; }
            set { resremaining = value; }
        }




        public ResourceBuilding(int xpos, int ypos, int health, int faction, string symbol)
        {
            Xpos = xpos;
            Ypos = ypos;
            Health = health;
            Faction = faction;
            Symbol = symbol;
            ResType = restype;
            respergametick = ResPerGametick;
            resremaining = ResRemaining;
        }

       

        public override bool isDestroyed()
        {
            if (health <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return "ResourceBuilding " + symbol + "\r\n Xpos:" + Xpos + "\r\n Ypos :" + Ypos;
        }

        public override int generateRes()
        {
           for(int i = 0; i <ResPerGametick; i ++)
           {
                int restype;
           }
            return resType;
        }



    }
}
