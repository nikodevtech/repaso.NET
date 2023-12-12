using DAL.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Contexto : DbContext 
    {


        public Contexto(DbContextOptions<Contexto> options): base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }

    }
}
