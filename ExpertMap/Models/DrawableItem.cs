using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ExpertMap.Models
{
    public abstract class DrawableItem
    {
        public DrawableItem(Rectangle rect)
        {
            this.Rectangle = rect;
        }

        public abstract void Draw(Graphics graphics);
        public abstract void RecalcCoordinates(PointF delta);
        
        public Rectangle Rectangle { get; set; }
        public float Opacity { get; set; }
    }
}
