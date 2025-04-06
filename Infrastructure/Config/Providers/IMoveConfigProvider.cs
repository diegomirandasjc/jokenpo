using Jokenpo.Domain.Models;

namespace Jokenpo.Infrastructure.Config.Providers;

public interface IMoveConfigProvider
{
    List<Move> LoadMoves();
}
