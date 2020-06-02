using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    public partial class GameForm2 : Form
    {
        private bool moveLeft, moveRight, moveUp, moveDown;
        private int points = 0;
        private int numberOfDiamonds = 19;

        private bool canMoveRight = true;
        private bool canMoveLeft = true;
        private bool canMoveUp = false;
        private bool canMoveDown = false;
        


        public GameForm2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm newForm = new MainForm();
            newForm.Show();
        }
        
        private void PlayTheGame(object sender, EventArgs e)
        {
            txtPoints.Text = "Your points: " + points;
            if(moveRight == true)
            {
                   
            }
            if (moveLeft == true) 
            {

            }
            if(moveDown == true)
            {

            }
            if(moveUp == true)
            {

            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("ljhjsdkfhkdjhf");
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            Console.WriteLine("hgsfukjaghfdk");
        }

        private void Key_Press(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("uuuuflhr");
            MessageBox.Show("jhsekrhfkeh");
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            Console.WriteLine("slkehyrkhj5;r");
            //switch (e.KeyCode)
            //{
            //    case Keys.Right:
            //        moveRight = 
            //}
        }

        private void ResetTheGame()
        {
            txtPoints.Text = "Your points: " + points;
            points = 0;

            player.Location = new Point(0, 0);
            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                { 
                    if (x.Visible == false)
                    {
                        x.Visible = true;
                    }
                }
            }
            GameTimer.Start();
        }

        private void GameEnded()
        {
            GameTimer.Stop();
            MainForm newForm = new MainForm();
            newForm.Show();
        }
    }
}
