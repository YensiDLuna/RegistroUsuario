using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegistroDeUsuario.Entidades
{
 public  class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }

        public Usuario(int usuarioId, string nombre, string clave)
        {
            UsuarioId = usuarioId;
            Nombre = nombre;
            Clave = clave;
        }

        public Usuario()
        {
            UsuarioId = 0;
            Nombre = string.Empty;
            Clave = string.Empty;
        }
    }
}
