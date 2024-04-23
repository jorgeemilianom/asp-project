using System;
using System.Collections.Generic;

namespace Curso_ASP.Models
{
    public partial class Curso
    {
        public int Id { get; set; }
        public string NombreCurso { get; set; } = null!;
        public int CantidadClases { get; set; }
        public int Precio { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
