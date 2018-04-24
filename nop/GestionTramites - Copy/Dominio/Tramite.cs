﻿
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
        public List<GrupoTramite> Grupos { get; set; }
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
            cmd.CommandText = @"INSERT INTO Tramite VALUES(@titulo,@desc,@costo,@tiempo);";
            cmd.Parameters.AddWithValue("@titulo", this.Titulo);
            cmd.Parameters.AddWithValue("@desc", this.Descripcion);
            cmd.Parameters.AddWithValue("@costo", this.Costo);
            cmd.Parameters.AddWithValue("@tiempo", this.Tiempo);
            cmd.Connection = cn;

            try
            {
                Conexion.AbrirConexion(cn);
                trn = cn.BeginTransaction();
                cmd.Transaction = trn;
                cmd.ExecuteNonQuery();
                //int ultimoId = (int)cmd.ExecuteScalar();

                int filasAfectadas = 0;
                for (int i = 0; i < this.Grupos.Count; i++)
                {
                    GrupoTramite gt = Grupos[i];
                    cmd.Parameters.Clear();
                    cmd.CommandText = @"INSERT INTO GrupoTramite VALUES(,@desc,@cantMaxFun)";

                    cmd.Parameters.Add(new SqlParameter("@desc", gt.Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@cantMaxFun", gt.CantidadMaxFuncionarios));
                    filasAfectadas += cmd.ExecuteNonQuery();

                    cmd.ExecuteNonQuery();

                    if (filasAfectadas == this.Grupos.Count)
                    {
                        trn.Commit();
                        return true;
                    }
                    else
                    {
                        trn.Rollback();
                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.Assert(false, ex.Message);
                trn.Rollback();
                return false;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
            return false;
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


        public static bool ExisteNombreTramite(string nombreTramite)
        {
            bool existe = false;
            string consulta = @"SELECT titulo FROM Tramite";
            SqlConnection cn = Conexion.CrearConexion();
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
                        if (tra.Titulo.Equals(nombreTramite))
                        {
                            existe = true;
                            continue;
                        }
                    }
                }
                dr.Close();
                return existe;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return existe;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
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
