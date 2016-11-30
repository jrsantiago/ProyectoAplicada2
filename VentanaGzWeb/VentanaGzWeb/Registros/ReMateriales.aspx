<%@ Page Title="" Language="C#" MasterPageFile="~/InicioGz.Master" AutoEventWireup="true" CodeBehind="ReMateriales.aspx.cs" Inherits="VentanaGzWeb.Registros.ReMateriales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td style="width: 323px">
                &nbsp;</td>
            <td style="font-family:Forte" colspan="2">
                <h1 class="text-center"> <asp:Image ID="ProductoImagen" runat="server" Height="117px" ImageUrl='~/Imagenes/gear-icon.png' Width="137px" /></h1>
                <h1 style="width: 366px"><span style="color: #000066"><strong>&nbsp;Registro Materiales&nbsp;</strong></span>&nbsp; </h1>
            </td>
        </tr>

        <tr class="text-center">
            <td style="width: 323px; height: 74px;">
                </td>
            <td style="height: 74px; width: 175px;" class="text-center">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblIdMateriales" runat="server">Id Materiales</asp:Label>
            </td>
            <td style="width: 106px; height: 74px;">
                <asp:TextBox ID="txtIdMateriales" runat="server" Width="146px"></asp:TextBox>
            </td>
            <td class="text-left" style="width: 533px; height: 74px;">
                &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtIdMateriales" ErrorMessage="Campo Id Material Vacio" Font-Size="X-Large" ForeColor="#CC0000" ValidationGroup="vgM">*</asp:RequiredFieldValidator>
                &nbsp;
                <asp:LinkButton runat="server" Text="Buscar</span>" CssClass="btn btn-primary" Width="93px" Height="32px" ID="btnBuscarMateriales" OnClick="BuscarButton_Click" ValidationGroup="vgM" />
                &nbsp;</td>
        </tr>

        <tr>

            <td style="width: 323px; height: 34px;">
                </td>

            <td style="height: 34px; width: 175px;" class="text-right">
                <br />
                <asp:Label ID="lblDetalle" runat="server">Descripcion Materiales</asp:Label>
            &nbsp;&nbsp;&nbsp;
            </td>
            <td colspan="2" style="height: 35px">
                <br />
                <asp:TextBox ID="txtDetalle" runat="server" Style="margin-left: 0px" Width="236px"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDetalle" ErrorMessage="Campo Descripcion Material Vacio" Font-Size="X-Large" ForeColor="#CC0000" ValidationGroup="vgM1">*</asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td style="width: 323px; height: 40px;">
                </td>
            <td style="height: 35px; width: 175px;" class="text-right">
                <asp:Label ID="lblUnidad" runat="server">Unidad</asp:Label>
            &nbsp;&nbsp;&nbsp;
            </td>
            <td colspan="2" style="height: 40px">
                <asp:TextBox ID="txtUnidad" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUnidad" ErrorMessage="Campo Unidad Vacio" Font-Size="X-Large" ForeColor="#CC0000" ValidationGroup="vgM1">*</asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td style="width: 323px; height: 28px;">
                &nbsp;</td>
            <td style="height: 35px; width: 175px;" class="text-right">
                <asp:Label ID="lblCantidad" runat="server">Cantidad</asp:Label>
            &nbsp;&nbsp;&nbsp;
            </td>
            <td colspan="2" style="height: 35px">
                <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCantidad" ErrorMessage="Campo Cantidad Vacio" Font-Size="X-Large" ForeColor="#CC0000" ValidationGroup="vgM1">*</asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td style="width: 323px; height: 36px;">
                &nbsp;</td>
            <td style="height: 36px; width: 175px;" class="text-right">
                <asp:Label ID="lblPrecio" runat="server">Precio</asp:Label>
            &nbsp;&nbsp;&nbsp;
            </td>
            <td colspan="2" style="height: 3px">
                <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPrecio" ErrorMessage="Campo Precio Vacio" Font-Size="X-Large" ForeColor="#CC0000" ValidationGroup="vgM1">*</asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td style="width: 323px">
                &nbsp;</td>
            <td class="text-center" style="width: 175px">
                <br />
                <asp:LinkButton runat="server" Text="Guardar"  CssClass="btn btn-primary" Width="93px" Height="33px" ID="btnGuardar" OnClick="GuardarButton_Click" ValidationGroup="vgM1" />  
            </td>
            <td style="width: 106px">
                 <br />
                
<asp:LinkButton runat="server" Text="Limpiar</span>" CssClass="btn btn-success" Width="93px" Height="33px" ID="btnLimpiar" OnClick="LimpiarButton_Click" />
            </td>
            <td style="width: 533px" class="text-left">    
                 <br />
                  <asp:LinkButton runat="server" Text="Eliminar</span>" CssClass="btn btn-danger" Width="93px" Height="33px" ID="btnEliminar" OnClick="EliminarButton_Click" ValidationGroup="vgM" />
            </td>
        </tr>

        <tr>
            <td style="width: 323px">
                <asp:ValidationSummary ID="ValidationSummary4" runat="server" ForeColor="#CC0000" ValidationGroup="vgM1" Width="170px" />
                <asp:ValidationSummary ID="ValidationSummary3" runat="server" ForeColor="#CC0000" ValidationGroup="vgM" Width="170px" />
            </td>
            <td class="text-center" style="width: 175px">
                &nbsp;</td>
            <td style="width: 106px">
                 &nbsp;</td>
            <td style="width: 533px" class="text-left">    
                 <br />
                 <br />
            </td>
        </tr>
    </table>

</asp:Content>
