using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        //calls the index method of our cheese controller
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Cheese> cheeses = CheeseData.GetAll(); // best way to bring in Cheeses directly, without using ViewBag

            //ViewBag.Cheeses = CheeseData.GetAll();
            //ViewData["cheese"] = CheeseData.GetAll(); // same as above

            return View(cheeses);
        }


        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();

            return View(addCheeseViewModel);
        }

      

        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if (ModelState.IsValid) // use the viewmodel to validate
            {
                //add the new cheese
                Cheese newCheese = new Cheese
                {
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description
                };

                CheeseData.Add(newCheese);
                return Redirect("/Cheese");
            }

            return View(addCheeseViewModel);

        }

        

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
