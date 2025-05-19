import { usePlayerKillDeathStats } from "../hooks/usePlayerKillDeathStats"
import { PlayerStatisticsTable } from "./PlayerStatisticsTable"

interface TeamTablesProps {
  teamOne: string
  teamTwo: string
  teamOnePlayers: string[]
  teamTwoPlayers: string[]
}

export const TeamTables = ({
  teamOne,
  teamTwo,
  teamOnePlayers,
  teamTwoPlayers,
}: TeamTablesProps) => {
  const { data: allPlayerStats, isLoading } = usePlayerKillDeathStats()

  const teamOnePlayerKillDeaths = allPlayerStats?.filter((player) =>
    teamOnePlayers.includes(player.playerName)
  )

  const teamTwoPlayerKillDeaths = allPlayerStats?.filter((player) =>
    teamTwoPlayers.includes(player.playerName)
  )

  return (
    <>
      {!isLoading && (
        <div className="section">
          <div className="row">
            <PlayerStatisticsTable
              teamName={teamOne}
              players={teamOnePlayerKillDeaths!}
            />
            <PlayerStatisticsTable
              teamName={teamTwo}
              players={teamTwoPlayerKillDeaths!}
            />
          </div>
        </div>
      )}
    </>
  )
}
