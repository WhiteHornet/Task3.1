using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevPOE2ndAttempt
{
    abstract class Unit
    {
        protected int xpos;
        protected int ypos;
        protected int health;
        protected int speed;
        protected int attack;
        protected int attackrange;
        protected string faction;

        abstract public int combat();
        abstract public int Death();
        abstract public int RestartPos();
        abstract public int CalcRange();
        abstract public int newPosition();
        abstract public int getHashCode();
        abstract public int toString();

        //protected int xpos;
        //protected int ypos;
        //protected int health;
        //protected int speed;
        //protected int attack;
        //protected int attackrange;
        //protected string faction;

        //abstract public void Move((Direction, direction);
        //abstract public void Combat(Unit u);
        //abstract public bool Integer(Unit u);
        //abstract public unit Closest(Unit[], units);
        //abstract public void Death();
        //abstract public string Tostring();

        



    }
}
