<%@ Page Title="" Language="C#" MasterPageFile="~/InicioGz.Master" AutoEventWireup="true" CodeBehind="ConsultaUsuario.aspx.cs" Inherits="VentanaGzWeb.Consultas.ConsUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style14" style="height: 162px; width: 524px">&nbsp;</td>
            <td class="auto-style14" style="height: 162px">&nbsp;<br />
                <br />
                <span  style="font-size: xx-large; font-family: Forte" class="auto-style16" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Consulta Usuario <asp:Image ID="UsuarioImagen" ImageUrl='~/Imagenes/Office-Customer-Male-Light-icon.png' runat="server" Height="98px" Width="140px" /></span><br />
                <br />
                <br />
                Buscar Por&nbsp; <asp:DropDownList ID="UsuarioDropDownList" runat="server" Height="22px" Width="192px">
                    <asp:ListItem Value="Id"></asp:ListItem>
                    <asp:ListItem>Nombre de Usuario</asp:ListItem>
                    <asp:ListItem>Nombre</asp:ListItem>
                    <asp:ListItem>Todos los Usuarios</asp:ListItem>
                </asp:DropDownList>
&nbsp; &nbsp;<asp:TextBox BorderColor="CadetBlue" CssClass="text-info" ID="BuscarTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button CssClass="btn btn-primary" ID="BuscarButton" runat="server" Text="Buscar" Width="90px" OnClick="BuscarButton_Click" Height="27px" />
                <span class="auto-style16"><span style="font-size: x-large; font-family: Forte" >
                <br />
                </span></span></td>
        </tr>
        <tr>
            <td style="height: 219px; width: 524px">&nbsp;</td>
            <td style="height: 219px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Repeater ID="Repeater" runat="server">
                                <ItemTemplate>

                                    <table style="border:1px solid #A55129;background-color:#dedddd; border-color:#5059fb">
                                        <tr>
                                            <td style="width: 200px">
                                            <asp:Image ID="imgEmployee" ImageUrl='<%# Eval("Imagenes")%>' runat="server" />

                                            </td>
                                            <td style="width: 200px">
                                                
                                                <table>
                                                   <tr>
                                                       <td>
                                                          <h4> <b style="color:#040d69">Id:</b></h4>
                                                       </td>
                                                       <td>
                                                           <asp:Label ID="lblId" runat="server" Text='<%#Eval("UsuariosId") %>'></asp:Label>
                                                       </td>
                                                   </tr>
                                                    <tr>
                                                        <td>
                                                            <h4><b style="color:#040d69">Nombre Usuario: </b></h4>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("UserName") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                           <h4> <b style="color:#040d69">Contrasena:</b></h4>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("Contrasena") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>

                                               
                                            </td>
                                        </tr>

                                </ItemTemplate>
                            </asp:Repeater>
                        &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 524px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
