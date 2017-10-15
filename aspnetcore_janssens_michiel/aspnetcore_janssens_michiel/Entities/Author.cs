using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcore_janssens_michiel.Entities
{
    public class Author
    {
        public string FullName => $"{FirstName} {LastName}";
       
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<AuthorBook> Books { get; set; }
    }
}
