using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penguin_Test01.Classes.Entities
{
    public class Wall : AbstractEntity 
    {
        private static string[] imageFiles = { "Wall.png" };
        private string myFileName;

        public Wall(int row, int column) : base(row, column)
        {
            int index = RNG.GetInstance().Next(0, imageFiles.Length);
            this.myFileName = imageFiles[index];
        }

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
