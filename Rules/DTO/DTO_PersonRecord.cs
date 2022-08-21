using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rules.DTO
{
    public record DTO_PersonRecord(string Firstname, string Lastname);
    public record DTO_PersonRecordFull
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DTO_PersonRecordFull(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string GetFullname()
        {
            return Firstname +" " + Lastname;
        }
        
    }

}
