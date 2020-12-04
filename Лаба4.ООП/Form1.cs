﻿using System;
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
        Bitmap bmp;
        Graphics graph;
        Color basic_color = Color.YellowGreen;
        Color selected_color = Color.Red;
        int kolvo_elem = 0;
        int index = 0;
        static int sizeStorage = 1;
        int index_sozdania;
        Storage storage = new Storage(sizeStorage);
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(picture.Width, picture.Height);
            graph = Graphics.FromImage(bmp);
        }
        public class CCircle
        {
            public bool painted = true;
            public int R=80;
            public Color color;
            public int x, y;
            public bool narisovana = true;
            public CCircle(int x,int y,Color color)
            {
                this.x = x-R;
                this.y = y-R;
                this.color = color;
            }
            ~CCircle() { 
            }
        }
        private int Check_In(ref Storage storage,int size,int x,int y)
        {
            if (storage.kolvo_zanyatix(size)!=0) 
            {
                for (int i = 0; i < size; i++)
                {
                    if (!storage.proverka(i))
                    {
                        if ((x - storage.objects[i].x) * (x - storage.objects[i].x) + (y - storage.objects[i].y) * (y - storage.objects[i].y) <= storage.objects[i].R * storage.objects[i].R)
                            return i;
                    }
                }

            }
            return -1;
        }
        private void MyPaint(int kolvo_elem,ref Storage storage)
        {
            if(storage.objects[kolvo_elem] != null)
            {
                Pen pen = new Pen(storage.objects[kolvo_elem].color, 4);
                graph.DrawEllipse(pen, storage.objects[kolvo_elem].x, storage.objects[kolvo_elem].y, storage.objects[kolvo_elem].R * 2, storage.objects[kolvo_elem].R * 2);
                picture.Image = bmp;
            }
        } 
        private void Remove_Selection(ref Storage storage)
        {
            for (int i = 0; i < sizeStorage; ++i)
                if (!storage.proverka(i))
                {
                    storage.objects[i].color = basic_color;
                    if (storage.objects[i].narisovana == true)
                        MyPaint(i, ref storage);
                }
        }
        private void picture_MouseClick(object sender, MouseEventArgs e)
        {
            CCircle krug = new CCircle(e.X, e.Y,basic_color);
            if (Check_In(ref storage, sizeStorage, krug.x, krug.y) != -1)
            {
                if (Control.ModifierKeys==Keys.Control)
                {
                    int x = e.X - krug.R;
                    int y = e.Y - krug.R;
                    for(int i = 0;i<sizeStorage;i++)
                        if (!storage.proverka(i))
                        {
                            if ((x - storage.objects[i].x) * (x - storage.objects[i].x) + (y - storage.objects[i].y) * (y - storage.objects[i].y) <= storage.objects[i].R * storage.objects[i].R)
                            {
                                storage.objects[i].color = selected_color;
                                MyPaint(i,ref storage);

                            }
                        }
                }
                else
                {
                    int x = e.X - krug.R;
                    int y = e.Y - krug.R;
                    Remove_Selection(ref storage);
                    for(int i =0;i<sizeStorage;i++)
                        if (!storage.proverka(i))
                        {
                            if ((x - storage.objects[i].x) * (x - storage.objects[i].x) + (y - storage.objects[i].y) * (y - storage.objects[i].y) <= storage.objects[i].R * storage.objects[i].R)
                            {
                                storage.objects[i].color = selected_color;
                                MyPaint(i,ref storage);
                                break;
                            }
                        }
                    storage.objects[Check_In(ref storage, sizeStorage, krug.x, krug.y)].color=selected_color;
                    MyPaint(Check_In(ref storage, sizeStorage, krug.x, krug.y), ref storage);
                }
                return;
            }
            storage.add_object(ref sizeStorage, ref krug, kolvo_elem, ref index_sozdania);
            Remove_Selection(ref storage);
            storage.objects[index_sozdania].color = selected_color;
            MyPaint(index_sozdania, ref storage) ;
            kolvo_elem++;
            

        }
        public class Storage
        {
           
            public CCircle[] objects;
            public Storage(int size)
            {
                objects = new CCircle[size];
                for (int i = 0; i < size; i++)
                    objects[i] = null;
            }
            public void add_object(ref int size, ref CCircle new_object,int ind,ref int index_sozdania)
            {
                Storage storage1 = new Storage(size + 1);
                for (int i = 0; i < size; i++)
                    storage1.objects[i] = objects[i];
                size = size + 1;
                    videlenie(size);
                for (int i = 0; i < size; i++)
                    objects[i] = storage1.objects[i];
                objects[ind] = new_object;
                index_sozdania = ind;
            }
            public void videlenie(int size)
            {
                objects = new CCircle[size];
                for (int i = 0; i < size; i++)
                    objects[i] = null;
            }
           public int kolvo_zanyatix(int size)
            {
                int count_zanyatih = 0;
                for(int i=0;i < size; i++)
                {
                    if (!proverka(i))
                        count_zanyatih++;
                }
                return count_zanyatih;
            }
            public bool proverka(int kolvo_elem)
            {
                if (objects[kolvo_elem] == null)
                    return true;
                else return false;
            }
            public void Delte_obj(ref int kolvo_elem)
            {
                if (objects[kolvo_elem] != null)
                {
                    objects[kolvo_elem] = null;
                    kolvo_elem--;
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(storage.kolvo_zanyatix(sizeStorage)!=0)
        }
    }
}
