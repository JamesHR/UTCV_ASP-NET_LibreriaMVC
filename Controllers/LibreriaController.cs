using Microsoft.AspNetCore.Mvc;


namespace LibreriaMVC.Controllers
{
    public class LibreriaController : Controller
    {
        // 
        // GET: /HelloWorld/

        public IActionResult Index(){
            return View();
        }

        /*
        public string Index()
        {
            return "Entrando a LibreriaController.Index";
        }
        */

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome()
        {
            return "Bienvenido a Libroteca Cheshire";
        }

        public string Chuchita(string name, string lastname)
        {
            return "Bienvenido a Libroteca Cheshire: " + name + " " + lastname;
        }
    }
}
