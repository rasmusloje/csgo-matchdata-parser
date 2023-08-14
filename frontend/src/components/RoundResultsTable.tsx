import { RoundResult } from "../types";

interface RoundResultsTableProps {
  rounds: RoundResult[];
}

function getImageName(winType: string): string {
  if (winType == "TerroristsWin") {
    return "/img/t_win.svg";
  } else if (winType == "TerroristsWinByBombExplosion") {
    return "/img/bomb_exploded.svg";
  } else if (winType == "CounterTerroristsWin") {
    return "/img/ct_win.svg";
  } else if (winType == "CounterTerroristsWinByDefusingBomb") {
    return "/img/bomb_defused.svg";
  }

  return "";
}

function getTeamWhoWonTheRound(
  winType: string,
  teamCt: string,
  teamT: string
): string {
  if (winType == "TerroristsWin") {
    return teamT + " won the round by time or eliminating opponents";
  } else if (winType == "TerroristsWinByBombExplosion") {
    return teamT + " won the round by bomb explosion";
  } else if (winType == "CounterTerroristsWin") {
    return teamCt + " won the round by time or eliminating opponents";
  } else if (winType == "CounterTerroristsWinByDefusingBomb") {
    return teamCt + " won the round by defusing the bomb";
  }

  return "";
}

const RoundResultsTable = ({ rounds }: RoundResultsTableProps) => {
  return (
    <>
      <div className="section">
        <h2>Round Results</h2>
        <div className="table-responsive">
          <table className="table table-borderless">
            <thead>
              <tr>
                {rounds.map((round, i) => (
                  <td key={i}>{round.roundNumber}</td>
                ))}
              </tr>
            </thead>
            <tbody>
              <tr>
                {rounds.map((round, i) => (
                  <td key={i}>
                    <img
                      src={getImageName(round.roundWinType)}
                      className="round-outcome"
                      title={getTeamWhoWonTheRound(
                        round.roundWinType,
                        round.teamPlayingCounterTerrorist,
                        round.teamPlayingTerrorist
                      )}
                    />
                  </td>
                ))}
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </>
  );
};

export default RoundResultsTable;
