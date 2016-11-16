using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace VentanaGzWeb.Consultas
{
    public partial class ConsUsuario : System.Web.UI.Page
    {
        Usuario usu = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public int convertirId()
        {
            int id = 0;
            int.TryParse(IdTextBox.Text, out id);
            return id;
        }    

        protected void BuscarButton_Click(object sender, EventArgs e)
        {

            DbVentana cone = new DbVentana();

            int id = convertirId();
            if (string.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                Response.Write("<script>alert('Introdusca Id')</script>");
            }
            else
            {

                DataSet ds = usu.GetData(convertirId());

                Repeater.DataSource = ds;
                Repeater.DataBind();
                UsuarioImagen.Visible = false;
                UsuarioLabel.Visible = false;

            }



        }

        //protected void ImprimirButton_Click(object sender, EventArgs e)
        //{
        //    int id = convertirId();
        //    Usuario usu = new Usuario();

        //    UsuarioReportViewer.LocalReport.DataSources.Clear();
        //    UsuarioReportViewer.ProcessingMode = ProcessingMode.Local;

        //    UsuarioReportViewer.LocalReport.ReportPath = @"Reportes\ReportUsuario1.rdlc";

        //    ReportDataSource source = new ReportDataSource("Usuario", usu.Listado("*", "UsuarioId=" + IdTextBox.Text, " "));

        //    UsuarioReportViewer.LocalReport.DataSources.Add(source);
        //    UsuarioReportViewer.LocalReport.Refresh();



        //}
    }
}