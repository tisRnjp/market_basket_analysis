using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Major_Project.Models
{
    public class myDbContext:DbContext
    {
        public DbSet<User> users { get; set; }
    }
}