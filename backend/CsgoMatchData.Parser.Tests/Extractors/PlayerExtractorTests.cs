using CsgoMatchData.Parser.Helpers;
using CsgoMatchData.Parser.Models;

namespace CsgoMatchData.Parser.Tests.Extractors;

public class PlayerExtractorTests
{
    [Theory]
    [InlineData("\"ZywOo<26><STEAM_1:1:76700232><CT>\"", "ZywOo", TeamType.CounterTerrorist)]
    [InlineData("\"b1t<32><STEAM_1:0:143170874><TERRORIST>\"", "b1t", TeamType.Terrorist)]
    public void Given_match_data_log_When_extracting_player_Then_parse_correctly(
        string actionText, 
        string expectedPlayerName, 
        TeamType expectedTeamType)
    {
        // Arrange & Act
        var player = PlayerExtractor.ParsePlayerFromActionText(actionText);
        
        // Assert
        Assert.True(player.Name == expectedPlayerName);
        Assert.True(player.TeamType == expectedTeamType);
    }
}