using Microsoft.AspNetCore.Mvc;
using MvcModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcModels.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;
        public HomeController(IRepository repository) => this.repository = repository;

        //public ViewResult Index(int id) => View(repository[id] ?? repository.People.Last());
        public IActionResult Index(int? id)
        {
            Person person;
            if (id.HasValue && (person = repository[id.Value]) != null)
            {
                return View(person);
            }
            return NotFound();
        }
    }
}
