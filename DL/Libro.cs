using System;
using System.Collections.Generic;

namespace DL;

public partial class Libro
{
    public byte IdLibro { get; set; }

    public string? TituloLibro { get; set; } = null!;

    public DateTime FechaPublicacion { get; set; }

    public byte? IdAutor { get; set; }

    public string? AutorNombre { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public byte? IdEditorial { get; set; }

    public string NombreEditorial { get; set; }

    public string Sipnosis { get; set; }

    public string? Portada { get; set; }

    public virtual Autor? IdAutorNavigation { get; set; }

    public virtual Editorial? IdEditorialNavigation { get; set; }
 
    public string ApellidoPaterno { get; set; }
    public string NombreEditorial { get; set; }
    public string ApellidoMaterno { get; set; }
    public string ApellidoPaterno { get; set; }
    public string NombreEditorial { get; set; }
    public string ApellidoMaterno { get; set; }
}
