﻿using CsgoMatchData.Parser.Handlers.Abstractions;
using CsgoMatchData.Parser.Helpers;
using CsgoMatchData.Parser.Models.Actions;
using CsgoMatchData.Parser.Models.Actions.Abstractions;

namespace CsgoMatchData.Parser.Handlers;

public class RoundStartHandler : ActionHandler
{
    public override EventBase? Parse(string actionText)
    {
        if (!actionText.Contains("Round_Start"))
        {
            return base.Parse(actionText);
        }

        var roundStart = TimeExtractor.ParseTimestampFromActionText(actionText);

        return new RoundStartEvent(roundStart);
    }
}
