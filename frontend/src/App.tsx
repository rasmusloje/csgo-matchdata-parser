import "./App.css";
import MatchResultHeader from "./components/MatchResultHeader";
import RoundResultsTable from "./components/RoundResultsTable";
import TeamTables from "./components/TeamTables";
import KillDistanceStatistics from "./components/KillDistanceStatistics";
import { useState, useEffect } from "react";
import { Teams, MatchResult, MatchResultResponse, TeamScores } from "./types";
import { apiGet } from "./api";

function App() {
  const [teams, setTeams] = useState<Teams>();
  const [loadingTeams, setLoadingTeams] = useState<boolean>(true);

  const [matchResult, setMatchResult] = useState<MatchResult>();
  const [loadingMatchResult, setLoadingMatchResult] = useState<boolean>(true);

  useEffect(() => {
    apiGet<MatchResultResponse>("MatchStatistics/Result").then((response) => {
      setMatchResult(response.data.matchResult);
      setLoadingMatchResult(false);
    });

    apiGet<Teams>("Match/Teams").then((response) => {
      setTeams(response.data);
      setLoadingTeams(false);
    });
  }, []);

  function getTeamScore(teamName: string, teamScores: TeamScores[]): number {
    let team = teamScores.find((t) => t.teamName == teamName);

    return team!.score;
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
  );
}

export default App;
