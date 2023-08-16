using Microsoft.EntityFrameworkCore;
using Model;
using System.Linq.Expressions;

namespace Data
{
    /// <summary>
    /// Implementación del patrón Repository de forma genérica
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repositorio<T> : IRepositorio<T>
        where T : EntidadBase
    {
        #region Members
        private readonly DbContext _contexto;
        #endregion

        #region Constructor
        /// <summary>
        /// Crea una nueva instancia del repositorio
        /// </summary>
        /// <param name="contexto">Contexto de EF</param>
        public Repositorio(DbContext contexto) 
            => _contexto = contexto 
            ?? throw new ArgumentNullException("Contexto");
        #endregion

        public DbContext Contexto => _contexto;

        public void Agregar(T item)
        {
            if (item != null)
            {
                GetSet().Add(item);
            }
        }

        public void Quitar(T item)
        {
            if (item != null)
            {
                GetSet().Remove(item);
            }
        }

        public void Modificar(T item)
        {
            if (item != null)
            {
                _contexto.Entry(item).State = EntityState.Modified;
            }
        }

        public T? Get(int id)
        {
            return id != 0 ? GetSet().Find(id) : null;
        }

        public IEnumerable<T> GetTodos()
        {
            return GetSet();
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> filtro)
        {
            return GetSet().Where(filtro);
        }

        public void ConfirmarCambios()
        {
            _contexto.SaveChanges();
        }
        public void DescartarCambios()
        {
            _contexto.ChangeTracker.Entries().Where(entry => entry.State != EntityState.Added)
                                  .ToList()
                                  .ForEach(entry => entry.State = EntityState.Unchanged);
            foreach (var entry in _contexto.ChangeTracker.Entries().Where(entry => entry.State == EntityState.Added))
            {
                entry.State = EntityState.Detached;
            }
        }

        public void Refrescar(T item)
        {
            if (item != null)
            {
                _contexto.Entry(item).Reload();
            }
        }

        #region IDisposable Miembros
        /// <summary>
        /// <see cref="M:System.IDisposable.Dispose"/>
        /// </summary>
        public void Dispose() => _contexto?.Dispose();
        #endregion

        #region Métodos Privados
        DbSet<T> GetSet()
        {
            return _contexto.Set<T>();
        }
        #endregion
    }
}
