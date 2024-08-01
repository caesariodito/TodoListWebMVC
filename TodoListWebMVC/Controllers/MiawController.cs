using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

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
        public IActionResult Index()
        {
            return View();
        }
        

        // GET: /Miaw/Anjay/ 
        public string Anjay(string name = "miaw", int numTimes  = 1)
        {
            return HtmlEncoder.Default.Encode($"You decided to say {name} {numTimes} times!");
        }
    }
}
