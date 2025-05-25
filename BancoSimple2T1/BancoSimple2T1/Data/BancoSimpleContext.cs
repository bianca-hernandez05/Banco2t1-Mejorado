using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BancoSimple2T1.Models;

namespace BancoSimple2T1.Data
{
    public class BancoSimpleContext : DbContext
    {
        //Aqui se llaman a cada una de las clases que estan dentro de la carpeta Models
        //las cuales representan cada una de las tablas que estan en la base de datos.

        public DbSet <Cliente> Cliente { get; set; }
        public DbSet <Cuenta> Cuenta { get; set;}
        public DbSet <Transaccion> Transacciones { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = DANELIA-SIS; database =BancoSimple2T1; trusted_Connection = true; trustservercertificate = true;") ;

        }
        //Definicion de filtro global
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cuenta>().HasQueryFilter ( c => c.Activa);
        }

    }
}
