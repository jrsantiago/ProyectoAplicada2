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
    public partial class ReporteProyectoWebForm : System.Web.UI.Page
    {
   
        protected void Page_Load(object sender, EventArgs e)
        {
            
                if (!IsPostBack)
                {
                    string Text = Request.QueryString["Text"];
                    string Orden = Request.QueryString["Orden"];

                    Proyectos mate = new Proyectos();

                    ProyectoReportViewer.LocalReport.DataSources.Clear();
                    ProyectoReportViewer.ProcessingMode = ProcessingMode.Local;


                    ProyectoReportViewer.LocalReport.ReportPath = @"Reportes\ReportProyecto.rdlc";

                    ReportDataSource source = new ReportDataSource("Proyecto", mate.ListaConsulta("*", Text, Orden));

                    ProyectoReportViewer.LocalReport.DataSources.Add(source);
                    ProyectoReportViewer.LocalReport.Refresh();
                }


        }
    }
}