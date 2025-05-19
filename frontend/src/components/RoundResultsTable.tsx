import { Fragment } from "react"
import { RoundResult } from "../types"

interface RoundResultsTableProps {
  rounds: RoundResult[]
}

function getImageName(winType: string): string {
  if (winType === "TerroristsWin") {
    return "/img/t_win.svg"
  } else if (winType === "TerroristsWinByBombExplosion") {
    return "/img/bomb_exploded.svg"
  } else if (winType === "CounterTerroristsWin") {
    return "/img/ct_win.svg"
  } else if (winType === "CounterTerroristsWinByDefusingBomb") {
    return "/img/bomb_defused.svg"
  }

  return ""
}

function getTeamWhoWonTheRound(
  winType: string,
  teamCt: string,
  teamT: string
): string {
  if (winType === "TerroristsWin") {
    return teamT + " won the round by time or eliminating opponents"
  } else if (winType === "TerroristsWinByBombExplosion") {
    return teamT + " won the round by bomb explosion"
  } else if (winType === "CounterTerroristsWin") {
    return teamCt + " won the round by time or eliminating opponents"
  } else if (winType === "CounterTerroristsWinByDefusingBomb") {
    return teamCt + " won the round by defusing the bomb"
  }

  return ""
}

function renderTeamImage(round: RoundResult) {
  return (
    <img
      src={getImageName(round.roundWinType)}
      className="round-outcome"
      title={getTeamWhoWonTheRound(
        round.roundWinType,
        round.teamPlayingCounterTerrorist,
        round.teamPlayingTerrorist
      )}
      alt="Round outcome"
    />
  )
}

export const RoundResultsTable = ({ rounds }: RoundResultsTableProps) => {
  return (
    <div className="section">
      <h2>Round Results</h2>
      <div className="table-responsive">
        <table className="table table-borderless">
          <thead>
            <tr>
              {rounds.map((round, i) =>
                i === 15 ? (
                  <Fragment key={i}>
                    <td key={1000}>-</td>
                    <td key={i}>{round.roundNumber}</td>
                  </Fragment>
                ) : (
                  <td key={i}>{round.roundNumber}</td>
                )
              )}
            </tr>
          </thead>
          <tbody>
            <tr>
              {rounds.map((round, i) =>
                i === 15 ? (
                  <Fragment key={i}>
                    <td key={1000}>
                      <img
                        src="img/people-arrows-solid.svg"
                        className="round-outcome"
                        title="Halftime - Switching sides"
                        alt="Halftime"
                      />
                    </td>
                    <td key={i}>{renderTeamImage(round)}</td>
                  </Fragment>
                ) : (
                  <td key={i}>{renderTeamImage(round)}</td>
                )
              )}
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  )
}
