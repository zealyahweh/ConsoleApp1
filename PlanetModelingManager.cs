// Decompiled with JetBrains decompiler
// Type: PlanetModelingManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 22C4C399-B83F-4A90-970F-58ADEF11038D
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\Dyson Sphere Program\DSPGAME_Data\Managed\Assembly-CSharp.dll

//using System;
//using System.Collections.Generic;
//using System.Threading;
//using UnityEngine;
//using UnityEngine.Rendering;

public static class PlanetModelingManager
{
    //public static Queue<PlanetData> genPlanetReqList = (Queue<PlanetData>)null;
    //public static Queue<PlanetData> modPlanetReqList = (Queue<PlanetData>)null;
    //public static Queue<PlanetData> fctPlanetReqList = (Queue<PlanetData>)null;
    //private static Thread planetComputeThread;
    //private static PlanetModelingManager.ThreadFlag planetComputeThreadFlag;
    //private static PlanetModelingManager.ThreadFlagLock planetComputeThreadFlagLock = new PlanetModelingManager.ThreadFlagLock();
    //public static List<string> planetComputeThreadLogs = new List<string>();
    //public static string planetComputeThreadError = string.Empty;
    //private static PlanetData currentModelingPlanet;
    //private static int currentModelingStage = 0;
    //private static int currentModelingSeamNormal = 0;
    //private static PlanetData currentFactingPlanet;
    //private static int currentFactingStage = 0;
    //private static List<Mesh> tmpMeshList = (List<Mesh>)null;
    //private static List<MeshRenderer> tmpMeshRendererList = (List<MeshRenderer>)null;
    //private static List<MeshCollider> tmpMeshColliderList = (List<MeshCollider>)null;
    //private static Collider tmpOceanCollider;
    //private static List<Vector3> tmpVerts = (List<Vector3>)null;
    //private static List<Vector3> tmpNorms = (List<Vector3>)null;
    //private static List<Vector4> tmpTgnts = (List<Vector4>)null;
    //private static List<Vector2> tmpUvs = (List<Vector2>)null;
    //private static List<Vector4> tmpUv2s = (List<Vector4>)null;
    //private static List<int> tmpTris = (List<int>)null;
    //private static GameObject tmpPlanetGameObject;
    //private static GameObject tmpPlanetBodyGameObject;
    //private static GameObject tmpPlanetReformGameObject;
    //private static MeshRenderer tmpPlanetReformRenderer;
    //public static short[] vegeHps;
    //public static Vector4[] vegeScaleRanges;
    //public static VegeProto[] vegeProtos;
    //public static int[] veinProducts;
    //public static int[] veinModelIndexs;
    //public static int[] veinModelCounts;
    //public static VeinProto[] veinProtos;
    //public static Camera heightmapCamera;
  
    public static PlanetAlgorithm Algorithm(PlanetData planet)
    {
        PlanetAlgorithm planetAlgorithm;
        switch (planet.algoId)
        {
            case 1:
                planetAlgorithm = (PlanetAlgorithm)new PlanetAlgorithm1();
                break;
            case 2:
                planetAlgorithm = (PlanetAlgorithm)new PlanetAlgorithm2();
                break;
            case 3:
                planetAlgorithm = (PlanetAlgorithm)new PlanetAlgorithm3();
                break;
            case 4:
                planetAlgorithm = (PlanetAlgorithm)new PlanetAlgorithm4();
                break;
            case 5:
                planetAlgorithm = (PlanetAlgorithm)new PlanetAlgorithm5();
                break;
            case 6:
                planetAlgorithm = (PlanetAlgorithm)new PlanetAlgorithm6();
                break;
            case 7:
                planetAlgorithm = (PlanetAlgorithm)new PlanetAlgorithm7();
                break;
            default:
                planetAlgorithm = (PlanetAlgorithm)new PlanetAlgorithm0();
                break;
        }
        planetAlgorithm?.Reset(planet.seed, planet);
        return planetAlgorithm;
    }

    //private enum ThreadFlag
    //{
    //    Ended,
    //    Running,
    //    Ending,
    //}
    //
    //private class ThreadFlagLock
    //{
    //    private int obj;
    //}
}
