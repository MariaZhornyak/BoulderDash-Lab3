﻿using System;
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


        public GameForm()
        {
            InitializeComponent();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyCode);
            switch (e.KeyCode)
            {
                case Keys.Right:
                    MovePlayerRight();
                    break;
                case Keys.Left:
                    break;
                case Keys.Up:
                    break;
                case Keys.Down:
                    break;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            Console.WriteLine("ddddddddd");
        }

        private void MovePlayerRight()
        {
            //Player.Left += 40;
            Player.Location = new Point(40, 0);
            Player.Update();
            GameTimer.Start();
            Console.WriteLine("kkkkkkkkk");
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            Player.Location = new Point(0, 0);
        }

        private void Key_Press(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine(e.KeyChar);
        }
    }
}
