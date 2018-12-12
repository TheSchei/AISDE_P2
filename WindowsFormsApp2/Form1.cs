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
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
