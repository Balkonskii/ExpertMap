using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ExpertMap.Tools
{
    public static class Functions
    {
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
    }
}
