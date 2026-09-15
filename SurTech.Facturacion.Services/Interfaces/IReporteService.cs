using SurTech.Facturacion.Core.Entities;

namespace SurTech.Facturacion.Services.Interfaces
{
    public interface IReporteService
    {
        string GenerarHtmlFactura(Comprobante comprobante, string nombreCliente);
        void GuardarFacturaPdf(Comprobante comprobante, string nombreCliente, string rutaArchivo);
    }
}