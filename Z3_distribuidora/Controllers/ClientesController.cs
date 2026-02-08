using Microsoft.AspNetCore.Mvc;

namespace Z3_distribuidora.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Indice()
        {
            return View();
        }

        public IActionResult EditarClliente()
        {
            return View();
        }


    }
}
