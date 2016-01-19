using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Test1webb.Models
{
    public class Hello
    {
        public int ID { get; set; }
        public string hej { get; set; }
    }
        public class HelloDBcontext : DbContext
    { 
        public DbSet<Hello> Hellos { get; set; }
    }
}