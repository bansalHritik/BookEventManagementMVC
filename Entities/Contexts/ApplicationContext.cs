using Entities.Models;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;

namespace Entities
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext():base("name=DefaultConnection") {}

        public DbSet<Event> Events { get; set; }

       
    }
}
