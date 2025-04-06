using Jokenpo.Domain.Models;
using Jokenpo.Domain.Services;
using Xunit;

namespace Jokenpo.Tests;

public class GameRuleServiceTests
{
    private readonly List<Move> _moves = new()
    {
        new Move
        {
            Name = "PEDRA",
            Defeats = new() { new DefeatRule { Target = "TESOURA", Action = "esmaga" } }
        },
        new Move
        {
            Name = "TESOURA",
            Defeats = new() { new DefeatRule { Target = "PAPEL", Action = "corta" } }
        },
        new Move
        {
            Name = "PAPEL",
            Defeats = new() { new DefeatRule { Target = "PEDRA", Action = "cobre" } }
        }
    };

    [Theory]
    [InlineData("PEDRA", "TESOURA", "PEDRA esmaga TESOURA — Jogador 1 venceu!")]
    [InlineData("TESOURA", "PAPEL", "TESOURA corta PAPEL — Jogador 1 venceu!")]
    [InlineData("PAPEL", "PEDRA", "PAPEL cobre PEDRA — Jogador 1 venceu!")]
    [InlineData("PEDRA", "PEDRA", "Empate!")]
    [InlineData("TESOURA", "PEDRA", "PEDRA esmaga TESOURA — Jogador 2 venceu!")]
    public void Deve_Retornar_Resultado_Correto(string p1, string p2, string expected)
    {
        var service = new GameRuleService(_moves);
        var result = service.GetWinner(p1, p2);

        Assert.Equal(expected, result);
    }
}
