﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClasificacionN3.ascx.cs" Inherits="ListasSarlaft.UserControls.Eventos.ClasificacionN3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/Sitio/OkMessageBox.ascx" TagPrefix="uc" TagName="OkMessageBox" %>

<style type="text/css">
    .gridViewHeader a:link
    {
        text-decoration: none;
    }

    .style1
    {
        width: 100%;
    }
</style>

<asp:SqlDataSource ID="sdsClasificacionN3" runat="server" ConnectionString="<%$ ConnectionStrings:SarlaftConnectionString %>"
    DeleteCommand="DELETE FROM [Eventos].[ClasificacionN3] WHERE [id] = @Id"
    InsertCommand="INSERT INTO [Eventos].[ClasificacionN3] ([nombre], [descripcion],[fecha_registro],[usuario_registro]) VALUES (@Nombre,@Descripcion, GETDATE(),@IdUsuario)"
    SelectCommand="SELECT [Id], [nombre],[descripcion], [Usuario],  CONVERT(VARCHAR(10),[fecha_registro],103) AS FechaRegistro FROM [Eventos].[ClasificacionN3], [Listas].[Usuarios] WHERE [ClasificacionN3].[usuario_registro] = [Usuarios].[IdUsuario]"
    UpdateCommand="UPDATE [Eventos].[ClasificacionN3] SET [descripcion] = @Descripcion, [nombre] = @Nombre  WHERE [id] = @Id">
    <DeleteParameters>
        <asp:Parameter Name="Id" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="Descripcion" Type="String" />
        <asp:Parameter Name="IdUsuario" Type="Int32" />
        <asp:Parameter Name="Nombre" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="Descripcion" Type="String" />
        <asp:Parameter Name="Nombre" Type="String" />
        <asp:Parameter Name="Id" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <uc:OkMessageBox ID="omb" runat="server" />
        <asp:Panel ID="pnlMsgBox" runat="server" Width="400px" CssClass="modalPopup" Style="display: none;">
            <table width="100%">
                <tr class="topHandle">
                    <td colspan="2" align="center" runat="server" id="tdCaption">
                        <asp:Label ID="lblCaption" runat="server" Text="Atención"
                            Font-Bold="False" Font-Names="Tahoma" Font-Size="11px"></asp:Label><br />
                    </td>
                </tr>
                <tr>
                    <td style="width: 60px" valign="middle" align="center">
                        <asp:Image ID="imgInfo" runat="server"
                            ImageUrl="~/Imagenes/Icons/icontexto-webdev-about.png" />
                    </td>
                    <td valign="middle" align="left">
                        <asp:Label ID="lblMsgBox" runat="server" Font-Bold="False" Font-Names="Tahoma"
                            Font-Size="11px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="2">
                        <asp:Button ID="btnImgokEliminar" runat="server" Text="Ok" OnClick="btnImgokEliminar_Click" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClientClick="$find('mypopup').hide(); return false;" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:ModalPopupExtender ID="mpeMsgBox" runat="server" PopupControlID="pnlMsgBox" BehaviorID="mypopup"
            Enabled="True" TargetControlID="btndummy" BackgroundCssClass="modalBackground" DropShadow="true">
        </asp:ModalPopupExtender>
        <asp:Button ID="btndummy" runat="server" Text="Button" Style="display: none" />
        <asp:Label ID="lblOk" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:Label ID="lblCancelar" runat="server" Text="Label" Visible="False"></asp:Label>
        <table align="center">
            <tr align="center" bgcolor="#333399">
                <td>
                    <asp:Label ID="Label13" runat="server" ForeColor="White" Text="Clasificaciones Nivel 3" Font-Bold="False"
                        Font-Names="Calibri" Font-Size="Large"></asp:Label>
                </td>
            </tr>
            <tr align="center" bgcolor="#EEEEEE" id="filaGrid" runat="server" visible="true">
                <td bgcolor="#EEEEEE">
                    <br />
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="gvClasificaciones" runat="server" CellPadding="4" DataSourceID="sdsClasificacionN3"
                                    ForeColor="#333333" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                                    DataKeyNames="id,Usuario" OnSelectedIndexChanged="gvClasificaciones_SelectedIndexChanged"
                                    ShowHeaderWhenEmpty="True" OnRowCommand="gvClasificaciones_RowCommand"
                                    HeaderStyle-CssClass="gridViewHeader" BorderStyle="Solid" GridLines="Vertical"
                                    CssClass="Apariencia" Font-Bold="False">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="Código" InsertVisible="False"
                                            ReadOnly="True" SortExpression="id">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre"
                                            SortExpression="Nombre" HtmlEncode="False"
                                            HtmlEncodeFormatString="False">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción"
                                            SortExpression="Descripcion" HtmlEncode="False"
                                            HtmlEncodeFormatString="False">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Usuario" HeaderText="Usuario"
                                            SortExpression="Usuario" Visible="False" />
                                        <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha de Creación"
                                            SortExpression="FechaRegistro">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField ShowHeader="False" HeaderText="Acción">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                    ImageUrl="~/Imagenes/Icons/edit.png" Text="Seleccionar" ToolTip="Editar" />
                                                <asp:ImageButton ID="btnImgEliminar" runat="server" CausesValidation="False" OnClick="btnImgEliminar_Click" CommandArgument="<%# Container.DataItemIndex %>"
                                                    ImageUrl="~/Imagenes/Icons/delete.png" Text="Eliminar" CommandName="Eliminar" ToolTip="Eliminar" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
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
                        <tr>
                            <td align="center">
                                <asp:ImageButton ID="imgBtnInsertar" runat="server" CausesValidation="False" CommandName="Insert"
                                    ImageUrl="~/Imagenes/Icons/Add.png" Text="Insert"
                                    OnClick="imgBtnInsertar_Click" ToolTip="Insertar" />
                            </td>
                        </tr>
                    </table>
                    <br />
                </td>
            </tr>
            <tr align="left" id="filaDetalle" runat="server" visible="false">
                <td bgcolor="#EEEEEE">

                    <table width="50%" align="center">
                        <tr id="tra" runat="server">
                            <td align="left" bgcolor="#BBBBBB">
                                <asp:Label ID="lblCodigo" runat="server" Text="Código:" CssClass="Apariencia"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtId" runat="server" Enabled="False" Width="70px"
                                    CssClass="Apariencia"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" bgcolor="#BBBBBB">
                                <asp:Label ID="lnlNombre" runat="server" Text="Nombre:" CssClass="Apariencia"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNombre" runat="server" Width="300px" CssClass="Apariencia" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
                                    ErrorMessage="Debe ingresar el Nombre." ToolTip="Debe ingresar el Nombre."
                                    ValidationGroup="iCanal" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" bgcolor="#BBBBBB">
                                <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion:" CssClass="Apariencia"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDescripcion" runat="server" Width="300px" CssClass="Apariencia" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion"
                                    ErrorMessage="Debe ingresar la descripción." ToolTip="Debe ingresar la descripción."
                                    ValidationGroup="iCanal" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" bgcolor="#BBBBBB">
                                <asp:Label ID="lblUsuario" runat="server" Text="Usuario:" CssClass="Apariencia"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtUsuario" runat="server" Width="100px" CssClass="Apariencia"
                                    Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" bgcolor="#BBBBBB">
                                <asp:Label ID="lblFechaRegistro" runat="server" Text="Fecha de Creación:" CssClass="Apariencia"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFecha" runat="server" Width="100px" CssClass="Apariencia"
                                    Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="2">
                                <table class="tablaSinBordes">
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="btnImgInsertar" runat="server" ImageUrl="~/Imagenes/Icons/guardar.png"
                                                Visible="False" OnClick="btnImgInsertar_Click" ToolTip="Guardar" ValidationGroup="iCanal"/>
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="btnImgActualizar" runat="server" ImageUrl="~/Imagenes/Icons/guardar.png"
                                                Style="text-align: right" OnClick="btnImgActualizar_Click" ToolTip="Guardar" ValidationGroup="iCanal"/>
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="btnImgCancelar" runat="server" ImageUrl="~/Imagenes/Icons/cancel.png"
                                                OnClick="btnImgCancelar_Click" ToolTip="Cancelar" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="gvClasificaciones" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>
<%--The fnClick javascript function will force the btnOk button to post back. 
(to actually achieve this we need to add a little piece of code in 
the Page_Load method of the user control.--%>
<script type="text/javascript">
    function fnClick(sender, e) {
        __doPostBack(sender, e);
    }
</script>
