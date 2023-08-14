using CsgoMatchData.Parser.Handlers;
using CsgoMatchData.Parser.Handlers.Abstractions;

namespace CsgoMatchData.Parser.Helpers;

internal class ActionHandlerSetup
{
    internal static ActionHandler SetupChain()
    {
        var killActionHandler = new KillHandler();
        var roundResultHandler = new RoundResultHandler();
        var teamPlayingCtHandler = new TeamPlayingCounterTerroristHandler();
        var teamPlayingTerroristHandler = new TeamPlayingTerroristHandler();
        
        killActionHandler
            .SetNext(killActionHandler)
            .SetNext(roundResultHandler)
            .SetNext(teamPlayingCtHandler)
            .SetNext(teamPlayingTerroristHandler);

        return killActionHandler;
    }
}