<%@ Page Title="" Language="C#" MasterPageFile="~/MastersPages/Admin.Master" AutoEventWireup="true" CodeBehind="ClasificacionN3.aspx.cs" Inherits="ListasSarlaft.Formularios.Eventos.ClasificacionN3" %>
<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCN" TagName="Clasifiacioness" Src="~/UserControls/Eventos/ClasificacionN3.ascx" %>


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCN:Clasifiacioness ID="Clasifiacioness" runat="server" />
</asp:Content>
