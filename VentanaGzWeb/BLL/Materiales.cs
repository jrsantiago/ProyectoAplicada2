using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BLL
{
   public class Materiales : ClaseMaestra
    {

        public int MaterialId { get; set; }
        public string Detalle { get; set; }
        public string Unidad { get; set; }
        public float Cantidad { get; set; }
        public float Precio { get; set; }
        public List<Materiales> Listar { get; set; }
        public Materiales()
        {
            this.MaterialId = 0;
            this.Detalle = "";
            this.Unidad = "";
            this.Cantidad = 0;
            this.Precio = 0;
            this.Listar = new List<Materiales>();
        }
        public override bool Buscar(int IdBuscado)
        {
            DbVentana cone = new DbVentana();
            DataTable dt = new DataTable();
            bool Retornar = true;

            try
            {
                dt = cone.ObtenerDatos(String.Format("Select * from Materiales where MaterialId = {0}", IdBuscado));
                if (dt.Rows.Count > 0)
                {
                    this.Detalle = dt.Rows[0]["Detalle"].ToString();
                    this.Unidad = dt.Rows[0]["Unidad"].ToString();
                    this.Cantidad = Convert.ToSingle(dt.Rows[0]["Cantidad"]);
                    this.Precio = Convert.ToSingle(dt.Rows[0]["Precio"]);
                }

            }
            catch (Exception ex)
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
                Retornar = cone.Ejecutar(String.Format("Update Materiales set Detalle='{0}',Unidad='{1}',Cantidad={3},Precio={4} where MaterialId={5}", this.Detalle, this.Unidad, this.Cantidad, this.Precio, this.MaterialId));

            }
            catch (Exception ex)
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
                Retornar = cone.Ejecutar(String.Format("Delete from Materiales where MaterialId={0}", this.MaterialId));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Retornar;
        }

        public override bool Insertar()
        {
            DbVentana cone = new DbVentana();
            bool Retornar = false;

            try
            {
                Retornar = cone.Ejecutar(String.Format("Insert into Materiales(Detalle,Unidad,Cantidad,Precio) Values('{0}','{1}',{2},{3})", this.Detalle, this.Unidad, this.Cantidad, this.Precio));              

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

            if(Condicion != string.Empty)
            {
                dt = cone.ObtenerDatos(String.Format("Select " + Campos + " from Materiales " + Condicion + campo, Orden));
            }
            else
            {
                dt = cone.ObtenerDatos(String.Format("Select * from Materiales "));
            }

            return dt;
        }
     

    }
    
}
