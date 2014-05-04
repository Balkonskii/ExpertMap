using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ExpertMap.Models
{
   public interface IDrawable
    {
        void Draw(Graphics graphics);
    }
}
