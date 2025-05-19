import { useQuery } from "@tanstack/react-query"
import { apiGet } from "../api"
import { KillDistanceStatisticsResponse } from "../types"

export const useKillDistanceStats = () =>
  useQuery<KillDistanceStatisticsResponse>({
    queryKey: ["killDistanceStats"],
    queryFn: async () => {
      const response = await apiGet<KillDistanceStatisticsResponse>(
        "match/statistics/kill-distances"
      )
      return response.data
    },
  })
