using CsgoMatchData.Parser.Handlers;
using CsgoMatchData.Parser.Models;
using CsgoMatchData.Parser.Models.Actions;

namespace CsgoMatchData.Parser.Tests;

public class KillHandlerTests
{
    [Fact]
    public void Given_match_data_log_When_log_is_kill_action_Then_parse_correctly_to_kill_event()
    {
        // Arrange
        var killHandler = new KillHandler();
        const string actionText = @"11/28/2021 - 20:42:05: ""ZywOo<26><STEAM_1:1:76700232><CT>"" [788 -2306 -416] killed ""b1t<32><STEAM_1:0:143170874><TERRORIST>"" [1407 -2389 -413] with ""usp_silencer"" (headshot)";

        // Act
        var result = killHandler.Parse(actionText);

        // Assert
        Assert.IsType<KillEvent>(result);
        var killAction = (KillEvent)result;
        Assert.True(killAction.Killer.Name == "ZywOo");
        Assert.True(killAction.Killer.TeamType == TeamType.CounterTerrorist);
        Assert.True(killAction.Victim.Name == "b1t");
        Assert.True(killAction.Victim.TeamType == TeamType.Terrorist);
        Assert.True(killAction.WeaponUsed.Name == "usp_silencer");
        Assert.True(Math.Abs(killAction.KillDistance.DistanceInUnits - 624.547058) < 1);
    }
}