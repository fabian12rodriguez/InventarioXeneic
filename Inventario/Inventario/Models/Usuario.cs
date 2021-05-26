using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.Models
{
    public class Usuario
    {
        private int id_usuario;
        private string codigo_usuario;
        private string nombre_usuario;
        private string apellido_usuario;
        private string mail_usuario;
        private bool habilitado_usuario;
        private int id_rol;

        public int Id_usuario { get => id_usuario; set => id_usuario = value; }
        public string Codigo_usuario { get => codigo_usuario; set => codigo_usuario = value; }
        public string Nombre_usuario { get => nombre_usuario; set => nombre_usuario = value; }
        public string Apellido_usuario { get => apellido_usuario; set => apellido_usuario = value; }
        public string Mail_usuario { get => mail_usuario; set => mail_usuario = value; }

        public bool Habilitado_usuario { get => habilitado_usuario; set => habilitado_usuario = value; }

        public int Id_rol { get => id_rol; set => id_rol = value; }


    }
}