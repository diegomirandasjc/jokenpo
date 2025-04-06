using Jokenpo.Domain.Services;

namespace Jokenpo.Application.UseCases;

public class PlayGameUseCase
{
    private readonly GameRuleService _ruleService;

    public PlayGameUseCase(GameRuleService ruleService)
    {
        _ruleService = ruleService;
    }

    public string Execute(string move1, string move2)
    {
        return _ruleService.GetWinner(move1, move2);
    }
}
