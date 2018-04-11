<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilAdmin.Master" AutoEventWireup="true" CodeBehind="EditarGrupo.aspx.cs" Inherits="InterfazWeb.PerfilAdmin.EditarGrupo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    Editar Grupo<br />
    --------------------<br />
    <asp:Panel ID="Panel_Seleccion_Grupo" runat="server">
        <br />
        Seleccione un Grupo:
        <asp:DropDownList ID="DropDownList_Grupos" runat="server" OnSelectedIndexChanged="combo_change" Width="72px">
            <asp:ListItem Selected="True">Grupo 1</asp:ListItem>
            <asp:ListItem>Grupo 2</asp:ListItem>
            <asp:ListItem>Grupo 3</asp:ListItem>
            <asp:ListItem>Grupo 4</asp:ListItem>
        </asp:DropDownList>

        <br />
        <asp:Button ID="Button_Editar_Grupo" runat="server" OnClick="Button_Editar_Grupo_Click" Text="Editar Grupo" />

        <br />
        <br />
    </asp:Panel>
    <p></p>
    <asp:Panel ID="Panel_Edicion_Grupo" runat="server">
        <br />
        Nombre:
        <asp:TextBox ID="TextBox_Nombre_Grupo" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button_Guardar" runat="server" Text="Guardar cambios" />
        <asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" Text="Cancelar" />
        <br />
        <br />
    </asp:Panel>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
   



</asp:Content>
