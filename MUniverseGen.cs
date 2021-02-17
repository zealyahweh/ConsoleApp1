using System.Xml;
using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MUniverseGen
{
    public int algoVersion = 20200403;
    private List<VectorLF3> tmp_poses;
    private List<VectorLF3> tmp_drunk;
    //private int[] tmp_state;

    public GalaxyData CreateGalaxy(GameDesc gameDesc)
    {
        int galaxySeed = gameDesc.galaxySeed;
        int starCount = gameDesc.starCount;
        StarGen StarGen = new StarGen();

        Random random = new Random(galaxySeed);
        int tempPoses = this.GenerateTempPoses(random.Next(), starCount, 4, 2.0, 2.3, 3.5, 0.18);
        GalaxyData galaxy = new GalaxyData();
        galaxy.seed = galaxySeed;
        galaxy.starCount = tempPoses;
        galaxy.stars = new StarData[tempPoses];
        //Assert.Positive(tempPoses);
        if (tempPoses <= 0)
            return galaxy;
        float num1 = (float)random.NextDouble();
        float num2 = (float)random.NextDouble();
        float num3 = (float)random.NextDouble();
        float num4 = (float)random.NextDouble();
        int num5 = Mathf.CeilToInt((float)(0.00999999977648258 * (double)tempPoses + (double)num1 * 0.300000011920929));
        int num6 = Mathf.CeilToInt((float)(0.00999999977648258 * (double)tempPoses + (double)num2 * 0.300000011920929));
        int num7 = Mathf.CeilToInt((float)(0.0160000007599592 * (double)tempPoses + (double)num3 * 0.400000005960464));
        int num8 = Mathf.CeilToInt((float)(0.0130000002682209 * (double)tempPoses + (double)num4 * 1.39999997615814));
        int num9 = tempPoses - num5;
        int num10 = num9 - num6;
        int num11 = num10 - num7;
        int num12 = (num11 - 1) / num8;
        int num13 = num12 / 2;
        for (int index = 0; index < tempPoses; ++index)
        {
            int seed = random.Next();
            if (index == 0)
            {
                //生成母星系
                galaxy.stars[index] = StarGen.CreateBirthStar(galaxy, seed);
            }
            else
            {
                ESpectrType needSpectr = ESpectrType.X;
                if (index == 3)
                    needSpectr = ESpectrType.M;
                else if (index == num11 - 1)
                    needSpectr = ESpectrType.O;
                EStarType needtype = EStarType.MainSeqStar;
                if (index % num12 == num13)
                    needtype = EStarType.GiantStar;
                if (index >= num9)
                    needtype = EStarType.BlackHole;
                else if (index >= num10)
                    needtype = EStarType.NeutronStar;
                else if (index >= num11)
                    needtype = EStarType.WhiteDwarf;
                galaxy.stars[index] = StarGen.CreateStar(galaxy, this.tmp_poses[index], index + 1, seed, needtype, needSpectr);
            }
        }
        //AstroPose[] astroPoses = galaxy.astroPoses;


        StarData[] stars = galaxy.stars;
        //for (int index = 0; index < galaxy.astroPoses.Length; ++index)
        //{
        //    astroPoses[index].uRot.w = 1f;
        //    astroPoses[index].uRotNext.w = 1f;
        //}


        for (int index = 0; index < tempPoses; ++index)
        {
            StarGen.CreateStarPlanets(galaxy, stars[index], gameDesc);
            //astroPoses[stars[index].id * 100].uPos = astroPoses[stars[index].id * 100].uPosNext = stars[index].uPosition;
            //astroPoses[stars[index].id * 100].uRot = astroPoses[stars[index].id * 100].uRotNext = Quaternion.identity;
            //astroPoses[stars[index].id * 100].uRadius = stars[index].physicsRadius;
        }
        //galaxy.UpdatePoses(0.0);


        galaxy.birthPlanetId = 0;
        if (tempPoses > 0)
        {
            StarData starData = stars[0];
            for (int index = 0; index < starData.planetCount; ++index)
            {
                PlanetData planet = starData.planets[index];
                ThemeProtoSet themes = ThemeWorks.GetThemes();
                var themeProto = themes.dataArray[planet.theme - 1];
                if (themeProto != null && themeProto.Distribute == EThemeDistribute.Birth)
                {
                    galaxy.birthPlanetId = planet.id;
                    galaxy.birthStarId = starData.id;
                    break;
                }
            }
        }
        //Assert.Positive(galaxy.birthPlanetId);
        for (int index1 = 0; index1 < tempPoses; ++index1)
        {
            StarData star = galaxy.stars[index1];
            for (int index2 = 0; index2 < star.planetCount; ++index2)
                PlanetModelingManager.Algorithm(star.planets[index2]).GenerateVeins(true);
        }
        //MUniverseGen.CreateGalaxyStarGraph(galaxy);
        return galaxy;
    }

    private int GenerateTempPoses(
      int seed,
      int targetCount,
      int iterCount,
      double minDist,
      double minStepLen,
      double maxStepLen,
      double flatten)
    {
        if (this.tmp_poses == null)
        {
            this.tmp_poses = new List<VectorLF3>();
            this.tmp_drunk = new List<VectorLF3>();
        }
        else
        {
            this.tmp_poses.Clear();
            this.tmp_drunk.Clear();
        }
        if (iterCount < 1)
            iterCount = 1;
        else if (iterCount > 16)
            iterCount = 16;
        this.RandomPoses(seed, targetCount * iterCount, minDist, minStepLen, maxStepLen, flatten);
        for (int index = this.tmp_poses.Count - 1; index >= 0; --index)
        {
            if (index % iterCount != 0)
                this.tmp_poses.RemoveAt(index);
            if (this.tmp_poses.Count <= targetCount)
                break;
        }
        return this.tmp_poses.Count;
    }

    private void RandomPoses(
      int seed,
      int maxCount,
      double minDist,
      double minStepLen,
      double maxStepLen,
      double flatten)
    {
        Random random = new Random(seed);
        double num1 = random.NextDouble();
        this.tmp_poses.Add(VectorLF3.zero);
        int num2 = 6;
        int num3 = 8;
        if (num2 < 1)
            num2 = 1;
        if (num3 < 1)
            num3 = 1;
        int num4 = (int)(num1 * (double)(num3 - num2) + (double)num2);
        for (int index = 0; index < num4; ++index)
        {
            int num5 = 0;
            while (num5++ < 256)
            {
                double num6 = random.NextDouble() * 2.0 - 1.0;
                double num7 = (random.NextDouble() * 2.0 - 1.0) * flatten;
                double num8 = random.NextDouble() * 2.0 - 1.0;
                double num9 = random.NextDouble();
                double d = num6 * num6 + num7 * num7 + num8 * num8;
                if (d <= 1.0 && d >= 1E-08)
                {
                    double num10 = Math.Sqrt(d);
                    double num11 = (num9 * (maxStepLen - minStepLen) + minDist) / num10;
                    VectorLF3 pt = new VectorLF3(num6 * num11, num7 * num11, num8 * num11);
                    if (!this.CheckCollision(this.tmp_poses, pt, minDist))
                    {
                        this.tmp_drunk.Add(pt);
                        this.tmp_poses.Add(pt);
                        if (this.tmp_poses.Count >= maxCount)
                            return;
                        break;
                    }
                }
            }
        }
        int num12 = 0;
        while (num12++ < 256)
        {
            for (int index = 0; index < this.tmp_drunk.Count; ++index)
            {
                if (random.NextDouble() <= 0.7)
                {
                    int num5 = 0;
                    while (num5++ < 256)
                    {
                        double num6 = random.NextDouble() * 2.0 - 1.0;
                        double num7 = (random.NextDouble() * 2.0 - 1.0) * flatten;
                        double num8 = random.NextDouble() * 2.0 - 1.0;
                        double num9 = random.NextDouble();
                        double d = num6 * num6 + num7 * num7 + num8 * num8;
                        if (d <= 1.0 && d >= 1E-08)
                        {
                            double num10 = Math.Sqrt(d);
                            double num11 = (num9 * (maxStepLen - minStepLen) + minDist) / num10;
                            VectorLF3 pt = new VectorLF3(this.tmp_drunk[index].x + num6 * num11, this.tmp_drunk[index].y + num7 * num11, this.tmp_drunk[index].z + num8 * num11);
                            if (!this.CheckCollision(this.tmp_poses, pt, minDist))
                            {
                                this.tmp_drunk[index] = pt;
                                this.tmp_poses.Add(pt);
                                if (this.tmp_poses.Count >= maxCount)
                                    return;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }

    private bool CheckCollision(List<VectorLF3> pts, VectorLF3 pt, double min_dist)
    {
        double num1 = min_dist * min_dist;
        foreach (VectorLF3 pt1 in pts)
        {
            double num2 = pt.x - pt1.x;
            double num3 = pt.y - pt1.y;
            double num4 = pt.z - pt1.z;
            if (num2 * num2 + num3 * num3 + num4 * num4 < num1)
                return true;
        }
        return false;
    }

    //public void CreateGalaxyStarGraph(GalaxyData galaxy)
    //{
    //    galaxy.graphNodes = new StarGraphNode[galaxy.starCount];
    //    for (int index1 = 0; index1 < galaxy.starCount; ++index1)
    //    {
    //        galaxy.graphNodes[index1] = new StarGraphNode(galaxy.stars[index1]);
    //        StarGraphNode graphNode1 = galaxy.graphNodes[index1];
    //        for (int index2 = 0; index2 < index1; ++index2)
    //        {
    //            StarGraphNode graphNode2 = galaxy.graphNodes[index2];
    //            if ((graphNode1.pos - graphNode2.pos).sqrMagnitude < 64.0)
    //            {
    //                MUniverseGen.list_sorted_add(graphNode1.conns, graphNode2);
    //                MUniverseGen.list_sorted_add(graphNode2.conns, graphNode1);
    //            }
    //        }
    //        MUniverseGen.line_arragement_for_add_node(graphNode1);
    //    }
    //}

    //private void list_sorted_add(List<StarGraphNode> l, StarGraphNode n)
    //{
    //    int count = l.Count;
    //    bool flag = false;
    //    for (int index = 0; index < count; ++index)
    //    {
    //        if (l[index].index == n.index)
    //        {
    //            flag = true;
    //            break;
    //        }
    //        if (l[index].index > n.index)
    //        {
    //            l.Insert(index, n);
    //            flag = true;
    //            break;
    //        }
    //    }
    //    if (flag)
    //        return;
    //    l.Add(n);
    //}

    //private void line_arragement_for_add_node(StarGraphNode node)
    //{
    //    if (MUniverseGen.tmp_state == null)
    //        MUniverseGen.tmp_state = new int[128];
    //    Array.Clear((Array)MUniverseGen.tmp_state, 0, MUniverseGen.tmp_state.Length);
    //    Vector3 pos1 = (Vector3)node.pos;
    //    for (int index1 = 0; index1 < node.conns.Count; ++index1)
    //    {
    //        StarGraphNode conn1 = node.conns[index1];
    //        Vector3 pos2 = (Vector3)conn1.pos;
    //        for (int index2 = index1 + 1; index2 < node.conns.Count; ++index2)
    //        {
    //            StarGraphNode conn2 = node.conns[index2];
    //            Vector3 pos3 = (Vector3)conn2.pos;
    //            bool flag = false;
    //            for (int index3 = 0; index3 < conn1.conns.Count; ++index3)
    //            {
    //                if (conn1.conns[index3] == conn2)
    //                {
    //                    flag = true;
    //                    break;
    //                }
    //            }
    //            if (flag)
    //            {
    //                float num1 = (float)(((double)pos2.x - (double)pos1.x) * ((double)pos2.x - (double)pos1.x) + ((double)pos2.y - (double)pos1.y) * ((double)pos2.y - (double)pos1.y) + ((double)pos2.z - (double)pos1.z) * ((double)pos2.z - (double)pos1.z));
    //                float num2 = (float)(((double)pos3.x - (double)pos1.x) * ((double)pos3.x - (double)pos1.x) + ((double)pos3.y - (double)pos1.y) * ((double)pos3.y - (double)pos1.y) + ((double)pos3.z - (double)pos1.z) * ((double)pos3.z - (double)pos1.z));
    //                float num3 = (float)(((double)pos2.x - (double)pos3.x) * ((double)pos2.x - (double)pos3.x) + ((double)pos2.y - (double)pos3.y) * ((double)pos2.y - (double)pos3.y) + ((double)pos2.z - (double)pos3.z) * ((double)pos2.z - (double)pos3.z));
    //                float num4 = (double)num1 <= (double)num2 ? ((double)num2 <= (double)num3 ? num3 : num2) : ((double)num1 <= (double)num3 ? num3 : num1);
    //                float num5 = (double)num1 >= (double)num2 ? ((double)num2 >= (double)num3 ? num3 : num2) : ((double)num1 >= (double)num3 ? num3 : num1);
    //                float num6 = (float)(((double)num1 + (double)num2 + (double)num3 - (double)num4 - (double)num5) * 1.00100004673004);
    //                float num7 = num5 * 1.01f;
    //                if ((double)num1 <= (double)num6 || (double)num1 <= (double)num7)
    //                {
    //                    if (MUniverseGen.tmp_state[index1] == 0)
    //                    {
    //                        MUniverseGen.list_sorted_add(node.lines, conn1);
    //                        MUniverseGen.list_sorted_add(conn1.lines, node);
    //                        MUniverseGen.tmp_state[index1] = 1;
    //                    }
    //                }
    //                else
    //                {
    //                    MUniverseGen.tmp_state[index1] = -1;
    //                    node.lines.Remove(conn1);
    //                    conn1.lines.Remove(node);
    //                }
    //                if ((double)num2 <= (double)num6 || (double)num2 <= (double)num7)
    //                {
    //                    if (MUniverseGen.tmp_state[index2] == 0)
    //                    {
    //                        MUniverseGen.list_sorted_add(node.lines, conn2);
    //                        MUniverseGen.list_sorted_add(conn2.lines, node);
    //                        MUniverseGen.tmp_state[index2] = 1;
    //                    }
    //                }
    //                else
    //                {
    //                    MUniverseGen.tmp_state[index2] = -1;
    //                    node.lines.Remove(conn2);
    //                    conn2.lines.Remove(node);
    //                }
    //                if ((double)num3 > (double)num6 && (double)num3 > (double)num7)
    //                {
    //                    conn1.lines.Remove(conn2);
    //                    conn2.lines.Remove(conn1);
    //                }
    //            }
    //        }
    //        if (MUniverseGen.tmp_state[index1] == 0)
    //        {
    //            MUniverseGen.list_sorted_add(node.lines, conn1);
    //            MUniverseGen.list_sorted_add(conn1.lines, node);
    //            MUniverseGen.tmp_state[index1] = 1;
    //        }
    //    }
    //    Array.Clear((Array)MUniverseGen.tmp_state, 0, MUniverseGen.tmp_state.Length);
    //}
}
