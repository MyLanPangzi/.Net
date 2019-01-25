using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blank.Models
{
    public class HelloWorldDbContext : DbContext
    {
        public HelloWorldDbContext(DbContextOptions<HelloWorldDbContext> options) : base(options)
        {
        }

        public HelloWorldDbContext()
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
