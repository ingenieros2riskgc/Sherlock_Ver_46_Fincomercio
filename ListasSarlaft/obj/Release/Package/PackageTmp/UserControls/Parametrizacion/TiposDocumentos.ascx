<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TiposDocumentos.ascx.cs" Inherits="ListasSarlaft.UserControls.Parametrizacion.TiposDocumentos" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register Src="~/UserControls/Sitio/OkMessageBox.ascx" TagPrefix="uc" TagName="OkMessageBox" %>
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
                    <td style="width: 60px" valign="middle" align="center" >
                        <asp:Image ID="imgInfo" runat="server" 
                            ImageUrl="~/Imagenes/Icons/icontexto-webdev-about.png"/>
                    </td>
                    <td valign="middle" align="left">
                        <asp:Label ID="lblMsgBox" runat="server" Font-Bold="False" Font-Names="Tahoma" 
                            Font-Size="11px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="2">
                        <asp:Button ID="btnImgokEliminar" runat="server" Text="Ok" OnClick="btnImgokEliminar_Click" Visible="false" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClientClick="$find('mypopup').hide(); return false;"/>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:ModalPopupExtender ID="mpeMsgBox" runat="server" PopupControlID="pnlMsgBox" BehaviorId="mypopup" 
            Enabled="True" TargetControlID="btndummy" BackgroundCssClass="modalBackground"  DropShadow="true" >
        </asp:ModalPopupExtender>
        <asp:Button ID="btndummy" runat="server" Text="Button" style="display:none"/>
        <asp:Label ID="lblOk" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:Label ID="lblCancelar" runat="server" Text="Label" Visible="False"></asp:Label>

        <table align="center"  width="100%">
                <tr align="center" bgcolor="#333399">
                    <td>
                        <asp:Label ID="lblTitulo" runat="server" ForeColor="White" Text="Tipos de Documentos" Font-Bold="False"
                            Font-Names="Calibri" Font-Size="Large"></asp:Label>
                    </td>
                </tr>
            <tr align="center" bgcolor="#EEEEEE"  id="filaGrid" runat="server" visible="true">
                <td bgcolor="#EEEEEE">
                    <br />
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="gvTiposDocumentos" runat="server" CellPadding="4" 
                                    ForeColor="#333333" AllowPaging="True" AllowSorting="True" 
                                    AutoGenerateColumns="False" 
                                    ShowHeaderWhenEmpty="True" HeaderStyle-CssClass="gridViewHeader" DataKeyNames="intIdTiposDocumento"
                                    OnRowCommand="gvTiposDocumentos_RowCommand" OnPageIndexChanging="gvTiposDocumentos_PageIndexChanging"
                                    BorderStyle="Solid" GridLines="Vertical" CssClass="Apariencia" 
                                    Font-Bold="False" >
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="intIdTiposDocumento" HeaderText="Código" InsertVisible="False" ReadOnly="True"
                                            SortExpression="IdTiposDocumento" >
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="strNombreDocumento" HeaderText="Nombre Documento" 
                                            SortExpression="strNombreDocumento" InsertVisible="False" ReadOnly="True" 
                                             />
                                        <asp:BoundField DataField="strDescripcionDocumento" HeaderText="Descripción Documento" 
                                            SortExpression="strDescripcionDocumento" >
                                        <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="booEstado" HeaderText="Estado" 
                                            SortExpression="booEstado" />
                                        
                                        <asp:TemplateField ShowHeader="False" HeaderText="Acción">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnImgActualizar" runat="server" CausesValidation="False" CommandName="Select"
                                                    CommandArgument="<%# Container.DataItemIndex %>"
                                                    ImageUrl="~/Imagenes/Icons/edit.png" Text="Seleccionar" ToolTip="Editar"/>
                                                <asp:ImageButton ID="btnImgEliminar" runat="server" CausesValidation="False"  CommandArgument="<%# Container.DataItemIndex %>"
                                                    ImageUrl="~/Imagenes/Icons/delete.png" Text="Eliminar" CommandName="Eliminar" ToolTip="Eliminar"/>
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
                                <tr>
                                    <td align="right">
                                        <asp:ImageButton ID="imgBtnInsertar" runat="server" CausesValidation="False" CommandName="Insert"
                                            OnClick="imgBtnInsertar_Click"
                                            ImageUrl="~/Imagenes/Icons/Add.png" Text="Insert"  ToolTip="Insertar"/>
                                    </td>
                                </tr>
                                </td>
                                </tr>
                    </table>
                    <br />
                </td>
            </tr>
            <tr align="left" id="filaDetalle" runat="server" visible="false">
                <td bgcolor="#EEEEEE">

                        <table  class="tabla" width="100%">
                            <tr>
                                <td align="left" bgcolor="#BBBBBB">
                                    <asp:Label ID="lblId" runat="server" Text="Id:" CssClass="Apariencia"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtId" runat="server" Enabled="False" Width="70px" 
                                        CssClass="Apariencia"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" bgcolor="#BBBBBB">
                                    <asp:Label ID="lblTipoDocumento" runat="server" Text="Nombre Tipo Documento:" CssClass="Apariencia"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNombreDocumento" runat="server" Width="300px" CssClass="Apariencia"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" bgcolor="#BBBBBB">
                                    <asp:Label ID="lblDescripcionDocumento" runat="server" Text="Descripción Tipo de Documento:" CssClass="Apariencia"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDescripcion" runat="server" Width="300px" CssClass="Apariencia"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" bgcolor="#BBBBBB">
                                    <asp:Label ID="lblEstado" runat="server" Text="Estado:" CssClass="Apariencia"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlEstado" runat="server" Font-Names="Calibri" Font-Size="Small"
                                                            Width="155px">
                                                            <asp:ListItem Value="---">--Seleccione--</asp:ListItem>
                                        <asp:ListItem Value="0">Inactivo</asp:ListItem>
                                        <asp:ListItem Value="1">Activo</asp:ListItem>
                                                        </asp:DropDownList>
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
                            

                            <tr align="center">
                                <td colspan="2">
                                    <table  class="tablaSinBordes">
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="btnImgInsertar" runat="server" ImageUrl="~/Imagenes/Icons/guardar.png"
                                                    OnClick="btnImgInsertar_Click"
                                                    Visible="False"  ToolTip="Guardar"/>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="btnImgActualizar" runat="server" ImageUrl="~/Imagenes/Icons/guardar.png"
                                                    Style="text-align: right"  OnClick="btnImgActualizar_Click"
                                                    ToolTip="Guardar"/>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="btnImgCancelar" runat="server" ImageUrl="~/Imagenes/Icons/cancel.png"
                                                     ToolTip="Cancelar"/>
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
       
    </Triggers>
</asp:UpdatePanel>


<script type="text/javascript">
    function fnClick(sender, e) {
        __doPostBack(sender, e);
    }
</script>