using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurTech.Facturacion.Core.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string ClaveHash { get; set; } = string.Empty;

        // Modificación clave: Por defecto, cualquier usuario creado en memoria es Alumno.
        // El único Profesor será el que inyectemos desde la base de datos.
        public string Rol { get; set; } = "Alumno";
    }
}