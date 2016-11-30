<%@ Page Title="" Language="C#" MasterPageFile="~/InicioGz.Master" AutoEventWireup="true" CodeBehind="ConsultaPresupuesto.aspx.cs" Inherits="VentanaGzWeb.Consultas.ConsultaPresupuesto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;" class="text-center" >
        <tr>
            <td style="height: 23px"><span style="font-size: xx-large; font-family:Forte; color: #000066"><strong>Consulta Presupuesto&nbsp; <span class="auto-style16" style="font-size: xx-large; font-family:Arial">
                <asp:Image ID="UsuarioImagen" runat="server" Height="98px" ImageUrl="~/Imagenes/SEO-icon (2).png" Width="103px" />
                <br />
                </span>
                </strong></span><br />
            </td>
        </tr>
        <tr>
            <td>
                Buscar Por
                <asp:DropDownList ID="PresupuestoDropDownList" runat="server" Height="21px" Width="111px">
                    <asp:ListItem>Proyecto Id</asp:ListItem>
                    <asp:ListItem>Cliente Id</asp:ListItem>
                </asp:DropDownList>
            &nbsp;
                <asp:TextBox ID="BuscarTextBox" runat="server"></asp:TextBox>
&nbsp;
                <asp:Button ID="BuscarButton" runat="server" Text="Buscar" CssClass="btn btn-primary" Width="82px" OnClick="BuscarButton_Click" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;
                </td>
        </tr>
        <tr>
            <td>
                <table class="nav-justified">
                    <tr>
                        <td style="width: 376px">&nbsp;</td>
                        <td>
                <asp:GridView ID="PresupuestoGridView" runat="server" Height="284px" Width="390px" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Detalle" HeaderText="Descripción" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Total Pie" />
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
                <br />
                
                <asp:Button ID="ImprimirButton" CssClass="btn btn-success" runat="server" Text="Imprimir" Width="95px" OnClick="ImprimirButton_Click" />
                
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            </td>
        </tr>
    </table>
</asp:Content>
