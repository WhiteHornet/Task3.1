using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GameDevPOE2ndAttempt
{
    //Veron potter -
    public partial class Form1 : Form
    {
        Map map = new Map(80, 80, 80, 80);
        const int BEGIN_X = 1;
        const int BEGIN_Y = 0;
        const int SPACE = 0;
        const int SIZE = 20;
        Random R = new Random();
        int turn = 0;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
                
        }

        private void GBMap_Enter(object sender, EventArgs e)
        {

        }

        private void Button_Click(object sender, EventArgs e)
        {
            int x = (((Button)sender).Location.X - GBMap.Location.X) / SIZE;
            int y = (((Button)sender).Location.Y - GBMap.Location.Y) / SIZE;

            txtInfo.Text = x + " " + y;
            foreach(Unit u in map.Units)
            {
                if(u.GetType() == typeof(MeleeUnit))
                {
                    MeleeUnit m = (MeleeUnit)u;
                    if(m.Xpos == x && m.Ypos == y)
                    {
                        txtInfo.Text = "Melee" + m.ToString();
                    }
                }
            }
            foreach (Unit Y in map.Units)
            {
                if (y.GetType() == typeof(RangesUnit))
                {
                    RangesUnit r = (RangesUnit)Y;
                    if (r.Xpos == x && r.Ypos == y)
                    {
                        txtInfo.Text = "Archer" + r.ToString();
                    }
                }
            }
            foreach (Unit X in map.Units)
            {
                if (y.GetType() == typeof(Grubs))
                {
                    Grubs G = (Grubs)X;
                    if (G.Xpos == x && G.Ypos == y)
                    {
                        txtInfo.Text = "Grubs" + G.ToString();
                    }
                }
            }

        }

        private void DisplayMap()
        {
            GBMap.Controls.Clear();
            foreach(Unit u in map.Units)
            {
                if(u.GetType() == typeof(MeleeUnit))
                {
                    int begin_x, begin_y;
                    begin_x = GBMap.Location.X;
                    begin_y = GBMap.Location.Y;
                    MeleeUnit m = (MeleeUnit)u;
                    Button b = new Button();
                    b.Size = new Size(SIZE, SIZE);
                    b.Location = new Point(begin_x + (m.Xpos * SIZE), begin_y + (m.Ypos * SIZE));
                    b.Text = m.Symbol;
                    if(m.Faction == 2)
                    {
                        b.ForeColor = Color.Silver;
                    }
                    else
                    {
                        b.ForeColor = Color.Orange;
                    }

                    if(m.Death())
                    {
                        b.ForeColor = Color.Black;
                    }
                    b.Click += new EventHandler(Button_Click);
                    GBMap.Controls.Add(b);
                }
               
                    else if(u.GetType() == typeof(RangesUnit))
                    {
                        int start_x, start_y;
                        start_x = GBMap.Location.X;
                        start_y = GBMap.Location.Y;
                        RangesUnit r = (RangesUnit)u;
                        Button b = new Button();
                        b.Size = new Size(SIZE, SIZE);
                        b.Location = new Point(start_x + (r.Xpos * SIZE), start_y + (r.Ypos * SIZE));
                        b.Text = r.Symbol;
                        if (r.Faction == 3)
                        {
                            b.ForeColor = Color.Silver;
                        }
                        else
                        {
                            b.ForeColor = Color.Orange;
                        }

                        if (r.Death())
                        {
                            b.ForeColor = Color.Black;
                        }
                        b.Click += new EventHandler(Button_Click);
                        GBMap.Controls.Add(b);
                    }

                else if (u.GetType() == typeof(Grubs))
                {
                    int begin_x, begin_y;
                    begin_x = GBMap.Location.X;
                    begin_y = GBMap.Location.Y;
                    Grubs g = (Grubs)u;
                    Button b = new Button();
                    b.Size = new Size(SIZE, SIZE);
                    b.Location = new Point(begin_x + (g.Xpos * SIZE), begin_y + (g.Ypos * SIZE));
                    b.Text = g.Symbol;
                    if (g.Faction == 1)
                    {
                        b.ForeColor = Color.Green;
                    }
                    
                    else if (g.Death())
                    {
                        b.ForeColor = Color.Black;
                    }
                    b.Click += new EventHandler(Button_Click);
                    GBMap.Controls.Add(b);
                }

                //else if (u.GetType() == typeof(deadshot))
                //{
                //    int begin_x, begin_y;
                //    begin_x = GBMap.Location.X;
                //    begin_y = GBMap.Location.Y;
                //    deadshot g = (deadshot)u;
                //    Button b = new Button();
                //    b.Size = new Size(SIZE, SIZE);
                //    b.Location = new Point(begin_x + (g.Xpos * SIZE), begin_y + (g.Ypos * SIZE));
                //    b.Text = g.Symbol;
                //    if (g.Faction == 4)
                //    {
                //        b.ForeColor = Color.LightBlue;
                //    }


                //    if (g.Death())
                //    {
                //        b.ForeColor = Color.Black;
                //    }
                //    b.Click += new EventHandler(Button_Click);
                //    GBMap.Controls.Add(b);
                //}

                //foreach (Building y in map.buildings)
                //{
                //    int begin_x, begin_y;
                //    begin_x = GBMap.Location.X;
                //    begin_y = GBMap.Location.Y;
                //    ResourceBuilding m = (ResourceBuilding)y;
                //    Button b = new Button();
                //    b.Size = new Size(SIZE, SIZE);
                //    b.Location = new Point(begin_x + (m.Xpos * SIZE), begin_y + (m.Ypos * SIZE));
                //    b.Text = m.Symbol;
                //    if (m.Faction == 2)
                //    {
                //        b.ForeColor = Color.Green;
                //    }
                //    else
                //    {
                //        b.ForeColor = Color.Orange;
                //    }

                //    if (m.isDestroyed())
                //    {
                //        b.ForeColor = Color.Black;
                //    }
                //    b.Click += new EventHandler(Button_Click);
                //    GBMap.Controls.Add(b);
                //}

                //else if (u.GetType() == typeof(FactoryBuilding))
                //{
                //    int start_x, start_y;
                //    start_x = GBMap.Location.X;
                //    start_y = GBMap.Location.Y;
                //    FactoryBuilding fb = (FactoryBuilding);
                //    Button b = new Button();
                //    b.Size = new Size(SIZE, SIZE);
                //    b.Location = new Point(start_x + (fb.Xpos * SIZE), start_y + (fb.Ypos * SIZE));
                //    b.Text = fb.Symbol;
                //    if (fb.Faction == 1)
                //    {
                //        b.ForeColor = Color.Green;
                //    }
                //    else
                //    {
                //        b.ForeColor = Color.Orange;
                //    }

                //    if (fb.isDestroyed())
                //    {
                //        b.ForeColor = Color.Black;
                //    }
                //    b.Click += new EventHandler(Button_Click);
                //    GBMap.Controls.Add(b);
                //}



            }
        }

        private void UpdateMap()
        {
            foreach (Unit u in map.Units)
            {
                if (u.GetType() == typeof(MeleeUnit))
                {
                    MeleeUnit m = (MeleeUnit)u;
                    if (m.Health < 5)
                    {
                        switch (R.Next(0, 5))
                        {
                            case 0: m.Move(Direction.North); break;
                            case 1: m.Move(Direction.West); break;
                            case 2: m.Move(Direction.South); break;
                            case 3: m.Move(Direction.East); break;
                        }
                    }
                    else
                    {
                        bool inCombat = false;
                        foreach (Unit e in map.Units)
                        {
                            if (u.Range(e))
                            {
                                u.Combat(e);
                                inCombat = true;

                            }
                        }
                        if (inCombat)
                        {
                            Unit c = m.Close(map.Units);
                            m.Move(m.Directionto(c));
                        }
                    }

                }
                else if (u.GetType() == typeof(RangesUnit))
                {
                    RangesUnit r = (RangesUnit)u;
                    if (r.Health < 20)
                    {
                        switch (R.Next(0, 4))
                        {
                            case 0: r.Move(Direction.North); break;
                            case 1: r.Move(Direction.West); break;
                            case 2: r.Move(Direction.South); break;
                            case 3: r.Move(Direction.East); break;
                        }
                    }
                    else
                    {
                        bool inCombat = false;
                        foreach (Unit e in map.Units)
                        {
                            if (u.Range(e))
                            {
                                u.Combat(e);
                                inCombat = true;
                            }
                        }
                        if (inCombat)
                        {
                            Unit c = r.Close(map.Units);
                            r.Move(r.Directionto(c));
                        }
                    }
                }
                else if (u.GetType() == typeof(Grubs))
                {
                    Grubs g = (Grubs)u;
                    if (g.Health < 20)
                    {
                        switch (R.Next(0, 4))
                        {
                            case 0: g.Move(Direction.North); break;
                            case 1: g.Move(Direction.West); break;
                            case 2: g.Move(Direction.South); break;
                            case 3: g.Move(Direction.East); break;
                        }
                    }
                    else
                    {
                        bool inCombat = false;
                        foreach (Unit e in map.Units)
                        {
                            if (u.Range(e))
                            {
                                u.Combat(e);
                                inCombat = true;

                            }
                        }
                        if (inCombat)
                        {
                            Unit c = g.Close(map.Units);
                            g.Move(g.Directionto(c));
                        }
                    }

                }

                //else if (u.GetType() == typeof(deadshot))
                //{
                //    deadshot ds = (deadshot)u;
                //    if (ds.Health < 20)
                //    {
                //        switch (R.Next(0, 4))
                //        {
                //            case 0: ds.Move(Direction.North); break;
                //            case 1: ds.Move(Direction.West); break;
                //            case 2: ds.Move(Direction.South); break;
                //            case 3: ds.Move(Direction.East); break;
                //        }
                //    }
                //    else
                //    {
                //        bool inCombat = false;
                //        foreach (Unit e in map.Units)
                //        {
                //            if (u.Range(e))
                //            {
                //                u.Combat(e);
                //                inCombat = true;

                //            }
                //        }
                //        if (inCombat)
                //        {
                //            Unit c = ds.Close(map.Units);
                //            ds.Move(ds.Directionto(c));
                //        }
                //    }

                //}


            }

            //foreach (Building y in map.buildings)
            //{
            //    if (y.GetType() == typeof(ResourceBuilding))
            //    {
            //        ResourceBuilding rb = (ResourceBuilding)y;
                    

            //    }
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            UpdateMap();
            DisplayMap();
            txtTurn.Text = (++turn).ToString();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
              
            
                 
                BinaryFormatter bf = new BinaryFormatter();

                FileStream fsout = new FileStream("Charact.dat", FileMode.Create, FileAccess.Write, FileShare.None);

                try
                {
                    using (fsout)
                    {
                        MessageBox.Show(" Info Saved");
                    }
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show("ErrorOcurred" + ex.Message);
                }

            

        }



        private void btnRead_Click(object sender, EventArgs e)
        {
            
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fsin = new FileStream("building.dat", FileMode.Open, FileAccess.Read, FileShare.None);

                try
                {
                    using (fsin)
                    {
                        map = (Map)bf.Deserialize(fsin);
                        MessageBox.Show(" Info Loaded");
                    }
                }
                catch
                {
                    MessageBox.Show("Error Ocurred");
                }

            




        }

        private void txtInfo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
