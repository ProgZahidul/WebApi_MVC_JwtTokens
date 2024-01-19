using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExamApiApp.Models
{
    public class appDb:DbContext

    {
        public DbSet<Designation> designations { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Experience> experiences { get; set; }
        public DbSet<UserInfo> users { get; set; }
        public appDb():base("DefaultConn")
        {
            
        }
    }
}