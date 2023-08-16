using CsgoMatchData.Parser.Handlers;
using CsgoMatchData.Parser.Models;
using CsgoMatchData.Parser.Models.Actions;

namespace CsgoMatchData.Parser.Tests.Handlers;

public class RoundResultHandlerTests
{
    [Theory]
    [MemberData(nameof(Data))]
    public void Given_match_data_log_When_log_is_round_result_Then_parse_correctly_to_round_result_event(
        string actionText, 
        RoundWinType expectedRoundWinType)
    {
        // Arrange
        var roundResultActionHandler = new RoundResultHandler();

        // Act
        var result = roundResultActionHandler.Parse(actionText);

        // Assert
        Assert.IsType<RoundResultEvent>(result);
        var roundResultEvent = (RoundResultEvent)result;
        Assert.True(roundResultEvent.RoundWinType == expectedRoundWinType);
    }
    
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[]
            {
                @"11/28/2021 - 20:57:43: Team ""CT"" triggered ""SFUI_Notice_Bomb_Defused"" (CT ""7"") (T ""1"")", 
                RoundWinType.CounterTerroristsWinByDefusingBomb
            },
            new object[]
            {
                @"11/28/2021 - 21:02:14: Team ""CT"" triggered ""SFUI_Notice_CTs_Win"" (CT ""9"") (T ""1"")", 
                RoundWinType.CounterTerroristsWin
            },
            new object[]
            {
                @"11/28/2021 - 21:05:10: Team ""TERRORIST"" triggered ""SFUI_Notice_Target_Bombed"" (CT ""9"") (T ""2"")", 
                RoundWinType.TerroristsWinByBombExplosion
            },
            new object[]
            {
                @"11/28/2021 - 21:07:42: Team ""TERRORIST"" triggered ""SFUI_Notice_Terrorists_Win"" (CT ""9"") (T ""3"")", 
                RoundWinType.TerroristsWin
            }
        };
}