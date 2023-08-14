import axios, { AxiosResponse } from "axios";

export function apiGet<T>(route: string): Promise<AxiosResponse<T, any>> {
    return axios
      .get<T>(
        "http://localhost:5176/api/" + route,
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      )
}