using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Autor
    {
        public byte IdAutor { get; set; } //PK
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string FechaNacimiento { get; set; }
        public string PaisOrigen { get; set; }

        public List<object> Autores { get; set; }

    }
}
