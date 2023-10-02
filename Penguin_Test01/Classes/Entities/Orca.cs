using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penguin_Test01.Classes.Entities
{
    public class Orca : AbstractEntity
    {
        private static string[] imageFiles = { "Orca.png", "Shark.png" };
        private string myFileName;

        private int apower;

        public Orca(int row, int column) : base(row, column)
        {
            int index = RNG.GetInstance().Next(0, imageFiles.Length);
            this.myFileName = imageFiles[index];
            this.apower = RNG.GetInstance().Next(15, 30); 
        }

        public int Apower { get => apower; set => apower = value; }

        public override void Draw(Graphics g)
        {
            base.DrawBackground(g);

            Rectangle myRectangle = base.GetRectangle();

            using (Image myImage = Image.FromFile(Map.Path + myFileName))
            {
                g.DrawImage(myImage, myRectangle); 
            }
        }
    }
}
