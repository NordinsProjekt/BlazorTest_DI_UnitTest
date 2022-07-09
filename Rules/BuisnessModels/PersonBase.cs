using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rules.BuisnessModels
{
    internal class PersonBase
    {
        public bool IsValid()
        {
            PropertyInfo[] props = this.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if (prop.GetValue(this, null) == null)
                    return false;
                if (prop.PropertyType == typeof(Int32))
                    if ((int)prop.GetValue(this, null) == 0)
                        return false;
                if (prop.PropertyType == typeof(Double))
                    if ((double)prop.GetValue(this, null) == 0)
                        return false;
            }
            return true;
        }
    }
}
