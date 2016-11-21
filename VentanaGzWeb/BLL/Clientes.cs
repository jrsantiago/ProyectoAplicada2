using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    public class Clientes : ClaseMaestra
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string  Direccion { get; set; }
        public string Cedula { get; set; }
        public string Email { get; set; }
        public List<Clientes>Listar { get; set; }

        public Clientes()
        {
            this.ClienteId = 0;
            this.Nombre = "";
            this.Telefono = "";
            this.Direccion = "";
            this.Cedula = "";
            this.Email = "";
            this.Listar = new List<Clientes>();

        }
        public override bool Insertar()
        {
            DbVentana cone = new DbVentana();
            bool Retornar = false;
            try
            {
                Retornar = cone.Ejecutar(String.Format("Insert into Clientes(Nombre,Telefono,Cedula,Direccion,Email)Values('{0}','{1}','{2}','{3}','{4}')", this.Nombre, this.Telefono, this.Cedula, this.Direccion, this.Email));

            }catch(Exception ex)
            {
                throw ex;
            }
            return Retornar;
        }

        public override bool Editar()
        {
            DbVentana cone = new DbVentana();
            bool Retornar = false;
            try
            {
                Retornar = cone.Ejecutar(String.Format("Update Clientes set Nombre='{0}',Telefono='{1}',Cedula='{2}',Direccion='{3}',Email='{4}' where ClienteId={5} ", this.Nombre, this.Telefono, this.Cedula, this.Direccion, this.Email, this.ClienteId));

            }catch(Exception ex)
            {
                throw ex;
            }
            return Retornar;
        }

        public override bool Eliminar()
        {
            DbVentana cone = new DbVentana();
            bool Retornar = false;
            try
            {
                Retornar = cone.Ejecutar(String.Format("Delete from Clientes where ClienteId= ", this.ClienteId));

            }catch(Exception ex)
            {
                throw ex;
            }
            return Retornar;
        }

        public override bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();
            DbVentana cone = new DbVentana();
            bool Retornar = false;
            try
            {
                dt = cone.ObtenerDatos(String.Format("Select * from Clientes where ClienteId = {0}",IdBuscado));

                if(dt.Rows.Count>0)
                {
                    this.ClienteId = (int)dt.Rows[0]["ClienteId"];
                    this.Nombre = dt.Rows[0]["Nombre"].ToString();
                    this.Telefono =  dt.Rows[0]["Telefono"].ToString();
                    this.Cedula = dt.Rows[0]["Cedula"].ToString();
                    this.Direccion = dt.Rows[0]["Direccion"].ToString();
                    this.Email = dt.Rows[0]["Email"].ToString();

                    Retornar = true;
                }

            }catch(Exception ex)
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
           

            return dt = cone.ObtenerDatos(String.Format("Select " + Campos + " from Clientes " + Condicion + campo, Orden));
        }

        public string ValidarCliente(string Nombre)
        {
            DbVentana cone = new DbVentana();
            DataTable dt = new DataTable();
            string nombre= "";
          dt=cone.ObtenerDatos(String.Format("Select Nombre from Clientes where Nombre = '{0}'", Nombre));

            if(dt.Rows.Count > 0)
            {
                nombre = dt.Rows[0]["Nombre"].ToString();
            }
            else nombre = "no";

            return nombre;
        }
        public bool ValidarCedula(string Cedula)
        {
            bool Retornar = false;
            DataTable dt = new DataTable();

            dt = this.Listado("Cedula", "where Cedula= " + Cedula, "Cedula ASC");
            if (dt.Rows.Count > 0)
            {
                Retornar = true;
            }

            return Retornar;
        }
        public bool ValidarEmail(string Email)
        {
            bool Retornar = false;
            DataTable dt = new DataTable();

            dt = this.Listado("Email", "where Email= " + Email, "Email ASC");
            if (dt.Rows.Count > 0)
            {
                Retornar = true;
            }
            return Retornar;
        }
    }
}
