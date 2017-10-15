using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcore_janssens_michiel.Models
{
    public class DictionaryModel
    {
        public Dictionary<int, BookDetailViewModel> Books = new Dictionary<int, BookDetailViewModel>
        {
            {1, new BookDetailViewModel {Author = "Michiel Janssens", ISBN ="484848484823", Title = "Kookboek"} },
            {2, new BookDetailViewModel {Author = "Bram Janssens", ISBN ="484848484823", Title = "piepboek"} },
            {3, new BookDetailViewModel {Author = "Michiel Janssens", ISBN ="475727", Title = "pastaboek"} },
            {4, new BookDetailViewModel {Author = "Bram Janssens", ISBN ="4877747575784823", Title = "pizzaboek"} },
        };
    }
}
