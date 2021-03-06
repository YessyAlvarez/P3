﻿
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data;
using AccesosDB;

namespace Dominio
{
    public class Grupo
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }



        #region CONTRUCTOR

        public Grupo()
        {

        }
        #endregion

        #region VALIDACION
        bool Validar()
        {
            return this.Nombre != null;
        }
        #endregion

        #region ACTIVE RECORD
        public bool AgregarGrupo()
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
                cmd.CommandText = @"INSERT TO INTO Grupo VALUES (@nombre);";

                cmd.Parameters.Add(new SqlParameter("@nombre", Nombre));

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
        public List<Grupo> listarTodosLosGrupos()
        {
            string consulta = @"SELECT * FROM Grupo";

            SqlConnection cn = Conexion.CrearConexion();
            List<Grupo> grupos = new List<Grupo>();

            SqlCommand cmd = new SqlCommand(consulta, cn);

            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Grupo grup = cargarDatosDesdeReader(dr);

                    if (grup.Codigo != 0)
                    {
                        grupos.Add(grup);
                    }
                }
                dr.Close();
                return grupos;
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



        protected static Grupo cargarDatosDesdeReader(IDataRecord fila)
        {
            Grupo grupo = null;

            if (fila != null)
            {
                grupo = new Grupo
                {

                    Nombre = fila.IsDBNull(fila.GetOrdinal("Nombre")) ? "" : fila.GetString(fila.GetOrdinal("Nombre"))
                };
            }
            return grupo;
        }
        #endregion

        #region TOSTRING
        public override string ToString()
        {
            return this.Nombre + "#" + this.Codigo;
        }
        #endregion

    }
}
