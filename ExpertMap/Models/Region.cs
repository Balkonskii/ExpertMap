using ExpertMap.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ExpertMap.Models
{
   public class Region : DrawableItem
    {
        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public List<Point> Points { get; set; }

        public Region(Rectangle rect, int regionId, string regionName) : base(rect)
        {
            RegionId = regionId;
            RegionName = regionName;
            this.Points = Drawer.GetRectanglePoints(rect).ToList();
        }

        public Region() : base(new Rectangle()) { }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawRectangle(Pens.Black, this.Rectangle);
        }

        public override void RecalcCoordinates(PointF delta)
        {
            var points = new List<Point>();

            foreach (Point point in Points)
            {
                points.Add(Drawer.ModifyToFormPoint(point, delta));
            }

            this.Rectangle = Drawer.GetRectangleFromPoints(points.ToArray());
        }
    }
}
