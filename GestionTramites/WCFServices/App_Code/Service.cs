using System;
using System.Collections.Generic;
using System.IO;
using Dominio;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{
    public bool WCFAddGrupo(string nombreGrupo)
    {
        Grupo grupo = new Grupo();
        grupo.Nombre = nombreGrupo;

        return grupo.AgregarGrupo();
    }

    public bool WCFAddTramite(string titulo, string desc, double costo, int tiempo, List<int> gruposTramite)
    {
        //Obtengo todos los id de los grupos y los convierto a DTOGrupoTramite
        /*
         * Código
         * 
         * */

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
        List<DTOGrupo> retorno = new List<DTOGrupo>();
        List<Grupo> grupos = Grupo.listarTodosLosGrupos();
        foreach (Grupo grup in grupos){
            DTOGrupo dtoGrupo = new DTOGrupo();
            dtoGrupo.Codigo = grup.Codigo;
            dtoGrupo.Nombre = grup.Nombre;
            retorno.Add(dtoGrupo);
        }
        return retorno;
    }

    public void WCFEditGrupo(int idGrupo, string nombreGrupo)
    {
        Grupo grupo = new Grupo
        {
            Codigo = idGrupo,
            Nombre = nombreGrupo
        };
        grupo.ModificarGrupo();

    }


    public int WCFValidarUsuario(string usuario, string password) {
        Usuario user = new Usuario
        {
            Email = usuario,
            Password = password
        };
        return user.ObtenerRol();
    }


    public string WCFGetNombreCompleto(string emailUsuario) {
        return Usuario.ObtenerNombreCompleto(emailUsuario);
    }
    

    public List<DTOGrupo> WCFListarGruposVacios() {
        List<DTOGrupo> retorno = new List<DTOGrupo>();
        List<Grupo> gruposVacios = Grupo.listarTodosLosGruposVacios();
        foreach (Grupo grup in gruposVacios)
        {
            DTOGrupo dtoGrupo = new DTOGrupo();
            dtoGrupo.Codigo = grup.Codigo;
            dtoGrupo.Nombre = grup.Nombre;
            retorno.Add(dtoGrupo);
        }
        return retorno;
    }



    public void WCFEliminarGrupo(string nombreGrupo) {



    }


}
