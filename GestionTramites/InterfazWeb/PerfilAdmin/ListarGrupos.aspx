<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PerfilAdmin.Master" AutoEventWireup="true" CodeBehind="ListarGrupos.aspx.cs" Inherits="InterfazWeb.Master.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
&nbsp;&nbsp;&nbsp; <asp:Panel ID="Panel1" runat="server" Height="102px">
    <asp:ListBox ID="ListBox_listaGrupos" runat="server" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
</asp:Panel>
</asp:Content>
