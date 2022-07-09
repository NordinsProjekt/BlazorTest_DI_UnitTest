using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_MSSQL_EF.Models
{
    public class PeopleContext : DbContext
    {
        public PeopleContext() : base() { }
        public DbSet<People> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-MBPUR5V\SQLEXPRESS;Initial Catalog=MyPeople;Integrated Security=SSPI;");
        }
    }
}
