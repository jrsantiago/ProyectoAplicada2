using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Data;

namespace VentanaGzWeb.Consultas
{
    public partial class ConsultaProyecto : System.Web.UI.Page
    {

        public string Text { get; set; }
        public string orden { get; set; }

       public ConsultaProyecto()
        {
            this.Text = "";
            this.orden = "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ProyectoCalendar.Visible = false;
                ProyectoSegundoCalendar.Visible = false;
                ImprimirButton.Visible = false;
               

                FalseControl();
               
            }
        }
        public void OrdenInsert()
        {

            if (ProyectoDropDownList.Text == "Fecha")
            {
                this.Text = " where P.Fecha ";
                this.orden = " between Convert(datetime,'" + PriFechaTextBox0.Text + "',5) AND Convert(datetime,'" + SegFechaTextBox.Text + "',5) ";
            }


            else if (ProyectoDropDownList.Text == "Id de Cliente")
            {
                this.Text = " where P.ClienteId = ";
                this.orden = BuscarTextBox.Text;
            }

            else if (ProyectoDropDownList.Text == "Id de Proyecto")
            {
                this.Text = " where D.ProyectoId = ";
                this.orden = BuscarTextBox.Text;
            }

        }
        public void FalseControl()
        {
            PrimeraImageUpdateButton.Visible = false;
            SegundaImageUpdateButton0.Visible = false;

            PriFechaTextBox0.Visible = false;
            SegFechaTextBox.Visible = false;

            FechaDesdeLabel.Visible = false;
            FechaHastaLabel.Visible = false;

        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            DbVentana cone = new DbVentana();
            Proyectos pro = new Proyectos();
            DataTable dt = new DataTable();
            

            if (string.IsNullOrWhiteSpace(BuscarTextBox.Text) && ProyectoDropDownList.Text != "Fecha")
            {
                Utilitarios.ShowToastr(this, "Error Campo Bacio", "Mensaje", "error");
            }
            else
            {

                    OrdenInsert();

                    ProyectoGridView.DataSource = pro.ListaConsulta("*", this.Text, this.orden);
                    ProyectoGridView.DataBind();

                if (ProyectoGridView.Rows.Count == 0)
                {
                    Utilitarios.ShowToastr(this, "Id incorrecto", "Mensaje", "error");
                }

                if (ProyectoGridView.Rows.Count > 0)
                {
                    ImprimirButton.Visible = true;
                }else
                {
                    ImprimirButton.Visible = false;
                }

            }
        }

        protected void PrimeraImageUpdateButton_Click(object sender, ImageClickEventArgs e)
        {
            if (ProyectoCalendar.Visible)
            {
                ProyectoCalendar.Visible = false;
            }else
            {
                ProyectoCalendar.Visible = true;
            }
        }

        protected void ProyectoCalendar_SelectionChanged(object sender, EventArgs e)
        {
            PriFechaTextBox0.Text = ProyectoCalendar.SelectedDate.ToString("dd/MM/yy");
            ProyectoCalendar.Visible = false;
        }

        protected void ProyectoSegundoCalendar_SelectionChanged(object sender, EventArgs e)
        {
            SegFechaTextBox.Text = ProyectoSegundoCalendar.SelectedDate.ToString("dd/MM/yy");
            ProyectoSegundoCalendar.Visible = false;
        }

        protected void SegundaImageUpdateButton0_Click(object sender, ImageClickEventArgs e)
        {
            if (ProyectoCalendar.Visible)
            {
                ProyectoSegundoCalendar.Visible = false;
            }
            else
            {
                ProyectoSegundoCalendar.Visible = true;
            }
        }

        protected void ProyectoDropDownList_SelectionChanged(object sender, EventArgs e)
        {

       
        }

        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            if (ProyectoGridView.Rows.Count==0)
            {
                Utilitarios.ShowToastr(this, "Error", "Mensaje", "error");
            }
            else
            {

                OrdenInsert();

                Response.Write("<script type='text/javascript'>detailedresults=window.open('/Reportes/ReporteProyectoWebForm.aspx?Text= " + this.Text + "&Orden= " + this.orden + "');</script>");

            }
        }

        protected void ProyectoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProyectoDropDownList.SelectedValue == "Fecha")
            {
                PrimeraImageUpdateButton.Visible = true;
                SegundaImageUpdateButton0.Visible = true;

                PriFechaTextBox0.Visible = true;
                SegFechaTextBox.Visible = true;

                FechaDesdeLabel.Visible = true;
                FechaHastaLabel.Visible = true;
            }
            else
            {
                FalseControl();
            }
        }
    }
}