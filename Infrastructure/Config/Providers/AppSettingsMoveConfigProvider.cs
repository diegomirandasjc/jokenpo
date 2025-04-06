using Jokenpo.Domain.Models;
using Microsoft.Extensions.Configuration;
 

namespace Jokenpo.Infrastructure.Config.Providers;

public class AppSettingsMoveConfigProvider : IMoveConfigProvider
{
    private readonly IConfiguration _config;

    public AppSettingsMoveConfigProvider(IConfiguration config)
    {
        _config = config;
    }

    public List<Move> LoadMoves()
    {
        return _config.GetSection("Moves").Get<List<Move>>() ?? new List<Move>();
    }
}
