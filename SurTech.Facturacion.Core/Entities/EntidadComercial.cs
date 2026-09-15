using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurTech.Facturacion.Core.Entities
{
    // Representa tanto a Clientes como a Proveedores (Módulo 2 del sistema)
    public class EntidadComercial
    {
        public int IdEntidad { get; set; }
        public string Cuit { get; set; } = string.Empty;
        public string RazonSocial { get; set; } = string.Empty;
        public string CondicionIva { get; set; } = string.Empty; // Ej: "Responsable Inscripto", "Exento"
        public string Tipo { get; set; } = string.Empty; // "Cliente" o "Proveedor"
    }
}