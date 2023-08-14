using CsgoMatchData.Parser.Handlers;
using CsgoMatchData.Parser.Models.Actions;

namespace CsgoMatchData.Parser.Tests;

public class TeamPlayingTerroristHandlerTests
{
    [Fact]
    public void Given_match_data_log_When_log_is_team_playing_t_Then_parse_correctly_to_team_playing_t_event()
    {
        // Arrange
        var teamPlayingTerroristHandler = new TeamPlayingTerroristHandler();
        const string actionText = @"11/28/2021 - 21:07:42: MatchStatus: Team playing ""TERRORIST"": NAVI GGBET";

        // Act
        var result = teamPlayingTerroristHandler.Parse(actionText);

        // Assert
        Assert.IsType<TeamPlayingTerroristEvent>(result);
        var teamPlayingTerroristEvent = (TeamPlayingTerroristEvent)result;
        Assert.True(teamPlayingTerroristEvent.TeamName == "NAVI GGBET");
    }
}