import { useQuery } from "@tanstack/react-query"
import { apiGet } from "../api"
import { PlayerKillDeathResponse } from "../types"

export const usePlayerKillDeathStats = () =>
  useQuery({
    queryKey: ["playerKillDeathStats"],
    queryFn: async () => {
      const response = await apiGet<PlayerKillDeathResponse>(
        "match/statistics/kill-death"
      )
      return response.data.playerKillDeathCounts
    },
  })
