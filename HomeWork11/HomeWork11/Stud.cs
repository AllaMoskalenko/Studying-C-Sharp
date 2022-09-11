using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork11
{
    internal class Stud
    {
        public string[] name;
        public string group;
        public int[] ses;

        public Stud(string[] name_, string group_, int[] ses_)
        {
            this.name = new string[3];
            for (int i = 0; i < 3; i++)
            {
                name[i] = name_[i];
            }

            this.group = group_;
            
            this.ses = new int[4];
            for (int i = 0; i < 4; i++)
            {
                ses[i] = ses_[i];
            }             
        }

        public Stud()
        {

        }

        public double Avrg()
        {
            return (double)(ses[0] + ses[1] + ses[2] + ses[3])/4;
        }
    }

}
