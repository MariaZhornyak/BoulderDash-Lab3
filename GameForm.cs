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
    public partial class GameForm : Form
    {
        private int points = 0;
        private int numberOfDiamonds = 19;

        public GameForm()
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

            PointCounter.Text = "Your points: " + points;

            if(this.points == this.numberOfDiamonds)
            {
                YouWonForm newForm = new YouWonForm();
                newForm.Show();
                this.Close();
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            //Console.WriteLine("uuuuuu");
        }

        private void MovePlayerRight()
        {
            if(Player.Left >= 360)
            {
                return;
            }

            Control nextBlock = null;
            Control nextNextBlock = null;

            foreach (Control x in this.Controls)
            {
                if(x.Left - 40 == Player.Left && x.Top == Player.Top)
                {
                    nextBlock = x;
                }
                else if (x.Left - 80 == Player.Left && x.Top == Player.Top)
                {
                    nextNextBlock = x;
                }
            }

            if (nextBlock.Visible)
            {
                if ((string)nextBlock.Tag == "stone")
                {
                    if (nextNextBlock == null || ((string)nextNextBlock.Tag != "sand" && nextNextBlock.Visible))
                    {
                        return;
                    }

                    nextNextBlock.Left -= 40;
                    nextNextBlock.Visible = false;
                    nextBlock.Left += 40;
                }
                else
                {
                    if((string)nextBlock.Tag == "diamond")
                    {
                        this.points++;
                    }
                    nextBlock.Visible = false;
                }
            }
            Player.Left += 40;
        }

        private void MovePlayerLeft()
        {
            if (Player.Left <= 0)
            {
                return;
            }

            Control nextBlock = null;
            Control nextNextBlock = null;

            foreach (Control x in this.Controls)
            {
                if (x.Left + 40 == Player.Left && x.Top == Player.Top)
                {
                    nextBlock = x;
                }
                else if (x.Left + 80 == Player.Left && x.Top == Player.Top)
                {
                    nextNextBlock = x;
                }
            }

            if (nextBlock.Visible)
            {
                if ((string)nextBlock.Tag == "stone")
                {
                    if (nextNextBlock == null || ((string)nextNextBlock.Tag != "sand" && nextNextBlock.Visible))
                    {
                        return;
                    }

                    nextNextBlock.Left += 40;
                    nextNextBlock.Visible = false;
                    nextBlock.Left -= 40;
                }
                else
                {
                    if ((string)nextBlock.Tag == "diamond")
                    {
                        this.points++;
                    }
                    nextBlock.Visible = false;
                }
            }

            Player.Left -= 40;
        }

        private void MovePlayerUp()
        {
            if (Player.Top <= 0)
            {
                return;
            }

            Control nextBlock = null;
            Control nextNextBlock = null;

            foreach (Control x in this.Controls)
            {
                if (x.Top + 40 == Player.Top && x.Left == Player.Left)
                {
                    nextBlock = x;
                }
                else if (x.Top + 80 == Player.Top && x.Left == Player.Left)
                {
                    nextNextBlock = x;
                }
            }

            if (nextBlock.Visible)
            {
                if ((string)nextBlock.Tag == "stone")
                {
                    if (nextNextBlock == null || ((string)nextNextBlock.Tag != "sand" && nextNextBlock.Visible))
                    {
                        return;
                    }

                    nextNextBlock.Top += 40;
                    nextNextBlock.Visible = false;
                    nextBlock.Top -= 40;
                }
                else
                {
                    if ((string)nextBlock.Tag == "diamond")
                    {
                        this.points++;
                    }
                    nextBlock.Visible = false;
                }
            }

            Player.Top -= 40;
        }

        private void MovePlayerDown()
        {
            if (Player.Top >= 360)
            {
                return;
            }

            Control nextBlock = null;
            Control nextNextBlock = null;

            foreach (Control x in this.Controls)
            {
                if (x.Top - 40 == Player.Top && x.Left == Player.Left)
                {
                    nextBlock = x;
                }
                else if (x.Top - 80 == Player.Top && x.Left == Player.Left)
                {
                    nextNextBlock = x;
                }
            }

            if (nextBlock.Visible)
            {
                if ((string)nextBlock.Tag == "stone")
                {
                    if (nextNextBlock == null || ((string)nextNextBlock.Tag != "sand" && nextNextBlock.Visible))
                    {
                        return;
                    }

                    nextNextBlock.Top -= 40;
                    nextNextBlock.Visible = false;
                    nextBlock.Top += 40;
                }
                else
                {
                    if ((string)nextBlock.Tag == "diamond")
                    {
                        this.points++;
                    }
                    nextBlock.Visible = false;
                }
            }

            Player.Top += 40;
        }

        private void newGameForm_Load(object sender, EventArgs e)
        {
            Player.Location = new Point(0, 0);
        }
    }
}
