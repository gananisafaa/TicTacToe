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
    public partial class StartForm : Form
    {
        //public static string p1_name, p2_name;
        private static bool bestOf3 = false;
        private static bool bestOf5 = false;
        private static bool newgame = true;

        public StartForm()
        {
            InitializeComponent();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            //GameOver.p1_cpt = 0;
            //GameOver.p2_cpt = 0;
            //GameOver.winner = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
               // p1_name = textBox1.Text;
               // p2_name = textBox2.Text;
                this.Hide();
                ChooseImage new_game = new ChooseImage(textBox1.Text,textBox2.Text, bestOf3, bestOf5, newgame);
                new_game.Show();

            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                bestOf3 = true;
               //// p1_name = textBox1.Text;
               // p2_name = textBox2.Text;
                this.Hide();
                ChooseImage new_game = new ChooseImage(textBox1.Text, textBox2.Text, bestOf3, bestOf5, newgame);
                new_game.Show();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                bestOf5 = true;
                //p1_name = textBox1.Text;
                //p2_name = textBox2.Text;
                this.Hide();
                ChooseImage new_game = new ChooseImage(textBox1.Text, textBox2.Text, bestOf3, bestOf5, newgame);
                new_game.Show();

            }
        }
    }
}
