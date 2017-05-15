using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowLayoutTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 3; i++)
            {
                panel1.Controls.Add(new MyButton
                {
                    Text = "Button " + i,
                    Width = i * 60,
                    Height = i * 30,
                    HorizontalAlignment = (i == 3 ? Modules.HorizontalAlignment.Left
                        : i == 2 ? Modules.HorizontalAlignment.Center
                        : Modules.HorizontalAlignment.Right)
                });
                panel2.Controls.Add(new MyButton
                {
                    Text = "Button " + i,
                    Width = i * 60,
                    Height = i * 30,
                    VerticalAlignment = (i == 3 ? Modules.VerticalAlignment.Top
                        : i == 2 ? Modules.VerticalAlignment.Middle
                        : Modules.VerticalAlignment.Bottom)
                });
            }
            new Modules.FlowLayout
            {
                Direction = Modules.FlowDirection.Down
            }.Layout(panel1.Controls.Cast<MyButton>());
            new Modules.FlowLayout
            {
                Direction = Modules.FlowDirection.Right
            }.Layout(panel2.Controls.Cast<MyButton>());
        }
    }

    class MyButton : Button, Modules.FlowLayoutItem
    {

        public Modules.HorizontalAlignment HorizontalAlignment
        {
            get;
            set;
        }

        public Modules.VerticalAlignment VerticalAlignment
        {
            get;
            set;
        }
    }
}
