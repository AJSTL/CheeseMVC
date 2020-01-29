﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {

        static private List<string> Cheeses = new List<string>();
       
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
        public IActionResult NewCheese(string name)
        {
            // add the new cheese
            Cheeses.Add(name);

            return Redirect("/Cheese");
        }

    }
}