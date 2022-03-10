using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace StroyMat
{
    public partial class Material
    {
        public string image
        {
            get
            {
                if (Image != null)
                {
                    return Image;
                }
                else
                {
                    return "Img/picture.png";
                }
            }
        }

        public SolidColorBrush MinColor
        {
            get
            {
                SolidColorBrush br = new SolidColorBrush(System.Windows.Media.Color.FromRgb(241, 146, 146));
                SolidColorBrush br2 = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 186, 1));
                if (MinCount > CountInStock)
                {
                    return br;
                }
                else if(MinCount * 3 <= CountInStock)
                {
                    return br2;
                }
                else
                {
                    return Brushes.White;
                }
            }
        }
    }
}
