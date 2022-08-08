using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rules.BuisnessModels
{
    internal class RandomPerson : PersonBase
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        private static readonly List<string> _firstname = new() 
        { "Jake","David","Emma","Julia","Peter","Gabriel","Paul"};
        private static readonly List<string> _lastname = new()
        { "Eriksson","Johansson","Karlsson","Nilsson","Johnsson","Larsson"};

        Random random = new();
        public RandomPerson()
        {
            Firstname = GetRandomFirstname();
            Lastname = GetRandomLastname();
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
