using CsgoMatchData.Parser.Models;

namespace CsgoMatchData.Logic.Models;

public record RoundResult(int RoundNumber, string TeamPlayingCounterTerrorist, string TeamPlayingTerrorist, RoundWinType RoundWinType);