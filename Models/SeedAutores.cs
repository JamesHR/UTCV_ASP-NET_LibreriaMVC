using System;
using System.Linq;
using LibreriaMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibreriaMVC.Models
{
    public class SeedAutores
    {
        public static void CargarDatos(IServiceProvider serviceProvider)
        {
            using (var contexto = new LibreriaDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<LibreriaDbContext>>()))
            {
                if (contexto.Autor.Any())
                {
                    return;
                }
                contexto.Autor.AddRange(
                    new Autores
                    {
                        nombre = "Paulo",
                        apellido = "Cohelo",
                        nacionalidad = "Brasilian",
                        fechaNacimiento = DateTime.Parse("1980-3-13")
                    },
                    new Autores
                    {
                        nombre = "Daniel",
                        apellido = "Mannix",
                        nacionalidad = "American",
                        fechaNacimiento = DateTime.Parse("1970-3-13")
                    },
                    new Autores
                    {
                        nombre = "Gabriel",
                        apellido = "Baca",
                        nacionalidad = "Mexicana",
                        fechaNacimiento = DateTime.Parse("1960-3-13")
                    }
                );
                contexto.SaveChanges();
            }
        }
    }
}
