using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class AddCheeseViewModel
    {
        // to represent all of the data associated with the "Add" View
        [Required]
        [Display(Name="Cheese Name")]
        public string Name { get; set; }

        [Required(ErrorMessage="You must give the cheese a description.")]
        public string Description { get; set; }
    }
}
