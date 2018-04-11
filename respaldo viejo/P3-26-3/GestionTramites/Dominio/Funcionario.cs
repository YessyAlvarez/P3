using AccesosDB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace Dominio
{
    public class Funcionario : Usuario
    {
        public string Nombre { get; set; }
        public bool Disponible { get; set; }
        public Grupo UnGrupo { get; set; }


        #region VALIDACION
        bool Validar()
        {
            return this.Nombre != null && this.Email != null;
        }
        #endregion

        #region ACTIVE RECORD
        public bool InsertarFuncionario()
        {
            SqlConnection cn = Conexion.CrearConexion();

            SqlCommand cmd = new SqlCommand();
            SqlTransaction trn = null;
            cmd.CommandText = @"INSERT INTO Usuario VALUES(@email,@passw,@perfil, @rol);";
            cmd.Parameters.AddWithValue("@email", this.Email);
            cmd.Parameters.AddWithValue("@passw", Usuario.MD5Hash(this.Password));
            cmd.Parameters.AddWithValue("@perfil", 2);
            cmd.Connection = cn;


            try
            {
                if (!this.Validar()) return false;
                //Conexion.AbrirConexion(cn);
                //trn = cn.BeginTransaction();
                //cmd.Transaction = trn;
                //cmd.ExecuteNonQuery();

                //cmd.Parameters.Clear();
                //cmd.CommandText = @"INSERT INTO Funcionario VALUES(@nombre,@disponible)";

                //cmd.Parameters.Add(new SqlParameter("@nombre", Nombre));
                //cmd.Parameters.Add(new SqlParameter("@disponible", 1));
                cmd.ExecuteNonQuery();

                trn.Commit();
                trn.Dispose();
                return true;

            }
            catch (SqlException ex)
            {
                Debug.Assert(false, ex.Message);
                trn.Rollback();
                return false;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }

        }

        #endregion

        #region METODO
        public List<Funcionario> listarFuncionariosDisponibles()
        {
            string consulta = @"SELECT * FROM Funcionario f, Usuario u 
                                WHERE f.idFuncionario = u.email AND f.disponible = 1"; /**Consultar por el tipo bool = bit 0,1**/
            SqlConnection cn = Conexion.CrearConexion();
            List<Funcionario> funcionarios = new List<Funcionario>();

            SqlCommand cmd = new SqlCommand(consulta, cn);

            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Funcionario unFunc = cargarDatosDesdeReader(dr);

                    if (unFunc.Disponible)
                    {
                        funcionarios.Add(unFunc);
                    }
                }

                dr.Close();
                return funcionarios;
            }
            catch (Exception ex) {
                Debug.Assert(false, ex.Message);
                return null;
            }
            finally
            {
                Conexion.CerrarConexion(cn);

            }


        }


        protected static Funcionario cargarDatosDesdeReader(IDataRecord fila) {

            Funcionario funcionario = null;

            /**Falta insertar Carga.**/
            return funcionario;

        }
        #endregion


        #region TOSTRING
        public override string ToString()
        {
            return this.Nombre + "#" + this.Disponible + "#" + this.UnGrupo.Nombre+ "#" + base.Rol + "#" +base.TipoPerfil+ "#" + this.Email;
        }
        #endregion
    }
}

