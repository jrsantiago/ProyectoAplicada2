using System;
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
        public List<ProductosDetalle> ListaMateriales { get; set; }

        public Proyectos()
        {
            this.ProyectoId = 0;
            this.ClienteId = 0;
            this.Descripcion = "";
            this.Fecha = "";
            this.Total = 0;
            this.Detalle = new List<ProyectosDetalle>();
            this.ListaMateriales = new List<ProductosDetalle>();
           
        }
        public void AgregarTrabajos(int ProyectoId,int ProductoId, float Ancho, float Altura,float Pie, float Precio)
        {
            this.Detalle.Add(new ProyectosDetalle(ProyectoId, ProductoId, Ancho, Altura, Pie, Precio));
        }
        public void AgregarConduse(int ProductoId, int cantidad)
        {
            this.ListaMateriales.Add(new ProductosDetalle(ProductoId, cantidad));
        }

        public override bool Insertar()
        {
            DbVentana cone = new DbVentana();
            DataTable dt = new DataTable();
            int Retornar = 0;
        
            object Identity;
            try
            {
                Identity = cone.ObtenerValor(String.Format("Insert Into Proyectos(Fecha,Total,ClienteId) values(Convert(datetime,'{0}',5),{1},{2}) SELECT @@Identity",this.Fecha ,this.Total, this.ClienteId));
                int.TryParse(Identity.ToString(), out Retornar);
                if (Retornar > 0)
                {
                    object Identity2;
                    int Retornar2 = 0;
                    foreach (ProyectosDetalle item in this.Detalle)
                    {
                        //areglar ete insert (poner id del producto)
                        Identity2 = cone.ObtenerValor(String.Format("Insert Into ProyectosDetalle(ProyectoId,ProductoId,Pie,Ancho,Altura,Precio) Values({0},'{1}',{2},{3},{4},{5}) SELECT @@Identity", Retornar, item.ProductoId, item.Pie, item.Ancho, item.Altura, item.Precio));
                        int.TryParse(Identity2.ToString(), out Retornar2);

                        //con el id anterior del producto hacer un select a a la tabla productodetalle y llenar ListaMateriales
                       dt = cone.ObtenerDatos(String.Format("Select * from ProductosDetalle where ProductoId ={0}", item.ProductoId));

                           foreach (DataRow row in dt.Rows)
                            {
                               this.ListaMateriales.Add(new ProductosDetalle(Convert.ToInt32(row[2]),Convert.ToInt32(row[3])));
                            }
                      
                         //recorrer lista materiales para insertar cada material y el calculo de su valor o cantidad en la tabla pryecto conduce
                        foreach(ProductosDetalle item2 in this.ListaMateriales)
                        {
                            if(item2.Asociacion == 0)
                            {
                                item2.Cantidad = item.Ancho/12;
                            }else
                            if(item2.Asociacion == 1)
                            {
                                item2.Cantidad = item.Altura/12;
                            }
               
                            cone.Ejecutar(String.Format("Insert Into ProyectoPresupuesto(ProyectoId,MaterialId,Cantidad) Values({0},{1},{2}) ", Retornar, item2.MaterialId,item2.Cantidad));
                        }
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
            DataTable dt = new DataTable();
          
            bool Retornar = false;
            try
            {
                 Retornar = cone.Ejecutar(String.Format("Update Proyectos set Fecha = Convert(datetime,'{0}',5),Total={1} where ProyectoId={2}", this.Fecha, this.Total,this.ProyectoId));
              
                  if (Retornar)
                   {
                       cone.Ejecutar(String.Format("Delete from ProyectosDetalle where ProyectoId = {0}", this.ProyectoId));
                       cone.Ejecutar(String.Format("Delete from ProyectoPresupuesto where ProyectoId = {0}", this.ProyectoId));

                    foreach (ProyectosDetalle item in this.Detalle)
                    {
                        cone.Ejecutar(String.Format("Insert Into ProyectosDetalle(ProyectoId,ProductoId,Pie,Ancho,Altura,Precio) Values({0},{1},{2},{3},{4},{5})", this.ProyectoId, item.ProductoId, item.Pie, item.Ancho, item.Altura, item.Precio));



                        dt = cone.ObtenerDatos(String.Format("Select * from ProductosDetalle where ProductoId ={0}", item.ProductoId));

                        foreach (DataRow row in dt.Rows)
                        {
                            this.ListaMateriales.Add(new ProductosDetalle(Convert.ToInt32(row[2]), Convert.ToInt32(row[3])));
                        }

                        //recorrer lista materiales para insertar cada material y el calculo de su valor o cantidad en la tabla pryecto conduce
                        foreach (ProductosDetalle item2 in this.ListaMateriales)
                        {
                            if (item2.Asociacion == 0)
                            {
                                item2.Cantidad = item.Ancho / 12;
                            }
                            else
                            if (item2.Asociacion == 1)
                            {
                                item2.Cantidad = item.Altura / 12;
                            }else
                            {
                                item2.Cantidad = 1;
                            }

                            cone.Ejecutar(String.Format("Insert Into ProyectoPresupuesto(ProyectoId,MaterialId,Cantidad) Values({0},{1},{2}) ", this.ProyectoId, item2.MaterialId, item2.Cantidad));

                        }

                    }
                }

            }catch(Exception ex)
            {
                throw ex;
            }
            return Retornar;

        }

        public override bool Eliminar()
        {
            bool Retornar = false;
            DbVentana cone = new DbVentana();

            try
            {
                Retornar = cone.Ejecutar(String.Format("Delete from ProyectoPresupuesto where ProyectoId ={0};" + "Delete from ProyectosDetalle where ProyectoId={0}; " + "Delete from Proyectos where ProyectoId={0}; ", this.ProyectoId));
               
            }
            catch(Exception ex)
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
                        AgregarTrabajos(1,Convert.ToInt32(row["ProductoId"]),Convert.ToSingle(row["Ancho"]), Convert.ToSingle(row["Altura"]),Convert.ToSingle(row["Pie"]), Convert.ToSingle(row["Precio"]));
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
            Productos tra = new Productos();
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
      
        public DataTable ListaConsulta(string Campos, string Condicion, string Orden)
        {
            DbVentana cone = new DbVentana();
            DataTable dt = new DataTable();
        
            string OrdenFinal = "";
            if (!Orden.Equals(""))
                OrdenFinal = "Order by " + Orden;

            return dt = cone.ObtenerDatos(String.Format("Select " + Campos + " from ProyectosDetalle as D inner join Proyectos P on D.ProyectoId = P.ProyectoId " + Condicion + Orden));
        }
        public DataTable ListarPresupuesto(string Campos, string Condicion, string Orden)
        {
            DbVentana cone = new DbVentana();
            DataTable dt = new DataTable();

            string OrdenFinal = "";
            if (!Orden.Equals(""))
                OrdenFinal = "Order by " + Orden;

            return dt = cone.ObtenerDatos(String.Format("Select " + Campos + " from ProyectoPresupuesto as O inner join Proyectos P on O.ProyectoId = P.ProyectoId inner join Materiales M on M.MaterialId = O.MaterialId " + Condicion + Orden+ " GROUP BY M.Detalle ORDER BY M.Detalle;"));
        }



    }
}
