using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    public class LibroController : Controller
    {
        [Route("api/Libro/Add")]
        [HttpGet]
        public IActionResult GetAll([FromBody] ML.Libro libro)
        {
            ML.Result result = BL.Libro.Add(libro);

            if (result.Correct)
            {
                return Ok(result.Objects);
            }
            else { return NotFound(result); }
        }

        [Route("api/Libro/GetByAutor/{id}")]
        [HttpGet]
        public IActionResult GetByAutor(byte id)
        {
            ML.Result result = BL.Libro.LibroGetbyAutor(id);

            if (result.Correct)
            {
                return Ok(result.Objects);
            }
            else { return NotFound(result); }
        }

        [Route("api/Libro/GetByTitulo/{titulo}")]
        [HttpGet]
        public IActionResult GetByTitulo(String titulo)
        {
            ML.Result result = BL.Libro.LibroGetbyTitulo(titulo);

            if (result.Correct)
            {
                return Ok(result.Objects);
            }
            else { return NotFound(result); }
        }

        [Route("api/Libro/LibroGetbyFechaPublicacion/{fecha}")]
        [HttpGet]
        public IActionResult LibroGetbyFechaPublicacion(string fecha)
        {
            ML.Result result = BL.Libro.LibroGetbyFechaPublicacion(fecha);

            if (result.Correct)
            {
                return Ok(result.Objects);
            }
            else { return NotFound(result); }
        }

        [Route("api/Libro/LibrosByEditorial/{id}")]
        [HttpGet]
        public IActionResult LibrosByEditorial(int id)
        {
            ML.Result result = BL.Libro.LibrosByEditorial(id);

            if (result.Correct)
            {
                return Ok(result.Objects);
            }
            else { return NotFound(result); }
        }

        [Route("api/Libro/LibroByAutor_Fecha/{autor},{fecha}")]
        [HttpGet]
        public IActionResult LibroByAutor_Fecha(string autor, string fecha)
        {
            ML.Result result = BL.Libro.LibroByAutor_Fecha(autor, fecha);

            if (result.Correct)
            {
                return Ok(result.Objects);
            }
            else { return NotFound(result); }
        }

        [Route("api/l/LibroDeleteByAutor/{id}")]
        [HttpDelete]
        public IActionResult LibroDeleteByAutor(byte id)
        {
            ML.Libro libro = new ML.Libro();
            libro.Autor = new ML.Autor();
            libro.Autor.IdAutor = id;
            ML.Result result = BL.Libro.LibroDeleteByAutor(libro);
            if (result.Correct)
            {
                return Ok(result.Object);
            }
            else { return NotFound(result); }
        }

        [Route("api/l/LibroDeleteByEditorial/{id}")]
        [HttpDelete]
        public IActionResult LibroDeleteByEditorial(byte id)
        {
            ML.Libro libro = new ML.Libro();
            libro.Autor = new ML.Autor();
            libro.Autor.IdAutor = id;
            ML.Result result = BL.Libro.LibroDeleteByEditorial(libro);
            if (result.Correct)
            {
                return Ok(result.Object);
            }
            else { return NotFound(result); }
        }
    }
}
