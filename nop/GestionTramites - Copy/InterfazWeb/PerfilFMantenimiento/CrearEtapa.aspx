<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilFMantenimiento.Master" AutoEventWireup="true" CodeBehind="CrearEtapa.aspx.cs" Inherits="InterfazWeb.PerfilFMantenimiento.CrearEtapa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Crear Etapa<br />-------------
    </p>
    <asp:Panel ID="Panel_CrearEtapa" runat="server">
        <br />
        Codigo<br />
        <asp:TextBox ID="TextBox_Codigo" runat="server"></asp:TextBox>
        <br />
        Descripcion<br />
        <asp:TextBox ID="TextBox_Descripcion" runat="server"></asp:TextBox>
        <br />
        Lapso maximo<br />
        <asp:TextBox ID="TextBox_Tiempo" runat="server"></asp:TextBox>
        <br />
        Tramite al que pertenece esta Etapa<br />
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Selected="True" Value="-1">Seleccione un Tramite</asp:ListItem>
            <asp:ListItem>Tramite1</asp:ListItem>
            <asp:ListItem>Tramite2</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <asp:Button ID="Button_NewEtapa" runat="server" Text="Crear Etapa" />
        <br />
    </asp:Panel>
    <p>
    </p>
    <p>
    </p>
    <asp:Panel ID="Panel_Msj" runat="server">
        <br />
        <asp:Label ID="Label_Msj" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button_Add_New_Etapa" runat="server" Text="Agregar una nueva etapa" />
        <br />
    </asp:Panel>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
