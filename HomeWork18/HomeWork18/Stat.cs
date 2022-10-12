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
    public partial class Stat : Form
    {
        public int[] statInfo = new int[9];
        public Stat()
        {
            InitializeComponent();
        }
        public void CountStat()
        {
            int totalGames = 0, easyGames = 0, hardGames = 0, peopleGames = 0;
            for (int i = 0; i < statInfo.Length; i++)
            {
                totalGames +=statInfo[i];
            }
            for (int i = 0; i < 3; i++)
            {
                easyGames += statInfo[i];
            }
            for (int i = 3; i < 6; i ++)
            {
                hardGames +=statInfo[i];    
            }
            for (int i = 6; i < 9; i ++)
            {
                peopleGames+=statInfo[i];
            }
            label26.Text = totalGames.ToString();
            label17.Text = easyGames.ToString();
            label16.Text = statInfo[0].ToString();
            label15.Text = statInfo[1].ToString();
            label14.Text = statInfo[2].ToString();
            label21.Text = hardGames.ToString();
            label20.Text = statInfo[3].ToString();
            label19.Text = statInfo[4].ToString();
            label18.Text = statInfo[5].ToString();
            label25.Text = peopleGames.ToString();
            label24.Text = statInfo[6].ToString();  
            label23.Text = statInfo[7].ToString();
            label22.Text = statInfo[8].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
