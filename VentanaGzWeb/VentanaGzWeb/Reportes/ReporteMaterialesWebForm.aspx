<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteMaterialesWebForm.aspx.cs" Inherits="VentanaGzWeb.Reportes.ReporteMaterialesWebForm" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ReporteMateriales</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
 
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="MaterialesReportViewer" runat="server" Height="609px" Width="1265px">
        </rsweb:ReportViewer>
 
    </div>
    </form>
</body>
</html>
