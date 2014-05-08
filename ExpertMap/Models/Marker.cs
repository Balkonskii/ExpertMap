using ExpertMap.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace ExpertMap.Models
{
    public class Marker : DrawableItem
    {
        public Point DefaultLocation { get; set; }

        private Image _image;

        public Marker(Image image, Point point)
            : base(new Rectangle(point, image.Size))
        {
            _image = image;
            DefaultLocation = point;
        }

        public override void Draw(System.Drawing.Graphics graphics)
        {
            ColorMatrix matrix = new ColorMatrix();
            matrix.Matrix33 = this.Opacity;
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            graphics.DrawImage(_image, Rectangle, 0, 0, _image.Width, _image.Height, GraphicsUnit.Pixel, attributes);

            //this.Panel.Location = new Point(Rectangle.Location.X - _image.Width / 2, Rectangle.Location.Y - _image.Height / 2);

            //graphics.DrawImage(_image, new Rectangle(Panel.Location.X, Panel.Location.Y, _image.Width, _image.Height), 0, 0,
            //    _image.Width, _image.Height, GraphicsUnit.Pixel, attributes);
        }

        public override void RecalcCoordinates(System.Drawing.PointF delta)
        {
            Rectangle = new Rectangle(Functions.ModifyToFormPoint(DefaultLocation, delta), Rectangle.Size);            
        }
    }
}
