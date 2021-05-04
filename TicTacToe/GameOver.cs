using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TicTacToe
{
    public partial class GameOver : Form
    {
        private static int winner;
        private static int p1_cpt ;
        private static  int p2_cpt ;
        private static bool dft = false;
        private bool bestOf3;
        private bool bestOf5;
        private string p1_name;
        private string p2_name;
        private static Image image_p1, image_p2;

        public GameOver(string p1, string p2, bool b3, bool b5, bool d, Image i1, Image i2, int w, int cpt1, int cpt2)
        {
            InitializeComponent();
            dft = d;
            bestOf3 = b3;
            bestOf5 = b5;
            p1_name = p1;
            p2_name = p2;
            image_p1 = i1;
            image_p2 = i2;
            p1_cpt = cpt1;
            p2_cpt = cpt2;
            winner = w;  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dft = false;
            p2_cpt = 0;
            p1_cpt = 0;
            this.Hide();
            StartForm new_game = new StartForm();
            new_game.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 new_game = new Form1(p1_name, p2_name, bestOf3, bestOf5, image_p1, image_p2, dft, false);
            new_game.Show();
        }

        private void GameOver_Load(object sender, EventArgs e)
        {
            string messageA = p1_name + " Won!!";
            string messageB = p2_name + " Won!!";
            string messageC = "Fair Game !";
            SoundPlayer win = new SoundPlayer(@"C:\Users\salon\Desktop\3IIR\POO\Mini Projet\TicTacToe\TicTacToe\Resources\Fire Crackers-SoundBible.com-1716803209.wav");

            if (winner==1)
            {
                if (bestOf3 && p1_cpt == 3)
                {
                    label6.Text = "Best Out Of 3 Is:" + p1_name;
                }
                else if (bestOf3 == true && p1_cpt == 5)
                {
                    label6.Text = "Best Out Of 5 Is:" + p1_name;

                }
                else
                    label6.Text = messageA;
                win.Play();
            }
            else if(winner==-1)
            {
                if (bestOf3 && p2_cpt == 3)
                {
                    label6.Text = "Best Out Of 3 Is:" +p2_name;
                }
                else if (bestOf3 == true && p2_cpt == 5)
                {
                    label6.Text = "Best Out Of 5 Is:" + p2_name;

                }
                else
                    label6.Text = messageB;
                win.Play();
            }
            else
            {
                label6.Text = messageC;

                SoundPlayer lose = new SoundPlayer(@"C:\Users\salon\Desktop\3IIR\POO\Mini Projet\TicTacToe\TicTacToe\Resources\fail-trombone-01.wav");
                lose.Play();
            }
            label4.Text = p1_name;
            label5.Text = p2_name;
            label2.Text = p1_cpt.ToString();
            label3.Text = p2_cpt.ToString();
        }

       
    }
}
