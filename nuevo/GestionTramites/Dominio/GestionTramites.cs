using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesosDB;

namespace Dominio
{
    public class GestionTramites
    {

             

        #region GRUPOS

        public Boolean AddGrupo(string nombreGrupo) {
            //Verifico que no hay aotro repetido antes de mandarlo al Servicio web?
            Boolean retorno = true;
            //Llamo al ws
            //retorno = a.AddGrupo(nombreGrupo);
            return retorno;
        }

        #endregion


        #region USUARIO

        public void AddUsuario(string usuario, string NombreCompleto, EnumPerfil rol)
        {
            /* Usuario user = new Usuario(usuario, NombreCompleto, rol);
             ListaUsuarios.Add(user);
             Serializar();*/
        }

        public EnumPerfil ValidarUsuario(string usuario, string password)
        {
            return Usuario.ObtenerRol(usuario, password); ;
        }


        public string GetNombreCompleto(string usuarioIngresado)
        {
            string nombrecompleto = "";
            /*if (ListaUsuarios.Count > 0)
            {
                foreach (Usuario usuario in ListaUsuarios)
                {
                    if (usuario.User == usuarioIngresado)
                    {
                        nombrecompleto = usuario.NombreCompleto;
                    }
                }
            }*/
            return nombrecompleto;
        }

        #endregion

        public static void generarTxtProveedores() {
            
        }

      
    }
}
