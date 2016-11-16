<%@ Page Title="" Language="C#" MasterPageFile="~/InicioGz.Master" AutoEventWireup="true" CodeBehind="ConsultaUsuario.aspx.cs" Inherits="VentanaGzWeb.Consultas.ConsUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style14" style="height: 162px; width: 366px">&nbsp;</td>
            <td class="auto-style14" style="height: 162px">&nbsp;<asp:Label BorderColor="Blue" ID="Label" runat="server" Text="Id" CssClass="auto-style7"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox BorderColor="CadetBlue" CssClass="text-info" ID="IdTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button CssClass="btn btn-primary" ID="BuscarButton" runat="server" Text="Buscar" Width="90px" OnClick="BuscarButton_Click" Height="27px" />
                <br />
                <br />
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="UsuarioLabel" runat="server" style="font-size: x-large; color: #000080" Text="Buscar Usuario"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 219px; width: 366px">&nbsp;</td>
            <td style="height: 219px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Image ID="UsuarioImagen" ImageUrl='~/Imagenes/Office-Customer-Male-Light-icon.png' runat="server" Height="98px" Width="140px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Repeater ID="Repeater" runat="server">
                                <ItemTemplate>

                                    <table style="border:1px solid #A55129;background-color:#FFF7E7">
                                        <tr>
                                            <td style="width: 200px">
                                            <asp:Image ID="imgEmployee" ImageUrl='<%# Eval("Imagenes")%>' runat="server" />

                                            </td>
                                            <td style="width: 200px">
                                                ......
                                                <table>
                                                   <tr>
                                                       <td>
                                                           <b>Id</b>
                                                       </td>
                                                       <td>
                                                           <asp:Label ID="lblId" runat="server" Text='<%#Eval("UsuariosId") %>'></asp:Label>
                                                       </td>
                                                   </tr>
                                                    <tr>
                                                        <td>
                                                            <b>Nombre Usuario </b>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("UserName") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <b>Contrasena</b>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("Contrasena") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>

                                               .......
                                            </td>
                                        </tr>

                                </ItemTemplate>
                            </asp:Repeater>
                        &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 366px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
