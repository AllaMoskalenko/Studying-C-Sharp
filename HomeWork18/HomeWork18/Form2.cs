using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork18
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
        }
        public string message { get; set; }
        public int again { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            again = 1;
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = message;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            again = 2;
            this.Close();
        }
    }
}
