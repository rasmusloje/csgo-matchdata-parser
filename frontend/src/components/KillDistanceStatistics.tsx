import { useKillDistanceStats } from "../hooks/useKillDistanceStats"

export const KillDistanceStatistics = () => {
  const { data: killDistanceStatistics, isLoading } = useKillDistanceStats()

  return (
    <>
      {!isLoading && killDistanceStatistics && (
        <div className="section">
          <div className="row">
            <div className="col-4">
              <h3>Shortest distance kill</h3>
              <p>
                {Math.round(
                  killDistanceStatistics.shortestKillDistance.distanceInMetres
                )}{" "}
                metres (
                {Math.round(
                  killDistanceStatistics.shortestKillDistance.distanceInUnits
                )}{" "}
                units)
              </p>
            </div>
            <div className="col-4">
              <h3>Average distance kill</h3>
              <p>
                {Math.round(
                  killDistanceStatistics.averageKillDistance.distanceInMetres
                )}{" "}
                metres (
                {Math.round(
                  killDistanceStatistics.averageKillDistance.distanceInUnits
                )}{" "}
                units)
              </p>
            </div>
            <div className="col-4">
              <h3>Longest distance kill</h3>
              <p>
                {Math.round(
                  killDistanceStatistics.longestKillDistance.distanceInMetres
                )}{" "}
                metres (
                {Math.round(
                  killDistanceStatistics.longestKillDistance.distanceInUnits
                )}{" "}
                units)
              </p>
            </div>
          </div>
        </div>
      )}
    </>
  )
}
