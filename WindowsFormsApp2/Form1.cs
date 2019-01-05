using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            Symulacja sym = new Symulacja();
            //richTextBox1.Text += sym.symuluj() +"\n";
            richTextBox1.Text += sym.symuluj() + "\n";
            rysuj(sym);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //836x310
        private void rysuj(Symulacja symul)
        {
            Bitmap bitmap = new Bitmap(@"..\..\uklad.bmp");
            Graphics graph = Graphics.FromImage(bitmap);
            PointF[] Prędkość = symul.Punkty_Prędkości.ToArray();
            PointF[] Bufor = symul.Punkty_Bufora.ToArray();
            //PointF[] jakość = symul.Punkty_Jakości.ToArray();
            obrazek.Image = bitmap;
            for (int i=0; i<Prędkość.Length; i++)
            {
                //50 to 283
                Prędkość[i].Y = 283 - (Prędkość[i].Y*233);
                Prędkość[i].X = 16 + (Prędkość[i].X * (764/(float)symul.Czas));
            }
            for (int i=0; i<Bufor.Length; i++)
            {
                Bufor[i].X = 16 + (Bufor[i].X * (764/(float)(symul.Czas)));
                Bufor[i].Y = 283 - ((Bufor[i].Y/((float)symul.BUFOR_MAX)) * 233);
            }
            //for (int i = 0; i < jakość.Length; i++)
            //{
            //    jakość[i].X = 16 + (jakość[i].X * (764 / (float)(symul.Czas)));
            //    jakość[i].Y = 283 - ((jakość[i].Y / 4) * 233);
            //}
            graph.DrawLines(new Pen(Color.Red), Prędkość);
            graph.DrawLines(new Pen(Color.Green), Bufor);
            //graph.DrawLines(new Pen(Color.Blue), jakość);
            graph.DrawString(Convert.ToString(symul.BUFOR_MAX)+"s", new Font("Segoe UI Light", 10), Brushes.Black, 57, 6.2F);
            graph.DrawString(Convert.ToString((int)symul.Czas) + "s", new Font("Segoe UI Light", 10), Brushes.Black, 730, 288);
        }
    }
}
