using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using ExpertMap.Models;
using System.Drawing.Imaging;

namespace ExpertMap.Tools
{
    public class Drawer
    {
        public Drawer()
        {
            DrawableItems = new List<DrawableItem>();
        }

        public List<DrawableItem> DrawableItems { get; set; }

        public void DrawItems(Graphics graphics)
        {
            DrawableItems.ForEach(x => x.Draw(graphics));
        }

        public void RecalcCoordinates(PointF delta)
        {
            DrawableItems.ForEach(x => x.RecalcCoordinates(delta));
        }

        public void DrawItem(Graphics graphics,DrawableItem item)
        {
            item.Draw(graphics);
        }
    }
}
