namespace Domain.Shared;

/// <summary>
/// Interfaz genérica para operaciones CRUD básicas sobre una entidad.
/// </summary>
/// <typeparam name="T">Tipo de entidad que hereda de <see cref="BaseEntity"/>.</typeparam>
public interface IRepositoryGeneric<T> where T : BaseEntity
{
    /// <summary>
    /// Obtiene todas las entidades del tipo <typeparamref name="T"/>.
    /// </summary>
    /// <returns>Una tarea que representa la operación asincrónica y contiene una colección de entidades.</returns>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// Obtiene una entidad por su identificador.
    /// </summary>
    /// <param name="id">El identificador de la entidad.</param>
    /// <returns>Una tarea que representa la operación asincrónica y contiene la entidad encontrada, o null si no existe.</returns>
    Task<T?> GetByIdAsync(int id);

    /// <summary>
    /// Crea una nueva entidad.
    /// </summary>
    /// <param name="entity">La entidad a crear.</param>
    /// <returns>Una tarea que representa la operación asincrónica y contiene la entidad creada con sus datos actualizados (por ejemplo, Id generado).</returns>
    Task<T> CreateAsync(T entity);

    /// <summary>
    /// Actualiza una entidad existente.
    /// </summary>
    /// <param name="entity">La entidad con los cambios a actualizar.</param>
    /// <returns>Una tarea que representa la operación asincrónica.</returns>
    Task UpdateAsync(T entity);

    /// <summary>
    /// Marca como eliminada una entidad por su identificador.
    /// </summary>
    /// <param name="id">El identificador de la entidad a eliminar.</param>
    /// <returns>Una tarea que representa la operación asincrónica.</returns>
    Task DeleteAsync(int id);
}
