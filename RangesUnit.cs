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

    public  class RangesUnit : Unit
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



        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }



        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }



        public int Attackrange
        {
            get { return attackrange; }
            set { attackrange = value; }
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

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public RangesUnit(int x, int y, int health, int attack, int speed, int range, int faction, string symbol, string name)
        {
            Xpos = x;
            Ypos = y;
            Health = health;
            Attack = attack;
            Speed = speed;
            Attackrange = attackrange;
            Faction = faction;
            Symbol = symbol;
            Name = "Archer";
        }

        public string GetName()
        {
            return Name;
        }

        public override void Combat(Unit u)
        {
            if (u.GetType() == typeof(RangesUnit))
            {
                Health -= ((RangesUnit)u).Attack;
            }
            else if (u.GetType() == typeof(RangesUnit))
            {
                Health -= ((MeleeUnit)u).Attack;
            }
        }

        public override bool Death()
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

        public override bool Range(Unit u)
        {
            if (u.GetType() == typeof(RangesUnit))
            {
                RangesUnit m = (RangesUnit)u;
                if (Distance(u) <= Attackrange)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public override Unit Close(Unit[] units)
        {
            Unit close = this;
            int close_distance = 40;
            foreach (Unit u in units)
            {
                if (u.GetType() == typeof(RangesUnit))
                {
                    if (((RangesUnit)u).Faction != Faction && ((RangesUnit)u).Death() == false)
                        if (Distance(u) < close_distance)
                        {
                            close = u;
                            close_distance = Distance(u);
                        }

                }
            }
            return close;
        }

        public Direction Directionto(Unit u)
        {
            if (u.GetType() == typeof(RangesUnit))
            {
                RangesUnit r = (RangesUnit)u;
                if (r.Xpos < Xpos)
                {
                    return Direction.North;
                }
                else if (r.Ypos > Ypos)
                {
                    return Direction.East;
                }
                else if (r.Xpos > xpos)
                {
                    return Direction.South;
                }
                else
                {
                    return Direction.West;
                }
            }
            else
            {
                return Direction.North;
            }
        }

        private int Distance(Unit u)
        {
            if (u.GetType() == typeof(RangesUnit))
            {
                RangesUnit r = (RangesUnit)u;
                int d = Math.Abs(Xpos - r.Xpos) + Math.Abs(Ypos - r.Ypos);
                return d;
            }
            else
            {
                return 0;
            }
        }

        public override void Move(Direction d)
        {
            switch (d)
            {
                case Direction.North:
                    {
                        Ypos -= Speed;
                        break;
                    }
                case Direction.East:
                    {
                        Xpos -= Speed;
                        break;
                    }
                case Direction.South:
                    {
                        Ypos -= Speed;
                        break;
                    }
                case Direction.West:
                    {
                        Xpos -= Speed;
                        break;
                    }
            }

        }

        public override string ToString()
        {
            return Name + " , " + Xpos + " , " +  Ypos  + " , " + health + " , ";
        }
        public override int getHashCode()
        {
            return getHashCode();
        }
    }
}
