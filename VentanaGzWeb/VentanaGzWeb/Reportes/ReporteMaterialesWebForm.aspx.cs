using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using Microsoft.Reporting.WebForms;

namespace VentanaGzWeb.Reportes
{
    public partial class ReporteMaterialesWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
            string Text = Request.QueryString["Text"];
            string Orden = Request.QueryString["Orden"];

            Materiales mate = new Materiales();

            MaterialesReportViewer.LocalReport.DataSources.Clear();
            MaterialesReportViewer.ProcessingMode = ProcessingMode.Local;


            MaterialesReportViewer.LocalReport.ReportPath = @"Reportes\MaterialesReport.rdlc";

            ReportDataSource source = new ReportDataSource("MaterialesDataSet", mate.Listado("*", Text, Orden));

            MaterialesReportViewer.LocalReport.DataSources.Add(source);
            MaterialesReportViewer.LocalReport.Refresh();
            }
  



        }
    }
}