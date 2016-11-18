using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Data;

namespace VentanaGzWeb.UserControl
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Trabajos tra = new Trabajos();

            dt = tra.Listado("*", "0=0", "ORDER BY Descripcion");
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
                UserControlDropDownList.Items.Add(Convert.ToString(tra.Listado("*", "0=0", "ORDER BY Descripcion").Rows[i]["Descripcion"]));
        }

    }
}