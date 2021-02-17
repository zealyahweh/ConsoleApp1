using System;
using System.Xml;
using System.Xml.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using Unity;



namespace DSPSeedFilter
{
    public static class DSPSeedFilter

    {

        //GalaxySeed = 14171500;
        //StarSeed = 1826783713
        static void Main()
        {
            DateTime StartTime = DateTime.Now;
            GameDesc gameDesc = new GameDesc
            {
                starCount = 64
            };
            ThemeProtoSet themes = ThemeWorks.GetThemes();
            int length = themes.dataArray.Length;
            gameDesc.themeIds = new int[length];
            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 50;



            for (int index = 0; index < length; ++index)
            {
                gameDesc.themeIds[index] = themes.dataArray[index].ID;
            }

            int StartSeed = 73295657;
            int EndSeed = 73295657;
            Parallel.For(
                StartSeed, 
                EndSeed + 1, 
                options, 
                (i, loopState) =>
                {
                    System.Console.WriteLine("StartLoop " + i.ToString("D8"));
                    gameDesc.galaxySeed = i;
                    MUniverseGen MUniverseGen = new MUniverseGen();
                    GalaxyData galaxyData = MUniverseGen.CreateGalaxy(gameDesc);
                    System.Console.WriteLine("Seed: " + galaxyData.seed.ToString("D8") + " BirthStar: " + galaxyData.stars[0].displayName);
                }
            
            );

            //for (int i = StartSeed; i < EndSeed+1; i++)
            //{
            //    gameDesc.galaxySeed = i;
            //    GalaxyData galaxyData = MUniverseGen.CreateGalaxy(gameDesc);
            //    System.Console.WriteLine("Seed: " + galaxyData.seed.ToString("D8") + " BirthStar: "+galaxyData.stars[0].displayName);
            //    //System.Console.WriteLine("START: " + galaxyData.stars[0].displayName);
            //    //System.Console.WriteLine("BH: " + galaxyData.stars[63].displayName);
            //    //System.Console.WriteLine("BH: " + galaxyData.stars[63].position.magnitude);
            //}








            DateTime EndTime = DateTime.Now;

            System.Console.WriteLine("Finished");
            Console.WriteLine("Time Used: " + EndTime.Subtract(StartTime).TotalSeconds + "Seconds");
            Console.WriteLine("Seed Calculated: " + (EndSeed - StartSeed + 1));
            System.Console.ReadLine();

        }

    }

}


public class GameDesc
{
    public int[] themeIds;
    public int galaxySeed;
    public int starCount;
}

public sealed class ThemeWorks
{
    private static ThemeWorks uniqueInstance;
    public ThemeProtoSet Theme;

    private ThemeWorks()
    {

    }

    public static ThemeProtoSet GetThemes()
    {
        if (uniqueInstance == null)
        {
            uniqueInstance = new ThemeWorks();
            XmlSerializer serializer = new XmlSerializer(typeof(ThemeProtoSet));
            ThemeProtoSet themes = (ThemeProtoSet)serializer.Deserialize(new XmlTextReader("ThemeProtoSet.xml"));
            uniqueInstance.Theme = themes;
        }
        return uniqueInstance.Theme;
    }

}




