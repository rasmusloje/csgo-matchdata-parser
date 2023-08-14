namespace CsgoMatchData.Parser.Models;

public class Distance
{
    private const float CsgoUnitToMetreRatio = (float)2.54;
    
    public Distance(float distanceInUnits)
    {
        DistanceInUnits = distanceInUnits;
    }

    public float DistanceInUnits { get; }
    public float DistanceInMetres => DistanceInUnits * CsgoUnitToMetreRatio / 100;
}