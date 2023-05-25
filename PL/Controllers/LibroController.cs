using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace PL.Controllers
{
    public class LibroController : Controller
    {
        private IHostingEnvironment environment;
        private IConfiguration configuration;
        public LibroController(IHostingEnvironment _environment, IConfiguration _configuration)
        {
            environment = _environment;
            configuration = _configuration;
        }

        public ActionResult GetAll()
        {
            ML.Libro libro = new ML.Libro();

            libro.Autor = new ML.Autor();
            libro.Editorial = new ML.Editorial();

            libro.Libros = new List<object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5230/api/");

                var responseTask = client.GetAsync("Libro/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Libro ResultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Libro>(resultItem.ToString());
                        libro.Libros.Add(ResultItemList);

                        ML.Result resultAutor = BL.Autor.GetAll();
                        ML.Result resultEditorial = BL.Editorial.GetAll();

                        libro.Autor.Autores = resultAutor.Objects;
                        libro.Editorial.Editoriales = resultEditorial.Objects;
                    }
                }
            }
            return View(libro);
        }

        [HttpPost]
        public ActionResult GetAll(ML.Libro libro)
        {
            ML.Result result = BL.Libro.GetAllLibro(libro.IdLibro, libro.Autor.IdAutor, libro.Editorial.IdEditorial);

            if (result.Correct)
            {
                ML.Result resultAutor = BL.Autor.GetAll();
                ML.Result resultEditorial = BL.Editorial.GetAll();

                libro.Autor.Autores = resultAutor.Objects;
                libro.Editorial.Editoriales = resultEditorial.Objects;
                libro.Libros = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al hacer la consulta Users";
            }

            return View(libro);
        }

        [HttpGet]
        public ActionResult Form(int? idLibro)
        {
            ML.Result resultAutor = BL.Autor.GetAll();
            ML.Result resultEditorial = BL.Editorial.GetAll();

            ML.Libro libro = new ML.Libro();
            libro.Autor = new ML.Autor();

            libro.Editorial = new ML.Editorial();

            if (resultAutor.Correct)
            {
                libro.Autor.Autores = resultAutor.Objects;
                libro.Editorial.Editoriales = resultEditorial.Objects;
            }
            if (idLibro == null)
            {
                return View(libro);
            }
            else
            {
                ML.Result result = new ML.Result();
                using (var client = new HttpClient())
                {
                    string urlApi = configuration["urlWebApi"];
                    client.BaseAddress = new Uri(urlApi);

                    var responseTask = client.GetAsync("Libro/GetById/" + idLibro);
                    responseTask.Wait();

                    var resultAPI = responseTask.Result;

                    if (resultAPI.IsSuccessStatusCode)
                    {
                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();
                        ML.Libro resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Libro>(readTask.Result.Object.ToString());
                        result.Object = resultItemList;

                        libro = (ML.Libro)result.Object;

                        libro.Autor.Autores = resultAutor.Objects;
                        libro.Editorial.Editoriales = resultEditorial.Objects;
                    }
                }
                return View(libro);
            }
        }
        [HttpPost]
        public ActionResult Form(ML.Libro libro)
        {
            IFormFile file = Request.Form.Files["inpImagen"];

            if (file != null)
            {
                libro.Portada = Convert.ToBase64String(ConvertToBytes(file));
            }
            //add
            using (var client = new HttpClient())
            {
                string urlApi = configuration["urlWebApi"];
                client.BaseAddress = new Uri(urlApi);

                var postTask = client.PostAsJsonAsync<ML.Libro>("Libro/Add", libro);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Registro correctamente insertado";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al actualizar el registro";
                    return PartialView("Modal");
                }
            }
        }
        public static byte[] ConvertToBytes(IFormFile imagen)
        {

            using var fileStream = imagen.OpenReadStream();

            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);

            return bytes;
        }

        [HttpGet]
        public ActionResult Delete(int idLibro)
        {
            using (var client = new HttpClient())
            {
                string urlApi = configuration["urlWebApi"];
                client.BaseAddress = new Uri(urlApi);

                var postTask = client.GetAsync("Libro/Delete/" + idLibro);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Registro correctamente Eliminado";
                    return PartialView("Modal");
                }
                else
        {
                    ViewBag.Message = "Ocurrio un error al eliminar el registro";
                    return PartialView("Modal");
                }
            }
        }
    }
}
