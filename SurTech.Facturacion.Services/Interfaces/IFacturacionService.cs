using SurTech.Facturacion.Core.Entities;

namespace SurTech.Facturacion.Services.Interfaces
{
    public interface IFacturacionService
    {
        bool RegistrarFactura(Comprobante comprobante, out string mensajeError);
    }
}