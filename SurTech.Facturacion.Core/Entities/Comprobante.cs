using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurTech.Facturacion.Core.Entities
{
    public class Comprobante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdComprobante { get; set; } // Clave autoincremental

        public int IdUsuario { get; set; }
        public int IdEntidad { get; set; }
        public string TipoOperacion { get; set; } = string.Empty;
        public string TipoComprobante { get; set; } = string.Empty;
        public DateTime FechaEmision { get; set; }
        public decimal NetoGravado { get; set; }
        public decimal ImporteIva { get; set; }
        public decimal Total { get; set; }

        // Propiedad clave para la relación 1 a Muchos:
        public List<ComprobanteDetalle> Detalles { get; set; } = new List<ComprobanteDetalle>();
    }
}