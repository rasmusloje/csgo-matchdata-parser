using CsgoMatchData.Parser.Handlers;
using CsgoMatchData.Parser.Models.Actions;

namespace CsgoMatchData.Parser.Tests;

public class RoundStartHandlerTests
{
    [Fact]
    public void Given_match_data_log_When_log_is_round_start_Then_parse_correctly_to_round_start_event()
    {
        // Arrange
        var roundStartHandler = new RoundStartHandler();
        var actionText = @"11/28/2021 - 21:01:12: World triggered ""Round_Start""";
        var expectedRoundStartTime = new DateTime(2021, 11, 28, 21, 1, 12);

        // Act
        var result = roundStartHandler.Parse(actionText);

        // Assert
        Assert.IsType<RoundStartEvent>(result);
        var roundStartEvent = (RoundStartEvent)result;
        Assert.True(roundStartEvent.RoundStart == expectedRoundStartTime);
    }
}