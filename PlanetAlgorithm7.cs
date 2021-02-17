
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlanetAlgorithm7 : PlanetAlgorithm
{
    private Vector3[] veinVectors = new Vector3[512];
    private EVeinType[] veinVectorTypes = new EVeinType[512];
    //private int veinVectorCount;
    private List<Vector2> tmp_vecs = new List<Vector2>(100);

    public override void GenerateVeins(bool sketchOnly)
    {
        lock ((object)this.planet)
        {
            ThemeProtoSet themes = ThemeWorks.GetThemes();
            var themeProto = themes.dataArray[this.planet.theme - 1];
            if (themeProto == null)
                return;
            System.Random random1 = new System.Random(this.planet.seed);
            random1.Next();
            random1.Next();
            random1.Next();
            random1.Next();
            random1.Next();
            System.Random random2 = new System.Random(random1.Next());
            //PlanetRawData data = this.planet.data;
            float num1 = 2.1f / this.planet.radius;
            //VeinProto[] veinProtos = PlanetModelingManager.veinProtos;
            //int[] veinModelIndexs = PlanetModelingManager.veinModelIndexs;
            //int[] veinModelCounts = PlanetModelingManager.veinModelCounts;
            //int[] veinProducts = PlanetModelingManager.veinProducts;
            int VeinCount = 15;
            int[] numArray1 = new int[VeinCount];
            float[] numArray2 = new float[VeinCount];
            float[] numArray3 = new float[VeinCount];
            if (themeProto.VeinSpot != null)
                Array.Copy((Array)themeProto.VeinSpot, 0, (Array)numArray1, 1, Math.Min(themeProto.VeinSpot.Length, numArray1.Length - 1));
            if (themeProto.VeinCount != null)
                Array.Copy((Array)themeProto.VeinCount, 0, (Array)numArray2, 1, Math.Min(themeProto.VeinCount.Length, numArray2.Length - 1));
            if (themeProto.VeinOpacity != null)
                Array.Copy((Array)themeProto.VeinOpacity, 0, (Array)numArray3, 1, Math.Min(themeProto.VeinOpacity.Length, numArray3.Length - 1));
            float p = 1f;
            ESpectrType spectr = this.planet.star.spectr;
            switch (this.planet.star.type)
            {
                case EStarType.MainSeqStar:
                    switch (spectr)
                    {
                        case ESpectrType.M:
                            p = 2.5f;
                            break;
                        case ESpectrType.K:
                            p = 1f;
                            break;
                        case ESpectrType.G:
                            p = 0.7f;
                            break;
                        case ESpectrType.F:
                            p = 0.6f;
                            break;
                        case ESpectrType.A:
                            p = 1f;
                            break;
                        case ESpectrType.B:
                            p = 0.4f;
                            break;
                        case ESpectrType.O:
                            p = 1.6f;
                            break;
                    }
                    break;
                case EStarType.GiantStar:
                    p = 2.5f;
                    break;
                case EStarType.WhiteDwarf:
                    p = 3.5f;
                    ++numArray1[9];
                    ++numArray1[9];
                    for (int index = 1; index < 12 && random1.NextDouble() < 0.449999988079071; ++index)
                        ++numArray1[9];
                    numArray2[9] = 0.7f;
                    numArray3[9] = 1f;
                    ++numArray1[10];
                    ++numArray1[10];
                    for (int index = 1; index < 12 && random1.NextDouble() < 0.449999988079071; ++index)
                        ++numArray1[10];
                    numArray2[10] = 0.7f;
                    numArray3[10] = 1f;
                    ++numArray1[12];
                    for (int index = 1; index < 12 && random1.NextDouble() < 0.5; ++index)
                        ++numArray1[12];
                    numArray2[12] = 0.7f;
                    numArray3[12] = 0.3f;
                    break;
                case EStarType.NeutronStar:
                    p = 4.5f;
                    ++numArray1[14];
                    for (int index = 1; index < 12 && random1.NextDouble() < 0.649999976158142; ++index)
                        ++numArray1[14];
                    numArray2[14] = 0.7f;
                    numArray3[14] = 0.3f;
                    break;
                case EStarType.BlackHole:
                    p = 5f;
                    ++numArray1[14];
                    for (int index = 1; index < 12 && random1.NextDouble() < 0.649999976158142; ++index)
                        ++numArray1[14];
                    numArray2[14] = 0.7f;
                    numArray3[14] = 0.3f;
                    break;
            }
            for (int index1 = 0; index1 < themeProto.RareVeins.Length; ++index1)
            {
                int rareVein = themeProto.RareVeins[index1];
                float num2 = this.planet.star.index != 0 ? themeProto.RareSettings[index1 * 4 + 1] : themeProto.RareSettings[index1 * 4];
                float rareSetting1 = themeProto.RareSettings[index1 * 4 + 2];
                float rareSetting2 = themeProto.RareSettings[index1 * 4 + 3];
                float num3 = rareSetting2;
                float num4 = 1f - Mathf.Pow(1f - num2, p);
                float num5 = 1f - Mathf.Pow(1f - rareSetting2, p);
                float num6 = 1f - Mathf.Pow(1f - num3, p);
                if (random1.NextDouble() < (double)num4)
                {
                    ++numArray1[rareVein];
                    numArray2[rareVein] = num5;
                    numArray3[rareVein] = num5;
                    for (int index2 = 1; index2 < 12 && random1.NextDouble() < (double)rareSetting1; ++index2)
                        ++numArray1[rareVein];
                }
            }
            float resourceCoef = this.planet.star.resourceCoef;
            //bool flag1 = (double)DSPGame.GameDesc.resourceMultiplier >= 99.5;
            //if (this.planet.galaxy.birthPlanetId == this.planet.id)
            //    resourceCoef *= 0.6666667f;
            //float num7 = 1f * 1.1f;
            Array.Clear((Array)this.veinVectors, 0, this.veinVectors.Length);
            Array.Clear((Array)this.veinVectorTypes, 0, this.veinVectorTypes.Length);
            //this.veinVectorCount = 0;
            //Vector3 vector3_1;
            //if (this.planet.galaxy.birthPlanetId == this.planet.id)
            //{
            //    Pose pose = this.planet.PredictPose(120.0);
            //    Vector3 vector3_2 = (Vector3)Maths.QInvRotateLF(pose.rotation, this.planet.star.uPosition - (VectorLF3)pose.position * 40000.0);
            //    vector3_2.Normalize();
            //    vector3_1 = vector3_2 * 0.75f;
            //}
            //else
            //{
            //    Vector3 vector3_2;
            //    vector3_2.x = (float)(random2.NextDouble() * 2.0 - 1.0);
            //    vector3_2.y = (float)random2.NextDouble() - 0.5f;
            //    vector3_2.z = (float)(random2.NextDouble() * 2.0 - 1.0);
            //    vector3_2.Normalize();
            //    vector3_1 = vector3_2 * (float)(random2.NextDouble() * 0.4 + 0.2);
            //}
            this.planet.veinSpotsSketch = numArray1;
            if (sketchOnly)
                return;
            //for (int index1 = 1; index1 < 15 && this.veinVectorCount < this.veinVectors.Length; ++index1)
            //{
            //    EVeinType eveinType = (EVeinType)index1;
            //    int num2 = numArray1[index1];
            //    if (num2 > 1)
            //        num2 += random2.Next(-1, 2);
            //    for (int index2 = 0; index2 < num2; ++index2)
            //    {
            //        int num3 = 0;
            //        Vector3 zero = Vector3.zero;
            //        bool flag2 = false;
            //        while (num3++ < 200)
            //        {
            //            zero.x = (float)(random2.NextDouble() * 2.0 - 1.0);
            //            zero.y = (float)(random2.NextDouble() * 2.0 - 1.0);
            //            zero.z = (float)(random2.NextDouble() * 2.0 - 1.0);
            //            if (eveinType != EVeinType.Oil)
            //                zero += vector3_1;
            //            zero.Normalize();
            //            if (eveinType != EVeinType.Bamboo || (double)data.QueryHeight(zero) <= (double)this.planet.realRadius - 4.0)
            //            {
            //                bool flag3 = false;
            //                float num4 = eveinType != EVeinType.Oil ? 196f : 100f;
            //                for (int index3 = 0; index3 < this.veinVectorCount; ++index3)
            //                {
            //                    if ((double)(this.veinVectors[index3] - zero).sqrMagnitude < (double)num1 * (double)num1 * (double)num4)
            //                    {
            //                        flag3 = true;
            //                        break;
            //                    }
            //                }
            //                if (!flag3)
            //                {
            //                    flag2 = true;
            //                    break;
            //                }
            //            }
            //        }
            //        if (flag2)
            //        {
            //            this.veinVectors[this.veinVectorCount] = zero;
            //            this.veinVectorTypes[this.veinVectorCount] = eveinType;
            //            ++this.veinVectorCount;
            //            if (this.veinVectorCount == this.veinVectors.Length)
            //                break;
            //        }
            //    }
            //}
            //Array.Clear((Array)this.planet.veinAmounts, 0, this.planet.veinAmounts.Length);
            //data.veinCursor = 1;
            //this.planet.veinGroups = new PlanetData.VeinGroup[this.veinVectorCount];
            //this.tmp_vecs.Clear();
            //VeinData vein = new VeinData();
            //for (int index1 = 0; index1 < this.veinVectorCount; ++index1)
            //{
            //    this.tmp_vecs.Clear();
            //    Vector3 normalized = this.veinVectors[index1].normalized;
            //    EVeinType veinVectorType = this.veinVectorTypes[index1];
            //    int index2 = (int)veinVectorType;
            //    Quaternion rotation = Quaternion.FromToRotation(Vector3.up, normalized);
            //    Vector3 vector3_2 = rotation * Vector3.right;
            //    Vector3 vector3_3 = rotation * Vector3.forward;
            //    this.planet.veinGroups[index1].type = veinVectorType;
            //    this.planet.veinGroups[index1].pos = normalized;
            //    this.planet.veinGroups[index1].count = 0;
            //    this.planet.veinGroups[index1].amount = 0L;
            //    this.tmp_vecs.Add(Vector2.zero);
            //    int num2 = Mathf.RoundToInt(numArray2[index2] * (float)random2.Next(20, 25));
            //    if (veinVectorType == EVeinType.Oil)
            //        num2 = 1;
            //    int num3 = 0;
            //    while (num3++ < 20)
            //    {
            //        int count = this.tmp_vecs.Count;
            //        for (int index3 = 0; index3 < count && this.tmp_vecs.Count < num2; ++index3)
            //        {
            //            if ((double)this.tmp_vecs[index3].sqrMagnitude <= 36.0)
            //            {
            //                double num4 = random2.NextDouble() * Math.PI * 2.0;
            //                Vector2 vector2_1 = new Vector2((float)Math.Cos(num4), (float)Math.Sin(num4));
            //                vector2_1 += this.tmp_vecs[index3] * 0.2f;
            //                vector2_1.Normalize();
            //                Vector2 vector2_2 = this.tmp_vecs[index3] + vector2_1;
            //                bool flag2 = false;
            //                for (int index4 = 0; index4 < this.tmp_vecs.Count; ++index4)
            //                {
            //                    if ((double)(this.tmp_vecs[index4] - vector2_2).sqrMagnitude < 0.850000023841858)
            //                    {
            //                        flag2 = true;
            //                        break;
            //                    }
            //                }
            //                if (!flag2)
            //                    this.tmp_vecs.Add(vector2_2);
            //            }
            //        }
            //        if (this.tmp_vecs.Count >= num2)
            //            break;
            //    }
            //    int num5 = Mathf.RoundToInt(numArray3[index2] * 100000f * resourceCoef);
            //    if (num5 < 20)
            //        num5 = 20;
            //    int num6 = num5 >= 16000 ? 15000 : Mathf.FloorToInt((float)num5 * (15f / 16f));
            //    int minValue = num5 - num6;
            //    int maxValue = num5 + num6 + 1;
            //    for (int index3 = 0; index3 < this.tmp_vecs.Count; ++index3)
            //    {
            //        Vector3 vector3_4 = (this.tmp_vecs[index3].x * vector3_2 + this.tmp_vecs[index3].y * vector3_3) * num1;
            //        vein.type = veinVectorType;
            //        vein.groupIndex = (short)index1;
            //        vein.modelIndex = (short)random2.Next(veinModelIndexs[index2], veinModelIndexs[index2] + veinModelCounts[index2]);
            //        vein.amount = Mathf.RoundToInt((float)random2.Next(minValue, maxValue) * num7);
            //        if (this.planet.veinGroups[index1].type != EVeinType.Oil)
            //            vein.amount = Mathf.RoundToInt((float)vein.amount * DSPGame.GameDesc.resourceMultiplier);
            //        if (vein.amount < 1)
            //            vein.amount = 1;
            //        if (flag1 && vein.type != EVeinType.Oil)
            //            vein.amount = 1000000000;
            //        vein.productId = veinProducts[index2];
            //        vein.pos = normalized + vector3_4;
            //        if (vein.type == EVeinType.Oil)
            //            vein.pos = this.planet.aux.RawSnap(vein.pos);
            //        vein.minerCount = 0;
            //        float num4 = data.QueryHeight(vein.pos);
            //        data.EraseVegetableAtPoint(vein.pos);
            //        vein.pos = vein.pos.normalized * num4;
            //        this.planet.veinAmounts[(int)veinVectorType] += (long)vein.amount;
            //        ++this.planet.veinGroups[index1].count;
            //        this.planet.veinGroups[index1].amount += (long)vein.amount;
            //        data.AddVeinData(vein);
            //    }
            //}
            this.tmp_vecs.Clear();
        }
    }

    private static float diff(float a, float b) => (double)a > (double)b ? a - b : b - a;
}
