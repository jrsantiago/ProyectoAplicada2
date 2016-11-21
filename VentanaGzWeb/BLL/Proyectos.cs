﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
   public class Proyectos : ClaseMaestra
    {
        public int ProyectoId { get; set; }
        public int ClienteId { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        public float Total { get; set; }
        public List <ProyectosDetalle> Detalle { get; set; }
        public List<Longitud> ListaLongitud { get; set; }

        public Proyectos()
        {
            this.ProyectoId = 0;
            this.ClienteId = 0;
            this.Descripcion = "";
            this.Fecha = "";
            this.Total = 0;
            this.Detalle = new List<ProyectosDetalle>();
            this.ListaLongitud = new List<Longitud>();
        }
        public void AgregarTrabajos(int ProyectoId,string Descripcion, float Ancho, float Altura,float Pie, float Precio)
        {
            this.Detalle.Add(new ProyectosDetalle(ProyectoId, Descripcion, Ancho, Altura, Pie, Precio));
        }

        public override bool Insertar()
        {
            DbVentana cone = new DbVentana();
            int Retornar = 0;
        
            object Identity;
            try
            {
                Identity = cone.ObtenerValor(String.Format("Insert Into Proyectos(Fecha,Total,ClienteId) values(Convert(datetime,'{0}',5),{1},{2}) SELECT @@Identity",this.Fecha ,this.Total, this.ClienteId));
                int.TryParse(Identity.ToString(), out Retornar);
                if (Retornar > 0)
                {
                    foreach (ProyectosDetalle item in this.Detalle)
                    {
                        cone.Ejecutar(String.Format("Insert Into ProyectosDetalle(ProyectoId,Descripcion,Pie,Ancho,Altura,Precio) Values({0},'{1}',{2},{3},{4},{5})", Retornar, item.Descripcion, item.Pie, item.Ancho, item.Altura, item.Precio));
                    }
                   
                }
                return Retornar > 0;
            }catch(Exception ex)
            {
                throw ex;
            }
           
        }

        public override bool Editar()
        {
            DbVentana cone = new DbVentana();
            int Retornar = 0;
            object Identity;
            try
            {
               Identity = cone.Ejecutar(String.Format("Update Proyectos set Descripcion='{0}',Fecha='{1}',Total={2} where ProyectoId={3} SELECT @@Identity", this.Descripcion, this.Fecha, this.Total,this.ProyectoId));
                int.TryParse(Identity.ToString(), out Retornar);
                if (Retornar>0)
                {
                    cone.Ejecutar(String.Format("Delete from ProyectosDetalle where ProyectoId = {0}", this.ProyectoId));
                    foreach(ProyectosDetalle item in Detalle)
                    {
                        cone.Ejecutar(String.Format("Insert Into ProyectosDetalle(ProyectoId,Descripcion,Pie,Ancho,Altura,Cantidad,Precio) Values({0},'{1}',{2},{3},{4},{6})", Retornar, item.Descripcion, item.Pie, item.Ancho, item.Altura,item.Precio));
                    }   
                    

                }

            }catch(Exception ex)
            {
                throw ex;
            }
            return Retornar>0;

        }

        public override bool Eliminar()
        {
            bool Retornar = false;
            DbVentana cone = new DbVentana();

            try
            {
                Retornar = cone.Ejecutar(String.Format("Delete from Proyectos where ProyectoId={0}; " + "Delete from ProyectosDetalle where ProyectoId={0}", this.ProyectoId));

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
            DataTable dtDetalle = new DataTable();

            bool Retornar = false;
            try
            {
                dt = cone.ObtenerDatos("Select * from Proyectos where ProyectoId = "+IdBuscado);
                if (dt.Rows.Count > 0)
                {
                    this.ProyectoId = (int)dt.Rows[0]["ProyectoId"];
                    this.ClienteId = (int)dt.Rows[0]["ClienteId"];
                    this.Fecha = dt.Rows[0]["Fecha"].ToString();
                    this.Total = Convert.ToSingle(dt.Rows[0]["Total"]);

                    dtDetalle = cone.ObtenerDatos(String.Format("Select * from ProyectosDetalle where ProyectoId ={0}",IdBuscado));
                
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        AgregarTrabajos(1,row["Descripcion"].ToString(),Convert.ToSingle(row["Ancho"]), Convert.ToSingle(row["Altura"]),Convert.ToSingle(row["Pie"]), Convert.ToSingle(row["Precio"]));
                    }
            
                }
                      return dt.Rows.Count > 0;
            }
            catch(Exception)
            {
                Retornar = false;
            }
            return Retornar;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            DbVentana cone = new DbVentana();
            DataTable dt = new DataTable();
            string OrdenFinal = "";

            if (!Orden.Equals(""))
                OrdenFinal = " Order by " + Orden;
            return dt = cone.ObtenerDatos(String.Format("Select " + Campos + "from Proyecto as p inner join  ProyectosDetalle pd on p.ProyectoId = pd.ProyectoId where " + Condicion + " " + OrdenFinal));
                
        }
        public float Precio(string TexAncho,string TexAltura,string Trabajo)
        {
            Trabajos tra = new Trabajos();
            float Ancho = 0;
            float Altura = 0;
            float Resultado = 0;
            float Rtotal = 0;
            float PieNormal = 0;
            float Pieminimo = 0;

            float.TryParse(TexAncho, out Ancho);
            float.TryParse(TexAltura, out Altura);

            Pieminimo = tra.ObtenerMinimoPie(Trabajo);
            PieNormal = tra.ObtenerPie(Trabajo);
            Resultado = Ancho * Altura /144;

            if (Resultado < Pieminimo )
            {
                Rtotal = Pieminimo * PieNormal;
            }
            else
            {
              Rtotal = Resultado * PieNormal;
            }

            return Rtotal;
         
        }
        public void AgregarLongitud(string Trabajo, float Ancho, float Altura)
        {
            this.ListaLongitud.Add(new Longitud(Trabajo, Ancho, Altura));
        }
        public DataTable ListaConsulta(string Campos, string Condicion, string Orden)
        {
            DbVentana cone = new DbVentana();
            DataTable dt = new DataTable();
        
            string OrdenFinal = "";
            if (!Orden.Equals(""))
                OrdenFinal = "Order by " + Orden;

            return dt = cone.ObtenerDatos(String.Format("Select " + Campos + " from ProyectosDetalle as D inner join Proyectos P on D.ProyectoId = P.ProyectoId " + Condicion + Orden));
        }
   

    }
}
