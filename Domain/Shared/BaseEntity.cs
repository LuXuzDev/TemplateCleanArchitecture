namespace Domain.Shared;

/// <summary>
/// Representa la entidad base del dominio.
/// Contiene propiedades comunes para el control de identidad,
/// auditoría y borrado lógico de las entidades.
/// </summary>
public class BaseEntity
{
    /// <summary>
    /// Identificador único de la entidad.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Indica si la entidad ha sido eliminada lógicamente.
    /// Permite implementar soft delete sin eliminar el registro físicamente.
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// Fecha y hora en la que la entidad fue creada.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Fecha y hora de la última actualización de la entidad.
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}
