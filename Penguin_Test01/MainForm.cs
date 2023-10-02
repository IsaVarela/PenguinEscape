using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Penguin_Test01.Classes.Entities; 

namespace Penguin_Test01
{
    public partial class MainForm : Form
    {
        private bool DisplayPath = false; 
        public MainForm()
        {
            InitializeComponent();
            GameManager.StartGame();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            const int Size = 40; 
            // this helps resize the map every level 
            int width = Map.maxColumns * Map.TileSize + Size;
            int height = Map.maxRows * Map.TileSize; 

            this.pictureBox1.Width = width;
            this.pictureBox1.Height = height;
            this.pictureBox1.Location = new Point(20, 50);
            this.ClientSize = new Size(width, height + 60);

            foreach (AbstractEntity obj in Map.arrayEntities)
            {
                obj.Draw(e.Graphics); 
            }

            foreach (Orca obj in GameManager.orcaList)
            {
                obj.Draw(e.Graphics); 
            }

            // Draw path 
            if (DisplayPath)
            {
                GameManager.player.DrawPath(e.Graphics);
            }

            GameManager.player.Draw(e.Graphics); 
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.W:
                    GameManager.player.CurrentDirection = Direction.UP;
                    GameManager.player.Move();
                    break;
                case Keys.Right:
                case Keys.D:
                    GameManager.player.CurrentDirection = Direction.RIGHT;
                    GameManager.player.Move();
                    break;
                case Keys.Left:
                case Keys.A:
                    GameManager.player.CurrentDirection = Direction.LEFT;
                    GameManager.player.Move();
                    break;
                case Keys.Down:
                case Keys.S:
                    GameManager.player.CurrentDirection = Direction.DOWN;
                    GameManager.player.Move();
                    break;
                case Keys.Space:
                    GameManager.player.CanUseHammer = true;
                    break; 
            }
            this.Refresh(); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.labelLives.Text = GameManager.player.Lives.ToString();
            this.labelHammer.Text = GameManager.player.Hammer.ToString();
            this.labelEnergy.Text = GameManager.player.Energy.ToString();
            this.Refresh(); 
        }

        private void pictureBoxHint_Click(object sender, EventArgs e)
        {
            DisplayPath = !DisplayPath; 
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
