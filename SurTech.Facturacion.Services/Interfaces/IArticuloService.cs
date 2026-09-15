using System.Collections.Generic;
using SurTech.Facturacion.Core.Entities;

namespace SurTech.Facturacion.Services.Interfaces
{
    public interface IArticuloService
    {
        IEnumerable<Articulo> ObtenerTodos();
        void Agregar(Articulo articulo);
        void GuardarArticulo(Articulo articulo);

        // ➕ Sobrecarga de 2 argumentos:
        bool GuardarArticulo(Articulo articulo, out string mensajeError);
    }
}