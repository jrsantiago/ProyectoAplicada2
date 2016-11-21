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
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ProyectoCalendar.Visible = false;
                ProyectoSegundoCalendar.Visible = false;

            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            DbVentana cone = new DbVentana();
            Proyectos pro = new Proyectos();
            DataTable dt = new DataTable();
            string Text = "";
            string orden = "";

            if (string.IsNullOrWhiteSpace(BuscarTextBox.Text) && ProyectoDropDownList.Text != "Fecha")
            {
                Utilitarios.ShowToastr(this, "Error Campo Bacio", "Mensaje", "error");
            }
            else
            {
               

                    if (ProyectoDropDownList.Text == "Fecha")
                    {
                        Text = " where P.Fecha ";
                        orden = " between Convert(datetime,'" + PriFechaTextBox0.Text + "',5) AND Convert(datetime,'" + SegFechaTextBox.Text + "',5) ";
                    }


                    else if (ProyectoDropDownList.Text == "Id de Cliente")
                    {
                        Text = " where P.ClienteId = ";
                        orden = BuscarTextBox.Text;
                    }

                    else if (ProyectoDropDownList.Text == "Id de Proyecto")
                    {
                        Text = " where D.ProyectoId = ";
                        orden = BuscarTextBox.Text;
                    }

                    ProyectoGridView.DataSource = pro.ListaConsulta("*", Text, orden);
                    ProyectoGridView.DataBind();

                if (ProyectoGridView.Rows.Count == 0)
                {
                    Utilitarios.ShowToastr(this, "Id incorrecto", "Mensaje", "error");
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
            if(ProyectoDropDownList.SelectedIndex == 2)
            {
                PrimeraImageUpdateButton.Visible = true;
                SegundaImageUpdateButton0.Visible = true;
            }
            else
            {
                PrimeraImageUpdateButton.Visible = false;
                SegundaImageUpdateButton0.Visible = false;
                PriFechaTextBox0.Visible = false;
                SegFechaTextBox.Visible = false;
            }
        }
    }
}