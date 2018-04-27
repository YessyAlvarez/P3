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
    bool WCFAddTramite(string titulo, string desc, double costo, int tiempo, List<int> gruposTramite);

	
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

    [OperationContract]
    void WCFEditGrupo(int idGrupo, string nombreGrupo);


    [OperationContract]
    int WCFValidarUsuario(string usuario, string password);

    [OperationContract]
    string WCFGetNombreCompleto(string nombreUsuario);


    [OperationContract]
    List<DTOGrupo> WCFListarGruposVacios();

    [OperationContract]
    void WCFEliminarGrupo(string nombreGrupo);



}

// Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
[DataContract]
public class DTOGrupo
{
    int codigo;
    string nombre;

    [DataMember]
    public int Codigo
    {
        get { return codigo; }
        set { codigo = value; }
    }

    [DataMember]
    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

}


[DataContract]
public class DTOGrupoTramite
{
    public string descripcion { get; set; }
    public int cantidadMaxFuncionarios { get; set; }
    public DTOGrupo grupo { get; set; }


    [DataMember]
    public string Descripcion
    {
        get { return descripcion; }
        set { descripcion = value; }
    }

    [DataMember]
    public int CantidadMaxFuncionarios
    {
        get { return cantidadMaxFuncionarios; }
        set { cantidadMaxFuncionarios = value; }
    }


    [DataMember]
    public DTOGrupo Grupo
    {
        get { return grupo; }
        set { grupo = value; }
    }
    
}
