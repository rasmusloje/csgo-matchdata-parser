export interface Team {
  name: string;
  playerNames: string[];
}

export interface Teams {
  teamOne: Team;
  teamTwo: Team;
}

export interface TeamScores {
  teamName: string;
  score: number;
}

export interface RoundResult {
  roundNumber: number;
  teamPlayingCounterTerrorist: string;
  teamPlayingTerrorist: string;
  roundWinType: string;
}

export interface MatchResult {
  teamScores?: TeamScores[];
  roundResults?: RoundResult[];
}

export interface MatchResultResponse {
  matchResult: MatchResult;
}
