using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Libro
    {
        public byte IdLibro { get; set; } //PK
        public string TituloLibro { get; set; }
        public string FechaPublicacion { get; set; }
        public string Sipnosis { get; set; }
        public string Portada { get; set; }

        public ML.Autor Autor { get; set; }//FK
        public ML.Editorial Editorial { get; set; }//FK

        public List<object> Libros { get; set; }
    }
}
