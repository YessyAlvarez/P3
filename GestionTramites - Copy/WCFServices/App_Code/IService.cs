﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using Dominio;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IService
{
    /***    NEWS WCF    ***/
    [OperationContract]
    bool WCFAddGrupo(string nombreGrupo);


    [OperationContract]
    bool WCFAddTramite(string titulo, string desc, double costo, int tiempo, List<GrupoTramite> gruposTramite);

   
    [OperationContract]
    bool WCFGuardarTxt();

    [OperationContract]
    bool WCFExisteNombreTramite(string nombreTramite);


    [OperationContract]
    List<Grupo> WCFGetGrupo();



    // TODO: agregue aquí sus operaciones de servicio
}

// Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
[DataContract]
public class CompositeType
{
    bool boolValue = true;
    string stringValue = "Hello ";

    [DataMember]
    public bool BoolValue
    {
        get { return boolValue; }
        set { boolValue = value; }
    }

    [DataMember]
    public string StringValue
    {
        get { return stringValue; }
        set { stringValue = value; }
    }
}
