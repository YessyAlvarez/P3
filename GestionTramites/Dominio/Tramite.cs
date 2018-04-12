
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using AccesosDB;

namespace Dominio
{
    public class Tramite
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public int Tiempo { get; set; }  /*Tiempo previsto de ejecuciòn en días*/
        //public List<Funcionario> grupoFuncionarios { get; set; }
        public List<Etapa> etapas { get; set; }

        #region VALIDACION
        bool Validar()
        {
            return this.Id > 0 && this.Titulo != null && this.Descripcion != null &&
                this.Costo >= 0 && this.Tiempo >= 0;
        }
        #endregion

        #region ACTIVE RECORD 

        public bool AgregarTramite()
        {
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand();
            SqlTransaction trn = null;
            cmd.Connection = cn;

            try
            {
                if (!this.Validar()) return false;
                Conexion.AbrirConexion(cn);
                trn = cn.BeginTransaction();
                cmd.Transaction = trn;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                //procedimiento para verificar si ya existe el titulo
                cmd.CommandText = @"CREATE PROCEDURE verificarTitulo (@titulo) AS IF EXIST (SELECT titulo FROM Tramite WHERE titulo = @titulo) BEGIN PRINT 'Ya existe este titulo' END ELSE INSERT INTO Tramite VALUES (@id, @titulo, @descripcion, @costo, @tiempo);";
                cmd.Parameters.AddWithValue("@titulo", Titulo);
                cmd.Parameters.Add(new SqlParameter("@id", Id));
                cmd.Parameters.Add(new SqlParameter("@titulo", Titulo));
                cmd.Parameters.Add(new SqlParameter("@descripcion", Descripcion));
                cmd.Parameters.Add(new SqlParameter("@costo", Costo));
                cmd.Parameters.Add(new SqlParameter("@tiempo", Tiempo));

                cmd.ExecuteNonQuery();
                int filasAfectadas = 0;

                for (int i = 0; i < this.etapas.Count; i++)
                {
                    Etapa eta = etapas[i];

                    if (eta != null)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = @"INSERT INTO Etapa VALUES (@codigo, @descripcion, @lapsoMax, @activa);";

                        cmd.Parameters.Add(new SqlParameter("@codigo", eta.Codigo));
                        cmd.Parameters.Add(new SqlParameter("@descripcion", eta.Descripcion));
                        cmd.Parameters.Add(new SqlParameter("@lapsoMax", eta.LapsoMax));
                        cmd.Parameters.Add(new SqlParameter("@activa", 1));

                        filasAfectadas += cmd.ExecuteNonQuery();
                    }
                }
                cmd.ExecuteNonQuery();
                //int filasAfectadas2 = 0;
                //for(int j= 0; j < this.grupoFuncionarios.Count; j++)
                //{
                //    Funcionario fno = grupoFuncionarios[j];

                //    if(fno!= null)
                //    {
                //        cmd.Parameters.Clear();
                //        cmd.CommandText = @"INSERT INTO Funcionario VALUES(@nombre,@disponible)";
                //        cmd.Parameters.Add(new SqlParameter("@nombre", fno.Nombre));
                //        cmd.Parameters.Add(new SqlParameter("@disponible", 1));

                //        filasAfectadas2 += cmd.ExecuteNonQuery();
                //    }
                //}
                if (filasAfectadas == this.etapas.Count)
                {
                    trn.Commit();
                    trn.Dispose();
                    return true;
                }
                else
                {
                    trn.Rollback();
                    return false;
                }

            }
            catch (Exception ex)
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
        public List<Tramite> listarLosTramites()
        {
            string consulta = @"SELECT * FROM Tramite";

            SqlConnection cn = Conexion.CrearConexion();
            List<Tramite> tramites = new List<Tramite>();

            SqlCommand cmd = new SqlCommand(consulta, cn);

            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Tramite tra = cargarDatosDesdeReader(dr);

                    if (tra.Id != 0)
                    {
                        tramites.Add(tra);
                    }
                }
                dr.Close();
                return tramites;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return null;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }

        protected static Tramite cargarDatosDesdeReader(IDataRecord fila)
        {
            Tramite tramite = null;

            return tramite;
        }
        #endregion

        #region TO STRING
        public override string ToString()
        {
            return this.Id + "| \n" + this.Titulo + "| \n" + this.Descripcion + "| \n" + this.Costo + "| \n" + this.Tiempo;
        }

        /**Preguntar**/
        public string ToString2()
        {
            return this.Id + "@" + this.etapas.ToString();
        }

        #endregion

    }
}
