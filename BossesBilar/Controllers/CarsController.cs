using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BossesBilar.Models;
using BossesBilar.Models.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BossesBilar.Controllers
{
    public class CarsController : Controller
    {
        CarsContext context;
        public CarsController(CarsContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = context.ListCars();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CarsCreateVM car)
        {
            if(ModelState.IsValid)
            {
                context.AddCar(car);
                return RedirectToAction(nameof(Index));
            }
            return View();
            
        }
    }
}
