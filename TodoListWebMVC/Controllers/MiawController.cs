using Microsoft.AspNetCore.Mvc;

namespace TodoListWebMVC.Controllers
{
    public class MiawController : Controller
    {

        // Will error if uncommented because I don't have the view(?)
        //public IActionResult Index()
        //{
        //    return View();
        //}
                 
        // GET: /Miaw/
        public string Index()
        {
            return "This is my default action...";
        }
        

        // GET: /Miaw/Anjay/ 
        public string Anjay()
        {
            return "This is the Anjay action method...";
        }
    }
}
