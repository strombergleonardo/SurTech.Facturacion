using SurTech.Facturacion.Core.Entities;

namespace SurTech.Facturacion.Core.Interfaces
{
    // Hereda todos los métodos de IRepository<Usuario> (Agregar, ObtenerPorId, etc.)
    // y agrega el contrato para la consulta específica de Login.
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario? ObtenerPorNombreUsuario(string nombreUsuario);
    }
}