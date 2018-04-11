using System;
using Dominio;
using System.Collections.Generic;
using System.IO;

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







    bool IService.WCFAddProveedor(string nombreCompletoProv, string nombreUsuario, string passw, string nombreFantasia, string email, string telefono, bool esVIP, double valorArancelVIP, List<ProveedorServicio> listaServicios)
    {
        throw new NotImplementedException();
    }

    List<Servicio> IService.WCFAllServiciosWhitTipoEvento()
    {
        throw new NotImplementedException();
    }

    bool IService.WCFChangeArancelAnualProveedor(int arancel)
    {
        throw new NotImplementedException();
    }

    bool IService.WCFChangeDatosProveedor(string idProveedor, DateTime fechaIngreso, bool esVIP, double valorArncelVIP)
    {
        throw new NotImplementedException();
    }

    bool IService.WCFDesactivarProveedor(string rutProveedor)
    {
        throw new NotImplementedException();
    }

    bool IService.WCFGuardarTxtProveedores()
    {
        throw new NotImplementedException();
    }

    int IService.WCFObtenerArancelAnualProveedor()
    {
        throw new NotImplementedException();
    }

    List<Proveedor> IService.WCFShowAllProveedores()
    {
        throw new NotImplementedException();
    }

    Proveedor IService.WCFShowProveedorPorRUT(string nombreRUT)
    {
        throw new NotImplementedException();
    }
}
