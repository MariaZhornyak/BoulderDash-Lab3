using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace BoulderDash
{
    public partial class QuitGameForm : Form
    {
        public QuitGameForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (StreamWriter file = new StreamWriter("Saved game.txt"))
            {
                file.Write(MainForm.CurrentGameForm.GameString);
            }

            MainForm.CurrentGameForm.Close();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
