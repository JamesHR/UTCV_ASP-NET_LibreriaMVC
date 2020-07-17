using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaMVC.Controllers
{
    [Authorize(Roles="admin")]
    public class CatalogosController : Controller
    {
        public CatalogosController () {}

        public IActionResult Index()
        {
            return View("../Catalogos/index");
        }

        public IActionResult Autor()
        {
            return RedirectToAction("Index","Autores");
        }
        public IActionResult Editorial()
        {
            return RedirectToAction("Index","Editoriales");
        }

        public IActionResult Libro()
        {
            return RedirectToAction("Index","libros");
        }
    }
}