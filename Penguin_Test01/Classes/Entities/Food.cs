using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; 

namespace Penguin_Test01.Classes.Entities
{
    public class Food : AbstractEntity
    {
        private static string[] imageFiles = { "Crab.png", "Lobster.png", "Fish.png" };
        private string myFileName;
        private int bonusEnergy; 
        public Food(int row, int column) : base(row, column)
        {
            int index = RNG.GetInstance().Next(0, imageFiles.Length);
            this.myFileName = imageFiles[index];
            this.BonusEnergy = RNG.GetInstance().Next(10, 25); 
        }

        public int BonusEnergy { get => bonusEnergy; set => bonusEnergy = value; }

        public override void Draw(Graphics g)
        {
            base.DrawBackground(g);
            Rectangle myRectangle = base.GetRectangle();

            using (Image myImage = Image.FromFile(Map.Path + this.myFileName))
            {
                g.DrawImage(myImage, myRectangle); 
            }
        }
    }
}
