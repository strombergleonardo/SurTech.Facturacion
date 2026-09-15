using SurTech.Facturacion.Core.Entities;
using SurTech.Facturacion.Core.Interfaces;
using SurTech.Facturacion.Data.Repositories;
using SurTech.Facturacion.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace SurTech.Facturacion.Services.BusinessLogic
{
    public class ArticuloService : IArticuloService
    {
        private readonly IRepository<Articulo> _articuloRepository;

        public ArticuloService(IRepository<Articulo> articuloRepository)
        {
            _articuloRepository = articuloRepository ?? throw new ArgumentNullException(nameof(articuloRepository));
        }

        public IEnumerable<Articulo> ObtenerTodos()
        {
            return _articuloRepository.ObtenerTodos();
        }

        public void Agregar(Articulo articulo)
        {
            if (articulo == null)
                throw new ArgumentNullException(nameof(articulo));

            _articuloRepository.Agregar(articulo);
            _articuloRepository.Guardar();
        }

        public void GuardarArticulo(Articulo articulo)
        {
            Agregar(articulo);
        }

        // ➕ Implementación que resuelve el error del miembro de interfaz:
        public bool GuardarArticulo(Articulo articulo, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (articulo == null)
            {
                mensajeError = "El artículo no puede ser nulo.";
                return false;
            }

            try
            {
                _articuloRepository.Agregar(articulo);
                _articuloRepository.Guardar();
                return true;
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al guardar el artículo: {ex.Message}";
                return false;
            }
        }
    }
}