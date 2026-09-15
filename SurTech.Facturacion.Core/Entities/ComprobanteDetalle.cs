using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurTech.Facturacion.Core.Entities
{
    public class ComprobanteDetalle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDetalle { get; set; } // 👈 Cambiado de IdComprobanteDetalle a IdDetalle

        [ForeignKey("Comprobante")]
        public int IdComprobante { get; set; }

        public int? IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }

        public Comprobante? Comprobante { get; set; }
    }
}