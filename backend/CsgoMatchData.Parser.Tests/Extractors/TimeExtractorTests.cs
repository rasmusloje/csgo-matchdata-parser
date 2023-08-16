using CsgoMatchData.Parser.Helpers;

namespace CsgoMatchData.Parser.Tests.Extractors;

public class TimeExtractorTests
{
    [Theory]
    [MemberData(nameof(Data))]
    public void ParseTimeFromActionText(string actionText, DateTime expectedDateTime)
    {
        // Arrange & Act
        var time = TimeExtractor.ParseTimestampFromActionText(actionText);
        
        // Assert
        Assert.True(time == expectedDateTime);
    }
    
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[]
            {
                @"11/28/2021 - 20:41:12: ""b1t<32><STEAM_1:0:143170874><TERRORIST>"" purchased ""molotov""", 
                new DateTime(2021, 11, 28, 20, 41, 12)
            },
            new object[]
            {
                @"11/28/2021 - 20:58:05: ""Kyojin<8><STEAM_1:1:22851120><CT>"" money change 1700-300 = $1400 (tracked) (purchase: weapon_hegrenade)", 
                new DateTime(2021, 11, 28, 20, 58, 5)
            },
            new object[]
            {
                @"11/28/2021 - 21:22:07: ""ZywOo<26><STEAM_1:1:76700232><TERRORIST>"" picked up ""c4""", 
                new DateTime(2021, 11, 28, 21, 22, 7)
            }
        };
}