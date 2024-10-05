using ImportSpedWeb.Data;
using ImportSpedWeb.DTO;
using ImportSpedWeb.Interfaces;
using ImportSpedWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ImportSpedWeb.Services
{
    public class ServicioUsuario : IServicioUsuario
    {

        public async Task<UsuarioAPI> GetUsuario(Login login)
            {

                UsuarioAPI usuario = null;

            try
            {
                if (login != null)
                {
                    using (var db = new ImportSpedContext())
                    {
                        usuario usu = new();


                        usu = await db.usuarios.Where(c => c.nome == login.Usuario && c.senha == login.Pass).FirstOrDefaultAsync();

                        if (usu != null)
                        {
                            usuario.usuario = usu.nome;
                            usuario.email = usu.email;
                        }


                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Usuario inválido: " + ex.Message);
            }
            finally
            {

            }

                return usuario;
            }

     
    }
}
