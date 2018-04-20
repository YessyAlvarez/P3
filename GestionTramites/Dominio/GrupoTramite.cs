
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
    public class GrupoTramite
    {
        public string Descripcion { get; set; }
        public int CantidadMaxFuncionarios { get; set; }
        public Grupo Grupo { get; set; }
        public List<Usuario> grupoFuncionarios { get; set; }
        
    }
}
