<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportePresupuestoWebForm.aspx.cs" Inherits="VentanaGzWeb.Reportes.ReportePresupuesto" %><%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ReportePresupuesto</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
    </div>
        <rsweb:ReportViewer ID="PresupuestoReportViewer" runat="server" Height="733px" Width="1078px">
        </rsweb:ReportViewer>
    </form>
</body>
</html>
