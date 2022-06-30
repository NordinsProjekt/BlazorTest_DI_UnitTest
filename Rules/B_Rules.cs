using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rules.BuisnessModels;

namespace Rules
{
    public class B_Rules
    {
        public B_Rules()
        {

        }
        public string GeneratePerson()
        {
            RandomPerson randomPerson = new RandomPerson();
            if (randomPerson.Valid)
                return randomPerson.Firstname + " " + randomPerson.Lastname;
            else
                throw new MissingFieldException("Kunde inte generera ett namn");
        }
    }
}
