
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using AccesosDB;

namespace Dominio
{
    public class Usuario
    {
        public string Email { set; get; }
        public string Password { set; get; }
        public EnumPerfil TipoPerfil { set; get; }
        public Grupo Rol { set; get; }



        #region BUSCAR USUARIO

        public int ObtenerRol()
        {
            int perfilUsuario = 0; //Por defecto no Autorizado

            string consulta = @"SELECT idRol FROM Usuario WHERE email='" + Email + "' AND password='" + Usuario.MD5Hash(Password) + "';";
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
                        perfilUsuario = 1; //EnumPerfil.Admin
                    }
                    else if (perfil.Equals("2"))
                    {
                        perfilUsuario = 2; //EnumPerfil.FuncionarioMantenimiento
                    }
                    else
                    {
                        perfilUsuario = 3; //EnumPerfil.Anonimo
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

        
        public static string ObtenerNombreCompleto(string emailUsuario)
        {
            string nombreCompleto = "Sin nombre";

            string consulta = @"SELECT nombreCompleto FROM Usuario WHERE email='" + emailUsuario + "';";
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand(consulta, cn);
            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    nombreCompleto = dr["nombreCompleto"].ToString();
                }
                dr.Close();
                return nombreCompleto;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return nombreCompleto;
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
