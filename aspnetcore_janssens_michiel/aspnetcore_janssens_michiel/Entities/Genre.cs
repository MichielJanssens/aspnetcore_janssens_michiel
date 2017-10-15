using System.Collections.Generic;

namespace aspnetcore_janssens_michiel.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Book> Books { get; set; }
    }
}
