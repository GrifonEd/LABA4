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
        private void MyPaint(int size,ref Storage storage)
        {
            if(storage.objects[size-1]!= null)
            {
                Pen pen = new Pen(storage.objects[size - 1].color, 4);
                picture.CreateGraphics().DrawEllipse(pen,)
            }
        } 

        private void picture_MouseClick(object sender, MouseEventArgs e)
        {
            CCircle krug = new CCircle(e.X, e.Y);

        }
        class Storage
        {
            public CCircle[] objects;
            public Storage(int size)
            {
                objects = new CCircle[size];
                for (int i = 0; i < size; i++)
                    objects[i] = null;
            }
            public void add_object(int size, CCircle new_object)
            {
                Storage storage1 = new Storage(size + 1);
                for (int i = 0; i < size; i++)
                    storage1.objects[i] = objects[i];
                size = size + 1;
                videlenie(size);
                for (int i = 0; i < size; i++)
                    objects[i] = storage1.objects[i];
                objects[size - 2] = new_object;
            }
            public void videlenie(int size)
            {
                objects = new CCircle[size];
                for (int i = 0; i < size; i++)
                    objects[i] = null;
            }
        }
    }
}
