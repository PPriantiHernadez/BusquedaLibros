using System;
using System.Collections.Generic;

namespace DL;

public partial class Editorial
{
    public byte IdEditorial { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
