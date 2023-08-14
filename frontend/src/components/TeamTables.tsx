import { useEffect, useState } from "react";
import PlayerStatTable from "./PlayerStatisticsTable";
import { apiGet } from "../api";

interface TeamTablesProps {
  teamOne: string;
  teamTwo: string;
  teamOnePlayers: string[];
  teamTwoPlayers: string[];
}

export interface PlayerKillDeath {
  playerName: string;
  amountOfKills: number;
  amountOfDeaths: number;
}

interface PlayerKillDeathResponse {
  playerKillDeathCounts: PlayerKillDeath[];
}

const TeamTables = ({
  teamOne,
  teamTwo,
  teamOnePlayers,
  teamTwoPlayers,
}: TeamTablesProps) => {
  const [teamOnePlayerKillDeaths, setTeamOnePlayerKillDeaths] =
    useState<PlayerKillDeath[]>();
  const [teamTwoPlayerKillDeaths, setTeamTwoPlayerKillDeaths] =
    useState<PlayerKillDeath[]>();
  const [loadingPlayerKillDeaths, setLoadingPlayerKillDeaths] =
    useState<boolean>(true);

  useEffect(() => {
    apiGet<PlayerKillDeathResponse>("PlayerStatistics/KillDeath").then((response) => {
      const filteredTeamOnePlayers = response.data!.playerKillDeathCounts.filter((player) =>
        teamOnePlayers.includes(player.playerName)
      );
      const filteredTeamTwoPlayers = response.data!.playerKillDeathCounts.filter((player) =>
        teamTwoPlayers.includes(player.playerName)
      );
      setTeamOnePlayerKillDeaths(filteredTeamOnePlayers);
      setTeamTwoPlayerKillDeaths(filteredTeamTwoPlayers);

      setLoadingPlayerKillDeaths(false);
    });
  }, []);

  return (
    <>
      {!loadingPlayerKillDeaths && (
        <div className="section">
          <div className="row">
            <PlayerStatTable
              teamName={teamOne}
              players={teamOnePlayerKillDeaths!}
            />
            <PlayerStatTable
              teamName={teamTwo}
              players={teamTwoPlayerKillDeaths!}
            />
          </div>
        </div>
      )}
    </>
  );
};

export default TeamTables;
