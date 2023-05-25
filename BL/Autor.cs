using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Autor
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.SistemaBusquedaContext context = new DL.SistemaBusquedaContext())
                {
                    var autorList = context.Autors.FromSqlRaw($"AutorGetAll").ToList();

                    result.Objects = new List<object>();

                    foreach (var row in autorList)
                    {
                        ML.Autor autor = new ML.Autor();

                        autor.IdAutor = row.IdAutor;
                        autor.Nombre = row.Nombre;
                        autor.ApellidoPaterno = row.ApellidoPaterno;
                        autor.ApellidoMaterno = row.ApellidoMaterno;
                        autor.FechaNacimiento = row.FechaNacimiento.ToString();
                        autor.PaisOrigen = row.PaisOrigen;


                        result.Objects.Add(autor);

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
    }
}
