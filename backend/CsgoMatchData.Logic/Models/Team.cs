namespace CsgoMatchData.Logic.Models;

public record Team(string Name, IReadOnlyCollection<string> PlayerNames);
