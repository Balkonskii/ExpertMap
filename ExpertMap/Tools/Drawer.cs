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

        public bool TryGetContainer(Point location, out DrawableItem container)
        {
            container = null;

            foreach (DrawableItem item in DrawableItems)
            {
                if (item.Rectangle.Contains(location))
                {
                    container = item;
                    return true;
                }
            }
            return false;
        }

        public bool TryGetRegion(Point location, out ExpertMap.Models.Region region)
        {
            region = null;

            foreach (DrawableItem item in DrawableItems.Where(x => x is ExpertMap.Models.Region))
            {
                if (item.Rectangle.Contains(location))
                {
                    region = (item as ExpertMap.Models.Region);
                    return true;
                }
            }
            return false;
        }

        public static Point[] GetRectanglePoints(Rectangle rect)
        {
            return new Point[] 
            { 
                rect.Location, 
                new Point(rect.Right, rect.Y),
                new Point(rect.Right,rect.Bottom),
                new Point(rect.X,rect.Bottom)
            };
        }

        public Rectangle GetDrawableRectangle(Point start, Point current)
        {
            int width = 0;
            int height = 0;
            int posX = 0;
            int posY = 0;

            if (current.X > start.X && current.Y > start.Y)
            {
                width = Math.Abs(current.X - start.X);
                height = Math.Abs(current.Y - start.Y);

                posX = start.X;
                posY = start.Y;
            }
            else if (current.X < start.X && current.Y < start.Y)
            {
                width = Math.Abs(start.X - current.X);
                height = Math.Abs(start.Y - current.Y);

                posX = current.X;
                posY = current.Y;
            }
            else if (current.X < start.X && current.Y > start.Y)
            {
                width = Math.Abs(start.X - current.X);
                height = Math.Abs(start.Y - current.Y);

                posX = current.X;
                posY = start.Y;
            }
            else if (current.X > start.X && current.Y < start.Y)
            {
                width = Math.Abs(start.X - current.X);
                height = Math.Abs(start.Y - current.Y);

                posX = start.X;
                posY = current.Y;
            }

            return new Rectangle(posX, posY, width, height);
        }

        public static PointF GetDelta(Size current, Size defaultSize)
        {
            return new PointF()
            {
                X = (float)current.Width / (float)defaultSize.Width,
                Y = (float)current.Height / (float)defaultSize.Height,
            };
        }

        public static Point ModifyToFormPoint(Point point, PointF delta)
        {
            Point result = new Point();
            result.X = (int)((float)point.X * delta.X);
            result.Y = (int)((float)point.Y * delta.Y);
            return result;
        }

        public static Point ModifyToBasePoint(Point point, PointF delta)
        {
            Point result = new Point();
            result.X = (int)((float)point.X / delta.X);
            result.Y = (int)((float)point.Y / delta.Y);
            return result;
        }

        public static Rectangle GetRectangleFromPoints(Point[] points)
        {
            if (points.Length == 0) return new Rectangle();
            var location = points[0];
            var maxX = points.Select(x => x.X).Max();
            var maxY = points.Select(x => x.Y).Max();
            return new Rectangle(location, new Size(maxX - location.X, maxY - location.Y));
        }

        public void SelectRegionFromPoint(Point location)
        {
            ExpertMap.Models.Region item = null;

            if (this.TryGetRegion(location, out item))
            {
                ResetSelected();
                //this.DrawableItems.Where(x => x is Marker && (x as Marker).Parent == item).
                //    ToList().ForEach(x => x.IsSelected = true);

                //item.IsSelected = true;
                SelectRegionsById(item.RegionId);
            }
            else
            {
                ResetSelected();
                ResetHighlighted();
            }
        }

        public void SelectRegionsById(int id)
        {
            this.DrawableItems.Where(x => x is ExpertMap.Models.Region && (x as ExpertMap.Models.Region).RegionId == id).
                ToList().ForEach(x => SelectRegion((x as ExpertMap.Models.Region)));
        }

        public void SelectRegion(ExpertMap.Models.Region region)
        {
            region.IsSelected = true;
            this.DrawableItems.Where(x => x is Marker && (x as Marker).Parent == region).
                              ToList().ForEach(x => x.IsSelected = true);
        }

        public void HighlightRegionsById(int id)
        {
            this.DrawableItems.Where(x => x is ExpertMap.Models.Region && (x as ExpertMap.Models.Region).RegionId == id).
                ToList().ForEach(x => HighlightRegion((x as ExpertMap.Models.Region)));
        }

        public void HighlightRegion(ExpertMap.Models.Region region)
        {
            region.HighlightInNextStep = true;
            this.DrawableItems.Where(x => x is Marker && (x as Marker).Parent == region).
                              ToList().ForEach(x => x.HighlightInNextStep = true);
        }

        public void HighlightFromPoint(Point location)
        {
            ExpertMap.Models.Region item = null;
            if (this.TryGetRegion(location, out item))
            {
                ResetHighlighted();
                HighlightRegionsById(item.RegionId); 
            }
        }

        public void ResetSelected()
        {
            this.DrawableItems.ForEach(x => x.IsSelected = false);
        }

        public void ResetHighlighted()
        {
            this.DrawableItems.ForEach(x => x.HighlightInNextStep = false);
        }

        public void HighlightSelectedItems()
        {
            ResetHighlighted();
            this.DrawableItems.Where(x => x.IsSelected).ToList().ForEach(x => x.HighlightInNextStep = true);
        }

        public IEnumerable<Marker> HoveredMarkers(Point location)
        {
            return DrawableItems.Where(x => x.Rectangle.Contains(location) && x is Marker).Cast<Marker>();
        }

        public IEnumerable<Models.Region> HoveredRegions(Point location)
        {
            return DrawableItems.Where(x => x.Rectangle.Contains(location) && x is Models.Region).Cast<Models.Region>();
        }        
    }
}
