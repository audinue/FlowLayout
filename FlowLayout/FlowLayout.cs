using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Modules
{
    public class FlowLayout
    {
        public FlowDirection Direction
        {
            get;
            set;
        }

        public void Layout(IEnumerable<FlowLayoutItem> items)
        {
            Size max = new Size();
            foreach (var item in items)
            {
                if (!item.Visible)
                {
                    continue;
                }
                max.Width = Math.Max(max.Width, item.Bounds.Width + item.Margin.Horizontal);
                max.Height = Math.Max(max.Height, item.Bounds.Height + item.Margin.Vertical);
            }
            switch (Direction)
            {
                case FlowDirection.Down:
                    int y = 0;
                    foreach (var item in items)
                    {
                        if (!item.Visible)
                        {
                            continue;
                        }
                        Rectangle b = item.Bounds;
                        Padding m = item.Margin;
                        switch (item.HorizontalAlignment)
                        {
                            case HorizontalAlignment.Left:
                                b.X = m.Left;
                                break;
                            case HorizontalAlignment.Center:
                                b.X = max.Width / 2 - (b.Width + m.Horizontal) / 2;
                                break;
                            case HorizontalAlignment.Right:
                                b.X = max.Width - b.Width - m.Right;
                                break;
                            default:
                                break;
                        }
                        b.Y = m.Top + y;
                        item.Bounds = b;
                        y += b.Height + m.Vertical;
                    }
                    break;
                case FlowDirection.Right:
                    int x = 0;
                    foreach (var item in items)
                    {
                        if (!item.Visible)
                        {
                            continue;
                        }
                        Rectangle b = item.Bounds;
                        Padding m = item.Margin;
                        b.X = m.Left + x;
                        switch (item.VerticalAlignment)
                        {
                            case VerticalAlignment.Top:
                                b.Y = m.Top;
                                break;
                            case VerticalAlignment.Middle:
                                b.Y = max.Height / 2 - (b.Height + m.Vertical) / 2;
                                break;
                            case VerticalAlignment.Bottom:
                                b.Y = max.Height - b.Height - m.Bottom;
                                break;
                            default:
                                throw new NotImplementedException();
                        }
                        item.Bounds = b;
                        x += b.Width + m.Horizontal;
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
