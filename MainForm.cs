using BoulderDash;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        public static GameForm CurrentGameForm;


        public MainForm()
        {
            InitializeComponent();
        }

        // New game
        private void button1_Click(object sender, EventArgs e)
        {
            GameForm newForm = new GameForm();
            newForm.Show();

            MainForm.CurrentGameForm = newForm;
        }

        //Show about form
        private void button2_Click(object sender, EventArgs e)
        {
            AboutForm newForm = new AboutForm();
            newForm.Show();
        }

        // Load saved game
        private void button4_Click(object sender, EventArgs e)
        {
            int points;
            int numberOfDiamonds;
            int width;
            int height;
            char[,] field;
            using (StreamReader file = new StreamReader("Saved game.txt"))
            {
                points = Convert.ToInt32(file.ReadLine().Split(' ')[1]);
                numberOfDiamonds = Convert.ToInt32(file.ReadLine().Split(' ')[1]);
                width = Convert.ToInt32(file.ReadLine().Split(' ')[1]);
                height = Convert.ToInt32(file.ReadLine().Split(' ')[1]);

                field = new char[width, height];
                for (int i = 0; i < height; i++)
                {
                    string row = file.ReadLine();
                    for (int j = 0; j < width; j++)
                    {
                        field[j, i] = row[j];
                    }
                }
            }

            GameForm newGameForm = new GameForm(width, height, field, points, numberOfDiamonds);
            newGameForm.Show();

            MainForm.CurrentGameForm = newGameForm;
        }

        //Exit
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}