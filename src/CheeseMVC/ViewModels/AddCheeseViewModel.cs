using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CheeseMVC.ViewModels
{
    public class AddCheeseViewModel//this class represents what the views will be doing(display and process of the form).
    {
        [Required]//Used to create vaidation of forms
        [Display(Name = "Cheese Name")]

        public string Name { get; set; }

        [Required(ErrorMessage ="You must give a description for your cheese")]
        
        public string Description { get; set; }

        public CheeseType Type { get; set; }
        public List<SelectListItem> CheeseTypes { get; set; }
        public AddCheeseViewModel()
        {
            CheeseTypes = new List<SelectListItem>();//empty list
            CheeseTypes.Add(new SelectListItem {
                Value = ((int)CheeseType.Hard).ToString(),
                Text = CheeseType.Hard.ToString()
            });

            
            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Soft).ToString(),
                Text = CheeseType.Soft.ToString()
            });

            
            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Fake).ToString(),
                Text = CheeseType.Fake.ToString()
            });
        }

        
    }
}
