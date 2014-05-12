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
            this.HighlightInNextStep = false;
        }

        private bool _highlightInNextStep = false;

        public abstract void Draw(Graphics graphics);
        public abstract void RecalcCoordinates(PointF delta);

        public bool IsSelected { get; set; }

        public bool HighlightInNextStep
        {
            get
            {
                return _highlightInNextStep;
            }
            set
            {
                _highlightInNextStep = value;
                ChangeHighlight(value);
            }
        }

        public Rectangle Rectangle { get; set; }
        public float Opacity { get; set; }

        private void ChangeHighlight(bool needToHighlight)
        {
            if (needToHighlight)
                Opacity = ExpertMap.Tools.ExpertMapOptions.CurrentOptions.SelectedDrawableItemOpacity;
            else
                Opacity = ExpertMap.Tools.ExpertMapOptions.CurrentOptions.DrawableItemOpacity;
        }
    }
}
