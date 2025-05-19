using CsgoMatchData.Parser.Handlers;
using CsgoMatchData.Parser.Models;
using CsgoMatchData.Parser.Models.Actions;

namespace CsgoMatchData.Parser.Tests.Handlers;

public class DoorDestroyedHandlerTests
{
    [Fact]
    public void Given_match_data_log_When_log_is_door_destroyed_Then_parse_correctly_to_door_destroyed_event()
    {
        // Arrange
        var doorDestroyedHandler = new DoorDestroyedHandler();
        var actionText =
            @"11/28/2021 - 21:19:19: ""Kyojin<34><STEAM_1:1:22851120><TERRORIST>"" [15 -843 -416] killed other ""prop_door_rotating<417>"" [257 -1310 -416] with ""hegrenade""";

        // Act
        var result = doorDestroyedHandler.Parse(actionText);

        // Assert
        Assert.IsType<DoorDestroyedEvent>(result);
        var doorDestroyedEvent = (DoorDestroyedEvent)result;
        Assert.True(doorDestroyedEvent.WeaponUsed.Name == "hegrenade");
        Assert.True(doorDestroyedEvent.DestroyedBy.TeamType == TeamType.Terrorist);
        Assert.True(doorDestroyedEvent.DestroyedBy.Name == "Kyojin");
    }
}
