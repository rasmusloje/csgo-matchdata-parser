using CsgoMatchData.Parser.Handlers.Abstractions;
using CsgoMatchData.Parser.Models;
using CsgoMatchData.Parser.Models.Actions;
using CsgoMatchData.Parser.Models.Actions.Abstractions;

namespace CsgoMatchData.Parser.Handlers;

public class RoundResultHandler : ActionHandler
{
    public override EventBase? Parse(string actionText)
    {
	    if (!actionText.Contains("SFUI_Notice_"))
	    {
		    return base.Parse(actionText);
	    }

	    var roundWinType = DecodeRoundWinType(actionText);
	    
	    return new RoundResultEvent(roundWinType);
    }

    private RoundWinType DecodeRoundWinType(string actionText)
    {
	    if (actionText.Contains("SFUI_Notice_Terrorists_Win"))
	    {
		    return RoundWinType.TerroristsWin;
	    }

	    if (actionText.Contains("SFUI_Notice_CTs_Win"))
	    {
		    return RoundWinType.CounterTerroristsWin;
	    }
	    if (actionText.Contains("SFUI_Notice_Target_Bombed"))
	    {
		    return RoundWinType.TerroristsWinByBombExplosion;
	    }
	    if (actionText.Contains("SFUI_Notice_Bomb_Defused"))
	    {
		    return RoundWinType.CounterTerroristsWinByDefusingBomb;
	    }

	    throw new ArgumentException("RoundWinType doesn't exist");
    }
}