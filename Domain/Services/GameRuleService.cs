using Jokenpo.Domain.Models;

namespace Jokenpo.Domain.Services;

public class GameRuleService
{
    private readonly List<Move> _moves;

    public GameRuleService(List<Move> moves)
    {
        _moves = moves;
    }

    public Move? GetMove(string name) =>
        _moves.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

    public string GetWinner(string move1Name, string move2Name)
    {
        var move1 = GetMove(move1Name);
        var move2 = GetMove(move2Name);

        if (move1 == null || move2 == null) return "Jogada inválida!";
        if (move1.Name == move2.Name) return "Empate!";

        var rule = move1.Defeats.FirstOrDefault(d => d.Target == move2.Name);
        if (rule != null) return $"{move1.Name} {rule.Action} {move2.Name} — Jogador 1 venceu!";

        var rule2 = move2.Defeats.FirstOrDefault(d => d.Target == move1.Name);
        if (rule2 != null) return $"{move2.Name} {rule2.Action} {move1.Name} — Jogador 2 venceu!";

        return "Sem regra definida para esse confronto!";
    }
}
