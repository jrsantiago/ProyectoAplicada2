<%@ Page Title="" Language="C#" MasterPageFile="~/InicioGz.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VentanaGzWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table>
      
                
            </td>
             <td>

            </td>
        </tr>
        <%-- TR Header --%>
    </table>




    <table  border="1" style="width:100%; height:100%">
        <tr>
            <td style="text-align:center" colspan="2">
               <h1>
                                      <b>Inicio de Seccion</b></h1> 
            </td>
        </tr>
        <tr  style="width:20px;height:20px">
            <td style="width:20px">
                 <img src="Imagenes/ImgUser.PNG" />
            </td>
            <td>
             
                <asp:TextBox ID="UserNameTextBox" runat="server" BackColor="#6699ff" BorderColor="#0a0aa7" CssClass="tex" ForeColor="White" Height="27px" ValidationGroup="vg" Width="234px"></asp:TextBox>
            </td>
        </tr>
        <tr  style="height:20px">
            <td>
                <img height="80" src="Imagenes/ImgPass.png" />
            </td>
            <td style="align-items:center">
                 <asp:TextBox ID="ContraseñaTextBox0" runat="server" BackColor="#6699ff" BorderColor="#0a0aa7" CssClass="tex" ForeColor="White" Height="27px" style="margin-left: 0px" TextMode="Password" ValidationGroup="vg" Width="234px"></asp:TextBox>
                <asp:ImageButton ID="EntrarImageButton" runat="server" BorderColor="#0b0565" Height="27px" ImageUrl="~/Imagenes/Enter.png" OnClick="EntrarImageButton_Click" ValidationGroup="vg" Width="40px" />   
            </td>
        </tr>
        <tr>
            <td colspan="3">
                 <asp:ValidationSummary ID="ValidationSummary2" runat="server" style="font-size: large; color: #FFFFFF" ValidationGroup="vg" Height="33px" Width="236px" />
            </td>
        </tr>
    </table>

</asp:Content>
