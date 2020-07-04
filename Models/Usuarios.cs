using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibreriaMVC.Models
{
    public class Usuarios
    {
        public Usuarios()
        {
            // No poner datos por Default
        }

        public int Id {get; set; }
        public String Nombre {get; set; }
        public String pApellido {get; set; }
        public String sApellido {get; set; }
        public String Correo {get; set; }
        public String Telefono {get; set; }
        public String Pais {get; set; }
        public String Password {get; set; }
        public DateTime FechaRegistro {get; set; }
        public String Rol {get; set; }
    }
}