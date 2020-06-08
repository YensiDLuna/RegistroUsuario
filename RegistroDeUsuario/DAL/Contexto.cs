using Microsoft.EntityFrameworkCore;

using RegistroDeUsuario.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroDeUsuario.DAL
{
    class Contexto : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\UsuarioComtrol.db");
        }

    }
}
