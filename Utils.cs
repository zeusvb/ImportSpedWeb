using ImportSpedWeb.DTO;
using ImportSpedWeb.Models;

namespace ImportSpedWeb
{
    public static class Utils
    {
        //public static EmpleadoDTO ToDTO(this Empleado e)
        //{
        //    if (e != null)
        //    {
        //        return new EmpleadoDTO
        //        {
        //            Nombre = e.Nombre,
        //            CodEmpleado = e.CodEmpleado,
        //            Email = e.Email,
        //            Edad = e.Edad
        //        };
        //    }

        //    return null;
        //}

        public static UsuarioDTO ToDTO(this UsuarioAPI u)
        {
            if (u != null)
            {
                return new UsuarioDTO
                {
                    Token = u.token,
                    Usuario = u.usuario
                };
            }

            return null;
        }
    }
}
