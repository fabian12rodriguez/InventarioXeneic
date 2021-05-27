using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.Models
{
    public class Marca
    {
        private int id_marca;
        private string descripcion_marca;

        public int Id_marca { get => id_marca; set => id_marca = value; }
        public string Descripcion_marca { get => descripcion_marca; set => descripcion_marca = value; }
    }
}