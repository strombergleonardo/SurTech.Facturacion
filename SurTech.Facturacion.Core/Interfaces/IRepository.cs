using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SurTech.Facturacion.Core.Interfaces
{
    // La 'T' representa cualquier Entidad de nuestro sistema (Usuario, Articulo, etc.)
    public interface IRepository<T> where T : class
    {
        T? ObtenerPorId(int id);
        IEnumerable<T> ObtenerTodos();
        IEnumerable<T> Buscar(Expression<Func<T, bool>> predicado);
        void Agregar(T entidad);
        void Actualizar(T entidad);
        void Eliminar(T entidad);
        void Guardar();
    }
} 