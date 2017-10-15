using System.Collections.Generic;
using System.Linq;
using aspnetcore_janssens_michiel.Data;
using aspnetcore_janssens_michiel.Entities;
using aspnetcore_janssens_michiel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aspnetcore_janssens_michiel.Controllers
{
    public class BookController : Controller
    {
        private readonly EntityContext _entityContext;

        public BookController(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }

        [HttpGet("/books/create")]
        public IActionResult CreateBook()
        {
            return View("Detail");
        }

        [HttpGet("/books")]
        public IActionResult Index()
        {
            var model = new BookListViewModel { Books = new List<BookDetailViewModel>() };
            var allBooks = GetFullGraph().OrderBy(x => x.Title).ToList();
            model.Books.AddRange(allBooks.Select(ConvertBook));
            return View(model);
        }


        [HttpGet("/books/{id}")]
        public IActionResult Detail([FromRoute] int id)
        {
            var book = GetFullGraph()
                .FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            var vm = ConvertBook(book);
            vm.Genres = _entityContext.Genre.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            }
            ).ToList();
            return View(vm);
        }


        [HttpPost("/books")]
        public IActionResult Persist([FromForm] BookDetailViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var book = vm.Id == 0 ? new Book() : GetFullGraph().FirstOrDefault(x => x.Id == vm.Id);
                book.Title = vm.Title;
                book.Genre = vm.GenreId.HasValue ? _entityContext.Genre.FirstOrDefault(x => x.Id == vm.GenreId) : null;
                book.CreationDate = vm.CreationDate;
                book.ISBN = vm.ISBN;
                if (vm.Id == 0)
                    _entityContext.Books.Add(book);
                else
                    _entityContext.Books.Update(book);
                _entityContext.SaveChanges();

                return Redirect("/books");
            }
            return View("Detail", vm);
        }

        [HttpPost("/books/{id}/delete")]
        public IActionResult Delete([FromRoute]int id)
        {
            var book = _entityContext.Books.FirstOrDefault(x => x.Id == id);

            _entityContext.Books.Remove(book);
            _entityContext.SaveChanges();

            return Redirect("/books");
        }

        private IIncludableQueryable<Book, Author> GetFullGraph()
        {
            return _entityContext.Books.Include(x => x.Genre).Include(x => x.Authors).ThenInclude(x => x.Author);
        }


        private static BookDetailViewModel ConvertBook(Book book)
        {
            var vm = new BookDetailViewModel
            {
                Id = book.Id,
                Title = book.Title,
                CreationDate = book.CreationDate,
                Author = string.Join(";", book.Authors.Select(x => x.Author.FullName)),
                Genre = book.Genre?.Name,
                GenreId = book.Genre?.Id
            };
            return vm;
        }
    }
}
