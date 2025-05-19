interface MatchResultHeaderProps {
  teamOne?: string
  teamTwo?: string
  teamOneScore?: number
  teamTwoScore?: number
}

export const MatchResultHeader = ({
  teamOne,
  teamTwo,
  teamOneScore,
  teamTwoScore,
}: MatchResultHeaderProps) => {
  return (
    <h1>
      {teamOne} ({teamOneScore}) vs. {teamTwo} ({teamTwoScore})
    </h1>
  )
}
