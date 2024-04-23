using System;
using System.Collections.Generic;

namespace Curso_ASP.Models
{
    public partial class Brandd
    {
        public Brandd()
        {
            Beerrs = new HashSet<Beerr>();
        }

        public int BrandId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Beerr> Beerrs { get; set; }
    }
}
