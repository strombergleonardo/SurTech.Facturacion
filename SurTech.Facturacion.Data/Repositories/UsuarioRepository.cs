using System.Linq;
using SurTech.Facturacion.Core.Entities;
using SurTech.Facturacion.Core.Interfaces;
using SurTech.Facturacion.Data.Context;

namespace SurTech.Facturacion.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        // Pasamos el DbContext a la clase base (Repository) mediante base(context)
        public UsuarioRepository(FacturacionDbContext context) : base(context)
        {
        }

        public Usuario? ObtenerPorNombreUsuario(string nombreUsuario)
        {
            // Usamos LINQ para buscar el primer usuario que coincida con el nombre.
            // FirstOrDefault devuelve el Usuario si lo encuentra, o null si no existe.
            return _dbSet.FirstOrDefault(u => u.NombreUsuario.ToLower() == nombreUsuario.ToLower());
        }
    }
}