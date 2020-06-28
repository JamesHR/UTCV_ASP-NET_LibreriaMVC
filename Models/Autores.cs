using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LibreriaMVC.Models
{
    public class Autores
    {
        public int ID { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Apellido")]
        public string apellido { get; set; }
        [Display(Name = "Nacionalidad")]
        public string nacionalidad { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime fechaNacimiento { get; set; }
    }
}