using Jokenpo.Application.UseCases;
using Jokenpo.Domain.Models;
using Jokenpo.Domain.Services;
using Xunit;

namespace Jokenpo.Tests;

public class PlayGameUseCaseTests
{
    private readonly PlayGameUseCase _useCase;

    public PlayGameUseCaseTests()
    {
        var moves = new List<Move>
        {
            new Move
            {
                Name = "LAGARTO",
                Defeats = new()
                {
                    new DefeatRule { Target = "SPOCK", Action = "envenena" }
                }
            },
            new Move
            {
                Name = "SPOCK",
                Defeats = new()
                {
                    new DefeatRule { Target = "TESOURA", Action = "quebra" }
                }
            }
        };

        var service = new GameRuleService(moves);
        _useCase = new PlayGameUseCase(service);
    }

    [Fact]
    public void Deve_Resolver_Jogada_Corretamente()
    {
        var resultado = _useCase.Execute("LAGARTO", "SPOCK");

        Assert.Equal("LAGARTO envenena SPOCK — Jogador 1 venceu!", resultado);
    }
}
