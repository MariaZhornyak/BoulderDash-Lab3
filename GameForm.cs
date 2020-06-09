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

        private int width = 9;
        private int height = 9;

        private (PictureBox sand, PictureBox stone, PictureBox diamond)[,] pictureBoxField;
        private char[,] field;
        private int points = 0;
        private int numberOfDiamonds = 0;
        
        public GameForm()
        {
            InitializeComponent();

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
            this.Player.Visible = true;
            this.PointCounter.Visible = true;
            this.pictureBoxField[0, 0].sand.Visible = false;
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

        private void newGameForm_Load(object sender, EventArgs e)
        {
            Player.Location = new Point(0, 0);
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
