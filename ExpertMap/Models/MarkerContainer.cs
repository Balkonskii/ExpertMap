using ExpertMap.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExpertMap.Models
{
   public class MarkerContainer : DrawableItem, IDisposable 
    {
        private Image _image;
        public Panel Panel { get; set; }
        private Point _startLocation;

       public MarkerContainer(Image image, Point point, Control parent)
       {
           this._image = image;
           Panel = new Panel();
           Panel.Location = point;
           Panel.Size = image.Size;
           _startLocation = point;
           Panel.Location = point;
           DrawableLocation = point;
           Panel.BackColor = Color.FromArgb(100, Color.Red);//Color.Transparent;
           parent.Controls.Add(Panel);
           Panel.Parent = parent;
       }

       public override void Draw(Graphics graphics)
       {
           ColorMatrix matrix = new ColorMatrix();
           matrix.Matrix33 = this.Opacity;
           ImageAttributes attributes = new ImageAttributes();
           attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

           this.Panel.Location = new Point(DrawableLocation.X - _image.Width / 2, DrawableLocation.Y - _image.Height / 2);

           graphics.DrawImage(_image, new Rectangle(Panel.Location.X, Panel.Location.Y, _image.Width, _image.Height), 0, 0,
               _image.Width, _image.Height, GraphicsUnit.Pixel, attributes);
       }

       public override void RecalcCoordinates(PointF delta)
       {
           DrawableLocation = Functions.ModifyToFormPoint(_startLocation, delta);
       }

       public void Dispose()
       {
           Panel.Parent.Controls.Remove(Panel);
           Panel.Parent.Invalidate(new Rectangle(Panel.Location, Panel.Size), false);
           Panel.Dispose();
       }
    }
}
