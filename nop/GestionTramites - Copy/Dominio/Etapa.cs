
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Configuration;
using AccesosDB;

namespace Dominio
{
    public class Etapa
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int LapsoMax { get; set; }
        public bool Activa { get; set; }




        #region VALIDAR
        public bool Validar()
        {
            return this.Codigo != null && this.Descripcion != null && this.LapsoMax >= 0;
        }

        #endregion

        #region TO STRING
        public override string ToString()
        {
            return this.Codigo + "@" + this.Descripcion + "@" + this.LapsoMax + "@" + this.Activa;
        }
        #endregion


    }


}


