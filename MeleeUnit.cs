using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevPOE2ndAttempt
{
    [Serializable]
    public class MeleeUnit : Unit
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

        public override void Combat(Unit u)
        {
            if(u.GetType() == typeof(MeleeUnit))
            {
                Health -= ((MeleeUnit)u).Attack;
            }
            else if(u.GetType() == typeof(MeleeUnit))
            {
                Health -= ((RangesUnit)u).Attack;
            }
        }

        public override bool Death()
        {
            if(health <= 0)
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
            if(u.GetType() == typeof(MeleeUnit))
            {
                MeleeUnit m = (MeleeUnit)u;
                if(Distance(u) <= Attackrange)
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

        private int Distance(Unit u)
        {
            if (u.GetType() == typeof(MeleeUnit))
            {
                MeleeUnit m = (MeleeUnit)u;
                int d = Math.Abs(Xpos - m.Xpos) + Math.Abs(Ypos - m.Ypos);
                return d;
            }
            else
            {
                return 0;
            }
        }

        public override Unit Close(Unit[] units)
        {
            Unit close = this;
            int close_distance = 40;
            foreach(Unit u in units)
            {
                if (u.GetType() ==typeof(MeleeUnit) && ((MeleeUnit)u).Death() == false)
                {
                    if (((MeleeUnit)u).Faction != Faction)
                        if(Distance(u) < close_distance)
                        {
                            close = u;
                            close_distance = Distance(u);
                        }

                }
            }
            return close;
        }

        public override string ToString()
        {

            return Name + " , " + Xpos + " , " + Ypos + " , " + health + " , ";

        }

        public Direction Directionto(Unit u)
        {
           if(u.GetType() == typeof(MeleeUnit))
           {
                MeleeUnit m = (MeleeUnit)u;
                if(m.Xpos < Xpos)
                {
                    return Direction.North;
                }
                else if(m.Ypos > Ypos)
                {
                    return Direction.East;
                }
                else if(m.Xpos > xpos)
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

        public override int getHashCode()
        {
            return getHashCode();

        }

    public MeleeUnit(int x, int y, int health, int attack, int speed, int range, int faction, string symbol, string name)
        {
            Xpos = x;
            Ypos = y;
            Health = health;
            Attack = attack;
            Speed = speed;
            Attackrange = attackrange;
            Faction = faction;
            Symbol = symbol;
            Name = "Warrior";
        }

        public override void Move(Direction d)
        {
            switch(d)
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

       
    }

}
