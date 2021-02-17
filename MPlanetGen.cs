using System;
using System.Collections.Generic;
using UnityEngine;

public class MPlanetGen
{
    public float[] orbitRadius = new float[17]
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
    public const double GRAVITY = 1.35385519905204E-06;
    public const double PI = 3.14159265358979;
    private List<int> tmp_theme;

    public PlanetData CreatePlanet(
      GalaxyData galaxy,
      StarData star,
      GameDesc gameDesc,
      int index,
      int orbitAround,
      int orbitIndex,
      int number,
      bool gasGiant,
      int info_seed,
      int gen_seed)
    {
        PlanetData planet = new PlanetData();
        Random random = new Random(info_seed);
        planet.index = index;
        planet.galaxy = star.galaxy;
        planet.star = star;
        planet.seed = gen_seed;
        planet.orbitAround = orbitAround;
        planet.orbitIndex = orbitIndex;
        planet.number = number;
        planet.id = star.id * 100 + index + 1;
        StarData[] stars = galaxy.stars;
        int num1 = 0;
        for (int index1 = 0; index1 < star.index; ++index1)
            num1 += stars[index1].planetCount;
        int num2 = num1 + index;
        if (orbitAround > 0)
        {
            for (int index1 = 0; index1 < star.planetCount; ++index1)
            {
                if (orbitAround == star.planets[index1].number && star.planets[index1].orbitAround == 0)
                {
                    planet.orbitAroundPlanet = star.planets[index1];
                    if (orbitIndex > 1)
                    {
                        planet.orbitAroundPlanet.singularity |= EPlanetSingularity.MultipleSatellites;
                        break;
                    }
                    break;
                }
            }
            //Assert.NotNull((object)planet.orbitAroundPlanet);
        }
        string str = star.planetCount > 20 ? (index + 1).ToString() : NameGen.roman[index + 1];
        planet.name = star.name + " " + str + "号星";
        double num3 = random.NextDouble();
        double num4 = random.NextDouble();
        double num5 = random.NextDouble();
        double num6 = random.NextDouble();
        double num7 = random.NextDouble();
        double num8 = random.NextDouble();
        double num9 = random.NextDouble();
        double num10 = random.NextDouble();
        double num11 = random.NextDouble();
        double num12 = random.NextDouble();
        double num13 = random.NextDouble();
        double num14 = random.NextDouble();
        double rand1 = random.NextDouble();
        double num15 = random.NextDouble();
        double rand2 = random.NextDouble();
        double rand3 = random.NextDouble();
        double rand4 = random.NextDouble();
        int theme_seed = random.Next();
        float a = Mathf.Pow(1.2f, (float)(num3 * (num4 - 0.5) * 0.5));
        float f1;
        if (orbitAround == 0)
        {
            float b = orbitRadius[orbitIndex] * star.orbitScaler;
            float num16 = (float)(((double)a - 1.0) / (double)Mathf.Max(1f, b) + 1.0);
            f1 = b * num16;
        }
        else
            f1 = (float)(((1600.0 * (double)orbitIndex + 200.0) * (double)Mathf.Pow(star.orbitScaler, 0.3f) * (double)Mathf.Lerp(a, 1f, 0.5f) + (double)planet.orbitAroundPlanet.realRadius) / 40000.0);
        planet.orbitRadius = f1;
        planet.orbitInclination = (float)(num5 * 16.0 - 8.0);
        if (orbitAround > 0)
            planet.orbitInclination *= 2.2f;
        planet.orbitLongitude = (float)(num6 * 360.0);
        if (star.type >= EStarType.NeutronStar)
        {
            if ((double)planet.orbitInclination > 0.0)
                planet.orbitInclination += 3f;
            else
                planet.orbitInclination -= 3f;
        }
        planet.orbitalPeriod = planet.orbitAroundPlanet != null ? Math.Sqrt(39.4784176043574 * (double)f1 * (double)f1 * (double)f1 / 1.08308421068537E-08) : Math.Sqrt(39.4784176043574 * (double)f1 * (double)f1 * (double)f1 / (1.35385519905204E-06 * (double)star.mass));
        planet.orbitPhase = (float)(num7 * 360.0);
        if (num15 < 0.0399999991059303)
        {
            planet.obliquity = (float)(num8 * (num9 - 0.5) * 39.9);
            if ((double)planet.obliquity < 0.0)
                planet.obliquity -= 70f;
            else
                planet.obliquity += 70f;
            planet.singularity |= EPlanetSingularity.LaySide;
        }
        else if (num15 < 0.100000001490116)
        {
            planet.obliquity = (float)(num8 * (num9 - 0.5) * 80.0);
            if ((double)planet.obliquity < 0.0)
                planet.obliquity -= 30f;
            else
                planet.obliquity += 30f;
        }
        else
            planet.obliquity = (float)(num8 * (num9 - 0.5) * 60.0);
        planet.rotationPeriod = (num10 * num11 * 1000.0 + 400.0) * (orbitAround != 0 ? 1.0 : (double)Mathf.Pow(f1, 0.25f)) * (!gasGiant ? 1.0 : 0.200000002980232);
        if (!gasGiant)
        {
            if (star.type == EStarType.WhiteDwarf)
                planet.rotationPeriod *= 0.5;
            else if (star.type == EStarType.NeutronStar)
                planet.rotationPeriod *= 0.200000002980232;
            else if (star.type == EStarType.BlackHole)
                planet.rotationPeriod *= 0.150000005960464;
        }
        planet.rotationPhase = (float)(num12 * 360.0);
        planet.sunDistance = orbitAround != 0 ? planet.orbitAroundPlanet.orbitRadius : planet.orbitRadius;
        planet.scale = 1f;
        double num17 = orbitAround != 0 ? planet.orbitAroundPlanet.orbitalPeriod : planet.orbitalPeriod;
        planet.rotationPeriod = 1.0 / (1.0 / num17 + 1.0 / planet.rotationPeriod);
        if (orbitAround == 0 && orbitIndex <= 4 && !gasGiant)
        {
            if (num15 > 0.959999978542328)
            {
                planet.obliquity *= 0.01f;
                planet.rotationPeriod = planet.orbitalPeriod;
                planet.singularity |= EPlanetSingularity.TidalLocked;
            }
            else if (num15 > 0.930000007152557)
            {
                planet.obliquity *= 0.1f;
                planet.rotationPeriod = planet.orbitalPeriod * 0.5;
                planet.singularity |= EPlanetSingularity.TidalLocked2;
            }
            else if (num15 > 0.899999976158142)
            {
                planet.obliquity *= 0.2f;
                planet.rotationPeriod = planet.orbitalPeriod * 0.25;
                planet.singularity |= EPlanetSingularity.TidalLocked4;
            }
        }
        if (num15 > 0.85 && num15 <= 0.9)
        {
            planet.rotationPeriod = -planet.rotationPeriod;
            planet.singularity |= EPlanetSingularity.ClockwiseRotate;
        }
        //planet.runtimeOrbitRotation = Quaternion.AngleAxis(planet.orbitLongitude, Vector3.up) * Quaternion.AngleAxis(planet.orbitInclination, Vector3.forward);
        //if (planet.orbitAroundPlanet != null)
        //    planet.runtimeOrbitRotation = planet.orbitAroundPlanet.runtimeOrbitRotation * planet.runtimeOrbitRotation;
        //planet.runtimeSystemRotation = planet.runtimeOrbitRotation * Quaternion.AngleAxis(planet.obliquity, Vector3.forward);
        float habitableRadius = star.habitableRadius;
        if (gasGiant)
        {
            planet.type = EPlanetType.Gas;
            planet.radius = 80f;
            planet.scale = 10f;
            planet.habitableBias = 100f;
        }
        else
        {
            float num16 = Mathf.Ceil((float)star.galaxy.starCount * 0.29f);
            if ((double)num16 < 11.0)
                num16 = 11f;
            float num18 = num16 - (float)star.galaxy.habitableCount;
            float num19 = (float)(star.galaxy.starCount - star.index);
            float sunDistance = planet.sunDistance;
            float num20 = 1000f;
            float f2 = 1000f;
            if ((double)habitableRadius > 0.0 && (double)sunDistance > 0.0)
            {
                f2 = sunDistance / habitableRadius;
                num20 = Mathf.Abs(Mathf.Log(f2));
            }
            float num21 = Mathf.Clamp(Mathf.Sqrt(habitableRadius), 1f, 2f) - 0.04f;
            float num22 = Mathf.Clamp(Mathf.Lerp(num18 / num19, 0.35f, 0.5f), 0.08f, 0.8f);
            planet.habitableBias = num20 * num21;
            planet.temperatureBias = (float)(1.20000004768372 / ((double)f2 + 0.200000002980232) - 1.0);
            float num23 = Mathf.Pow(Mathf.Clamp01(planet.habitableBias / num22), num22 * 10f);
            if (num13 > (double)num23 && star.index > 0 || planet.orbitAround > 0 && planet.orbitIndex == 1 && star.index == 0)
            {
                planet.type = EPlanetType.Ocean;
                ++star.galaxy.habitableCount;
            }
            else if ((double)f2 < 0.833333015441895)
            {
                float num24 = Mathf.Max(0.15f, (float)((double)f2 * 2.5 - 0.850000023841858));
                planet.type = num14 >= (double)num24 ? EPlanetType.Vocano : EPlanetType.Desert;
            }
            else if ((double)f2 < 1.20000004768372)
            {
                planet.type = EPlanetType.Desert;
            }
            else
            {
                float num24 = (float)(0.899999976158142 / (double)f2 - 0.100000001490116);
                planet.type = num14 >= (double)num24 ? EPlanetType.Ice : EPlanetType.Desert;
            }
            planet.radius = 200f;
        }
        if (planet.type != EPlanetType.Gas && planet.type != EPlanetType.None)
        {
            planet.precision = 200;
            planet.segment = 5;
        }
        else
        {
            planet.precision = 64;
            planet.segment = 2;
        }
        planet.luminosity = Mathf.Pow(planet.star.lightBalanceRadius / (planet.sunDistance + 0.01f), 0.6f);
        if ((double)planet.luminosity > 1.0)
        {
            planet.luminosity = Mathf.Log(planet.luminosity) + 1f;
            planet.luminosity = Mathf.Log(planet.luminosity) + 1f;
            planet.luminosity = Mathf.Log(planet.luminosity) + 1f;
        }
        planet.luminosity = Mathf.Round(planet.luminosity * 100f) / 100f;
        this.SetPlanetTheme(planet, star, gameDesc, 0, 0, rand1, rand2, rand3, rand4, theme_seed);
        //star.galaxy.astroPoses[planet.id].uRadius = planet.realRadius;
        return planet;
    }

    public void SetPlanetTheme(
      PlanetData planet,
      StarData star,
      GameDesc game_desc,
      int set_theme,
      int set_algo,
      double rand1,
      double rand2,
      double rand3,
      double rand4,
      int theme_seed)
    {
        if (set_theme > 0)
        {
            planet.theme = set_theme;
        }
        else
        {
            if (this.tmp_theme == null)
                this.tmp_theme = new List<int>();
            else
                this.tmp_theme.Clear();
            int[] themeIds = game_desc.themeIds;
            int length = themeIds.Length;
            for (int index1 = 0; index1 < length; ++index1)
            {
                ThemeProtoSet themes1 = ThemeWorks.GetThemes();
                var themeProto = themes1.dataArray[index1];
                bool flag = false;
                if (planet.star.index == 0 && planet.type == EPlanetType.Ocean)
                {
                    if (themeProto.Distribute == EThemeDistribute.Birth)
                        flag = true;
                }
                else if (themeProto.PlanetType == planet.type && (double)themeProto.Temperature * (double)planet.temperatureBias >= -0.100000001490116)
                {
                    if (planet.star.index == 0)
                    {
                        if (themeProto.Distribute == EThemeDistribute.Default)
                            flag = true;
                    }
                    else if (themeProto.Distribute != EThemeDistribute.Birth)
                        flag = true;
                }
                if (flag)
                {
                    for (int index2 = 0; index2 < planet.index; ++index2)
                    {
                        if (planet.star.planets[index2].theme == themeProto.ID)
                        {
                            flag = false;
                            break;
                        }
                    }
                }
                if (flag)
                    this.tmp_theme.Add(themeProto.ID);
            }
            if (this.tmp_theme.Count == 0)
            {
                for (int index1 = 0; index1 < length; ++index1)
                {
                    ThemeProtoSet themes1 = ThemeWorks.GetThemes();
                    var themeProto = themes1.dataArray[index1];
                    bool flag = false;
                    if (themeProto.PlanetType == EPlanetType.Desert)
                        flag = true;
                    if (flag)
                    {
                        for (int index2 = 0; index2 < planet.index; ++index2)
                        {
                            if (planet.star.planets[index2].theme == themeProto.ID)
                            {
                                flag = false;
                                break;
                            }
                        }
                    }
                    if (flag)
                        this.tmp_theme.Add(themeProto.ID);
                }
            }
            if (this.tmp_theme.Count == 0)
            {
                for (int index = 0; index < length; ++index)
                {
                    ThemeProtoSet themes1 = ThemeWorks.GetThemes();
                    var themeProto = themes1.dataArray[index];
                    if (themeProto.PlanetType == EPlanetType.Desert)
                        this.tmp_theme.Add(themeProto.ID);
                }
            }
            planet.theme = this.tmp_theme[(int)(rand1 * (double)this.tmp_theme.Count) % this.tmp_theme.Count];
        }

        ThemeProtoSet themes = ThemeWorks.GetThemes();
        var themeProto1 = themes.dataArray[planet.theme - 1];

        if (set_algo > 0)
        {
            planet.algoId = set_algo;
        }
        else
        {
            planet.algoId = 0;
            if (themeProto1 != null && themeProto1.Algos != null && 1 > 0)
            {
                planet.algoId = themeProto1.Algos.@int;
                //planet.algoId = themeProto1.Algos[(int)(rand2 * (double)themeProto1.Algos.Length) % themeProto1.Algos.Length];
                planet.mod_x = (double)themeProto1.ModX.x + rand3 * ((double)themeProto1.ModX.y - (double)themeProto1.ModX.x);
                planet.mod_y = (double)themeProto1.ModY.x + rand4 * ((double)themeProto1.ModY.y - (double)themeProto1.ModY.x);
            }
        }
        if (themeProto1 == null)
            return;
        planet.type = themeProto1.PlanetType;
        planet.ionHeight = themeProto1.IonHeight;
        planet.windStrength = themeProto1.Wind;
        planet.waterHeight = themeProto1.WaterHeight;
        planet.waterItemId = themeProto1.WaterItemId;
        planet.levelized = themeProto1.UseHeightForBuild;
        if (planet.type != EPlanetType.Gas)
            return;
        int length1 = themeProto1.GasItems.Length;
        int length2 = themeProto1.GasSpeeds.Length;
        int[] numArray1 = new int[length1];
        float[] numArray2 = new float[length2];
        float[] numArray3 = new float[length1];
        for (int index = 0; index < length1; ++index)
            numArray1[index] = themeProto1.GasItems[index];
        double num1 = 0.0;
        Random random = new Random(theme_seed);
        for (int index = 0; index < length2; ++index)
        {
            float num2 = themeProto1.GasSpeeds[index] * (float)(random.NextDouble() * 0.190909147262573 + 0.909090876579285);
            numArray2[index] = num2 * Mathf.Pow(star.resourceCoef, 0.3f);
            //ItemProto itemProto = LDB.items.Select(numArray1[index]);
            //numArray3[index] = (float)itemProto.HeatValue;
            //num1 += (double)numArray3[index] * (double)numArray2[index];
        }
        //planet.gasItems = numArray1;
        planet.gasSpeeds = numArray2;
        //planet.gasHeatValues = numArray3;
        planet.gasTotalHeat = num1;
    }
}
