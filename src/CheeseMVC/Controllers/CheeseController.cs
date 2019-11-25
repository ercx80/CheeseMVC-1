using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {

        // GET: /<controller>/
        public IActionResult Index()
        {
            CheeseListViewModel model = new CheeseListViewModel {
                Cheeses = CheeseData.GetAll()
            };

            return View(model);
        }

        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();//create a instance of the view model add cheese
            
            return View(addCheeseViewModel);// here i am passing the form via the view model
        }

        [HttpPost]
        
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)//here i recieve an addcheese viewmodel object
        {
            if (ModelState.IsValid)//this checks if the form state that is passed to the controller is valid. It's gotta have data
            {
                // Add the new cheese to my existing cheeses
                Cheese newCheese = new Cheese
                {
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description,
                    Type = addCheeseViewModel.Type
                };

                CheeseData.Add(newCheese);

                return Redirect("/Cheese");
            }
            return View(addCheeseViewModel);
            
        }

        public IActionResult Detail(int id)
        {
            ViewBag.cheese = CheeseData.GetById(id);
            ViewBag.title = "Cheese Detail";
            return View();
        }

    }
}
