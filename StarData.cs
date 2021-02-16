using System;
using UnityEngine;

public class StarData
{
    public GalaxyData galaxy;
    public int seed;
    public int index;
    public int id;
    public string name = string.Empty;
    public string overrideName = string.Empty;
    public VectorLF3 position = VectorLF3.zero;
    public VectorLF3 uPosition;
    public float mass = 1f;
    public float lifetime = 50f;
    public float age;
    public EStarType type;
    public float temperature = 8500f;
    public ESpectrType spectr;
    public float classFactor;
    public float color;
    public float luminosity = 1f;
    public float radius = 1f;
    public float acdiskRadius;
    public float habitableRadius = 1f;
    public float lightBalanceRadius = 1f;
    public float dysonRadius = 10f;
    public float orbitScaler = 1f;
    public float asterBelt1OrbitIndex;
    public float asterBelt2OrbitIndex;
    public float asterBelt1Radius;
    public float asterBelt2Radius;
    public int planetCount;
    public float level;
    public float resourceCoef = 1f;
    public PlanetData[] planets;
    public const double kEnterDistance = 3600000.0;
    public const float kPhysicsRadiusRatio = 1200f;
    public const float kViewRadiusRatio = 800f;

    public string displayName => string.IsNullOrEmpty(this.overrideName) ? this.name : this.overrideName;

    public float dysonLumino => Mathf.Round((float)Math.Pow((double)this.luminosity, 0.330000013113022) * 1000f) / 1000f;

    public float systemRadius
    {
        get
        {
            float num = this.dysonRadius;
            if (this.planetCount > 0)
                num = this.planets[this.planetCount - 1].sunDistance;
            return num;
        }
    }

    public float physicsRadius => this.radius * 1200f;

    public float viewRadius => this.radius * 800f;

    public string typeString
    {
        get
        {
            string str = string.Empty;
            if (this.type == EStarType.GiantStar)
                str = this.spectr > ESpectrType.K ? (this.spectr > ESpectrType.F ? (this.spectr != ESpectrType.A ? str + "蓝巨星" : str + "白巨星") : str + "黄巨星") : str + "红巨星";
            else if (this.type == EStarType.WhiteDwarf)
                str += "白矮星";
            else if (this.type == EStarType.NeutronStar)
                str += "中子星";
            else if (this.type == EStarType.BlackHole)
                str += "黑洞";
            else if (this.type == EStarType.MainSeqStar)
                str = str + this.spectr.ToString() + "型恒星";
            return str;
        }
    }

    public long GetResourceAmount(int type)
    {
        long num = 0;
        for (int index = 0; index < this.planetCount; ++index)
        {
            PlanetData planet = this.planets[index];
            if (planet.type != EPlanetType.Gas)
                num += planet.veinAmounts[type];
        }
        return num;
    }

    public int GetResourceSpots(int type)
    {
        int num = 0;
        for (int index = 0; index < this.planetCount; ++index)
        {
            PlanetData planet = this.planets[index];
            if (planet.type != EPlanetType.Gas && planet.veinSpotsSketch != null)
                num += planet.veinSpotsSketch[type];
        }
        return num;
    }

    public bool loaded
    {
        get
        {
            if (this.planets == null)
                return false;
            for (int index = 0; index < this.planetCount; ++index)
            {
                if (!this.planets[index].loaded)
                    return false;
            }
            return true;
        }
    }


    public string OrbitsDescString()
    {
        string str = string.Empty;
        for (int index1 = 1; index1 <= 12; ++index1)
        {
            int num = 0;
            for (int index2 = 0; index2 < this.planetCount; ++index2)
            {
                if (this.planets[index2].orbitAround == 0 && this.planets[index2].orbitIndex == index1)
                {
                    num = this.planets[index2].number;
                    break;
                }
            }
            str = (double)this.asterBelt1OrbitIndex != (double)index1 ? ((double)this.asterBelt2OrbitIndex != (double)index1 ? str + num.ToString() : str + "b") : str + "a";
        }
        return str;
    }
}
