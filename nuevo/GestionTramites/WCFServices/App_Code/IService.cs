using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IService
{
    /***    NEWS WCF    ***/
    [OperationContract]
    bool WCFAddGrupo(string nombreGrupo);


    [OperationContract]
    bool WCFAddTramite(string titulo, string desc, double costo, int tiempo, List<DTOGrupoTramite> gruposTramite);

   
    [OperationContract]
    bool WCFGuardarTxt();


    [OperationContract]
    bool WCFExisteNombreTramite(string nombreTramite);


    [OperationContract]
    List<DTOGrupo> WCFGetGrupo();

    [OperationContract]
    List<DTOGrupo> WCFListarGrupos();

    [OperationContract]
    DTOGrupo WCFObtenerGrupoPorId(int idGrupo);



    // TODO: agregue aquí sus operaciones de servicio
}

// Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
[DataContract]
public class DTOGrupo
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


[DataContract]
public class DTOGrupoTramite
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
