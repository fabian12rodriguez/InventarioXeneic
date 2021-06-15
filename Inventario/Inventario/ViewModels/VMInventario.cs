using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.ViewModels
{
    public class VMInventario
    {
        /*Articulos*/
        private int id_articulo;
        private string nombre_articulo;
        private string modelo_articulo;
        private int id_marca;
        private int id_tipo_articulo;
        private bool habilitado_articulo;
        private string imagen_articulo;
        /*Marca*/
        private string desc_marca_articulo;
        private string desc_tipo_articulo;
        /*Movimientos_Stock*/
        private int id_mvt;
        private string fecha_mvt;
        private int cantidad_mvt;
        private string observaciones_mvt;
        private int stock;
        /*Usuarios*/
        private int id_usuario;
        private string codigo_usuario;
        private string password_usuario;
        private string nombre_usuario;
        private string apellido_usuario;
        private string mail_usuario;
        private bool habilitado_usuario;
        private int id_rol;

        /*Roles*/
        private string descripcion_rol;

        /*Reportes*/
        private int cantidad;
        private string area;

        /*Articulos*/
        public int Id_articulo { get => id_articulo; set => id_articulo = value; }
        public string Nombre_articulo { get => nombre_articulo; set => nombre_articulo = value; }
        public string Modelo_articulo { get => modelo_articulo; set => modelo_articulo = value; }
        public int Id_marca { get => id_marca; set => id_marca = value; }
        public int Id_tipo_articulo { get => id_tipo_articulo; set => id_tipo_articulo = value; }
        public string Imagen_articulo { get => imagen_articulo; set => imagen_articulo = value; }
        public bool Habilitado_articulo { get => habilitado_articulo; set => habilitado_articulo = value; }
        /*Marca*/
        public string Desc_marca_articulo { get => desc_marca_articulo; set => desc_marca_articulo = value; }
        public string Desc_tipo_articulo { get => desc_tipo_articulo; set => desc_tipo_articulo = value; }
        /*Movimientos_Stock*/
        public int Id_mvt { get => id_mvt; set => id_mvt = value; }
        public string Fecha_mvt { get => fecha_mvt; set => fecha_mvt = value; }
        public int Cantidad_mvt { get => cantidad_mvt; set => cantidad_mvt = value; }
        public string Observaciones_mvt { get => observaciones_mvt; set => observaciones_mvt = value; }
        public int Stock { get => stock; set => stock = value; }
        /*Usuarios*/
        public int Id_usuario { get => id_usuario; set => id_usuario = value; }
        public string Codigo_usuario { get => codigo_usuario; set => codigo_usuario = value; }
        public string Password_usuario { get => password_usuario; set => password_usuario = value; }
        public string Nombre_usuario { get => nombre_usuario; set => nombre_usuario = value; }
        public string Apellido_usuario { get => apellido_usuario; set => apellido_usuario = value; }
        public string Mail_usuario { get => mail_usuario; set => mail_usuario = value; }
        public bool Habilitado_usuario { get => habilitado_usuario; set => habilitado_usuario = value; }
        public int Id_rol { get => id_rol; set => id_rol = value; }
        /*Roles*/
        public string Descripcion_rol { get => descripcion_rol; set => descripcion_rol = value; }

        /*Reportes*/
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string Area { get => area; set => area = value; }
    }
}