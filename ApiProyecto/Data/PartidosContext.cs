using ApiProyecto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProyecto.Data
{
    public class PartidosContext:DbContext
    {
        public PartidosContext(DbContextOptions<PartidosContext> options) : base(options)
        {
            
        }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Jugador> Jugadores { get; set;}
        public DbSet<Posts> Posts { get; set;}
        public DbSet<Liga> Ligas { get; set; }
        public DbSet<Partidos> Partidos { get; set; }
    }
}
