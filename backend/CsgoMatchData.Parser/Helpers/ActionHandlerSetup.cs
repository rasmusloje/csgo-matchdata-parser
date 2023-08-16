using CsgoMatchData.Parser.Handlers;
using CsgoMatchData.Parser.Handlers.Abstractions;

namespace CsgoMatchData.Parser.Helpers;

internal class ActionHandlerSetup
{
    internal static ActionHandler SetupChain()
    {
        var roundStartHandler = new RoundStartHandler();
        var killActionHandler = new KillHandler();
        var roundEndHandler = new RoundEndHandler();
        var roundResultHandler = new RoundResultHandler();
        var teamPlayingCtHandler = new TeamPlayingCounterTerroristHandler();
        var teamPlayingTerroristHandler = new TeamPlayingTerroristHandler();
        var doorDestroyedHandler = new DoorDestroyedHandler();
        
        roundStartHandler
            .SetNext(killActionHandler)
            .SetNext(roundEndHandler)
            .SetNext(roundResultHandler)
            .SetNext(teamPlayingCtHandler)
            .SetNext(teamPlayingTerroristHandler)
            .SetNext(doorDestroyedHandler);

        return roundStartHandler;
    }
}