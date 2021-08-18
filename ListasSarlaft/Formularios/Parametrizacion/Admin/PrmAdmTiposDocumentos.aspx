<%@ Page Title="" Language="C#" MasterPageFile="~/MastersPages/Admin.Master" AutoEventWireup="true" CodeBehind="PrmAdmTiposDocumentos.aspx.cs" Inherits="ListasSarlaft.Formularios.Parametrizacion.Admin.PrmAdmTiposDocumentos" %>
<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="CCTD" TagName="TiposDocumentos" Src="~/UserControls/Parametrizacion/TiposDocumentos.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CCTD:TiposDocumentos ID="TiposDocumentos" runat="server"/>
</asp:Content>
