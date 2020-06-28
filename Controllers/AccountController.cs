using Microsoft.AspNetCore.Mvc;

namespace LibreriaMVC.Controllers
{
    public class AccountController : Controller
    {
        public AccountController () {}

        [HttpGet]
        public IActionResult Login()
        {
            // Return por Action
            return RedirectToAction("Login", "Home");
            
            // Return por ruta
            //return View("~/Views/Home/Login.cshtml");
        }
    }
}
