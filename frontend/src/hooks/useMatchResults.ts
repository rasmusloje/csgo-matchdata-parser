import { useQuery } from "@tanstack/react-query"
import { apiGet } from "../api"
import { MatchResultResponse } from "../types"

export const useMatchResults = () =>
  useQuery({
    queryKey: ["matchResults"],
    queryFn: async () => {
      const response = await apiGet<MatchResultResponse>("match/results")
      return response.data.matchResult
    },
  })
