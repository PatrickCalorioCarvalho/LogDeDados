using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LogDeDados.Models;

namespace LogDeDados.Models
{
    public class LogDeDadosContext : DbContext
    {
        public LogDeDadosContext (DbContextOptions<LogDeDadosContext> options)
            : base(options)
        {
        }

        public DbSet<LogDeDados.Models.Log> Log { get; set; }

        public DbSet<LogDeDados.Models.Usuario> Usuario { get; set; }
    }
}
