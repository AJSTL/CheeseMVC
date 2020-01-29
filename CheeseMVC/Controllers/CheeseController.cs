using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {

        //static private List<string> Cheeses = new List<string>();

        /*Add a description field to the application. This will involve:
        Modifying the static cheeses list to be a dictionary with key/value pairs that correspond to the name and description.
        Adding a new form field in Cheese/Add.cshtml to allow for submission of the description.
        Modify the NewCheese action to insert the description of the new cheese into the cheeses dictionary.
        Display the description field in the Cheese/Index.cshtml view template.*/

        private static Dictionary<string,string> Cheeses = new Dictionary<string, string>();


        //calls the index method of our cheese controller
        // GET: /<controller>/
        public IActionResult Index()
            {
               ViewBag.Cheeses = Cheeses;

                return View();
            }


            public IActionResult Add()
            {
                 return View();
            }


            [HttpPost]
            [Route("/Cheese/Add")]
            public IActionResult NewCheese(string name, string description)
            {
                // add the new cheese
                Cheeses.Add(name, description);

                return Redirect("/Cheese");
            }

    }
}
