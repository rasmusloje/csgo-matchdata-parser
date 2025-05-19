import "./App.css"
import { KillDistanceStatistics } from "./components/KillDistanceStatistics"
import { MatchResultHeader } from "./components/MatchResultHeader"
import { RoundResultsTable } from "./components/RoundResultsTable"
import { TeamTables } from "./components/TeamTables"
import { useMatchResults } from "./hooks/useMatchResults"
import { useMatchTeams } from "./hooks/useMatchTeams"
import { TeamScores } from "./types"

function App() {
  const { data: teams, isLoading: loadingTeams } = useMatchTeams()
  const { data: matchResult, isLoading: loadingMatchResult } = useMatchResults()

  function getTeamScore(teamName: string, teamScores: TeamScores[]): number {
    const team = teamScores.find((t) => t.teamName === teamName)
    return team?.score ?? 0
  }

  return (
    <div className="h-100 text-center">
      <div className="col-lg-8 mx-auto p-3 py-md-5">
        <header className="d-flex justify-content-center pb-3 mb-5 border-bottom">
          <span className="fs-4">CS:GO Match Data Visualization</span>
        </header>

        <main>
          {!loadingMatchResult && !loadingTeams && (
            <MatchResultHeader
              teamOne={teams!.teamOne.name}
              teamTwo={teams!.teamTwo.name}
              teamOneScore={getTeamScore(
                teams!.teamOne.name,
                matchResult!.teamScores!
              )}
              teamTwoScore={getTeamScore(
                teams!.teamTwo.name,
                matchResult!.teamScores!
              )}
            />
          )}

          {!loadingMatchResult && (
            <RoundResultsTable rounds={matchResult!.roundResults!} />
          )}

          {!loadingTeams && (
            <TeamTables
              teamOne={teams!.teamOne.name}
              teamTwo={teams!.teamTwo.name}
              teamOnePlayers={teams!.teamOne.playerNames}
              teamTwoPlayers={teams!.teamTwo.playerNames}
            />
          )}

          <KillDistanceStatistics />
        </main>
      </div>
    </div>
  )
}

export default App
