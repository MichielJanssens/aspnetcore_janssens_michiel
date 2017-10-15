using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using aspnetcore_janssens_michiel.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace aspnetcore_janssens_michiel.Models
{
    public class BookDetailViewModel
    {
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        [RegularExpression(@"^(97(8|9))?\d{9}(\d|X)$")]
        public string ISBN { get; set; }
        public DateTime CreationDate { get; set; }
        public int Id { get; set; }
        public string Genre { get; set; }
        public int? GenreId { get; set; }
        public List<SelectListItem> Genres { get; set; }
    }
}
