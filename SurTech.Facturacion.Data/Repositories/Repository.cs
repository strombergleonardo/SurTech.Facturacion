using Microsoft.EntityFrameworkCore;
using SurTech.Facturacion.Core.Interfaces;
using SurTech.Facturacion.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SurTech.Facturacion.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly FacturacionDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(FacturacionDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public T? ObtenerPorId(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> ObtenerTodos()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<T> Buscar(Expression<Func<T, bool>> predicado)
        {
            return _dbSet.Where(predicado).ToList();
        }

        public void Agregar(T entidad)
        {
            _dbSet.Add(entidad);
        }

        public void Actualizar(T entidad)
        {
            _dbSet.Update(entidad);
        }

        public void Eliminar(T entidad)
        {
            _dbSet.Remove(entidad);
        }

        public void Guardar()
        {
            _context.SaveChanges();
        }
    }
}