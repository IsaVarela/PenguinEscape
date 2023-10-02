using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; 

namespace Penguin_Test01.Classes.Entities
{
    public class EmptyTile : AbstractEntity
    {
        public EmptyTile(int row, int column) : base(row, column)
        {
        }

        public override void Draw(Graphics g)
        {
            Rectangle myRectangle = base.GetRectangle();
            Brush myBrush = new SolidBrush(Color.LightBlue);
            g.FillRectangle(myBrush, myRectangle);

            myBrush.Dispose(); 
        }
    }
}
