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
            var location = points[0];
            var maxX = points.Select(x => x.X).Max();
            var maxY = points.Select(x => x.Y).Max();
            return new Rectangle(location, new Size(maxX - location.X, maxY - location.Y));
        }
    }
}
