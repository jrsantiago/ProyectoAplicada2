using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
   public class Productos : ClaseMaestra
    {
        public int ProductoId { get; set; }
        public int Clienteid { get; set; }
        public string Descripcion { get; set; }
        public float Pie {get; set;}
        public float MinimoPie { get; set; }
        public List<ProductosDetalle>Detalle { get; set; }

        public Productos()
        {
            this.ProductoId = 0;
            this.Descripcion = "";
            this.Pie = 0;
            this.MinimoPie = 0;

          
            this.Detalle = new List<ProductosDetalle>();
        }
        public void AgregarProducto(string Material,int Asociacion)
        {
            this.Detalle.Add(new ProductosDetalle(Material, Asociacion));
        }
        public override bool Insertar()
        {
            int Retornar = 0;
            DbVentana cone = new DbVentana();
            object Identity = null;
            try
            {
                Identity = cone.ObtenerValor(String.Format("Insert into Productos(Descripcion,Pie,MinimoPie) Values('{0}',{1},{2}) SELECT @@Identity",this.Descripcion, this.Pie,this.MinimoPie));
                int.TryParse(Identity.ToString(), out Retornar);
                
                if(Retornar >0)
                {
                 
                    foreach (ProductosDetalle item in this.Detalle)
                    {
                      cone.Ejecutar(String.Format("Insert into ProductosDetalle(ProductoId,Detalle,Asociacion) Values({0},'{1}',{2})", Retornar, item.Detalle, item.Asociacion));
                    }
                }

            }catch(Exception ex)
            {
                throw ex;
            }

            return Retornar>0;
           
        }       
        public override bool Editar()
        {
            bool Retornar = false;
            DbVentana cone = new DbVentana();
            try
            {
                Retornar = cone.Ejecutar(String.Format("Update Productos set Descripcion='{0}',Pie={1},MinimoPie={2} where ProductoId={3}",this.Descripcion,this.Pie,this.MinimoPie,this.ProductoId));
                if(Retornar)
                {
                    cone.Ejecutar(String.Format("Delete from ProductosDetalle where ProductoId={0}",this.ProductoId));
                    
                   
                        foreach (ProductosDetalle item in this.Detalle)
                        {
                            cone.Ejecutar(String.Format("Insert into ProductosDetalle(ProductoId,Detalle,Asociacion) Values({0},'{1}',{2})", this.ProductoId, item.Detalle, item.Asociacion));
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
                Retornar = cone.Ejecutar(String.Format("Delete from ProductosDetalle where ProductoId ={0}; "+"Delete from Productos where ProductoId={0}",this.ProductoId));

            }catch(Exception ex)
            {
                throw ex;
            }
            return Retornar;
        }
        public override bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();
            DataTable dtDetalle = new DataTable();
            DbVentana cone = new DbVentana();
            bool Retornar = false;
           try
            {
                dt = cone.ObtenerDatos(String.Format("Select * from Productos where ProductoId ={0} ",IdBuscado));
                if(dt.Rows.Count>0)
                {
                    Retornar = true;
                    this.ProductoId = (int)dt.Rows[0]["ProductoId"];
                    this.Pie =Convert.ToSingle(dt.Rows[0]["Pie"]);
                    this.Descripcion = dt.Rows[0]["Descripcion"].ToString();
                    this.MinimoPie = Convert.ToSingle(dt.Rows[0]["MinimoPie"]);

                    dtDetalle = cone.ObtenerDatos(String.Format("Select * from ProductosDetalle where ProductoId={0}", IdBuscado));
                    foreach(DataRow row in dtDetalle.Rows)
                    {
                        AgregarProducto(row["Detalle"].ToString(),(int)row["Asociacion"]);
                    }
                }
                return dt.Rows.Count>0;

            }catch(Exception)
            {
              Retornar= false;
            }
            return Retornar;
        }
        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            DbVentana cone = new DbVentana();
            DataTable dt = new DataTable();
            string OrdenFinal = "";
            if (!Orden.Equals(""))
                OrdenFinal = "Order by " + Orden;
            return dt = cone.ObtenerDatos("Select "+Campos+" from Productos where "+Condicion+ Orden);
        }
        public float ObtenerPie(string Trabajo)
        {
            DataTable dt = new DataTable();
            DbVentana cone = new DbVentana();
            float pie = 0;
            

            dt = cone.ObtenerDatos(String.Format("Select * from Productos where Descripcion ='{0}'", Trabajo));
            if(dt.Rows.Count>0)
            {
                pie = Convert.ToSingle(dt.Rows[0]["Pie"]);

            }
            return pie;
        }
        public float ObtenerMinimoPie(string Trabajo)
        {
            DataTable dt = new DataTable();
            DbVentana cone = new DbVentana();
            float pie = 0;


            dt = cone.ObtenerDatos(String.Format("Select * from Productos where Descripcion ='{0}'", Trabajo));
            if (dt.Rows.Count > 0)
            {
                pie = Convert.ToSingle(dt.Rows[0]["MinimoPie"]);

            }
            return pie;
        }
    }
}
