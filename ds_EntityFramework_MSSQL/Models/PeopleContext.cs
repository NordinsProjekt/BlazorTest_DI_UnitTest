using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_EntityFramework_MSSQL.Models
{
    public class PeopleContext : DbContext
    {
        public DbSet<People> People { get; set; }
    }
}
