public class GalaxyData
{
    public int seed;
    public int starCount;
    public StarData[] stars;
    public int birthPlanetId;
    public int birthStarId;
    public int habitableCount;
    public const double AU = 40000.0;
    public const double LY = 2400000.0;
    //public StarGraphNode[] graphNodes;
    //public AstroPose[] astroPoses;

    //public GalaxyData() => this.astroPoses = new AstroPose[25600];


    public StarData StarById(int starId)
    {
        int index = starId - 1;
        return index < 0 || index >= this.stars.Length ? (StarData)null : this.stars[index];
    }

    public PlanetData PlanetById(int planetId)
    {
        int index1 = planetId / 100 - 1;
        int index2 = planetId % 100 - 1;
        if (index1 < 0 || index1 >= this.stars.Length)
            return (PlanetData)null;
        if (this.stars[index1] == null)
            return (PlanetData)null;
        return index2 < 0 || index2 >= this.stars[index1].planets.Length ? (PlanetData)null : this.stars[index1].planets[index2];
    }

    //public void UpdatePoses(double time)
    //{
    //    for (int index1 = 0; index1 < this.starCount; ++index1)
    //    {
    //        for (int index2 = 0; index2 < this.stars[index1].planetCount; ++index2)
    //            this.stars[index1].planets[index2].UpdateRuntimePose(time);
    //    }
    //}
}
