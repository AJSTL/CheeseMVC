using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;


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

        


        //calls the index method of our cheese controller
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Cheeses = CheeseData.GetAll();
            //ViewData["cheese"] = CheeseData.GetAll();

            return View();
        }


        public IActionResult Add()
        {
            return View();
        }

        //public IActionResult Duplicate(string name)
        //{
       //     Content("{0} is a duplicate cheese. Please enter a different cheese.", name); //does not work
      //   return Redirect("/Cheese"); 
      //  }
      

        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult NewCheese(Cheese newCheese)
        {
            /*
            Cheese newCheese = new Cheese
            {
                Description = description,
                Name = name
            };

             ^^ shorthand, same as:
                Cheese newCheese = new Cheese(); 
                newCheese.Description=description; 
                newCheese.Name=name; */

            // Cheeses.Add(new Cheese(name,description)); // code above does the same but without a constructor; uses the default in the model

            //add the new cheese
            CheeseData.Add(newCheese);

            return Redirect("/Cheese");
            
        }

        /*public IActionResult Remove()
        {
            ViewBag.cheeses = Cheeses;
            return View();
        }*/

        /*
        [HttpPost]
        [Route("/Cheese/Remove")]
        public IActionResult RemoveCheese(string[] cheeseName)
        {
            {
                // remove the old cheese
                foreach (Cheese cheese in cheeseName)
                {
                    Cheeses.Remove(cheese);
                }
                return Redirect("/Cheese");
            }
        }
        */

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheeses";
            ViewBag.cheeses = CheeseData.GetAll();
            return View();
        }

        
        [HttpPost]
        [Route("/Cheese/Remove")]
        public IActionResult Remove(int[] cheeseIds)
        {
            foreach (int cheeseId in cheeseIds) //loop over the cheese ID integers 
            {
                CheeseData.Remove(cheeseId);
                //Cheeses.RemoveAll(x => x.CheeseId == cheeseId);
            }
            return Redirect("/");
        }
        
    

    }
}
