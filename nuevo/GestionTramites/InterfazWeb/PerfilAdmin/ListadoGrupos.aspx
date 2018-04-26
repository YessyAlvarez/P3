<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilAdmin.Master" AutoEventWireup="true" CodeBehind="ListadoGrupos.aspx.cs" Inherits="InterfazWeb.Master.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Listado de grupos <br />
    ------------------
    <br />
    <br />
    <asp:Panel ID="Panel1" runat="server" Height="102px">
        <asp:ListBox ID="ListBox_listaGrupos" runat="server" DataTextField="Nombre" DataValueField="Codigo" AutoPostBack="True"></asp:ListBox>
    </asp:Panel>
</asp:Content>
