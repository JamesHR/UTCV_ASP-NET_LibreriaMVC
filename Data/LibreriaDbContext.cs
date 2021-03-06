using System;
using LibreriaMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace LibreriaMVC.Data
{
    public class LibreriaDbContext : DbContext
    {

        public DbSet<Autores> Autor { get; set; }
        public DbSet<Libros> Libro { get; set; }
        public DbSet<Editoriales> Editorial { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<UsuariosSalt> UsuariosSalt { get; set; }

        //Builder
        public LibreriaDbContext(DbContextOptions<LibreriaDbContext> options) : base(options)
        {
            //Vacío
        }
    }
}