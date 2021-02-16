using System;
using System.Xml;
using System.Xml.Serialization;
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
            for (int i = 1; i < 11; i++)
            {


                GameDesc gameDesc = new GameDesc
                {
                    galaxySeed = i,
                    starCount = 64
                };
                ThemeProtoSet themes = DSPSeedFilter.PublicTheme();
                int length = themes.dataArray.Length;
                gameDesc.themeIds = new int[length];
                for (int index = 0; index < length; ++index)
                {
                    gameDesc.themeIds[index] = themes.dataArray[index].ID;
                }

                GalaxyData galaxyData = MUniverseGen.CreateGalaxy(gameDesc);
                System.Console.WriteLine("SEED: " + galaxyData.seed);
                System.Console.WriteLine("START: " + galaxyData.stars[0].displayName);
            }






            System.Console.WriteLine("Finish");
            System.Console.ReadLine();

        }

        public static ThemeProtoSet PublicTheme()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ThemeProtoSet));
            ThemeProtoSet themes = (ThemeProtoSet)serializer.Deserialize(new XmlTextReader("ThemeProtoSet.xml"));
            return themes;
        }

    }

}


public class GameDesc
{
    public int[] themeIds;
    public int galaxySeed;
    public int starCount;
}






