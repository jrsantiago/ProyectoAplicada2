<%@ Page Title="" Language="C#" MasterPageFile="~/InicioGz.Master" AutoEventWireup="true" CodeBehind="ConsultaProducto.aspx.cs" Inherits="VentanaGzWeb.Consultas.ConsultaProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="text-center" style="font-family:Forte"><strong><h1><span style="color: #000066">Consulta Productos</span><span  style="font-size: xx-large; font-family:Arial; width: 512px;" class="auto-style16" ><asp:Image ID="UsuarioImagen" ImageUrl='~/Imagenes/SEO-icon (2).png' runat="server" Height="89px" Width="105px" /></span>
                </h1></strong>&nbsp;
                </td>
        </tr>
        <tr>
            <td class="text-center"><strong>Buscar Por&nbsp;
                <asp:DropDownList ID="DropDownList1" runat="server" Height="18px" Width="101px">
                </asp:DropDownList>
&nbsp;
                <asp:TextBox ID="BuscarTextBox" runat="server"></asp:TextBox>
&nbsp;
                <asp:Button ID="BuscarButton" CssClass="btn btn-primary" runat="server" Text="Buscar" Width="83px" />
                <br />
                </strong></td>
        </tr>
        <tr>
            <td>
                <table style="width:100%;">
                    <tr>
                        <td style="width: 443px" class="text-right">Descripción<asp:TextBox ID="DescripcionTextBox" runat="server" ReadOnly="True" style="font-weight: bold"></asp:TextBox>
&nbsp;<br />
                        </td>
                        <td>
                            &nbsp;&nbsp;<strong>
                </strong>Precio Pie<strong>&nbsp;
                <asp:TextBox ID="PieTextBox" runat="server" ReadOnly="True" style="font-weight: bold"></asp:TextBox>
&nbsp;
                </strong>Minimo Pie <strong>
                <asp:TextBox ID="MinimoPieTextBox" runat="server" ReadOnly="True" style="font-weight: bold"></asp:TextBox>
                </strong>
                            <br />
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 443px">&nbsp;</td>
                        <td>
                            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="240px" Width="388px" AutoGenerateColumns="False">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="ProductoId" HeaderText="ProductoId" />
                                    <asp:BoundField DataField="MaterialId" HeaderText="MaterialId" />
                                    <asp:BoundField DataField="Asociacion" HeaderText="Asociación" />
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
