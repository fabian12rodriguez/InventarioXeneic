using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.Models
{
    public class Articulo
    {
        



        private int id_articulo;
        private string nombre_articulo;
        private string modelo_articulo;
        private int id_marca;
        private int id_tipo_articulo;
        private string imagen_articulo ;

        public int Id_articulo { get => id_articulo; set => id_articulo = value; }
        public string Nombre_articulo { get => nombre_articulo; set => nombre_articulo = value; }
        public string Modelo_articulo { get => modelo_articulo; set => modelo_articulo = value; }
        public int Id_marca { get => id_marca; set => id_marca = value; }
        public int Id_tipo_articulo { get => id_tipo_articulo; set => id_tipo_articulo = value; }

        public string Imagen_articulo { get => imagen_articulo; set => imagen_articulo = value; }

        

    }
}