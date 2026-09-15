using System;
using System.Linq;
using SurTech.Facturacion.Core.Entities;
using SurTech.Facturacion.Data.Context;
using SurTech.Facturacion.Services.Interfaces;

namespace SurTech.Facturacion.Services.BusinessLogic
{
    public class FacturacionService : IFacturacionService
    {
        private readonly FacturacionDbContext _context;

        public FacturacionService(FacturacionDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool RegistrarFactura(Comprobante comprobante, out string mensajeError)
        {
            mensajeError = string.Empty;

            try
            {
                // 1. EF Core agrega la cabecera y detecta automáticamente la lista en comprobante.Detalles
                _context.Comprobantes.Add(comprobante);

                // 2. Al guardar cambios:
                //    a) SQLite genera el IdComprobante único de la cabecera.
                //    b) EF Core le asigna ese nuevo IdComprobante a cada fila dentro de Detalles.
                //    c) SQLite inserta los detalles autogenerando cada IdComprobanteDetalle.
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al registrar comprobante: {ex.Message}";
                return false;
            }
        }
    }
}