<%@ Page Title="" Language="C#" MasterPageFile="~/InicioGz.Master" AutoEventWireup="true" CodeBehind="ConsultaMateriales.aspx.cs" Inherits="VentanaGzWeb.Consultas.ConsultaMaeriales" %><%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%; height: 489px;">
        <tr>
            <td class="auto-style14" style="height: 74px; width: 1345px">&nbsp;</td>
            <td class="auto-style14" style="height: 74px; width: 808px;"><span style="font-size: xx-large; font-family:Forte; color: #0B0664;"><strong>Consulta </strong>M<span style="font-weight: bold">ateriales</span></span>&nbsp; <span class="auto-style16" style="font-size: xx-large; font-family:Arial">
                <asp:Image ID="UsuarioImagen" runat="server" Height="98px" ImageUrl="~/Imagenes/SEO-icon (2).png" Width="103px" />
                </span>
            </td>
            <td class="auto-style14" style="height: 74px">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style14" style="height: 74px; width: 1345px"></td>
            <td class="auto-style14" style="height: 74px; width: 808px;">&nbsp; Buscar Por
                <asp:DropDownList ID="MaterialesDropDownList" runat="server" Height="22px" Width="184px">
                    <asp:ListItem Value="Todos Los Materiales">Todos Los Materiales</asp:ListItem>
                    <asp:ListItem>Nombre</asp:ListItem>
                    <asp:ListItem Value="Id">Id</asp:ListItem>
                </asp:DropDownList>
&nbsp;&nbsp; <asp:TextBox ID="BuscarTextBox" runat="server" Width="78px"></asp:TextBox>
&nbsp;&nbsp;
                </td>
            <td class="auto-style14" style="height: 74px">
                <asp:Button ID="BuscarButton" CssClass="btn btn-primary" runat="server" OnClick="BuscarButton_Click" Text="Buscar" />
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 1345px; height: 319px"></td>
            <td style="height: 319px; width: 808px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:GridView ID="MaterialesGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="270px" Width="464px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Detalle" HeaderText="Detalle" />
                        <asp:BoundField DataField="Unidad" HeaderText="Unidad" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" />
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
            <td style="height: 319px"></td>
        </tr>
        <tr>
            <td class="auto-style19" style="width: 1345px">&nbsp;</td>
            <td style="width: 808px">&nbsp;
                <asp:Button ID="ImprimirButton" runat="server"  CssClass="btn btn-success" OnClick="ImprimirButton_Click" Text="Imprimir" />


                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 1345px">
                <table style="width: 100%;">
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
            <td style="width: 808px">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
