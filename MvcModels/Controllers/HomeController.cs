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

        public ViewResult Create() => View(new Person());

        [HttpPost]
        public ViewResult Create(Person model) => View(nameof(Index), model);

        public ViewResult DisplaySummary([Bind(nameof(AdressSummary.City), Prefix = nameof(Person.HomeAdress))]AdressSummary model) => View(model);

        //public ViewResult Names(string[] names) => View(names ?? new string[0]);
        public ViewResult Names(List<string> names) => View(names ?? new List<string>());
    }
}
