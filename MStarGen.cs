using System;
using UnityEngine;

public static class StarGen
{
    public static float[] orbitRadius = new float[17]
    {
    0.0f,
    0.4f,
    0.7f,
    1f,
    1.4f,
    1.9f,
    2.5f,
    3.3f,
    4.3f,
    5.5f,
    6.9f,
    8.4f,
    10f,
    11.7f,
    13.5f,
    15.4f,
    17.5f
    };
    public static float specifyBirthStarMass = 0.0f;
    public static float specifyBirthStarAge = 0.0f;
    private static double[] pGas = new double[10];
    private const double PI = 3.14159265358979;

    public static StarData CreateStar(
      GalaxyData galaxy,
      VectorLF3 pos,
      int id,
      int seed,
      EStarType needtype,
      ESpectrType needSpectr = ESpectrType.X)
    {
        StarData starData = new StarData()
        {
            galaxy = galaxy,
            index = id - 1
        };
        starData.level = galaxy.starCount <= 1 ? 0.0f : (float)starData.index / (float)(galaxy.starCount - 1);
        starData.id = id;
        starData.seed = seed;
        Random random1 = new Random(seed);
        int seed1 = random1.Next();
        int Seed = random1.Next();
        starData.position = pos;
        float num1 = (float)pos.magnitude / 32f;
        if ((double)num1 > 1.0)
            num1 = Mathf.Log(Mathf.Log(Mathf.Log(Mathf.Log(Mathf.Log(num1) + 1f) + 1f) + 1f) + 1f) + 1f;
        starData.resourceCoef = Mathf.Pow(7f, num1) * 0.6f;
        Random random2 = new Random(Seed);
        double r1 = random2.NextDouble();
        double r2 = random2.NextDouble();
        double num2 = random2.NextDouble();
        double rn = random2.NextDouble();
        double rt = random2.NextDouble();
        double num3 = (random2.NextDouble() - 0.5) * 0.2;
        double num4 = random2.NextDouble() * 0.2 + 0.9;
        double y = random2.NextDouble() * 0.4 - 0.2;
        double num5 = Math.Pow(2.0, y);
        float num6 = Mathf.Lerp(-0.98f, 0.88f, starData.level);
        float averageValue = (double)num6 >= 0.0 ? num6 + 0.65f : num6 - 0.65f;
        float standardDeviation = 0.33f;
        if (needtype == EStarType.GiantStar)
        {
            averageValue = y <= -0.08 ? 1.6f : -1.5f;
            standardDeviation = 0.3f;
        }
        float num7 = StarGen.RandNormal(averageValue, standardDeviation, r1, r2);
        switch (needSpectr)
        {
            case ESpectrType.M:
                num7 = -3f;
                break;
            case ESpectrType.O:
                num7 = 3f;
                break;
        }
        float p1 = (float)((double)Mathf.Clamp((double)num7 <= 0.0 ? num7 * 1f : num7 * 2f, -2.4f, 4.65f) + num3 + 1.0);
        switch (needtype)
        {
            case EStarType.WhiteDwarf:
                starData.mass = (float)(1.0 + r2 * 5.0);
                break;
            case EStarType.NeutronStar:
                starData.mass = (float)(7.0 + r1 * 11.0);
                break;
            case EStarType.BlackHole:
                starData.mass = (float)(18.0 + r1 * r2 * 30.0);
                break;
            default:
                starData.mass = Mathf.Pow(2f, p1);
                break;
        }
        double d = 5.0;
        if ((double)starData.mass < 2.0)
            d = 2.0 + 0.4 * (1.0 - (double)starData.mass);
        starData.lifetime = (float)(10000.0 * Math.Pow(0.1, Math.Log10((double)starData.mass * 0.5) / Math.Log10(d) + 1.0) * num4);
        switch (needtype)
        {
            case EStarType.GiantStar:
                starData.lifetime = (float)(10000.0 * Math.Pow(0.1, Math.Log10((double)starData.mass * 0.58) / Math.Log10(d) + 1.0) * num4);
                starData.age = (float)(num2 * 0.0399999991059303 + 0.959999978542328);
                break;
            case EStarType.WhiteDwarf:
            case EStarType.NeutronStar:
            case EStarType.BlackHole:
                starData.age = (float)(num2 * 0.400000005960464 + 1.0);
                if (needtype == EStarType.WhiteDwarf)
                {
                    starData.lifetime += 10000f;
                    break;
                }
                if (needtype == EStarType.NeutronStar)
                {
                    starData.lifetime += 1000f;
                    break;
                }
                break;
            default:
                starData.age = (double)starData.mass >= 0.5 ? ((double)starData.mass >= 0.8 ? (float)(num2 * 0.699999988079071 + 0.200000002980232) : (float)(num2 * 0.400000005960464 + 0.100000001490116)) : (float)(num2 * 0.119999997317791 + 0.0199999995529652);
                break;
        }
        float num8 = starData.lifetime * starData.age;
        if ((double)num8 > 5000.0)
            num8 = (float)(((double)Mathf.Log(num8 / 5000f) + 1.0) * 5000.0);
        if ((double)num8 > 8000.0)
            num8 = (Mathf.Log(Mathf.Log(Mathf.Log(num8 / 8000f) + 1f) + 1f) + 1f) * 8000f;
        starData.lifetime = num8 / starData.age;
        float f = (float)(1.0 - (double)Mathf.Pow(Mathf.Clamp01(starData.age), 20f) * 0.5) * starData.mass;
        starData.temperature = (float)(Math.Pow((double)f, 0.56 + 0.14 / (Math.Log10((double)f + 4.0) / Math.Log10(5.0))) * 4450.0 + 1300.0);
        double num9 = Math.Log10(((double)starData.temperature - 1300.0) / 4500.0) / Math.Log10(2.6) - 0.5;
        if (num9 < 0.0)
            num9 *= 4.0;
        if (num9 > 2.0)
            num9 = 2.0;
        else if (num9 < -4.0)
            num9 = -4.0;
        starData.spectr = (ESpectrType)Mathf.RoundToInt((float)num9 + 4f);
        starData.color = Mathf.Clamp01((float)((num9 + 3.5) * 0.200000002980232));
        starData.classFactor = (float)num9;
        starData.luminosity = Mathf.Pow(f, 0.7f);
        starData.radius = (float)(Math.Pow((double)starData.mass, 0.4) * num5);
        starData.acdiskRadius = 0.0f;
        float p2 = (float)num9 + 2f;
        starData.habitableRadius = Mathf.Pow(1.7f, p2) + 0.25f * Mathf.Min(1f, starData.orbitScaler);
        starData.lightBalanceRadius = Mathf.Pow(1.7f, p2);
        starData.orbitScaler = Mathf.Pow(1.35f, p2);
        if ((double)starData.orbitScaler < 1.0)
            starData.orbitScaler = Mathf.Lerp(starData.orbitScaler, 1f, 0.6f);
        StarGen.SetStarAge(starData, starData.age, rn, rt);
        starData.dysonRadius = starData.orbitScaler * 0.28f;
        if ((double)starData.dysonRadius * 40000.0 < (double)starData.physicsRadius * 1.5)
            starData.dysonRadius = (float)((double)starData.physicsRadius * 1.5 / 40000.0);
        starData.uPosition = starData.position * 2400000.0;
        starData.name = NameGen.RandomStarName(seed1, starData, galaxy);
        starData.overrideName = string.Empty;
        return starData;
    }

    public static StarData CreateBirthStar(GalaxyData galaxy, int seed)
    {
        StarData starData = new StarData();
        starData.galaxy = galaxy;
        starData.index = 0;
        starData.level = 0.0f;
        starData.id = 1;
        starData.seed = seed;
        starData.resourceCoef = 0.6f;
        Random random1 = new Random(seed);
        int seed1 = random1.Next();
        int Seed = random1.Next();
        starData.name = NameGen.RandomName(seed1);
        starData.overrideName = string.Empty;
        starData.position = VectorLF3.zero;
        Random random2 = new Random(Seed);
        double r1 = random2.NextDouble();
        double r2 = random2.NextDouble();
        double num1 = random2.NextDouble();
        double rn = random2.NextDouble();
        double rt = random2.NextDouble();
        double num2 = random2.NextDouble() * 0.2 + 0.9;
        double num3 = Math.Pow(2.0, random2.NextDouble() * 0.4 - 0.2);
        float p1 = Mathf.Clamp(StarGen.RandNormal(0.0f, 0.08f, r1, r2), -0.2f, 0.2f);
        starData.mass = Mathf.Pow(2f, p1);
        if ((double)StarGen.specifyBirthStarMass > 0.100000001490116)
            starData.mass = StarGen.specifyBirthStarMass;
        if ((double)StarGen.specifyBirthStarAge > 9.99999974737875E-06)
            starData.age = StarGen.specifyBirthStarAge;
        double d = 2.0 + 0.4 * (1.0 - (double)starData.mass);
        starData.lifetime = (float)(10000.0 * Math.Pow(0.1, Math.Log10((double)starData.mass * 0.5) / Math.Log10(d) + 1.0) * num2);
        starData.age = (float)(num1 * 0.4 + 0.3);
        if ((double)StarGen.specifyBirthStarAge > 9.99999974737875E-06)
            starData.age = StarGen.specifyBirthStarAge;
        float f = (float)(1.0 - (double)Mathf.Pow(Mathf.Clamp01(starData.age), 20f) * 0.5) * starData.mass;
        starData.temperature = (float)(Math.Pow((double)f, 0.56 + 0.14 / (Math.Log10((double)f + 4.0) / Math.Log10(5.0))) * 4450.0 + 1300.0);
        double num4 = Math.Log10(((double)starData.temperature - 1300.0) / 4500.0) / Math.Log10(2.6) - 0.5;
        if (num4 < 0.0)
            num4 *= 4.0;
        if (num4 > 2.0)
            num4 = 2.0;
        else if (num4 < -4.0)
            num4 = -4.0;
        starData.spectr = (ESpectrType)Mathf.RoundToInt((float)num4 + 4f);
        starData.color = Mathf.Clamp01((float)((num4 + 3.5) * 0.200000002980232));
        starData.classFactor = (float)num4;
        starData.luminosity = Mathf.Pow(f, 0.7f);
        starData.radius = (float)(Math.Pow((double)starData.mass, 0.4) * num3);
        starData.acdiskRadius = 0.0f;
        float p2 = (float)num4 + 2f;
        starData.habitableRadius = Mathf.Pow(1.7f, p2) + 0.2f * Mathf.Min(1f, starData.orbitScaler);
        starData.lightBalanceRadius = Mathf.Pow(1.7f, p2);
        starData.orbitScaler = Mathf.Pow(1.35f, p2);
        if ((double)starData.orbitScaler < 1.0)
            starData.orbitScaler = Mathf.Lerp(starData.orbitScaler, 1f, 0.6f);
        StarGen.SetStarAge(starData, starData.age, rn, rt);
        starData.dysonRadius = starData.orbitScaler * 0.28f;
        if ((double)starData.dysonRadius * 40000.0 < (double)starData.physicsRadius * 1.5)
            starData.dysonRadius = (float)((double)starData.physicsRadius * 1.5 / 40000.0);
        starData.uPosition = VectorLF3.zero;
        starData.name = NameGen.RandomStarName(seed1, starData, galaxy);
        starData.overrideName = string.Empty;
        return starData;
    }

    private static double _signpow(double x, double pow)
    {
        double num = x <= 0.0 ? -1.0 : 1.0;
        return Math.Abs(Math.Pow(x, pow)) * num;
    }

    public static void CreateStarPlanets(GalaxyData galaxy, StarData star, GameDesc gameDesc)
    {
        Random random1 = new Random(star.seed);
        random1.Next();
        random1.Next();
        random1.Next();
        Random random2 = new Random(random1.Next());
        double num1 = random2.NextDouble();
        double num2 = random2.NextDouble();
        double num3 = random2.NextDouble();
        double num4 = random2.NextDouble();
        double num5 = random2.NextDouble();
        double num6 = random2.NextDouble() * 0.2 + 0.9;
        double num7 = random2.NextDouble() * 0.2 + 0.9;
        if (star.type == EStarType.BlackHole)
        {
            star.planetCount = 1;
            star.planets = new PlanetData[star.planetCount];
            int info_seed = random2.Next();
            int gen_seed = random2.Next();
            star.planets[0] = MPlanetGen.CreatePlanet(galaxy, star, gameDesc, 0, 0, 3, 1, false, info_seed, gen_seed);
        }
        else if (star.type == EStarType.NeutronStar)
        {
            star.planetCount = 1;
            star.planets = new PlanetData[star.planetCount];
            int info_seed = random2.Next();
            int gen_seed = random2.Next();
            star.planets[0] = MPlanetGen.CreatePlanet(galaxy, star, gameDesc, 0, 0, 3, 1, false, info_seed, gen_seed);
        }
        else if (star.type == EStarType.WhiteDwarf)
        {
            if (num1 < 0.699999988079071)
            {
                star.planetCount = 1;
                star.planets = new PlanetData[star.planetCount];
                int info_seed = random2.Next();
                int gen_seed = random2.Next();
                star.planets[0] = MPlanetGen.CreatePlanet(galaxy, star, gameDesc, 0, 0, 3, 1, false, info_seed, gen_seed);
            }
            else
            {
                star.planetCount = 2;
                star.planets = new PlanetData[star.planetCount];
                if (num2 < 0.300000011920929)
                {
                    int info_seed1 = random2.Next();
                    int gen_seed1 = random2.Next();
                    star.planets[0] = MPlanetGen.CreatePlanet(galaxy, star, gameDesc, 0, 0, 3, 1, false, info_seed1, gen_seed1);
                    int info_seed2 = random2.Next();
                    int gen_seed2 = random2.Next();
                    star.planets[1] = MPlanetGen.CreatePlanet(galaxy, star, gameDesc, 1, 0, 4, 2, false, info_seed2, gen_seed2);
                }
                else
                {
                    int info_seed1 = random2.Next();
                    int gen_seed1 = random2.Next();
                    star.planets[0] = MPlanetGen.CreatePlanet(galaxy, star, gameDesc, 0, 0, 4, 1, true, info_seed1, gen_seed1);
                    int info_seed2 = random2.Next();
                    int gen_seed2 = random2.Next();
                    star.planets[1] = MPlanetGen.CreatePlanet(galaxy, star, gameDesc, 1, 1, 1, 1, false, info_seed2, gen_seed2);
                }
            }
        }
        else if (star.type == EStarType.GiantStar)
        {
            if (num1 < 0.300000011920929)
            {
                star.planetCount = 1;
                star.planets = new PlanetData[star.planetCount];
                int info_seed = random2.Next();
                int gen_seed = random2.Next();
                star.planets[0] = MPlanetGen.CreatePlanet(galaxy, star, gameDesc, 0, 0, num3 <= 0.5 ? 2 : 3, 1, false, info_seed, gen_seed);
            }
            else if (num1 < 0.800000011920929)
            {
                star.planetCount = 2;
                star.planets = new PlanetData[star.planetCount];
                if (num2 < 0.25)
                {
                    int info_seed1 = random2.Next();
                    int gen_seed1 = random2.Next();
                    star.planets[0] = MPlanetGen.CreatePlanet(galaxy, star, gameDesc, 0, 0, num3 <= 0.5 ? 2 : 3, 1, false, info_seed1, gen_seed1);
                    int info_seed2 = random2.Next();
                    int gen_seed2 = random2.Next();
                    star.planets[1] = MPlanetGen.CreatePlanet(galaxy, star, gameDesc, 1, 0, num3 <= 0.5 ? 3 : 4, 2, false, info_seed2, gen_seed2);
                }
                else
                {
                    int info_seed1 = random2.Next();
                    int gen_seed1 = random2.Next();
                    star.planets[0] = MPlanetGen.CreatePlanet(galaxy, star, gameDesc, 0, 0, 3, 1, true, info_seed1, gen_seed1);
                    int info_seed2 = random2.Next();
                    int gen_seed2 = random2.Next();
                    star.planets[1] = MPlanetGen.CreatePlanet(galaxy, star, gameDesc, 1, 1, 1, 1, false, info_seed2, gen_seed2);
                }
            }
            else
            {
                star.planetCount = 3;
                star.planets = new PlanetData[star.planetCount];
                if (num2 < 0.150000005960464)
                {
                    int info_seed1 = random2.Next();
                    int gen_seed1 = random2.Next();
                    star.planets[0] = MPlanetGen.CreatePlanet(galaxy, star, gameDesc, 0, 0, num3 <= 0.5 ? 2 : 3, 1, false, info_seed1, gen_seed1);
                    int info_seed2 = random2.Next();
                    int gen_seed2 = random2.Next();
                    star.planets[1] = MPlanetGen.CreatePlanet(galaxy, star, gameDesc, 1, 0, num3 <= 0.5 ? 3 : 4, 2, false, info_seed2, gen_seed2);
                    int info_seed3 = random2.Next();
                    int gen_seed3 = random2.Next();
                    star.planets[2] = MPlanetGen.CreatePlanet(galaxy, star, gameDesc, 2, 0, num3 <= 0.5 ? 4 : 5, 3, false, info_seed3, gen_seed3);
                }
                else if (num2 < 0.75)
                {
                    int info_seed1 = random2.Next();
                    int gen_seed1 = random2.Next();
                    star.planets[0] = MPlanetGen.CreatePlanet(galaxy, star, gameDesc, 0, 0, num3 <= 0.5 ? 2 : 3, 1, false, info_seed1, gen_seed1);
                    int info_seed2 = random2.Next();
                    int gen_seed2 = random2.Next();
                    star.planets[1] = MPlanetGen.CreatePlanet(galaxy, star, gameDesc, 1, 0, 4, 2, true, info_seed2, gen_seed2);
                    int info_seed3 = random2.Next();
                    int gen_seed3 = random2.Next();
                    star.planets[2] = MPlanetGen.CreatePlanet(galaxy, star, gameDesc, 2, 2, 1, 1, false, info_seed3, gen_seed3);
                }
                else
                {
                    int info_seed1 = random2.Next();
                    int gen_seed1 = random2.Next();
                    star.planets[0] = MPlanetGen.CreatePlanet(galaxy, star, gameDesc, 0, 0, num3 <= 0.5 ? 3 : 4, 1, true, info_seed1, gen_seed1);
                    int info_seed2 = random2.Next();
                    int gen_seed2 = random2.Next();
                    star.planets[1] = MPlanetGen.CreatePlanet(galaxy, star, gameDesc, 1, 1, 1, 1, false, info_seed2, gen_seed2);
                    int info_seed3 = random2.Next();
                    int gen_seed3 = random2.Next();
                    star.planets[2] = MPlanetGen.CreatePlanet(galaxy, star, gameDesc, 2, 1, 2, 2, false, info_seed3, gen_seed3);
                }
            }
        }
        else
        {
            Array.Clear((Array)StarGen.pGas, 0, StarGen.pGas.Length);
            if (star.index == 0)
            {
                star.planetCount = 4;
                StarGen.pGas[0] = 0.0;
                StarGen.pGas[1] = 0.0;
                StarGen.pGas[2] = 0.0;
            }
            else if (star.spectr == ESpectrType.M)
            {
                star.planetCount = num1 >= 0.1 ? (num1 >= 0.3 ? (num1 >= 0.8 ? 4 : 3) : 2) : 1;
                if (star.planetCount <= 3)
                {
                    StarGen.pGas[0] = 0.2;
                    StarGen.pGas[1] = 0.2;
                }
                else
                {
                    StarGen.pGas[0] = 0.0;
                    StarGen.pGas[1] = 0.2;
                    StarGen.pGas[2] = 0.3;
                }
            }
            else if (star.spectr == ESpectrType.K)
            {
                star.planetCount = num1 >= 0.1 ? (num1 >= 0.2 ? (num1 >= 0.7 ? (num1 >= 0.95 ? 5 : 4) : 3) : 2) : 1;
                if (star.planetCount <= 3)
                {
                    StarGen.pGas[0] = 0.18;
                    StarGen.pGas[1] = 0.18;
                }
                else
                {
                    StarGen.pGas[0] = 0.0;
                    StarGen.pGas[1] = 0.18;
                    StarGen.pGas[2] = 0.28;
                    StarGen.pGas[3] = 0.28;
                }
            }
            else if (star.spectr == ESpectrType.G)
            {
                star.planetCount = num1 >= 0.4 ? (num1 >= 0.9 ? 5 : 4) : 3;
                if (star.planetCount <= 3)
                {
                    StarGen.pGas[0] = 0.18;
                    StarGen.pGas[1] = 0.18;
                }
                else
                {
                    StarGen.pGas[0] = 0.0;
                    StarGen.pGas[1] = 0.2;
                    StarGen.pGas[2] = 0.3;
                    StarGen.pGas[3] = 0.3;
                }
            }
            else if (star.spectr == ESpectrType.F)
            {
                star.planetCount = num1 >= 0.35 ? (num1 >= 0.8 ? 5 : 4) : 3;
                if (star.planetCount <= 3)
                {
                    StarGen.pGas[0] = 0.2;
                    StarGen.pGas[1] = 0.2;
                }
                else
                {
                    StarGen.pGas[0] = 0.0;
                    StarGen.pGas[1] = 0.22;
                    StarGen.pGas[2] = 0.31;
                    StarGen.pGas[3] = 0.31;
                }
            }
            else if (star.spectr == ESpectrType.A)
            {
                star.planetCount = num1 >= 0.3 ? (num1 >= 0.75 ? 5 : 4) : 3;
                if (star.planetCount <= 3)
                {
                    StarGen.pGas[0] = 0.2;
                    StarGen.pGas[1] = 0.2;
                }
                else
                {
                    StarGen.pGas[0] = 0.1;
                    StarGen.pGas[1] = 0.28;
                    StarGen.pGas[2] = 0.3;
                    StarGen.pGas[3] = 0.35;
                }
            }
            else if (star.spectr == ESpectrType.B)
            {
                star.planetCount = num1 >= 0.3 ? (num1 >= 0.75 ? 6 : 5) : 4;
                if (star.planetCount <= 3)
                {
                    StarGen.pGas[0] = 0.2;
                    StarGen.pGas[1] = 0.2;
                }
                else
                {
                    StarGen.pGas[0] = 0.1;
                    StarGen.pGas[1] = 0.22;
                    StarGen.pGas[2] = 0.28;
                    StarGen.pGas[3] = 0.35;
                    StarGen.pGas[4] = 0.35;
                }
            }
            else if (star.spectr == ESpectrType.O)
            {
                star.planetCount = num1 >= 0.5 ? 6 : 5;
                StarGen.pGas[0] = 0.1;
                StarGen.pGas[1] = 0.2;
                StarGen.pGas[2] = 0.25;
                StarGen.pGas[3] = 0.3;
                StarGen.pGas[4] = 0.32;
                StarGen.pGas[5] = 0.35;
            }
            else
                star.planetCount = 1;
            star.planets = new PlanetData[star.planetCount];
            int num8 = 0;
            int num9 = 0;
            int orbitAround = 0;
            int num10 = 1;
            for (int index = 0; index < star.planetCount; ++index)
            {
                int info_seed = random2.Next();
                int gen_seed = random2.Next();
                double num11 = random2.NextDouble();
                double num12 = random2.NextDouble();
                bool gasGiant = false;
                if (orbitAround == 0)
                {
                    ++num8;
                    if (index < star.planetCount - 1 && num11 < StarGen.pGas[index])
                    {
                        gasGiant = true;
                        if (num10 < 3)
                            num10 = 3;
                    }
                    for (; star.index != 0 || num10 != 3; ++num10)
                    {
                        int num13 = star.planetCount - index;
                        int num14 = 9 - num10;
                        if (num14 > num13)
                        {
                            float a = (float)num13 / (float)num14;
                            float num15 = num10 <= 3 ? Mathf.Lerp(a, 1f, 0.15f) + 0.01f : Mathf.Lerp(a, 1f, 0.45f) + 0.01f;
                            if (random2.NextDouble() < (double)num15)
                                goto label_63;
                        }
                        else
                            goto label_63;
                    }
                    gasGiant = true;
                }
                else
                {
                    ++num9;
                    gasGiant = false;
                }
            label_63:
                star.planets[index] = MPlanetGen.CreatePlanet(galaxy, star, gameDesc, index, orbitAround, orbitAround != 0 ? num9 : num10, orbitAround != 0 ? num9 : num8, gasGiant, info_seed, gen_seed);
                ++num10;
                if (gasGiant)
                {
                    orbitAround = num8;
                    num9 = 0;
                }
                if (num9 >= 1 && num12 < 0.8)
                {
                    orbitAround = 0;
                    num9 = 0;
                }
            }
        }
        int num16 = 0;
        int num17 = 0;
        int index1 = 0;
        for (int index2 = 0; index2 < star.planetCount; ++index2)
        {
            if (star.planets[index2].type == EPlanetType.Gas)
            {
                num16 = star.planets[index2].orbitIndex;
                break;
            }
        }
        for (int index2 = 0; index2 < star.planetCount; ++index2)
        {
            if (star.planets[index2].orbitAround == 0)
                num17 = star.planets[index2].orbitIndex;
        }
        if (num16 > 0)
        {
            int num8 = num16 - 1;
            bool flag = true;
            for (int index2 = 0; index2 < star.planetCount; ++index2)
            {
                if (star.planets[index2].orbitAround == 0 && star.planets[index2].orbitIndex == num16 - 1)
                {
                    flag = false;
                    break;
                }
            }
            if (flag && num4 < 0.2 + (double)num8 * 0.2)
                index1 = num8;
        }
        int index3 = num5 >= 0.2 ? (num5 >= 0.4 ? (num5 >= 0.8 ? 0 : num17 + 1) : num17 + 2) : num17 + 3;
        if (index3 != 0 && index3 < 5)
            index3 = 5;
        star.asterBelt1OrbitIndex = (float)index1;
        star.asterBelt2OrbitIndex = (float)index3;
        if (index1 > 0)
            star.asterBelt1Radius = StarGen.orbitRadius[index1] * (float)num6 * star.orbitScaler;
        if (index3 <= 0)
            return;
        star.asterBelt2Radius = StarGen.orbitRadius[index3] * (float)num7 * star.orbitScaler;
    }

    public static void SetStarAge(StarData star, float age, double rn, double rt)
    {
        float num1 = (float)(rn * 0.1 + 0.95);
        float num2 = (float)(rt * 0.4 + 0.8);
        float num3 = (float)(rt * 9.0 + 1.0);
        star.age = age;
        if ((double)age >= 1.0)
        {
            if ((double)star.mass >= 18.0)
            {
                star.type = EStarType.BlackHole;
                star.spectr = ESpectrType.X;
                star.mass *= 2.5f * num2;
                star.radius *= 1f;
                star.acdiskRadius = star.radius * 5f;
                star.temperature = 0.0f;
                star.luminosity *= 1f / 1000f * num1;
                star.habitableRadius = 0.0f;
                star.lightBalanceRadius *= 0.4f * num1;
            }
            else if ((double)star.mass >= 7.0)
            {
                star.type = EStarType.NeutronStar;
                star.spectr = ESpectrType.X;
                star.mass *= 0.2f * num1;
                star.radius *= 0.15f;
                star.acdiskRadius = star.radius * 9f;
                star.temperature = num3 * 1E+07f;
                star.luminosity *= 0.1f * num1;
                star.habitableRadius = 0.0f;
                star.lightBalanceRadius *= 3f * num1;
                star.orbitScaler *= 1.5f * num1;
            }
            else
            {
                star.type = EStarType.WhiteDwarf;
                star.spectr = ESpectrType.X;
                star.mass *= 0.2f * num1;
                star.radius *= 0.2f;
                star.acdiskRadius = 0.0f;
                star.temperature = num2 * 150000f;
                star.luminosity *= 0.04f * num2;
                star.habitableRadius *= 0.15f * num2;
                star.lightBalanceRadius *= 0.2f * num1;
            }
        }
        else
        {
            if ((double)age < 0.959999978542328)
                return;
            float num4 = (float)(Math.Pow(5.0, Math.Abs(Math.Log10((double)star.mass) - 0.7)) * 5.0);
            if ((double)num4 > 10.0)
                num4 = (float)(((double)Mathf.Log(num4 * 0.1f) + 1.0) * 10.0);
            float num5 = (float)(1.0 - (double)Mathf.Pow(star.age, 30f) * 0.5);
            star.type = EStarType.GiantStar;
            star.mass = num5 * star.mass;
            star.radius = num4 * num2;
            star.acdiskRadius = 0.0f;
            star.temperature = num5 * star.temperature;
            star.luminosity = 1.6f * star.luminosity;
            star.habitableRadius = 9f * star.habitableRadius;
            star.lightBalanceRadius = 3f * star.habitableRadius;
            star.orbitScaler = 3.3f * star.orbitScaler;
        }
    }

    private static float RandNormal(
      float averageValue,
      float standardDeviation,
      double r1,
      double r2)
    {
        return averageValue + standardDeviation * (float)(Math.Sqrt(-2.0 * Math.Log(1.0 - r1)) * Math.Sin(2.0 * Math.PI * r2));
    }
}
