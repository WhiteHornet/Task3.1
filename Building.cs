using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevPOE2ndAttempt
{
    public abstract class Building
    {
        protected int xpos;
        protected int ypos;
        protected int health;
        protected int faction;
        protected string symbol;
        protected int resType;
        protected int respergametick;
        protected int resremaining;
        protected int unittoproduce;
        protected int gametickperproduction;
        protected int spawnpoint;


        abstract public bool isDestroyed();
        abstract public int generateRes();

    }

}
