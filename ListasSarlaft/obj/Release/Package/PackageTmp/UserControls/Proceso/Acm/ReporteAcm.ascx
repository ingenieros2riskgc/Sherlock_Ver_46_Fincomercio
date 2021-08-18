<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReporteAcm.ascx.cs" Inherits="ListasSarlaft.UserControls.Proceso.Acm.ReporteAcm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/UserControls/Sitio/OkMessageBox.ascx" TagPrefix="uc" TagName="OkMessageBox" %>
<link href="../../../Styles/AdminSitio.css" rel="stylesheet" type="text/css" />
<style>
    .popup {
        border: Silver 1px solid;
        color: #060F40;
        background: #ffffff;
    }

    .spacing {
        height: 20px
    }

    .text-center {
        text-align: center;
        font-family: Verdana, Arial, Helvetica, sans-serif;
    }

    .auto-style1 {
        text-align: "left";
        background-color: #BBBBBB;
        height: 25px;
    }

    .auto-style2 {
        height: 25px;
    }
</style>
<asp:UpdatePanel ID="updPanel" runat="server">
    <ContentTemplate>
        <uc:OkMessageBox ID="omb" runat="server" />
        <div class="TituloLabel" id="divTitulo" runat="server">
            <asp:Label ID="Ltitulo" runat="server" ForeColor="White" Text="Reporte de Acm" Font-Bold="False"
                Font-Names="Calibri" Font-Size="Large"></asp:Label>
            </div>
            <div style="height: 20px"></div>
        <table style=" width: 60%">
            <tr>
                <td align="center">
                    <asp:Label ID="lblText" Text="Para exportar el reporte: " runat="server"></asp:Label>
                </td>
                            <td align="center">
                                
                                <asp:ImageButton ID="btnDescargarAcm" runat="server" ImageUrl="~/Imagenes/Icons/pdfImg.jpg" 
                                    ToolTip="Descargar" OnClick="btnDescargarAcm_Click" />
                            </td>
                <td>Para exportar a Excel:
                    </td>
                    <td>
                        <asp:ImageButton ID="ImButtonExcelExport" runat="server" ImageUrl="~/Imagenes/Icons/excel.png" OnClick="ImButtonExcelExport_Click" />
                    </td>
                        </tr>
        </table>
            <table style="width: 100%">
                                        <tr>
                                            <td style="width: 100%">
                                                <asp:GridView ID="gvAcm" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    ForeColor="#333333" HeaderStyle-CssClass="gridViewHeader" BorderStyle="Solid" GridLines="Vertical"
                                                    CssClass="Apariencia" Font-Bold="False" Width="100%" >
                                                    <Columns>
                                                        <asp:BoundField DataField="IdAcm" HeaderText="Id" HeaderStyle-CssClass="no-visible" ItemStyle-CssClass="no-visible" />
                                                        <asp:BoundField DataField="Codigo" HeaderText="Código" />
                                                        <asp:BoundField DataField="NombreCadenaValor" HeaderText="Cadena Valor" />
                                                        <asp:BoundField DataField="NombreMacroproceso" HeaderText="Macroproceso" />
                                                         <asp:BoundField DataField="NombreProceso" HeaderText="Proceso" />
                                                        <%--<asp:BoundField DataField="NombreSubproceso" HeaderText="Subproceso" />--%>
                                                        <asp:BoundField DataField="NombreUsuarioRegistra" HeaderText="Usuario Registra" />
                                                        <asp:BoundField DataField="NombreOrigenNoConformidad" HeaderText="Origen no conformidad" />
                                                        <asp:BoundField DataField="DescripcionNoConformidad" HeaderText="Descripcion No Conformidad" />
                                                        
                                                        
                                                        <%--<asp:BoundField DataField="NombreResponsable" HeaderText="Responsable" />--%>
                                                        <asp:BoundField DataField="NombreEstado" HeaderText="Estado" />
                                                        
                                                    </Columns>
                                                    <EditRowStyle BackColor="#999999" />
                                                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
        
    </ContentTemplate>
    <Triggers>
        
        <asp:PostBackTrigger ControlID="btnDescargarAcm" />
        <asp:PostBackTrigger ControlID="ImButtonExcelExport" />
    </Triggers>
</asp:UpdatePanel>
