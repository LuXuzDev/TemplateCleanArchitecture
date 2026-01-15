using System.Windows.Input;
using FastEndpoints;

namespace Application.RefreshToken.Commands;

public abstract class GenerateRefreshTokenCommand:ICommand<string>
{
    public int Request { get; set; }
}