using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {
        public static ML.Result Add(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.PpriantiProgramacionNcapasCoreContext context = new DL.PpriantiProgramacionNcapasCoreContext())
                {
                    int queryEF = context.Database.ExecuteSqlRaw($"AseguradoraAdd '{aseguradora.Nombre}', {aseguradora.Usuario.IdUsuario}");
                    //int queryEF = context.Database.ExecuteSqlRaw($"SemestreAdd '{semestre.Nombre}', {semestre.IdSemestre} ");


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
                result.ErrorMessage = "Ocurrio un error al insertar la aseguradora" + ex;
            }
            return result;
        }
    }
}
