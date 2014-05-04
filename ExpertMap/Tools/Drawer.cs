using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using ExpertMap.Models;

namespace ExpertMap.Tools
{
    public class Drawer
    {
        public Drawer()
        {

        }

        public List<IDrawable> DrawableItems { get; set; }

        public void DrawItems(Graphics graphics)
        {
            DrawableItems.ForEach(x => x.Draw(graphics));
        }
    }
}
