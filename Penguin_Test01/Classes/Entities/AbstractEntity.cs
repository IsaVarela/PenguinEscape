using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; 

namespace Penguin_Test01.Classes.Entities
{
    public abstract class AbstractEntity
    {
        private int row;
        private int column;

        public AbstractEntity(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public int Row { get => row; set => row = value; }
        public int Column { get => column; set => column = value; }

        public abstract void Draw(Graphics g);

        public void DrawBackground(Graphics g)
        {
            Rectangle myRectangle = this.GetRectangle();
            Brush myBrush = new SolidBrush(Map.backColor);
            g.FillRectangle(myBrush, myRectangle);

            myBrush.Dispose(); 
        }

        public Rectangle GetRectangle()
        {
            int PointX = this.column * Map.TileSize;
            int PointY = this.row * Map.TileSize;
            int width = Map.TileSize;
            int height = Map.TileSize;

            return new Rectangle(PointX, PointY, width, height); 
        }
    }
}
