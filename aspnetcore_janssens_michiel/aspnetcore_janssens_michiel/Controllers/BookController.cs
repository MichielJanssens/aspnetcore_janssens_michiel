using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aspnetcore_janssens_michiel.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aspnetcore_janssens_michiel.Controllers
{
    [Route("/books")]
    public class BookController : Controller
    {
        // GET: /<controller>/
        
        [HttpGet]
        public IActionResult Index()
        {
            var model = new DictionaryModel();
            

            return View(model);
        }

        [HttpGet("/books/{id}")]
        public IActionResult BookDetail([FromRoute]int id)
        {
            var model = new DictionaryModel().Books[id];

            return View(model);
        }
    }
}
