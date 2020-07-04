using System;
using System.Threading.Tasks;
using LibreriaMVC.Data;
using LibreriaMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaMVC.Controllers
{
    public class UsuarioController : Controller
    {
        // 1. Agregar el contexto
        private readonly LibreriaDbContext con;

        // 2. Constructor para inicializar el contexto
        public UsuarioController (LibreriaDbContext _con) => this.con = _con;

        // 3. Función para agregar
        [HttpPost]
        public async Task<IActionResult> Add (
            [Bind("Nombre, pApellido, sApellido, Correo, Telefono, Pais, Password")] 
            Usuarios usu)
            {
                if (ModelState.IsValid)
                {
                    usu.FechaRegistro = DateTime.Now;
                    usu.Rol = "cliente";

                    //Agregar el usuario
                    con.Add(usu);

                    // Insertar el cambio a la base de datos
                    await con.SaveChangesAsync();
                    
                    // Si todo sale bien, redirigir a p+agina Login
                    return RedirectToAction("Login", "Home");
                }
                
                // En caso de no  realizar el registro redirigir a página Registro
                ModelState.AddModelError("Error", "Verifica tus datos.");
                return RedirectToAction("Registro", "Home");
            }
    }
}