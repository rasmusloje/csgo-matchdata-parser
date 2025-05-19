using CsgoMatchData.Parser.Handlers;
using CsgoMatchData.Parser.Models.Actions;

namespace CsgoMatchData.Parser.Tests.Handlers;

public class TeamPlayingCounterTerroristHandlerTests
{
    [Fact]
    public void Given_match_data_log_When_log_is_team_playing_ct_Then_parse_correctly_to_team_playing_ct_event()
    {
        // Arrange
        var teamPlayingCounterTerroristHandler = new TeamPlayingCounterTerroristHandler();
        const string actionText =
            @"11/28/2021 - 21:07:42: MatchStatus: Team playing ""CT"": TeamVitality";

        // Act
        var result = teamPlayingCounterTerroristHandler.Parse(actionText);

        // Assert
        Assert.IsType<TeamPlayingCounterTerroristEvent>(result);
        var teamPlayingCounterTerroristEvent = (TeamPlayingCounterTerroristEvent)result;
        Assert.True(teamPlayingCounterTerroristEvent.TeamName == "TeamVitality");
    }
}
