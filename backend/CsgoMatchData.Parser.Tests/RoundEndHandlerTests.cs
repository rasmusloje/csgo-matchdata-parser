using MatchData.Parser.Handlers;
using MatchData.Parser.Models.Actions;

namespace MatchData.Parser.Tests;

public class RoundEndHandlerTests
{
    [Fact]
    public void Given_match_data_log_When_log_is_round_end_Then_parse_correctly_to_round_end_event()
    {
        // Arrange
        var roundEndActionHandler = new RoundEndHandler();
        var actionText = @"11/28/2021 - 21:02:14: World triggered ""Round_End""";
        var expectedRoundEndTime = new DateTime(2021, 11, 28, 21, 02, 14);

        // Act
        var result = roundEndActionHandler.Parse(actionText);

        // Assert
        Assert.IsType<RoundEndEvent>(result);
        var roundEndAction = (RoundEndEvent)result;
        Assert.True(roundEndAction.RoundEnd == expectedRoundEndTime);
    }
}