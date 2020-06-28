using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibreriaMVC.Models
{
    public class Libros
    {
        public int ID { get; set; }
        // Foraneas
        public int AutoresID { get; set; }
        public int EditorialesID { get; set; }

        [Display (Name = "Titulo")]
        public String Titulo { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        [Display (Name = "Precio")]
        public decimal Precio { get; set; }
        
        [Display (Name = "Fecha de publicación")]
        public DateTime FechaPublicacion { get; set; }

        // Propiedades de navegación
        [Display (Name = "Autor")]
        public Autores autor { get; set; }
        [Display (Name = "Editorial")]
        public Editoriales editorial { get; set; }
    }
}