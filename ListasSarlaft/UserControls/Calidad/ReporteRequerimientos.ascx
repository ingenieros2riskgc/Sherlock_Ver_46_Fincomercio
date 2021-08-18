<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReporteRequerimientos.ascx.cs"
    Inherits="ListasSarlaft.UserControls.Calidad.ReporteRequerimientos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<style type="text/css">
    .gridViewHeader a:link {
        text-decoration: none;
    }

    .FondoAplicacion {
        background-color: Gray;
        filter: alpha(opacity=80);
        opacity: 0.8;
    }

    .scrollingControlContainer {
        overflow-x: hidden;
        overflow-y: scroll;
    }

    .scrollingCheckBoxList {
        border: 1px #808080 solid;
        margin: 10px 10px 10px 10px;
        height: 200px;
    }

    .popup {
        border: Silver 1px solid;
        color: #060F40;
        background: #ffffff;
    }

    .no-visible {
        display: none
    }
</style>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table align="center" bgcolor="#EEEEEE">
            <tr align="center" bgcolor="#333399">
                <td>
                    <asp:Label ID="Label1" runat="server" ForeColor="White" Text="Reporte de estado de requerimientos"
                        Font-Bold="False" Font-Names="Calibri" Font-Size="Large" Width="400px"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <table id="tbGridSelccion" runat="server" align="center">
            <tr align="center">
                <td>
                    <table>
                        <tr align="left">
                            <td bgcolor="#BBBBBB">
                                <asp:Label ID="LopcionComentarios" runat="server" Text="Tipo de reporte" Font-Names="Calibri"
                                    Font-Size="Small"></asp:Label>
                            </td>
                            <td bgcolor="#EEEEEE">
                                <asp:DropDownList ID="DDLopcionesComentarios" runat="server" Width="250px" Font-Names="Calibri"
                                    Font-Size="Small" AutoPostBack="True" OnSelectedIndexChanged="DDLopcionesComentarios_SelectedIndexChanged">
                                    <asp:ListItem Value="0">--Seleccione una opción--</asp:ListItem>
                                    <asp:ListItem Value="1">Abierto</asp:ListItem>
                                    <asp:ListItem Value="2">Asignado</asp:ListItem>
                                    <asp:ListItem Value="3">En desarollo</asp:ListItem>
                                    <asp:ListItem Value="4">En catalogación</asp:ListItem>
                                    <asp:ListItem Value="5">En pruebas</asp:ListItem>
                                    <asp:ListItem Value="6">Devuelto</asp:ListItem>
                                    <asp:ListItem Value="7">Certificado</asp:ListItem>
                                    <asp:ListItem Value="8">En producción</asp:ListItem>
                                    <asp:ListItem Value="9">Cerrado</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>            
        </table>

        <%--<br />
        <div id="Div0" runat="server" visible="false" class="ColumnStyle">
            <table id="Tbuttons" class="tabla" align="center" width="25%">
                <tr align="center">
                    <td>Exportar a Excel:
                    </td>
                    <td>
                        <asp:ImageButton ID="ImButtonExcelExportReporte" runat="server" ImageUrl="~/Imagenes/Icons/excel.png" OnClick="ImButtonExcelExportReporte_Click" />
                    </td>
                </tr>
            </table>
        </div>--%>

        <br />
        <table align="center">
        <tr align="center">
            <td style="margin-left: 40px">
                <asp:GridView ID="gvGesReq" runat="server" CellPadding="4" EnableModelValidation="True" 
                    ForeColor="#333333" GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="False"
                    ShowHeaderWhenEmpty="True" BorderStyle="Solid" HorizontalAlign="Center" Font-Names="Calibri" Font-Size="Small" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                    <Columns>
                        <asp:BoundField DataField="idGESREQ" HeaderText="Id Requerimiento" Visible="false"></asp:BoundField>
                        <asp:BoundField DataField="Empresa" HeaderText="Empresa" ItemStyle-HorizontalAlign="Center" ></asp:BoundField>
                        <asp:BoundField DataField="Usuario" HeaderText="Usuario" ItemStyle-HorizontalAlign="Center" ></asp:BoundField>
                        <asp:BoundField DataField="NumeroREQ" HeaderText="Número Requerimiento" ItemStyle-HorizontalAlign="Center" ></asp:BoundField>
                        <asp:BoundField DataField="FechaCreacionGESREQ" HeaderText="Fecha de registro" ItemStyle-HorizontalAlign="Center" Visible="true" ></asp:BoundField>
                        <asp:BoundField DataField="TipoFalla" HeaderText="Tipo de falla" ItemStyle-HorizontalAlign="Center" Visible="true" ></asp:BoundField>
                        <asp:BoundField DataField="GrupoAsignado" HeaderText="Grupo Asignado" ItemStyle-HorizontalAlign="Center" Visible="true"></asp:BoundField>
                        <asp:BoundField DataField="Encargado" HeaderText="Encargado" ItemStyle-HorizontalAlign="Center" Visible="true" ></asp:BoundField>
                        <asp:BoundField DataField="Estado" HeaderText="Estado" ItemStyle-HorizontalAlign="Center" Visible="true"></asp:BoundField>
                        <asp:BoundField DataField="Criticidad" HeaderText="Criticidad" ItemStyle-HorizontalAlign="Center" Visible="true" ></asp:BoundField>
                        <asp:BoundField DataField="FechaVencimientoGESREQ" HeaderText="Fecha de vencimiento" ItemStyle-HorizontalAlign="Center" Visible="true" ></asp:BoundField>
                    </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="White" Font-Bold="True" ForeColor="White"></FooterStyle>
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" CssClass="gridViewHeader"></HeaderStyle>
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left"></RowStyle>
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                        <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>
                        <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>
                        <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
                </asp:GridView>
            </td>
        </tr>
        </table>





        <asp:ModalPopupExtender ID="mpeMsgBox" runat="server" TargetControlID="btndummy"
            PopupControlID="pnlMsgBox" OkControlID="btnAceptar" BackgroundCssClass="FondoAplicacion"
            Enabled="True" DropShadow="true">
        </asp:ModalPopupExtender>
        <asp:Button ID="btndummy" runat="server" Text="Button" Style="display: none" />
        <asp:Panel ID="pnlMsgBox" runat="server" Width="400px" Style="display: none;" BorderColor="#575757"
            BackColor="#FFFFFF" BorderStyle="Solid">
            <table width="100%">
                <tr class="topHandle" style="background-color: #5D7B9D">
                    <td colspan="2" align="center" runat="server" id="tdCaption">&nbsp;
                        <asp:Label ID="lblCaption" runat="server" Text="Atención" Font-Names="Calibri" Font-Size="Small"></asp:Label><br />
                    </td>
                </tr>
                <tr>
                    <td style="width: 60px" valign="middle" align="center">
                        <asp:Image ID="imgInfo" runat="server" ImageUrl="~/Imagenes/Icons/icontexto-webdev-about.png" />
                    </td>
                    <td valign="middle" align="left">
                        <asp:Label ID="lblMsgBox" runat="server" Font-Names="Calibri" Font-Size="Small"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="2">
                        <asp:Button ID="btnAceptar" runat="server" Text="Ok" Font-Names="Calibri" Font-Size="Small" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
