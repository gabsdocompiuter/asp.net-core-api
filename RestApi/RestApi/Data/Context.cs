using Microsoft.EntityFrameworkCore;
using RestApi.Models;
using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
    }
}
