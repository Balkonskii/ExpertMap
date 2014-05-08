using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ExpertMap.Models
{
    public abstract class DrawableItem
    {
        private Point _drawableLocation = new Point();

        public float Opacity { get; set; }

        public abstract void Draw(Graphics graphics);
        public abstract void RecalcCoordinates(PointF delta);

        /// <summary>
        /// левый верхний угол
        /// </summary>
        public Point DrawableLocation
        {
            get { return _drawableLocation; }
            set
            {
                _drawableLocation = value;

                //if (value.X < 1)
                //    _drawableLocation.X = 1;

                //if (value.Y < 1)
                //    _drawableLocation.Y = 1;
            }
        }
    }
}
