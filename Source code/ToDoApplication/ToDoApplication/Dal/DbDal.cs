using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ToDoApplication.Models;

namespace ToDoApplication.Dal
{
    public class DbDal : DbContext
    {
        public DbDal():base("MyConnectionString")
        {

        }
        public DbSet<Task> tasks { get; set; }
        public DbSet<User> users { get; set; }
    }
}