using System;
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
    public partial class newGameForm : Form
    {
        private int points = 0;
        private bool gameEnded = false;
        private int numberOfDiamonds = 19;

        private bool goRight, goLeft, goUp, goDown;
        private bool canMoveRight = true;
        private bool canMoveLeft = true;
        private bool canMoveUp = false;
        private bool canMoveDown = false;


        public newGameForm()
        {
            InitializeComponent();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    MovePlayerRight();
                    break;
                case Keys.Left:
                    MovePlayerLeft();
                    break;
                case Keys.Up:
                    MovePlayerUp();
                    break;
                case Keys.Down:
                    MovePlayerDown();
                    break;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            //Console.WriteLine("uuuuuu");
        }

        private void MovePlayerRight()
        {
            PointCounter.Text = "Your points: " + points;
            
            Player.Left += 40;
        }

        private void MovePlayerLeft()
        {
            PointCounter.Text = "Your points: " + points;
            if(Player.Location.X > 0)
            {

            }
            Player.Left -= 40;
        }

        private void MovePlayerUp()
        {
            PointCounter.Text = "Your points: " + points;
            if(Player.Location.Y > 0)
            {

            }
            Player.Top -= 40;
        }

        private void MovePlayerDown()
        {
            PointCounter.Text = "Your points: " + points;
            if(Player.Location.Y <= 360)
            {

            }
            Player.Top += 40;
        }

        private void newGameForm_Load(object sender, EventArgs e)
        {
            Player.Location = new Point(0, 0);
        }
    }
}
