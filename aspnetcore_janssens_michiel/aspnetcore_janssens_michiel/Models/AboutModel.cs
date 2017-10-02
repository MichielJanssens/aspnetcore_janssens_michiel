using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcore_janssens_michiel.Models
{
    public class AboutModel
    {
        public string Name { get; set; }

        public DateTime Now => DateTime.Now;
        public double DaysUntilBirthday { get; set; }
    }
}
