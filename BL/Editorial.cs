using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Editorial
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.SistemaBusquedaContext context = new DL.SistemaBusquedaContext())
                {
                    var editorialList = context.Autors.FromSqlRaw($"EditorialGetAll").ToList();

                    result.Objects = new List<object>();

                    foreach (var row in editorialList)
                    {
                        ML.Editorial editorial = new ML.Editorial();

                        editorial.IdEditorial = row.IdEditorial;
                        editorial.Nombre = row.Nombre;

                        result.Objects.Add(editorial);

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
