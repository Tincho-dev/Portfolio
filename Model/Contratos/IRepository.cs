using System.Linq.Expressions;

namespace Model
{
    /// <summary>
    /// Contrato de Repositorio basado en el patrón Repository
    /// </summary>
    /// <example>Ver Guía de Arquitectura N-Capas Orientada al Dominio con .NET 4.0 - Pag. 102</example>
    /// <remarks>
    /// Implementación parcial del patrón
    /// </remarks>
    /// <typeparam name="T">Cualquier entidad del dominio que herede de EntityBase</typeparam>
    public interface IRepositorio<T> : IDisposable
        //where T : EntidadBase
    {
        void Agregar(T item);
        void Quitar(T item);
        void Modificar(T item);
        T Get(int id);
        IEnumerable<T> GetTodos();
        IEnumerable<T> Where(Expression<Func<T, bool>> filtro);
        void ConfirmarCambios();
        void DescartarCambios();
        void Refrescar(T item);
    }
}
