using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork14
{
    internal class Abonent
    {
        public string name;
        public string number;


        public Abonent(string _name, string _number)
        {
            this.name = _name;
            this.number = _number;
        }

        public static string FindName (Abonent[] abon, string findName)
        {
            int low, high, mid;
            low = 0;
            high = abon.Length-1;
            string _name;

            while (low <= high)
            {
                mid = (low+high)/2;
                _name = abon[mid].name;
                if (String.Compare(findName, _name) == 0)
                {
                    return abon[mid].number;
                }
                if (String.Compare(findName, _name) > 0)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid -1;
                }
            }
            return "Такого абонента не існує в нашому довіднику";
           
        }
    }
}
