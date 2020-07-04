using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaMVC.Controllers
{
    [Authorize]
    public class CatalogosController : Controller
    {
        public CatalogosController () {}

        public IActionResult Index()
        {
            return View("../Catalogos/Index");
        }

        public IActionResult Autor()
        {
            return View("../Catalogos/Autores/Index");
        }
        public IActionResult Editorial()
        {
            return View("../Catalogos/Editoriales/Index");
        }

        public IActionResult Libro()
        {
            return View("../Catalogos/Libros/Index");
        }
    }
}