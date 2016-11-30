<%@ Page Title="" Language="C#" MasterPageFile="~/InicioGz.Master" AutoEventWireup="true" CodeBehind="ReProyectoDetalle.aspx.cs" Inherits="VentanaGzWeb.Registros.ReProyectoDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="text-center" style="height: 97px; font-family:Forte"> &nbsp; <asp:Image ID="ProductoImagen" runat="server" Height="138px" ImageUrl='~/Imagenes/gear-icon.png' Width="168px" />
                <strong>
                <h1 style="color: #000066">Registro Proyecto</h1></strong></td> 
        </tr>
        <tr>
            <td class="text-center">Proyecto Id
                &nbsp;<asp:TextBox ID="BuscarIdTextBox" runat="server" ValidationGroup="vgPro"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="BuscarIdTextBox" ErrorMessage="Campo Proyecto Id Vacio" ForeColor="#CC0000" style="font-size: x-large" ValidationGroup="vgPro">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="BuscarIdTextBox" ErrorMessage="Solo Caracteres Numericos" ForeColor="#CC0000" style="font-size: x-large" ValidationExpression="[0-9]+" ValidationGroup="vgPro">*</asp:RegularExpressionValidator>
                <asp:Button ID="BuscarProyectoButton" runat="server" CssClass="btn btn-primary" OnClick="BuscarProyectoButton_Click" Text="Buscar" Width="90px" ValidationGroup="vgPro" />
                <br />
                <br />
                <br />
                        </td>
        </tr>
        <tr>
            <td>
                <table style="width: 100%; height: 172px;">
                    <tr>
                        <td class="text-center" style="height: 72px"> Cliente Id <asp:TextBox ID="BuscarClienteTextBox" runat="server" ValidationGroup="vgD" Width="149px"></asp:TextBox>
&nbsp;&nbsp;<asp:Button ID="BuscarClienteButton" CssClass="btn btn-primary" runat="server" Text="Buscar" Width="91px" OnClick="BuscarClienteButton_Click" ValidationGroup="vgD" />
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="BuscarClienteTextBox" ErrorMessage="Campo Cliente Vacio" ForeColor="#CC0000" style="font-size: x-large" ValidationGroup="vgD">*</asp:RequiredFieldValidator>
                        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="BuscarClienteTextBox" ErrorMessage="Solo Caracteres Numericos" ForeColor="#CC0000" style="font-size: x-large" ValidationExpression="[0-9]+" ValidationGroup="vgD">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text-center" style="height: 62px">Cliente&nbsp;
                            <asp:TextBox ID="ClienteTextBox" runat="server" Width="120px" ReadOnly="True" ValidationGroup="vgD"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ClienteTextBox" ErrorMessage="Campo Cliente Vacio" ForeColor="#CC0000" style="font-size: x-large" ValidationGroup="vgc">*</asp:RequiredFieldValidator>
                            &nbsp;&nbsp;&nbsp;&nbsp; Fecha&nbsp;
                            <asp:TextBox ID="FechaTextBox" runat="server" Height="25px" Width="80px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="text-center" style="height: 55px"> Producto &nbsp;<asp:DropDownList ID="TrabajoDropDownList" runat="server" Height="27px" Width="162px">
                            </asp:DropDownList>
&nbsp;&nbsp;Ancho&nbsp;
                            <asp:TextBox ID="AnchoTextBox" runat="server" Width="68px" ValidationGroup="vgD"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="AnchoTextBox" ErrorMessage="Campo Ancho Vacio" ForeColor="#CC0000" style="font-size: x-large" ValidationGroup="vgc">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="AnchoTextBox" ErrorMessage="Solo Caracteres Numericos" ForeColor="#CC0000" style="font-size: x-large" ValidationExpression="[0-9]+" ValidationGroup="vgc">*</asp:RegularExpressionValidator>
&nbsp;Atura&nbsp;
                            <asp:TextBox ID="AlturaTextBox" runat="server" Width="68px" ValidationGroup="vgD"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="AlturaTextBox" ErrorMessage="Campo Altura Vacio" ForeColor="#CC0000" style="font-size: x-large" ValidationGroup="vgc">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="AlturaTextBox" ErrorMessage="Solo Caracteres Numericos" ForeColor="#CC0000" style="font-size: x-large" ValidationExpression="[0-9]+" ValidationGroup="vgc">*</asp:RegularExpressionValidator>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="AgregarButton" runat="server" Text="Agregar" Width="113px" OnClick="AgregarButton_Click" ValidationGroup="vgc" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text-right" style="height: 113px">
                            <table class="nav-justified">
                                <tr>
                                    <td style="width: 125px" class="auto-style13">&nbsp;</td>
                                    <td style="width: 661px" class="text-center">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <div style=" vertical-align: top; overflow: auto; width: 744px; height:
375px; margin-bottom: 1px;" class="text-right" >
                                        <asp:GridView ID="DetalleGridView" runat="server" Height="335px" style="margin-left: 88px" Width="582px" AutoGenerateColumns="False" OnRowDataBound="DetalleGridView_RowDataBound">
                                            <Columns>
                                                <asp:BoundField DataField="ProductoId" HeaderStyle-BackColor="#5880D7" ItemStyle-BackColor="White" ItemStyle-BorderWidth="2px" HeaderStyle-BorderWidth="3px" HeaderText="ProductoId" >
<HeaderStyle BackColor="#5880D7" BorderWidth="3px"></HeaderStyle>

<ItemStyle BackColor="White" BorderWidth="2px"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Ancho" HeaderStyle-BackColor="#5880D7" ItemStyle-BackColor="White" ItemStyle-BorderWidth="2px" HeaderStyle-BorderWidth="3px" HeaderText="Ancho" >
<HeaderStyle BackColor="#5880D7" BorderWidth="3px"></HeaderStyle>

<ItemStyle BackColor="White" BorderWidth="2px"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Altura" HeaderStyle-BackColor="#5880D7" ItemStyle-BackColor="White" ItemStyle-BorderWidth="2px" HeaderStyle-BorderWidth="3px" HeaderText="Altura" >
<HeaderStyle BackColor="#5880D7" BorderWidth="3px"></HeaderStyle>

<ItemStyle BackColor="White" BorderWidth="2px"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Pie" HeaderStyle-BackColor="#5880D7" ItemStyle-BackColor="White" ItemStyle-BorderWidth="2px" HeaderStyle-BorderWidth="3px" HeaderText="Pie" >
<HeaderStyle BackColor="#5880D7" BorderWidth="3px"></HeaderStyle>

<ItemStyle BackColor="White" BorderWidth="2px"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Precio" HeaderStyle-BackColor="#5880D7" ItemStyle-BackColor="White" ItemStyle-BorderWidth="2px" HeaderStyle-BorderWidth="3px" HeaderText="Precio" >
<HeaderStyle BackColor="#5880D7" BorderWidth="3px"></HeaderStyle>

<ItemStyle BackColor="White" BorderWidth="2px"></ItemStyle>
                                                </asp:BoundField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                            
                                            </EmptyDataTemplate>
                                        </asp:GridView>

Total&nbsp;&nbsp; <asp:TextBox ID="TotalTextBox" runat="server" Width="74px" ReadOnly="True"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <br />
                                            <br />
                                           
                                   </div>
                                        <div class="text-left">
                                      <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC0000" ValidationGroup="vgD" />
                                        </div>
                                        <div class="text-left">
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="#CC0000" ValidationGroup="vgPro" />
                                       
                                        </div>
                                        <div class="text-left">
                                       
                                        <asp:ValidationSummary ID="ValidationSummary3" runat="server" ForeColor="#CC0000" ValidationGroup="vgc" />
                                        </div>
                                       </td>
                                    <td style="width: 193px">
                                        &nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="text-center" style="height: 100px">
                    &nbsp;<asp:Button ID="GuardarButton" CssClass="btn btn-primary" runat="server" Text="Guardar" Width="99px" OnClick="GuardarButton_Click" ValidationGroup="vgD" />
&nbsp;&nbsp;
                <asp:Button ID="LimpiarButton" runat="server" CssClass="btn btn-success" Text="Limpiar" Width="99px" OnClick="LimpiarButton_Click1" />
&nbsp;&nbsp;
                <asp:Button ID="EliminarButton" CssClass="btn btn-danger" runat="server" Text="Eliminar" Width="99px" OnClick="EliminarButton_Click1" ValidationGroup="vgPro" />
            </td>
        </tr>
    </table>
</asp:Content>
