using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Modules
{
    public interface FlowLayoutItem
    {
        Rectangle Bounds
        {
            get;
            set;
        }

        Padding Margin
        {
            get;
            set;
        }

        HorizontalAlignment HorizontalAlignment
        {
            get;
            set;
        }

        VerticalAlignment VerticalAlignment
        {
            get;
            set;
        }

        bool Visible
        {
            get;
            set;
        }
    }
}
