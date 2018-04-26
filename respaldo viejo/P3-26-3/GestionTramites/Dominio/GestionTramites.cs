using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class GestionTramites
    {

        #region USUARIO
        //public List<Usuario> listaUsuarios;
        //public void AddUsuario(string Email, string Password)
        //{

        //    Usuario user = new Usuario(Email, Password, EnumPerfil.Admin, RolGrupo.);
        //    listaUsuarios.Add(user);

        //     //ClinicaMedica.Serializar();*/
        //}

        //public EnumPerfil ValidarUsuario(string usuario, string password)
        //{
        //    return Usuario.ObtenerRol(usuario, password); 
        //}


        //public string GetNombreCompleto(string usuarioIngresado)
        //{
        //    string email = "";
        //    if (listaUsuarios.Count > 0)
        //    {
        //        foreach (Usuario usuario in listaUsuarios)
        //        {
        //            if (usuario.User == usuarioIngresado)
        //            {
        //                listaUsuarios = usuario.NombreCompleto;
        //            }
        //        }
        //    }
        //    return email;
        //}

        #endregion

        public static void generarTxtGrupos() {
            //Cargar la lista de Grupo
            List<Grupo> grupos = Grupo.listarTodosLosGrupos();

            //Crear o reemplazar el archivo
            string path = @"C:\Users\Diseño\Desktop\grupos.txt";
            if (File.Exists(path)) {
                File.Delete(path);
            }
            File.Create(path).Close();

            ////Cargar Servicios al proveedor
            //foreach (Grupo p in grupos) {
            //    p.ListaServicios = ProveedorServicio.traerServiciosProveedor(p.RUT);
            //}
            //Crear string
            
            TextWriter tw = new StreamWriter(path);

            
            foreach (Grupo p in grupos) {
                string textoArchivo = null;
                textoArchivo += p.ToString();
                tw.WriteLine(textoArchivo);
            }
            tw.Close();
        }
        //public static void generarTxtServicios() {
       /*     List<Servicio> servicios = Servicio.ObtenerServiciosConTipoEvento();

            //Crear o reemplazar el archivo
            string path = @"C:\Users\IEUser\Desktop\proveedores.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            File.Create(path);
            TextWriter tw = new StreamWriter(path);
           
                string textoArchivo = null;
                textoArchivo += s.ToString2();
            
                tw.WriteLine(textoArchivo);
            }
            tw.Close();
            foreach (Servicio s in servicios) {

            }
            */
       // }
    }
}
