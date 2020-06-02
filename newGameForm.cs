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
            Player.Left += 40;
        }

        private void MovePlayerLeft()
        {
            Player.Left -= 40;
        }

        private void MovePlayerUp()
        {
            Player.Top -= 40;
        }

        private void MovePlayerDown()
        {
            Player.Top += 40;
        }

        private void newGameForm_Load(object sender, EventArgs e)
        {
            Player.Location = new Point(0, 0);
        }
    }
}
