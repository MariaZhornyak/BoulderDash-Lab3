using BoulderDash;
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
        public int posX { get { return Player.Left / 40; } }
        public int posY { get { return Player.Top / 40; } }

        public int width = 9;
        public int height = 9;

        public (PictureBox sand, PictureBox stone, PictureBox diamond)[,] pictureBoxField;
        public char[,] field;
        public int points = 0;
        public int numberOfDiamonds = 0;
        
        public GameForm(int width = 9, int height = 9, char[,] field = null, int points = -1, int numberOfDiamonds = -1)
        {
            InitializeComponent();

            this.width = width;
            this.height = height;

            this.pictureBoxField = new (PictureBox sand, PictureBox stone, PictureBox diamond)[this.width, this.height];
            this.field = new char[this.width, this.height];

            foreach (Control x in this.Controls)
            {
                int xCoord = x.Left / 40;
                int yCoord = x.Top / 40;
                switch ((string)x.Tag)
                {
                    case "diamond":
                        this.pictureBoxField[xCoord, yCoord].diamond = (PictureBox)x;
                        break;
                    case "sand":
                        this.pictureBoxField[xCoord, yCoord].sand = (PictureBox)x;
                        break;
                    case "stone":
                        this.pictureBoxField[xCoord, yCoord].stone = (PictureBox)x;
                        break;
                }
                x.Visible = false;
            }

            if (field != null)
            {
                this.points = points;
                this.numberOfDiamonds = numberOfDiamonds;

                this.width = field.GetLength(0);
                this.height = field.GetLength(1);

                for (int i = 0; i < this.width; i++)
                {
                    for (int j = 0; j < this.height; j++)
                    {
                        this[i, j] = field[i, j];
                    }
                }
            }
            else
            {
                Random rnd = new Random();
                this.numberOfDiamonds = 0;
                for (int i = 0; i < this.width; i++)
                {
                    for (int j = 0; j < this.height; j++)
                    {
                        int random = rnd.Next(0, 100);
                        if (random < 80 || (i == 0 && j == 0))
                        {
                            this[i, j] = Chars.sand;
                        }
                        else if (random < 90)
                        {
                            this[i, j] = Chars.stone;
                        }
                        else
                        {
                            this[i, j] = Chars.diamond;
                            this.numberOfDiamonds++;
                        }
                    }
                }
            }

            this.Player.Visible = true;
            this.PointCounter.Visible = true;
            this.PressEscape.Visible = true;
            this.pictureBoxField[0, 0].sand.Visible = false;
            this.pictureBoxField[this.posX, this.posY].sand.Visible = false;
        }

        private char this[int x, int y]
        {
            get
            {
                return this.field[x, y];
            }
            set
            {
                this.field[x, y] = value;
                this.pictureBoxField[x, y].sand.Visible = false;
                this.pictureBoxField[x, y].stone.Visible = false;
                this.pictureBoxField[x, y].diamond.Visible = false;
                switch (value)
                {
                    case Chars.sand:
                        this.pictureBoxField[x, y].sand.Visible = true;
                        break;
                    case Chars.stone:
                        this.pictureBoxField[x, y].stone.Visible = true;
                        break;
                    case Chars.diamond:
                        this.pictureBoxField[x, y].diamond.Visible = true;
                        break;
                    case Chars.player:
                        Player.Left = x * 40;
                        Player.Top = y * 40;
                        break;
                }
            }
        }

        public string GameString
        {
            get
            {
                string s = "";

                s += $"Points: {this.points}\nNumberOfDiamonds: {this.numberOfDiamonds}\nWidth: {this.width}\nHeight: {this.height}\n";

                this[this.posX, this.posY] = Chars.player;
                for (int i = 0; i < this.width; i++)
                {
                    for (int j = 0; j < this.height; j++)
                    {
                        s += this[j, i];
                    }
                    s += '\n';
                }

                return s;
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    MovePlayer(1, 0);
                    break;
                case Keys.Left:
                    MovePlayer(-1, 0);
                    break;
                case Keys.Up:
                    MovePlayer(0, -1);
                    break;
                case Keys.Down:
                    MovePlayer(0, 1);
                    break;
                case Keys.Escape:
                    QuitGameForm newForm = new QuitGameForm();
                    newForm.Show();
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

        public void MovePlayer(int dX, int dY)
        {
            int newPosX = this.posX + dX;
            int newPosY = this.posY + dY;
            int afterNewPosX = this.posX + 2 * dX;
            int afterNewPosY = this.posY + 2 * dY;
            if (newPosX < 0 || newPosX > this.width - 1 || newPosY < 0 || newPosY > this.height - 1)
            {
                return;
            }

            if (this[newPosX, newPosY] == Chars.diamond)
            {
                this.points++;
            }
            else if (this[newPosX, newPosY] == Chars.stone)
            {
                try
                {
                    char afterNextSymbol = this[afterNewPosX, afterNewPosY];
                    if (afterNextSymbol == Chars.stone || afterNextSymbol == Chars.diamond)
                    {
                        return;
                    }
                    else
                    {
                        this[afterNewPosX, afterNewPosY] = Chars.stone;
                    }
                }
                catch
                {
                    return;
                }
            }

            this[newPosX, newPosY] = Chars.player;
            this[this.posX, this.posY] = ' ';
        }
    }

    public class Chars
    {
        public const char stone = 'o';
        public const char sand = '.';
        public const char player = 'I';
        public const char diamond = 'D';
        public const char space = ' ';
    }
}