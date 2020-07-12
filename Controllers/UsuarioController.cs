using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using LibreriaMVC.Data;
using LibreriaMVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                
                // Si todo sale bien, redirigir a página Login
                return RedirectToAction("Login", "Home");
            }
            
            // En caso de no  realizar el registro redirigir a página Registro
            ModelState.AddModelError("Error", "Verifica tus datos.");
            return RedirectToAction("Registro", "Home");
        }

        // 4. Función para iniciar sesión
        public async Task<IActionResult> login (Usuarios usu)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Por favor verifique sus datos");
                return RedirectToAction("Login", "Home");
            }
            else
            {
                // Datos invalidos
                var usuario = await con.Usuarios.FirstOrDefaultAsync (u => u.Correo == usu.Correo && u.Password == usu.Password);
                if(usuario == null)
                {
                    ModelState.AddModelError("Error", "Las credenciales proporcionadas no son válidas");
                    // Carga la vista de Login y mando el modelo
                    return View ("../Home/Login", usu);
                }
                else
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, usuario.Nombre + "" + usuario.pApellido),
                        new Claim(ClaimTypes.Email, usuario.Correo),
                        new Claim(ClaimTypes.Role, usuario.Rol)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    
                    var authProperties = new AuthenticationProperties
                    {
                        // Tiempo de vida de la cookie
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10)
                    };

                    await HttpContext.SignInAsync (
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal (claimsIdentity),
                        authProperties
                    );

                    // Indicar la vista a donde se debe ir después del inicio de sesión
                    return (usuario.Rol.ToString().Trim().Equals("cliente")) ? 
                        RedirectToAction("Index", "Home")
                        : RedirectToAction("Index", "Catalogos");
                }
            }
        }

        // 5. Función para cerrar sesión
        [HttpGet]
        public async Task<IActionResult> logout ()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}