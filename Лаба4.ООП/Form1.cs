using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лаба4.ООП
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class CCircle
        {
            public int R;
            public int x, y;
            public CCircle(int x,int y)
            {
                this.x = x;
                this.y = y;
            }
            ~CCircle() { 
            }
        }

        private void picture_MouseClick(object sender, MouseEventArgs e)
        {
            CCircle krug = new CCircle(e.X, e.Y);

        }
    }
}
