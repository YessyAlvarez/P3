﻿using System;
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

    public bool WCFAddTramite(string titulo, string desc, double costo, int tiempo, List<Object> gruposTramite)
    {

        /**
         * 
         * lógica
         * 
         **/

        return true;
    }

    bool IService.WCFGuardarTxt()
    {
        throw new NotImplementedException();
    }

   
}
