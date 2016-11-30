<%@ Page Title="" Language="C#" MasterPageFile="~/InicioGz.Master" AutoEventWireup="true" CodeBehind="ConsultaProyecto.aspx.cs" Inherits="VentanaGzWeb.Consultas.ConsultaProyecto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table  class="text-center" style="width:100%; height: 209px;">
        <tr style="font-family:Forte">
            <td class="auto-style16" style="font-size: xx-large ;color: #0B0664">Consulta Proyectos&nbsp;
                <span  style="font-size: xx-large; font-family:Arial; width: 512px;" class="auto-style16" ><asp:Image ID="UsuarioImagen" ImageUrl='~/Imagenes/SEO-icon (2).png' runat="server" Height="66px" Width="67px" /></span>
                <table style="width:100%;">
                    <tr>
                        <td style="font-size: large; font-family:Arial; color: #000000; height: 76px;">Buscar por 
                            <asp:DropDownList ID="ProyectoDropDownList" runat="server" Height="22px" Width="170px" OnSelectedIndexChanged="ProyectoDropDownList_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem>Id de Cliente</asp:ListItem>
                                <asp:ListItem Value="Id de Proyecto"></asp:ListItem>
                                <asp:ListItem>Fecha</asp:ListItem>
                            </asp:DropDownList>
&nbsp;<asp:TextBox ID="BuscarTextBox" runat="server" Height="22px"></asp:TextBox>
&nbsp; 
                            <asp:Button CssClass="btn btn-primary" ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="font-size: large; font-family:Arial; color: #000000">
                            <asp:Label ID="FechaDesdeLabel" runat="server" Text="Desde"></asp:Label>
                     
                            <asp:TextBox ID="PriFechaTextBox0" runat="server" Width="105px" AutoPostBack="True" Visible="False"></asp:TextBox>
&nbsp;              
                            <asp:ImageButton ID="PrimeraImageUpdateButton" runat="server" ImageUrl="/Imagenes/event-search-icon.png" Width="36px" OnClick="PrimeraImageUpdateButton_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            <asp:Label ID="FechaHastaLabel" runat="server" Text="Hasta"></asp:Label>
                            <asp:TextBox ID="SegFechaTextBox" runat="server" Width="103px"></asp:TextBox>
&nbsp;<asp:ImageButton ID="SegundaImageUpdateButton0" runat="server" ImageUrl="/Imagenes/event-search-icon.png" Width="36px" OnClick="SegundaImageUpdateButton0_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width:100%;">
                                <tr>
                                    <td style="width: 155px; font-family:'Arial Unicode MS'">
                                        <asp:Calendar  ID="ProyectoSegundoCalendar" runat="server" Height="200px" Width="220px"  BackColor="White"  BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" ShowGridLines="True" OnSelectionChanged="ProyectoSegundoCalendar_SelectionChanged">
                                            <DayHeaderStyle BackColor="#5880D7" Font-Bold="True" Height="1px" />
                                            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                            <OtherMonthDayStyle ForeColor="#CC9966" />
                                            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                            <SelectorStyle BackColor="#FFCC66" />
                                            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                                        </asp:Calendar>
                                        <asp:Calendar  ID="ProyectoCalendar" runat="server" Height="200px" Width="220px"  BackColor="White"  BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" ShowGridLines="True" OnSelectionChanged="ProyectoCalendar_SelectionChanged">
                                            <DayHeaderStyle BackColor="#5880D7" Font-Bold="True" Height="1px" />
                                            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                            <OtherMonthDayStyle ForeColor="#CC9966" />
                                            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                            <SelectorStyle BackColor="#FFCC66" />
                                            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                                        </asp:Calendar>
                                    </td>
                                    <td style="font-family:'Arial Unicode MS'">
                                        <asp:GridView ID="ProyectoGridView" runat="server" Height="312px" style="margin-left: 88px; font-size: medium;" Width="625px" AutoGenerateColumns="False" >
                                            <Columns>
                                                <asp:BoundField DataField="ProyectoId" HeaderStyle-BackColor="#5880D7" ItemStyle-BackColor="White" ItemStyle-BorderWidth="2px" HeaderStyle-BorderWidth="3px" HeaderText="Id" >
<HeaderStyle BackColor="#5880D7" BorderWidth="3px"></HeaderStyle>

<ItemStyle BackColor="White" BorderWidth="2px"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ClienteId" HeaderStyle-BackColor="#5880D7" ItemStyle-BackColor="White" ItemStyle-BorderWidth="2px" HeaderStyle-BorderWidth="3px" HeaderText="Id Cliente" >
<HeaderStyle BackColor="#5880D7" BorderWidth="3px"></HeaderStyle>

<ItemStyle BackColor="White" BorderWidth="2px"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ProductoId" HeaderStyle-BackColor="#5880D7" ItemStyle-BackColor="White" ItemStyle-BorderWidth="2px" HeaderStyle-BorderWidth="3px" HeaderText="ProductoId" >
<HeaderStyle BackColor="#5880D7" BorderWidth="3px"></HeaderStyle>

<ItemStyle BackColor="White" BorderWidth="2px"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Pie" HeaderStyle-BackColor="#5880D7" ItemStyle-BackColor="White" ItemStyle-BorderWidth="2px" HeaderStyle-BorderWidth="3px" HeaderText="Pie" >
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
                                                <asp:BoundField DataField="Precio" HeaderStyle-BackColor="#5880D7" ItemStyle-BackColor="White" ItemStyle-BorderWidth="2px" HeaderStyle-BorderWidth="3px" HeaderText="Precio" >
<HeaderStyle BackColor="#5880D7" BorderWidth="3px"></HeaderStyle>

<ItemStyle BackColor="White" BorderWidth="2px"></ItemStyle>
                                                </asp:BoundField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                              
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                            </td>
                                </tr>
                                <tr>
                                    <td " style="width: 155px">&nbsp;</td>
                                    <td class="text-left"> 
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            <asp:Button CssClass="btn btn-success " ID="ImprimirButton" runat="server" Text="Imprimir" OnClick="ImprimirButton_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
