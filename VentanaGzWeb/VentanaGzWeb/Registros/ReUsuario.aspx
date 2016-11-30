<%@ Page Title="" Language="C#" MasterPageFile="~/InicioGz.Master" AutoEventWireup="true" CodeBehind="ReUsuario.aspx.cs" Inherits="VentanaGzWeb.Registros.RUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%; height: 591px;">
        <tr>
            <td style="height: 167px; font-family:Forte" class="text-center"><asp:Image ID="ProductoImagen" runat="server" Height="124px" ImageUrl='~/Imagenes/Office-Customer-Male-Light-icon.png' Width="148px" />
                        <br />
               <h1 style="color: #000066"> Registro Usuario</h1></td>
        </tr>
        <tr>
            <td style="height: 95px" class="text-center">
                <br />
                &nbsp;<asp:Label ID="Label1" runat="server" Text="Id"></asp:Label>
&nbsp; <asp:TextBox ID="IdTextBox" runat="server" Width="140px" Height="22px" CssClass="auto-style5"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="IdTextBox" ErrorMessage="Campo Id Vacio" ForeColor="Red" style="font-size: x-large" ValidationGroup="vg2">*</asp:RequiredFieldValidator>
                        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="IdTextBox" ErrorMessage="Solo Caracteres Numericos" ForeColor="#CC0000" style="font-size: x-large" ValidationExpression="[0-9]+" ValidationGroup="vg2">*</asp:RegularExpressionValidator>
                    <asp:Button CssClass="btn btn-primary" ID="BuscarButton" runat="server" Height="29px" OnClick="BuscarButton_Click" Text="Buscar" Width="116px" ValidationGroup="vg2" />
                </td>
        </tr>
        <tr>
            <td style="height: 330px">
                <table style="width: 100%; height: 281px;">
                    <tr>
                        <td class="auto-style14" style="height: 35px; text-align: center;">
                    &nbsp;Nombre&nbsp;&nbsp;
                    <asp:TextBox CssClass="text-capitalize " ID="NombreTextBox" runat="server" Width="220px" ValidationGroup="vg"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="NombreTextBox" ErrorMessage="Campo Nombre Vacio" ForeColor="Red" style="font-size: x-large" ValidationGroup="vgU">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="NombreTextBox" ErrorMessage="Solo Caracteres de Letras" ForeColor="#CC0000" style="font-size: x-large" ValidationExpression="^[a-zA-Z]+(\s*[a-zA-Z]*)*[a-zA-Z]+$" ValidationGroup="vgU">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style14" style="height: 35px; text-align: center;">
                            Nombre de Usuario&nbsp; <asp:TextBox CssClass="text-capitalize " ID="UserNameTextBox" runat="server" Width="198px" ValidationGroup="vg"></asp:TextBox>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="UserNameTextBox" ErrorMessage="Campo Nombre De Usuario Vacio" ForeColor="Red" style="font-size: x-large" ValidationGroup="vgU">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="UserNameTextBox" ErrorMessage="Solo Caracteres de Letras" ForeColor="#CC0000" style="font-size: x-large" ValidationExpression="^[a-zA-Z]+(\s*[a-zA-Z]*)*[a-zA-Z]+$" ValidationGroup="vgU">*</asp:RegularExpressionValidator>
                            &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 35px; text-align: center;" class="auto-style14">&nbsp;&nbsp;&nbsp; Contraseña&nbsp;&nbsp; <asp:TextBox ID="ContrasenaTextBox" runat="server" Width="211px" ValidationGroup="vg" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ContrasenaTextBox" ErrorMessage="Campo Contraseña Vacio" ForeColor="Red" style="font-size: x-large" ValidationGroup="vgU">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="ContrasenaTextBox" ErrorMessage="Solo Caracteres de Letras" ForeColor="#CC0000" style="font-size: x-large" ValidationExpression="^[a-zA-Z]+(\s*[a-zA-Z]*)*[a-zA-Z]+$" ValidationGroup="vgU">*</asp:RegularExpressionValidator>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
                            </td>
                    </tr>
                    <tr>
                        <td class="auto-style14" style="height: 35px; text-align: center;"><span style="font-size: medium">&nbsp;&nbsp;&nbsp; Repita Contraseña</span><span style="font-size: x-large">&nbsp;<asp:TextBox ID="RepitContrasenaTextBox" runat="server" Width="210px" Height="21px" ValidationGroup="vg" TextMode="Password"></asp:TextBox>
                            &nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="ContrasenaTextBox" ControlToValidate="RepitContrasenaTextBox" ErrorMessage="Contraseñas No Coinciden" ForeColor="Red" ValidationGroup="vgU">*</asp:CompareValidator>
                            &nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style14" style="height: 35px; text-align: center;">&nbsp; Restricción&nbsp; <asp:DropDownList ID="RestriccionDropDownList" runat="server" Width="137px">
                        <asp:ListItem>Administrador</asp:ListItem>
                        <asp:ListItem>Usuario</asp:ListItem>
                    </asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    </tr>
                    <tr>
                        <td class="text-center">&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<table class="nav-justified">
                                <tr>
                                    <td style="height: 21px; width: 513px" class="text-right">&nbsp; Foto&nbsp;
                                        <br />
                                        &nbsp;</td>
                                    <td style="height: 21px">
                <asp:FileUpload ID="FotoUpload" runat="server" />
                                    </td>
                                </tr>
                            </table>
                            <div class="text-center">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" style="margin-top: 0px" ValidationGroup="vgU" Width="164px" />
                            &nbsp;<asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="Red" style="margin-top: 0px" ValidationGroup="vg2" Width="164px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text-center">
                    <asp:Button CssClass="btn btn-primary" ID="GuardarButton" runat="server" Height="29px" OnClick="GuardarButton_Click" Text="Guardar" Width="115px" ValidationGroup="vgU" />
&nbsp;
                    <asp:Button CssClass="btn btn-success" ID="LimpiarButton" runat="server" Height="29px" Text="Limpiar" Width="116px" OnClick="LimpiarButton_Click" />
                    &nbsp; <asp:Button CssClass="btn btn-danger" ID="EliminarButton" runat="server" Height="29px" Text="Eliminar" Width="116px" OnClick="EliminarButton_Click" ValidationGroup="vg2" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
                    &nbsp;
                    &nbsp;&nbsp;</td>
        </tr>
    </table>
</asp:Content>
