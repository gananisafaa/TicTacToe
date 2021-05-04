using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using System.Globalization;

namespace TicTacToe
{
    
    class Grille
    {
        private Cellule[,] grid;
        private int[,] tab;
        private int clic = 0;
        private static List<string> sauvegarde;
        private static Image image_p1, image_p2;
        private static bool dft = false;
        private bool bestOf3;
        private bool bestOf5;
        private string p1_name;
        private string p2_name;
        private int winner;
        private static int p1_cpt;
        private static int p2_cpt;
        private bool newgame;
        public Grille(int L,string p1,string p2, bool b3, bool b5, Image i1, Image i2, bool d, bool ng)
        {
            grid = new Cellule[3, 3];
            tab = new int[3, 3];
            sauvegarde = new List<string>();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    grid[i, j] = new Cellule(50 + j * L, 50 + i * L, 100);
            image_p1 = i1;
            image_p2 = i2;
            dft = d;
            bestOf3 = b3;
            bestOf5 = b5;
            p1_name = p1;
            p2_name = p2;
            newgame = ng;

        }
        public bool SeachRect(Point p, out int ix, out int jy)
        {
            ix = -1;
            jy = -1;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (grid[i, j].PointInCell(p)) 
                    {
                        ix = i;
                        jy = j;
                        return true;
                    };

            return false;
        }
        public void dessiner(ref Graphics g)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    grid[i, j].dessiner(ref g);

        }
       

        public bool PlayerB(ref Graphics g, Point p)
        {
            Image image = image_p2;
            int i = -1, j = -1;
            bool r = SeachRect(p, out i, out j);
            if (!r) 
            { 
                return false;
            }
            else
            {
                if(dft)
                    grid[i, j].rond(ref g);
                else
                    grid[i, j].DrawImage(ref g, image);
                SoundPlayer clicking = new SoundPlayer(@"C:\Users\salon\Desktop\3IIR\POO\Mini Projet\TicTacToe\TicTacToe\Resources\Stapling Paper-SoundBible.com-238116558.wav");
                clicking.Play();
                tab[i, j] = -1;
                string e;
                e = p2_name + ": (" + i + ", " + j + ")";                
                sauvegarde.Add(e);
                clic++;
                return true;
            }
        }
        public bool PlayerA(ref Graphics g, Point p)
        {
            Image image = image_p1;
            int i = -1, j = -1;
            bool r = SeachRect(p, out i, out j);
            if (!r)
            {
                return false;
            }
            else
            {
                if (dft)
                    grid[i, j].Croix(ref g);
                else
                    grid[i, j].DrawImage(ref g,image);
                SoundPlayer clicking = new SoundPlayer(@"C:\Users\salon\Desktop\3IIR\POO\Mini Projet\TicTacToe\TicTacToe\Resources\Stapling Paper-SoundBible.com-238116558.wav");
                clicking.Play();
                tab[i, j] = 1;
                string e;
                e = p1_name + ": (" + i + ", " + j + ")";
                sauvegarde.Add(e);
                clic++;
                return true; 
            
            }
        }
      
        public int IsWinner()
        {
            int[] ligne = new int[3];
            int[] colonne = new int[3];
            int diag1 = 0, diag2 = 0;
            for (int i = 0; i < 3; i++)
            {
                ligne[i] = 0;
                colonne[i] = 0;

                for (int j = 0; j < 3; j++)
                {
                    ligne[i] += tab[i, j];
                    colonne[i] += tab[j, i];
                    if (i == j)
                    {
                        diag1 += tab[i, j];
                    }
                    if (i + j == 2)
                    {
                        diag2 += tab[i, j];
                    }

                }
            }
            if (diag1 == 3 || diag2 == 3)
            {
                return 1;
            }
            else if (diag1 == -3 || diag2 == -3)
            {
                return -1;
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    if (ligne[i] == 3 || colonne[i] == 3)
                    {
                        return 1;

                    }
                    else if (ligne[i] == -3 || colonne[i] == -3)
                    {
                        return -1;
                    }

                }
            }
            if (clic == 9)
            {
                return 2;

            }
            return 0;
        }
        public void Save()
        {
            sauvegarde.Add("Game Over");
            
                using (StreamWriter sw = new StreamWriter("test.txt"))
                {
                    for(int i=0; i<sauvegarde.Count;i++)
                    {
                        sw.WriteLine(sauvegarde[i]);
                    }
                }
            sauvegarde.Clear();
        }
        public void ResetGame(Form1 f)
        {

            tab = new int[3, 3];

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    grid[i, j].reset();
            clic = 0;
            
            f.Refresh(); // redessiner
            
        }
        public bool CheckForGameOver(Form1 f)
        {
           
            int nWin = this.IsWinner();
            if (newgame) { p1_cpt = 0; p2_cpt = 0; }
            if (nWin == 1)
            {
                p1_cpt++;
                Save();
                winner = 1;
                f.Hide();
                GameOver new_game = new GameOver(p1_name,p2_name,bestOf3,bestOf5,dft,image_p1,image_p2, winner, p1_cpt, p2_cpt);
                new_game.Show();
                return true;
            }
            else if (nWin == -1) 
            {
                p2_cpt++;
                Save();
                winner = -1;
                f.Hide();
                GameOver new_game = new GameOver(p1_name, p2_name, bestOf3, bestOf5, dft, image_p1, image_p2,winner,p1_cpt,p2_cpt);
                new_game.Show();
                return true;
            }
            else if (nWin == 2)
            {
                Save();
                winner = 0;
                f.Hide();
                GameOver new_game = new GameOver(p1_name, p2_name, bestOf3, bestOf5, dft, image_p1, image_p2, winner, p1_cpt, p2_cpt);
                new_game.Show();
                return true;
            }

            return false;

        }

       

    }
}
