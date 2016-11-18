using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL;
using DAL;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace BLL
{
   public class Usuario : ClaseMaestra
    {

        public int UsuarioId { get; set; }
        public string Contrasena { get; set; }
        public string UserName { get; set; }
        public string Nombre { get; set; }
        public int Restriccion { get; set; }
        public string Imagenes { get; set; }
        public List<Usuario> listar { get; set; }

        DataTable dt = new DataTable();
        public Usuario()
        {
            this.UsuarioId = 0;
            this.Contrasena = "";
            this.UserName = "";
            this.Restriccion = 0;
            this.listar = new List<Usuario>();
            this.Imagenes = "";
        }

        public override bool Insertar()
        {
            DbVentana cone = new DbVentana();
            bool retornar = false;
            try
            {
                retornar = cone.Ejecutar(String.Format("Insert into Usuarios(Contrasena,UserName,Restriccion,Nombre,Imagenes) Values('{0}','{1}', {2},'{3}','{4}')", this.Contrasena, this.UserName, this.Restriccion, this.Nombre, this.Imagenes));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retornar;
        }

        public override bool Editar()
        {
            bool retornar = false;
            DbVentana cone = new DbVentana();
            try
            {
                retornar = cone.Ejecutar(String.Format("Update Usuarios set Contrasena='{0}',UserName='{1}',Nombre='{2}',Restriccion = {3} WHERE UsuarioId = {4}", this.Contrasena, this.UserName, this.Nombre, this.Restriccion, this.UsuarioId));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retornar;
        }

        public override bool Eliminar()
        {
            bool Retornar = false;
            DbVentana cone = new DbVentana();
            try
            {
                Retornar = cone.Ejecutar(String.Format("Delete From Usuarios where UsuarioId ={0}", this.UsuarioId));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Retornar;
        }

        public override bool Buscar(int IdBuscado)
        {
            DbVentana cone = new DbVentana();
           
            bool Retornar = true;
            try
            {
                dt = cone.ObtenerDatos(String.Format("Select * from Usuarios where UsuariosId = {0}", IdBuscado));
                if (dt.Rows.Count > 0)
                {
                    this.UsuarioId = (int)dt.Rows[0]["UsuariosId"];
                    this.Contrasena = dt.Rows[0]["Contrasena"].ToString();
                    this.UserName = dt.Rows[0]["UserName"].ToString();
                    this.Nombre = dt.Rows[0]["Nombre"].ToString();
                    this.Restriccion = (int)dt.Rows[0]["Restriccion"];
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Retornar;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            DbVentana cone = new DbVentana();
            DataTable dt = new DataTable();
            string campo = " '{0}'";

            string OrdenFinal = "";
            if (!Orden.Equals(""))
                OrdenFinal = "Order by " + Orden;


            return dt= cone.ObtenerDatos(String.Format("Select " + Campos + " from Usuarios "+Condicion+campo,Orden));
        }
        public DataSet GetData(DataTable dt)
        {
            int id = 0;
            DbVentana cone = new DbVentana();

            if(dt.Rows.Count > 0)
            {
                id = (int)dt.Rows[0]["UsuariosId"];
            }
            

            string Cs = ConfigurationManager.ConnectionStrings["VentanaDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(Cs))
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Usuarios where UsuariosId=" + id, con);
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
        }
        public string ValidarUserNombre(string UserName)
        {
            string Validar = "";
            DbVentana cone = new DbVentana();

            dt = cone.ObtenerDatos(String.Format("Select UserName from Usuarios where UserName='{0}'", UserName));
            if(dt.Rows.Count > 0)
            {
                Validar = dt.Rows[0]["UserName"].ToString();
            }
            return Validar;
        }
        public string ValidarContrasena(string Contrasena)
        {
            string Validar = "";
            DbVentana cone = new DbVentana();

            dt = cone.ObtenerDatos(String.Format("Select Contrasena from Usuarios where Contrasena='{0}'", Contrasena));
            if (dt.Rows.Count > 0)
            {
                Validar = dt.Rows[0]["Contrasena"].ToString();
            }
            return Validar;
        }

    }
}
