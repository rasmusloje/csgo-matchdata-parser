using CsgoMatchData.Parser.Models.Actions.Abstractions;

namespace CsgoMatchData.Parser.Handlers.Abstractions;

public interface IActionHandler
{
    IActionHandler SetNext(IActionHandler actionHandler);
    EventBase? Parse(string actionText);
}
