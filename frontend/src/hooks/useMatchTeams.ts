import { useQuery } from "@tanstack/react-query"
import { apiGet } from "../api"
import { Teams } from "../types"

export const useMatchTeams = () =>
  useQuery({
    queryKey: ["matchTeams"],
    queryFn: async () => {
      const response = await apiGet<Teams>("match/teams")
      return response.data
    },
  })
