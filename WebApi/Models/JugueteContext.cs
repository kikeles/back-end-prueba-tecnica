using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class JugueteContext : DbContext
    {
        public JugueteContext(DbContextOptions<JugueteContext> options)
            : base(options)
        {

        }

        public DbSet<Juguete> Juguetes { get; set; }
    }
}
