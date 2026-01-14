using Domain.Exceptions;

namespace Shared.Exception;

public static class ExceptionHelper
{
    public static void ThrowNotFound(string details, ExceptionCode errorCode = ExceptionCode.None)
    {
        throw new ApiException(ExceptionType.NotFound, errorCode, "Recurso no encontrado", details);
    }
}
