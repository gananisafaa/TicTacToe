using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private Grille game;
        bool verrou = true;
        private string p1_name;
        private string p2_name;
       
        int i = 0;
        public Form1(string p1, string p2, bool b3, bool b5, Image i1, Image i2, bool d, bool ng)
        {
            InitializeComponent();
            game = new Grille(100,p1,p2, b3, b5,i1,i2,d,ng);
            p1_name = p1;
            p2_name = p2;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = p1_name;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            game.dessiner(ref g);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            
            Graphics g = this.CreateGraphics();
            Point p = e.Location;
            if (i == 0)
                verrou = true;
            switch (e.Button)
            {
                
                case MouseButtons.Left:
                    {
                        bool ok = false;
                          if (verrou)
                        {
                            i++;
                            ok = this.game.PlayerA(ref g, p);
                            if (ok)
                            {
                                verrou = false;
                                label3.Text = p2_name;

                            }
                        }
                        bool test = game.CheckForGameOver(this);
                        if (test) verrou = true;
                    }

                    break;

                case MouseButtons.Right:
                    {
                        bool ok = true;
                      
                        if (!verrou)
                        {
                            i++;
                            ok = this.game.PlayerB(ref g, p);
                            label3.Text = p1_name;
                            if (ok)
                            {
                                verrou = true;
                                label3.Text = p1_name;

                            }
                        }
                        bool test = game.CheckForGameOver(this);
                        if (test) verrou = true;
                    }

                    break;
                default:
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            game.ResetGame(this);
            i = 0;
            label3.Text = p1_name;

        }
       
    }
}
