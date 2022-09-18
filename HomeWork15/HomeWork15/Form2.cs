using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork15
{
    public partial class Form2 : Form
    {
        List<IEngine> tengine = new List<IEngine>();
        List<IFuelReservoir> treservoir = new List<IFuelReservoir>();
        public Rocket trocket;
        IBody tbody;
        int countstages = 0;
        public Form2()
        {
            InitializeComponent();
            button4.Enabled = false;
            button3.Enabled = false;
                        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            treservoir.Clear();
            tengine.Clear();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            
            string tEngine, tReservoir;
            tEngine = comboBox2.Text;
            tReservoir = comboBox3.Text;
               
            listBox1.Items.Add(tEngine + " " +tReservoir);

            if (comboBox2.SelectedIndex == 0) tengine.Add(new ReactiveEngine());
            if (comboBox2.SelectedIndex == 1) tengine.Add(new DetonationEngine());
            if (comboBox2.SelectedIndex == 2) tengine.Add(new PlasmaEngine());

            if (comboBox3.SelectedIndex == 0) treservoir.Add(new SmallReservoir());
            if (comboBox3.SelectedIndex == 1) treservoir.Add(new MiddleReservoir());
            if (comboBox3.SelectedIndex == 2) treservoir.Add(new BigReservoir());

            countstages++;

            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            button4.Enabled = false;
            if (textBox1.Text != "" && comboBox1.SelectedIndex >= 0 && listBox1.Items.Count > 0)
            {
                button3.Enabled = true;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex>=0&& comboBox3.SelectedIndex >= 0)
            {
                button4.Enabled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && comboBox1.SelectedIndex >=0 && listBox1.Items.Count >0)
            {
                button3.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            treservoir.Clear();
            tengine.Clear();
            countstages = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0 ) tbody = new SmallBody();
            if (comboBox1.SelectedIndex == 1 ) tbody = new MiddleBody();
            if (comboBox1.SelectedIndex == 2 ) tbody = new BigBody();
            trocket = new Rocket(textBox1.Text, countstages, tengine.ToArray(), tbody, treservoir.ToArray());
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button4.Enabled = false;
            button3.Enabled = false;
            if (trocket == null)                           //esli trocket ne pustaya, znachit eto redaktirovanie 
            {
                
            }
            else
            {
                textBox1.Text = trocket.Name;
                if (trocket.body.ToString() == "SmallBody") comboBox1.SelectedIndex = 0;
                if (trocket.body.ToString() == "MiddleBody") comboBox1.SelectedIndex = 1;
                if (trocket.body.ToString() == "BigBody") comboBox1.SelectedIndex = 2;

                for (int i = 0; i < trocket.NumOfStages; i++)
                {
                    listBox1.Items.Add(trocket.engine[i].ToString() + " ");
                }
                for (int i = 0; i < trocket.NumOfStages; i++)
                {
                    listBox1.Items.Add(trocket.fuelReservoir[i].ToString() + " ");
                }
                countstages = trocket.NumOfStages;
                for (int i = 0; i < countstages; i++)
                {
                    tengine.Add(trocket.engine[i]);
                    treservoir.Add(trocket.fuelReservoir[i]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) tbody = new SmallBody();
            if (comboBox1.SelectedIndex == 1) tbody = new MiddleBody();
            if (comboBox1.SelectedIndex == 2) tbody = new BigBody();
            Rocket canFlyRocket = new Rocket(textBox1.Text, countstages, tengine.ToArray(), tbody, treservoir.ToArray());

            label6.Text = canFlyRocket.CanFly();

        }
    }
}
