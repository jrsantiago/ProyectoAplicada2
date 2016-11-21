<%@ Page Title="" Language="C#" MasterPageFile="~/InicioGz.Master" AutoEventWireup="true" CodeBehind="ConsultaClientes.aspx.cs" Inherits="VentanaGzWeb.Consultas.ConsultaClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
        <dt class="text-center" style="font-family:Forte; font-size: xx-large; color: #000066; height: 161px;">
            <table style="width:100%;">
                <tr>
                    <td style="height: 86px"></td>
                </tr>
                <tr>
                    <td>Consulta Clientes
                <span  style="font-size: xx-large; font-family: Forte" class="auto-style16" ><asp:Image ID="UsuarioImagen" ImageUrl='~/Imagenes/Cliente or usuario.png' runat="server" Height="98px" Width="103px" /></span></td>
                </tr>
            </table>
        </dt>
        <p>
        </p>
        <p>
        </p>

        <p style="height: 47px">
     
      
            <table class="text-center" style="width:100%;">
                <tr>
                    <td>

            <tb class="text-center" style="font-size: large">
                &nbsp;Buscar Cliente Por:
            
                <asp:DropDownList CssClass="text-center" ID="ClienteDropDownList" runat="server" Width="175px" Height="22px">
                    <asp:ListItem>Id</asp:ListItem>
                    <asp:ListItem>Nombre</asp:ListItem>
                    <asp:ListItem>Cedula</asp:ListItem>
                    <asp:ListItem>Email</asp:ListItem>
                    <asp:ListItem>Todos los Clientes</asp:ListItem>
                </asp:DropDownList>
&nbsp;<asp:TextBox ID="BuscarTextBox" runat="server" Height="22px" Width="144px"></asp:TextBox>

            &nbsp; <asp:Button ID="BuscarButton" runat="server" CssClass="btn btn-primary" Text="Buscar" Width="104px" OnClick="BuscarButton_Click" />
                
                </tb>

                    </td>
                </tr>
            </table>
     
      
    <dt class="text-center">
        
        <table style="width:100%;">
            <tr>
                <bt>
                                        <td>&nbsp;</td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td>
                                        <asp:GridView ID="ClienteGridView" runat="server" Height="312px" style="margin-left: 88px" Width="625px" AutoGenerateColumns="False" >
                                            <Columns>
                                                <asp:BoundField DataField="ClienteId" HeaderStyle-BackColor="#5880D7" ItemStyle-BackColor="White" ItemStyle-BorderWidth="2px" HeaderStyle-BorderWidth="3px" HeaderText="Id" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Nombre" HeaderStyle-BackColor="#5880D7" ItemStyle-BackColor="White" ItemStyle-BorderWidth="2px" HeaderStyle-BorderWidth="3px" HeaderText="Nombre" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Telefono" HeaderStyle-BackColor="#5880D7" ItemStyle-BackColor="White" ItemStyle-BorderWidth="2px" HeaderStyle-BorderWidth="3px" HeaderText="Telefono" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Cedula" HeaderStyle-BackColor="#5880D7" ItemStyle-BackColor="White" ItemStyle-BorderWidth="2px" HeaderStyle-BorderWidth="3px" HeaderText="Cedula" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Direccion" HeaderStyle-BackColor="#5880D7" ItemStyle-BackColor="White" ItemStyle-BorderWidth="2px" HeaderStyle-BorderWidth="3px" HeaderText="Dirección" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Email" HeaderStyle-BackColor="#5880D7" ItemStyle-BackColor="White" ItemStyle-BorderWidth="2px" HeaderStyle-BorderWidth="3px" HeaderText="Email" >
                                                </asp:BoundField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                              
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                            &nbsp;</td>
                                            </bt>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        
    </dt>
        
</asp:Content>
