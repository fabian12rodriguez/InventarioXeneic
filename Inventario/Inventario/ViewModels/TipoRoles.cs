using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.ViewModels
{
    public class TipoRoles
    {
        private int id_rol;
        private string descripcion_rol;

        public int Id_rol { get => id_rol; set => id_rol = value; }
        public string Descripcion_rol { get => descripcion_rol; set => descripcion_rol = value; }

    }
}