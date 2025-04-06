namespace Jokenpo.Domain.Models;

public class DefeatRule
{
    public string Target { get; set; } = string.Empty;
    public string Action { get; set; } = string.Empty;
}

public class Move
{
    public string Name { get; set; } = string.Empty;
    public List<DefeatRule> Defeats { get; set; } = new();
}
