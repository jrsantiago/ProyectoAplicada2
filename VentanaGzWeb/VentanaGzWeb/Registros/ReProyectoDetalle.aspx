<%@ Page Title="" Language="C#" MasterPageFile="~/InicioGz.Master" AutoEventWireup="true" CodeBehind="ReProyectoDetalle.aspx.cs" Inherits="VentanaGzWeb.Registros.ReProyectoDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="text-center" style="height: 87px"> Proyecto Id
                <asp:TextBox ID="BuscarIdTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                <asp:Button ID="BuscarProyectoButton" runat="server" CssClass="btn btn-primary" OnClick="BuscarProyectoButton_Click" Text="Buscar" Width="90px" />
            </td> 
        </tr>
        <tr>
            <td class="text-center">&nbsp;&nbsp; 
                        </td>
        </tr>
        <tr>
            <td>
                <table style="width: 100%; height: 172px;">
                    <tr>
                        <td class="text-center" style="height: 72px"> Cliente Id <asp:TextBox ID="BuscarClienteTextBox" runat="server" ValidationGroup="vg"></asp:TextBox>
&nbsp;&nbsp;<asp:Button ID="BuscarClienteButton" CssClass="btn btn-primary" runat="server" Text="Buscar" Width="91px" OnClick="BuscarClienteButton_Click" ValidationGroup="vgc" />
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="BuscarClienteTextBox" ErrorMessage="Campo Cliente Vacio" ForeColor="#CC0000" style="font-size: x-large" ValidationGroup="vgc">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text-center" style="height: 62px">Cliente&nbsp;
                            <asp:TextBox ID="ClienteTextBox" runat="server" Width="168px" ReadOnly="True"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Fecha&nbsp;
                            <asp:TextBox ID="FechaTextBox" runat="server" Height="25px" Width="84px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    </tr>
                    <tr>
                        <td class="text-center" style="height: 55px"> Articulo &nbsp;<asp:DropDownList ID="TrabajoDropDownList" runat="server" Height="27px" Width="162px">
                            </asp:DropDownList>
&nbsp;&nbsp;Ancho&nbsp;
                            <asp:TextBox ID="AnchoTextBox" runat="server" Width="68px"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="AnchoTextBox" ErrorMessage="Campo Ancho Vacio" ForeColor="#CC0000" style="font-size: x-large" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                            &nbsp; Atura&nbsp;
                            <asp:TextBox ID="AlturaTextBox" runat="server" Width="68px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="AlturaTextBox" ErrorMessage="Campo Altura Vacio" ForeColor="#CC0000" style="font-size: x-large" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="AgregarButton" runat="server" Text="Agregar" Width="113px" OnClick="AgregarButton_Click" ValidationGroup="vg" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text-right" style="height: 113px">
                            <table class="nav-justified">
                                <tr>
                                    <td style="width: 125px" class="auto-style13">&nbsp;</td>
                                    <td style="width: 661px">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <div style=" vertical-align: top; overflow: auto; width: 744px; height:
375px" >
                                        <asp:GridView ID="DetalleGridView" runat="server" Height="335px" style="margin-left: 88px" Width="582px" AutoGenerateColumns="False" OnRowDataBound="DetalleGridView_RowDataBound">
                                            <Columns>
                                                <asp:BoundField DataField="Descripcion" HeaderStyle-BackColor="#5880D7" ItemStyle-BackColor="White" ItemStyle-BorderWidth="2px" HeaderStyle-BorderWidth="3px" HeaderText="Descripcion" >
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
                                            <br />

Total&nbsp;&nbsp; <asp:TextBox ID="TotalTextBox" runat="server" Width="74px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <br />
                                            <br />
                                            <asp:GridView ID="ResumenGridView" runat="server" AutoGenerateColumns="False" Width="372px">
                                                <Columns>
                                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                                                    <asp:BoundField DataField="AnchoTotal" HeaderText="Ancho Total" />
                                                    <asp:BoundField DataField="AlturaTotal" HeaderText="Altura Total" />
                                                    <asp:BoundField DataField="PieTotal" HeaderText="PieTotal" />
                                                </Columns>
                                            </asp:GridView>
                                   </div>
                                      <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC0000" ValidationGroup="vg" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="#CC0000" ValidationGroup="vgc" />
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
                    &nbsp;
                    &nbsp;
                    &nbsp;&nbsp;<asp:Button ID="GuardarButton" CssClass="btn btn-primary" runat="server" Text="Guardar" Width="99px" OnClick="GuardarButton_Click" />
&nbsp;&nbsp;
                <asp:Button ID="LimpiarButton" runat="server" CssClass="btn btn-success" Text="Limpiar" Width="99px" OnClick="LimpiarButton_Click1" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="EliminarButton" CssClass="btn btn-danger" runat="server" Text="Eliminar" Width="99px" />
            </td>
        </tr>
    </table>
</asp:Content>
