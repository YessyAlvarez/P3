using System;
using System.Collections.Generic;
using System.IO;
using Dominio;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{
    public bool WCFAddGrupo(string nombreGrupo)
    {
        bool retorno = true;

        /**
         * 
         * lógica
         * 
         **/

        return retorno;
    }

    public bool WCFAddTramite(string titulo, string desc, double costo, int tiempo, List<DTOGrupoTramite> gruposTramite)
    {
        Tramite newTramite = new Tramite
        {
            Titulo = titulo,
            Descripcion = desc,
            Costo = costo,
            Tiempo = tiempo,
            //Grupos = gruposTramite
        };

        return newTramite.AgregarTramite();
    }

    bool IService.WCFGuardarTxt()
    {
        throw new NotImplementedException();
    }


    public bool WCFExisteNombreTramite(string nombreTramite)
    {
        return Tramite.ExisteNombreTramite(nombreTramite);
    }

    public List<DTOGrupo> WCFGetGrupo()
    {
        return null;// Grupo.listarTodosLosGrupos();
    }


    public DTOGrupo WCFObtenerGrupoPorId(int idGrupo) {
        return null; // Grupo.ObtenerGrupoPorId(idGrupo);
    }

    public List<DTOGrupo> WCFListarGrupos()
    {
        return null; // Grupo.MiListarTodosLosGrupos();
    }
}
