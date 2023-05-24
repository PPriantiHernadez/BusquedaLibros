using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {
        //CREAR NUEVA INFORMACION DE LIBRO :) PRISCILA
        public static ML.Result Add(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.SistemaBusquedaContext context = new DL.SistemaBusquedaContext())
                {
                    int queryEF = context.Database.ExecuteSqlRaw($"LibroAdd '{libro.TituloLibro}', '{libro.FechaPublicacion}' ,{libro.Autor.IdAutor}, {libro.Editorial.IdEditorial}, '{libro.Sipnosis}','{libro.Portada}'");

                    if (queryEF > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el libro" + ex;
            }
            return result;
        }

        //CREAR CONSULTAS POR TITULO DE LIBRO :)
        public static ML.Result LibroGetbyAutor(byte IdAutor)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.SistemaBusquedaContext context = new DL.SistemaBusquedaContext())
                {
                    var libroList = context.Libros.FromSqlRaw($"LibroGetbyAutor  {IdAutor}").ToList();

                    result.Objects = new List<object>();

                    foreach (var row in libroList)
                    {
                        ML.Libro libro = new ML.Libro();

                        libro.IdLibro = row.IdLibro;
                        libro.TituloLibro = row.TituloLibro;
                        libro.FechaPublicacion = row.FechaPublicacion.ToString("ddMMyyyy");

                        libro.Autor = new ML.Autor();
                        libro.Autor.IdAutor = row.IdAutor.Value;
                        libro.Autor.Nombre = row.NombreAutor;
                        libro.Autor.ApellidoPaterno = row.ApellidoPaterno;
                        libro.Autor.ApellidoMaterno = row.ApellidoMaterno;

                        libro.Editorial = new ML.Editorial();
                        libro.Editorial.IdEditorial = row.IdEditorial.Value;
                        libro.Editorial.Nombre = row.NombreEditorial;

                        libro.Sipnosis = row.Sipnosis;
                        libro.Portada = row.Portada;

                        result.Objects.Add(libro);

                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;

            }
            return result;
        }

        //CREAR CONSULTAS POR TITULO DE LIBRO :) 
        public static ML.Result LibroGetbyTitulo(string TituloLibro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.SistemaBusquedaContext context = new DL.SistemaBusquedaContext())
                {
                    var libroList = context.Libros.FromSqlRaw($"LibroGetbyTitulo  '{TituloLibro}'").ToList();

                    result.Objects = new List<object>();

                    foreach (var row in libroList)
                    {
                        ML.Libro libro = new ML.Libro();

                        libro.IdLibro = row.IdLibro;
                        libro.TituloLibro = row.TituloLibro;
                        libro.FechaPublicacion = row.FechaPublicacion.ToString("ddMMyyyy");

                        libro.Autor = new ML.Autor();
                        libro.Autor.IdAutor = row.IdAutor.Value;
                        libro.Autor.Nombre = row.NombreAutor;
                        libro.Autor.ApellidoPaterno = row.ApellidoPaterno;
                        libro.Autor.ApellidoMaterno = row.ApellidoMaterno;


                        libro.Editorial = new ML.Editorial();
                        libro.Editorial.IdEditorial = row.IdEditorial.Value;
                        libro.Editorial.Nombre = row.NombreEditorial;

                        libro.Sipnosis = row.Sipnosis;
                        libro.Portada = row.Portada;

                        result.Objects.Add(libro);

                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;

            }
            return result;
        }

        //CREAR CONSULTAS POR FECHA DE PUBLICACION :)
        public static ML.Result LibroGetbyFechaPublicacion(string FechaPublicacion)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.SistemaBusquedaContext context = new DL.SistemaBusquedaContext())
                {
                    var libroList = context.Libros.FromSqlRaw($"LibroGetbyFechaPublicacion  '{FechaPublicacion}'").ToList();

                    result.Objects = new List<object>();

                    foreach (var row in libroList)
                    {
                        ML.Libro libro = new ML.Libro();

                        libro.IdLibro = row.IdLibro;
                        libro.TituloLibro = row.TituloLibro;
                        libro.FechaPublicacion = row.FechaPublicacion.ToString("ddMMyyyy");

                        libro.Autor = new ML.Autor();
                        libro.Autor.IdAutor = row.IdAutor.Value;
                        libro.Autor.Nombre = row.NombreAutor;
                        libro.Autor.ApellidoPaterno = row.ApellidoPaterno;
                        libro.Autor.ApellidoMaterno = row.ApellidoMaterno;

                        libro.Editorial = new ML.Editorial();
                        libro.Editorial.IdEditorial = row.IdEditorial.Value;
                        libro.Editorial.Nombre = row.NombreEditorial;

                        libro.Sipnosis = row.Sipnosis;
                        libro.Portada = row.Portada;

                        result.Objects.Add(libro);

                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;

            }
            return result;
        }
        //CONSULTA LIBRO EDITORIAL :3
>>>>>>>>> Temporary merge branch 2
        public static ML.Result LibrosByEditorial(int idEditorial)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.SistemaBusquedaContext cnn = new DL.SistemaBusquedaContext())
                {
                    var query = cnn.Libros.FromSqlRaw($"LibrosByEditorial {idEditorial}").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var row in query)
                        {
                            ML.Libro libro = new ML.Libro();

                            libro.IdLibro = row.IdLibro;
                            libro.TituloLibro = row.TituloLibro;
                            libro.FechaPublicacion = row.FechaPublicacion.ToString();

                            libro.Autor = new ML.Autor();
                            libro.Autor.IdAutor = Convert.ToByte(row.IdAutor);
                            libro.Autor.Nombre = row.NombreAutor;
                            libro.Autor.ApellidoPaterno = row.ApellidoPaterno;
                            libro.Autor.ApellidoMaterno = row.ApellidoMaterno;

                            libro.Editorial = new ML.Editorial();
                            libro.Editorial.IdEditorial = Convert.ToByte(row.IdEditorial);
                            libro.Editorial.Nombre = row.NombreEditorial;

                            result.Objects.Add(libro);
                        }

                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "An error occurred while inserting the record into the table" + result.Ex;
                throw;
            }
            return result;
        }


        //CONSULTA POR AUTOR Y EDITORIAL :3
        public static ML.Result LibroByAutor_Fecha(int idAutor, string fecha)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.SistemaBusquedaContext cnn = new DL.SistemaBusquedaContext())
                {
                    var query = cnn.Libros.FromSqlRaw($"LibroByAutor_Fecha {idAutor},'{fecha}'").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var row in query)
                        {
                            ML.Libro libro = new ML.Libro();
                            libro.IdLibro = row.IdLibro;
                            libro.TituloLibro = row.TituloLibro;
                            libro.FechaPublicacion = row.FechaPublicacion.ToString();

                            libro.Autor = new ML.Autor();
                            libro.Autor.IdAutor = Convert.ToByte(row.IdAutor);
                            libro.Autor.Nombre = row.NombreAutor;
                            libro.Autor.ApellidoPaterno = row.ApellidoPaterno;
                            libro.Autor.ApellidoMaterno = row.ApellidoMaterno;

                            libro.Editorial = new ML.Editorial();
                            libro.Editorial.IdEditorial = Convert.ToByte(row.IdEditorial);
                            libro.Editorial.Nombre = row.NombreEditorial;

                            result.Objects.Add(libro);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "An error occurred while inserting the record into the table" + result.Ex;
                //throw;
            }
            return result;
        }

        //BORRADOR LIBROS POR AUTOR :3
        public static ML.Result LibroDeleteByAutor(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.SistemaBusquedaContext cnn = new DL.SistemaBusquedaContext())
                {
                    int query = cnn.Database.ExecuteSqlRaw($"LibroDeleteByAutor {libro.Autor.IdAutor}");

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
<<<<<<<<< Temporary merge branch 1
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "An error occurred while inserting the record into the table" + result.Ex;
                //throw;
            }
            return result;
        }

        public static ML.Result LibroDeleteByEditorial(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.SistemaBusquedaContext cnn = new DL.SistemaBusquedaContext())
                {
                    int query = cnn.Database.ExecuteSqlRaw($"LibroDeleteByAutor {libro.Editorial.IdEditorial}");

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
=========
>>>>>>>>> Temporary merge branch 2
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "An error occurred while inserting the record into the table" + result.Ex;
                //throw;
            }
            return result;
        }

<<<<<<<<< Temporary merge branch 1
        //CREAR CONSULTAS POR TITULO DE LIBRO :) PRISCILA

        public static ML.Result LibroGetbyTitulo(string TituloLibro)
=========
        //BORRADOR LIBROS POR EDITORIAL :3
        public static ML.Result LibroDeleteByEditorial(ML.Libro libro)
>>>>>>>>> Temporary merge branch 2
        {
            ML.Result result = new ML.Result();

            try
            {
<<<<<<<<< Temporary merge branch 1
                using (DL.SistemaBusquedaContext context = new DL.SistemaBusquedaContext())
                {
                    var libroList = context.Libros.FromSqlRaw($"LibroGetbyTitulo  '{TituloLibro}'").ToList();

                    result.Objects = new List<object>();

                    foreach (var row in libroList)
                    {
                        ML.Libro libro = new ML.Libro();

                        libro.IdLibro = row.IdLibro;
                        libro.TituloLibro = row.TituloLibro;
                        libro.FechaPublicacion = row.FechaPublicacion.ToString("ddMMyyyy");

                        libro.Autor = new ML.Autor();
                        libro.Autor.IdAutor = row.IdAutor.Value;

                        libro.Editorial = new ML.Editorial();
                        libro.Editorial.IdEditorial = row.IdEditorial.Value;

                        libro.Sipnosis = row.Sipnosis;
                        libro.Portada = row.Portada;

                        result.Objects.Add(libro);

                    }
                    result.Correct = true;
=========
                using (DL.SistemaBusquedaContext cnn = new DL.SistemaBusquedaContext())
                {
                    int query = cnn.Database.ExecuteSqlRaw($"LibroDeleteByEditorial {libro.Editorial.IdEditorial}");

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
>>>>>>>>> Temporary merge branch 2
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
<<<<<<<<< Temporary merge branch 1
                result.ErrorMessage = ex.Message;

            }
            return result;
        }

        //CREAR CONSULTAS POR FECHA DE PUBLICACION :) PRISCILA
        public static ML.Result LibroGetbyFechaPublicacion(string FechaPublicacion)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.SistemaBusquedaContext context = new DL.SistemaBusquedaContext())
                {
                    var libroList = context.Libros.FromSqlRaw($"LibroGetbyFechaPublicacion  '{FechaPublicacion}'").ToList();

                    result.Objects = new List<object>();

                    foreach (var row in libroList)
                    {
                        ML.Libro libro = new ML.Libro();

                        libro.IdLibro = row.IdLibro;
                        libro.TituloLibro = row.TituloLibro;
                        libro.FechaPublicacion = row.FechaPublicacion.ToString("ddMMyyyy");

                        libro.Autor = new ML.Autor();
                        libro.Autor.IdAutor = row.IdAutor.Value;

                        libro.Editorial = new ML.Editorial();
                        libro.Editorial.IdEditorial = row.IdEditorial.Value;

                        libro.Sipnosis = row.Sipnosis;
                        libro.Portada = row.Portada;

                        result.Objects.Add(libro);

                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;

=========
                result.ErrorMessage = "An error occurred while deleting the record into the table" + result.Ex;
                throw;
>>>>>>>>> Temporary merge branch 2
            }
            return result;
        }
    }
}
