using System;
using System.Collections.Generic;

namespace Curso_ASP.Models
{
    public partial class Beerr
    {
        public int BeerId { get; set; }
        public string? Name { get; set; }
        public int? BrandId { get; set; }

        public virtual Brandd? Brand { get; set; }
    }
}
