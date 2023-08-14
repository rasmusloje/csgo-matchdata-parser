import { PlayerKillDeath } from "./TeamTables";

interface PlayerStatisticsProps {
  teamName: string;
  players: PlayerKillDeath[];
}

const PlayerStatisticsTable = ({
  teamName,
  players,
}: PlayerStatisticsProps) => {
  return (
    <>
      <div className="col-6">
        <h3>{teamName}</h3>
        <div className="table-responsive">
          <table className="table">
            <thead>
              <tr>
                <td>Player Name</td>
                <td>Kills</td>
                <td>Deaths</td>
              </tr>
            </thead>
            <tbody>
              {players
                .sort(function (a, b) {
                  return b.amountOfKills - a.amountOfKills;
                })
                .map((player, i) => (
                  <tr key={i}>
                    <td>{player.playerName}</td>
                    <td>{player.amountOfKills}</td>
                    <td>{player.amountOfDeaths}</td>
                  </tr>
                ))}
            </tbody>
          </table>
        </div>
      </div>
    </>
  );
};

export default PlayerStatisticsTable;
