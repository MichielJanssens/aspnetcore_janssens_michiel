using System;
using System.Collections.Generic;

namespace aspnetcore_janssens_michiel.Models
{
    public class BookListViewModel
    {
        public List<BookDetailViewModel> Books { get; set; }
        public DateTime GeneratedAt => DateTime.Now;
    }
}