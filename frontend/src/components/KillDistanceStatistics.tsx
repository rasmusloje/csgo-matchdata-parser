import { useEffect, useState } from "react";
import { apiGet } from "../api";

interface DistanceStatistic {
  distanceInUnits: number;
  distanceInMetres: number;
}

interface KillDistanceStatistics {
  shortestKillDistance: DistanceStatistic;
  averageKillDistance: DistanceStatistic;
  longestKillDistance: DistanceStatistic;
}

const KillDistanceStatistics = () => {
  const [killDistanceStatistics, setKillDistanceStatistics] =
    useState<KillDistanceStatistics>();
  const [loadingKillDistanceStatistics, setLoadingKillDistanceStatistics] =
    useState<boolean>(true);

  useEffect(() => {
    apiGet<KillDistanceStatistics>("MatchStatistics/KillDistances").then(
      (response) => {
        setKillDistanceStatistics(response.data);
        setLoadingKillDistanceStatistics(false);
      }
    );
  }, []);

  return (
    <>
      {!loadingKillDistanceStatistics && (
        <div className="section">
          <div className="row">
            <div className="col-4">
              <h3>Shortest distance kill</h3>
              <p>
                {Math.round(
                  killDistanceStatistics!.shortestKillDistance.distanceInMetres
                )}{" "}
                metres (
                {Math.round(
                  killDistanceStatistics!.shortestKillDistance.distanceInUnits
                )}{" "}
                units)
              </p>
            </div>
            <div className="col-4">
              <h3>Average distance kill</h3>
              <p>
                {Math.round(
                  killDistanceStatistics!.averageKillDistance.distanceInMetres
                )}{" "}
                metres (
                {Math.round(
                  killDistanceStatistics!.averageKillDistance.distanceInUnits
                )}{" "}
                units)
              </p>
            </div>
            <div className="col-4">
              <h3>Longest distance kill</h3>
              <p>
                {Math.round(
                  killDistanceStatistics!.longestKillDistance.distanceInMetres
                )}{" "}
                metres (
                {Math.round(
                  killDistanceStatistics!.longestKillDistance.distanceInUnits
                )}{" "}
                units)
              </p>
            </div>
          </div>
        </div>
      )}
    </>
  );
};

export default KillDistanceStatistics;
