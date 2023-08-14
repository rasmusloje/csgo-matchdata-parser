using System.Text;
using CsgoMatchData.Parser.Helpers;
using CsgoMatchData.Parser.Models;

namespace CsgoMatchData.Parser.Services;

public class MatchDataParserService
{
    public static IReadOnlyCollection<Round> GetRoundsFromFile(string filepath)
    {
        var filteredMatchDataSegment = GetFilteredMatchDataSegmentFromFile(filepath);

        var rounds = new List<Round>();
        var handlerChain = ActionHandlerSetup.SetupChain();
        
        for (var i = 0; i < filteredMatchDataSegment.Count; i++)
        {
            if (filteredMatchDataSegment[i].Contains("Game Over"))
            {
                break;
            }
            
            if (filteredMatchDataSegment[i].Contains("Round_Start"))
            {
                var roundEvents = new List<RoundEvent>();
        
                while (i < filteredMatchDataSegment.Count && !filteredMatchDataSegment[i - 1].Contains("Round_End"))
                {
                    var timestamp = TimeExtractor.ParseTimestampFromActionLog(filteredMatchDataSegment[i]);
        
                    var result = handlerChain.Parse(filteredMatchDataSegment[i]);
                    if (result != null)
                    {
                        roundEvents.Add(new RoundEvent(timestamp, result));
                    }
                    
                    i++;
                }
                
                rounds.Add(new Round(roundEvents));
            }
        }

        return rounds;
    }

    private static ArraySegment<string> GetFilteredMatchDataSegmentFromFile(string filepath)
    {
        var lines = File.ReadAllLines(filepath, Encoding.UTF8);

        var matchStartIndices = new List<int>();
        for (var i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains("Match_Start"))
            {
                matchStartIndices.Add(i);
            }
        }

        var matchActualStartIndex = matchStartIndices.Max();
        var filteredMatchDataSegment = new ArraySegment<string>(lines, matchActualStartIndex, lines.Length - matchActualStartIndex);
        
        return filteredMatchDataSegment;
    }
}