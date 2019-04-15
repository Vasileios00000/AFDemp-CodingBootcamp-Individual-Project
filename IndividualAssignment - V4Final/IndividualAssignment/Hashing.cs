using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualAssignment
{
    public class Hashing
    {
        public static double HashingMethod(string name)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"a",7},{"f",7},{"k",19},{"p",19},{"u",7},{"z",2},
                {"b",8},{"g",66},{"l",4},{"q",18},{"v",11},
                {"c",9},{"h",15},{"m",3},{"r",1},{"w",9},
                {"d",10},{"i",60},{"n",1},{"s",4},{"x",6},
                {"e",10},{"j",55},{"o",1},{"t",1},{"y",10},
            };

            string NameLower = name.ToLower();


            string Hash = "";

            string a = NameLower[0].ToString();

            for (int i = 0; i < NameLower.Count(); i++)
            {
                if (dict.ContainsKey(NameLower[i].ToString()))
                {
                    Hash = Hash + dict[NameLower[i].ToString()];
                }
                if (!dict.ContainsKey(NameLower[i].ToString()))
                {
                    Hash = Hash + NameLower[i].ToString();
                }

            }

            double HashedNumber = Convert.ToDouble(Hash);

            double Final = Math.Round(Math.Round(HashedNumber * 1.25) * 0.687);

            return Final;
        }


    }
}
