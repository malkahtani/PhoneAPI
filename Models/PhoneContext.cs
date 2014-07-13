using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhoneAPI.Models
{
    public class PhoneContext : DbContext
    {

        public PhoneContext()
            : base("name=PhoneDBConnectionString") 
        {
                     

            
        }

            public DbSet<Rank> Ranks { get; set; }
            public DbSet<Dep> Deps { get; set; }
            public DbSet<Emp> Emps { get; set; }
       
    }
}