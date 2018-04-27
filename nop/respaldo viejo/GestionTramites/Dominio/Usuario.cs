using AccesosDB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Dominio
{
    public class Usuario
    {
        public string UsuarioLogin { set; get; }
        public string Password { set; get; }
        public EnumRol TipoPerfil { set; get; }
        public string NombreApellido { set; get; }


        /*   public Usuario(string unNombreApellido, string nombreUsuario, string passw, EnumPerfil tipoPerfl)
           {
               this.NombreApellido = unNombreApellido;
               this.UsuarioLogin = nombreUsuario;
               this.Password = passw;
               this.TipoPerfil = tipoPerfl;
           }
           */


        #region BUSCAR USUARIO

        public static EnumRol ObtenerRol(string usuario, string password)
        {
            EnumRol perfilUsuario = EnumRol.NoAutorizado;

            string consulta = @"SELECT idRol FROM Usuario WHERE email='" + usuario + "' AND password='" + Usuario.MD5Hash(password) + "';";
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand(consulta, cn);
            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string perfil = dr["idRol"].ToString();
                    if (perfil.Equals("1"))
                    {
                        perfilUsuario = EnumRol.Admin;
                    }
                    else if (perfil.Equals("2"))
                    {
                        perfilUsuario = EnumRol.FuncionarioMantenimiento;
                    }
                    else if (perfil.Equals("3"))
                    {
                        perfilUsuario = EnumRol.FuncionarioEscribano;
                    }
                    else
                    {
                        perfilUsuario = EnumRol.NoAutorizado;
                    }
                }
                dr.Close();
                return perfilUsuario;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return perfilUsuario;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }

        #endregion
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }


    }
}
