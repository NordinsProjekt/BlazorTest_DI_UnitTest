using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rules.BuisnessModels
{
    internal class RandomPerson
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        private List<string> _firstname = new List<string>() 
        { "Jake","David","Emma","Julia","Peter"};
        private List<string> _lastname = new List<string>()
        { "Eriksson","Johansson","Karlsson","Nilsson"};

        public bool Valid = false;
        Random random = new Random();
        public RandomPerson()
        {
            Firstname = GetRandomFirstname();
            Lastname = GetRandomLastname();
            Valid = true;
        }

        private string GetRandomFirstname()
        {
            return _firstname[random.Next(_firstname.Count)].ToString();
        }

        private string GetRandomLastname()
        {
            return _lastname[random.Next(_lastname.Count)].ToString();
        }
    }
}
