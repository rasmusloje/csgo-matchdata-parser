using CsgoMatchData.Parser.Models.Actions.Abstractions;

namespace CsgoMatchData.Parser.Handlers.Abstractions;

public abstract class ActionHandler : IActionHandler
{
    private IActionHandler? _nextHandler;
    
    public IActionHandler SetNext(IActionHandler actionHandler)
    {
        _nextHandler = actionHandler;

        return actionHandler;
    }

    public virtual EventBase? Parse(string actionText)
    {
        return _nextHandler?.Parse(actionText);
    }
}