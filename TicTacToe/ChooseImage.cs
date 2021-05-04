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

namespace TicTacToe
{
    public partial class ChooseImage : Form
    {
        private static Image image_p1,image_p2;
        private static bool dft = false;
        private string p1_name;
        private string p2_name;
        private bool bestOf3;
        private bool bestOf5;
        private bool newgame;
        public ChooseImage(string p1, string p2, bool b3, bool b5, bool ng)
        {
            InitializeComponent();
            p1_name = p1;
            p2_name = p2;
            bestOf3 = b3;
            bestOf5 = b5;
            newgame = ng;
        }

        private void ChooseImage_Load(object sender, EventArgs e)
        {
            label3.Text = p1_name;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            choose(pictureBox1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            choose(pictureBox2);

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            choose(pictureBox3);

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            choose(pictureBox6);

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            choose(pictureBox5);

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            choose(pictureBox4);

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            choose(pictureBox9);

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            choose(pictureBox8);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            choose(pictureBox7);

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            choose(pictureBox12);

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            choose(pictureBox11);

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            choose(pictureBox10);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dft = true;
            this.Hide();
            Form1 new_game = new Form1(p1_name,p2_name,bestOf3,bestOf5,image_p1,image_p2,dft, newgame);
            new_game.Show();
        }

        private void choose(PictureBox pb)
        {
            if (label3.Text == p1_name)
            {
                image_p1 = pb.Image;
                label3.Text = p2_name;
            }
            else
            {
                if (image_p1 != pb.Image)
                {
                    dft = false;
                    image_p2 = pb.Image;
                    this.Hide();
                    Form1 new_game = new Form1(p1_name, p2_name, bestOf3, bestOf5, image_p1, image_p2, dft, newgame);
                    new_game.Show();


                }

            }
            SoundPlayer clicking = new SoundPlayer(@"C:\Users\salon\Desktop\3IIR\POO\Mini Projet\TicTacToe\TicTacToe\Resources\Stapling Paper-SoundBible.com-238116558.wav");
            clicking.Play();
        }
    }
}
