using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlanetAlgorithm
{
    protected int seed;
    protected PlanetData planet;
    private Vector3[] veinVectors = new Vector3[512];
    private EVeinType[] veinVectorTypes = new EVeinType[512];
    private int veinVectorCount;
    private List<Vector2> tmp_vecs = new List<Vector2>(100);

    public void Reset(int _seed, PlanetData _planet)
    {
        this.seed = _seed;
        this.planet = _planet;
    }

    public abstract void GenerateTerrain(double modX, double modY);

    public abstract void GenerateVegetables();

    public virtual void CalcWaterPercent()
    {
        if (this.planet.type == EPlanetType.Gas)
            this.planet.windStrength = 0.0f;
        PlanetAlgorithm.CalcLandPercent(this.planet);
    }

    public virtual void GenerateVeins(bool sketchOnly)
    {
        lock ((object)this.planet)
        {
            ThemeProto themeProto = LDB.themes.Select(this.planet.theme);
            if (themeProto == null)
                return;
            System.Random random1 = new System.Random(this.planet.seed);
            random1.Next();
            random1.Next();
            random1.Next();
            random1.Next();
            int _birthSeed = random1.Next();
            System.Random random2 = new System.Random(random1.Next());
            PlanetRawData data = this.planet.data;
            float num1 = 2.1f / this.planet.radius;
            VeinProto[] veinProtos = PlanetModelingManager.veinProtos;
            int[] veinModelIndexs = PlanetModelingManager.veinModelIndexs;
            int[] veinModelCounts = PlanetModelingManager.veinModelCounts;
            int[] veinProducts = PlanetModelingManager.veinProducts;
            int[] numArray1 = new int[veinProtos.Length];
            float[] numArray2 = new float[veinProtos.Length];
            float[] numArray3 = new float[veinProtos.Length];
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
            bool flag1 = this.planet.galaxy.birthPlanetId == this.planet.id;
            if (flag1 && !sketchOnly)
                this.planet.GenBirthPoints(data, _birthSeed);
            float resourceCoef = this.planet.star.resourceCoef;
            bool flag2 = (double)DSPGame.GameDesc.resourceMultiplier >= 99.5;
            if (flag1)
                resourceCoef *= 0.6666667f;
            float num7 = 1f * 1.1f;
            Array.Clear((Array)this.veinVectors, 0, this.veinVectors.Length);
            Array.Clear((Array)this.veinVectorTypes, 0, this.veinVectorTypes.Length);
            this.veinVectorCount = 0;
            Vector3 vector3_1;
            if (flag1)
            {
                vector3_1 = this.planet.birthPoint;
                vector3_1.Normalize();
                vector3_1 *= 0.75f;
            }
            else
            {
                Vector3 vector3_2;
                vector3_2.x = (float)(random2.NextDouble() * 2.0 - 1.0);
                vector3_2.y = (float)random2.NextDouble() - 0.5f;
                vector3_2.z = (float)(random2.NextDouble() * 2.0 - 1.0);
                vector3_2.Normalize();
                vector3_1 = vector3_2 * (float)(random2.NextDouble() * 0.4 + 0.2);
            }
            this.planet.veinSpotsSketch = numArray1;
            if (sketchOnly)
                return;
            if (flag1)
            {
                this.veinVectorTypes[0] = EVeinType.Iron;
                this.veinVectors[0] = this.planet.birthResourcePoint0;
                this.veinVectorTypes[1] = EVeinType.Copper;
                this.veinVectors[1] = this.planet.birthResourcePoint1;
                this.veinVectorCount = 2;
            }
            for (int index1 = 1; index1 < 15 && this.veinVectorCount < this.veinVectors.Length; ++index1)
            {
                EVeinType eveinType = (EVeinType)index1;
                int num2 = numArray1[index1];
                if (num2 > 1)
                    num2 += random2.Next(-1, 2);
                for (int index2 = 0; index2 < num2; ++index2)
                {
                    int num3 = 0;
                    Vector3 zero = Vector3.zero;
                    bool flag3 = false;
                    while (num3++ < 200)
                    {
                        zero.x = (float)(random2.NextDouble() * 2.0 - 1.0);
                        zero.y = (float)(random2.NextDouble() * 2.0 - 1.0);
                        zero.z = (float)(random2.NextDouble() * 2.0 - 1.0);
                        if (eveinType != EVeinType.Oil)
                            zero += vector3_1;
                        zero.Normalize();
                        float num4 = data.QueryHeight(zero);
                        if ((double)num4 >= (double)this.planet.radius && (eveinType != EVeinType.Oil || (double)num4 >= (double)this.planet.radius + 0.5))
                        {
                            bool flag4 = false;
                            float num5 = eveinType != EVeinType.Oil ? 196f : 100f;
                            for (int index3 = 0; index3 < this.veinVectorCount; ++index3)
                            {
                                if ((double)(this.veinVectors[index3] - zero).sqrMagnitude < (double)num1 * (double)num1 * (double)num5)
                                {
                                    flag4 = true;
                                    break;
                                }
                            }
                            if (!flag4)
                            {
                                flag3 = true;
                                break;
                            }
                        }
                    }
                    if (flag3)
                    {
                        this.veinVectors[this.veinVectorCount] = zero;
                        this.veinVectorTypes[this.veinVectorCount] = eveinType;
                        ++this.veinVectorCount;
                        if (this.veinVectorCount == this.veinVectors.Length)
                            break;
                    }
                }
            }
            Array.Clear((Array)this.planet.veinAmounts, 0, this.planet.veinAmounts.Length);
            data.veinCursor = 1;
            this.planet.veinGroups = new PlanetData.VeinGroup[this.veinVectorCount];
            this.tmp_vecs.Clear();
            VeinData vein = new VeinData();
            for (int index1 = 0; index1 < this.veinVectorCount; ++index1)
            {
                this.tmp_vecs.Clear();
                Vector3 normalized = this.veinVectors[index1].normalized;
                EVeinType veinVectorType = this.veinVectorTypes[index1];
                int index2 = (int)veinVectorType;
                Quaternion rotation = Quaternion.FromToRotation(Vector3.up, normalized);
                Vector3 vector3_2 = rotation * Vector3.right;
                Vector3 vector3_3 = rotation * Vector3.forward;
                this.planet.veinGroups[index1].type = veinVectorType;
                this.planet.veinGroups[index1].pos = normalized;
                this.planet.veinGroups[index1].count = 0;
                this.planet.veinGroups[index1].amount = 0L;
                this.tmp_vecs.Add(Vector2.zero);
                int num2 = Mathf.RoundToInt(numArray2[index2] * (float)random2.Next(20, 25));
                if (veinVectorType == EVeinType.Oil)
                    num2 = 1;
                float num3 = numArray3[index2];
                if (flag1 && index1 < 2)
                {
                    num2 = 6;
                    num3 = 0.2f;
                }
                int num4 = 0;
                while (num4++ < 20)
                {
                    int count = this.tmp_vecs.Count;
                    for (int index3 = 0; index3 < count && this.tmp_vecs.Count < num2; ++index3)
                    {
                        if ((double)this.tmp_vecs[index3].sqrMagnitude <= 36.0)
                        {
                            double num5 = random2.NextDouble() * Math.PI * 2.0;
                            Vector2 vector2_1 = new Vector2((float)Math.Cos(num5), (float)Math.Sin(num5));
                            vector2_1 += this.tmp_vecs[index3] * 0.2f;
                            vector2_1.Normalize();
                            Vector2 vector2_2 = this.tmp_vecs[index3] + vector2_1;
                            bool flag3 = false;
                            for (int index4 = 0; index4 < this.tmp_vecs.Count; ++index4)
                            {
                                if ((double)(this.tmp_vecs[index4] - vector2_2).sqrMagnitude < 0.850000023841858)
                                {
                                    flag3 = true;
                                    break;
                                }
                            }
                            if (!flag3)
                                this.tmp_vecs.Add(vector2_2);
                        }
                    }
                    if (this.tmp_vecs.Count >= num2)
                        break;
                }
                int num6 = Mathf.RoundToInt(num3 * 100000f * resourceCoef);
                if (num6 < 20)
                    num6 = 20;
                int num8 = num6 >= 16000 ? 15000 : Mathf.FloorToInt((float)num6 * (15f / 16f));
                int minValue = num6 - num8;
                int maxValue = num6 + num8 + 1;
                for (int index3 = 0; index3 < this.tmp_vecs.Count; ++index3)
                {
                    Vector3 vector3_4 = (this.tmp_vecs[index3].x * vector3_2 + this.tmp_vecs[index3].y * vector3_3) * num1;
                    vein.type = veinVectorType;
                    vein.groupIndex = (short)index1;
                    vein.modelIndex = (short)random2.Next(veinModelIndexs[index2], veinModelIndexs[index2] + veinModelCounts[index2]);
                    vein.amount = Mathf.RoundToInt((float)random2.Next(minValue, maxValue) * num7);
                    if (this.planet.veinGroups[index1].type != EVeinType.Oil)
                        vein.amount = Mathf.RoundToInt((float)vein.amount * DSPGame.GameDesc.resourceMultiplier);
                    if (vein.amount < 1)
                        vein.amount = 1;
                    if (flag2 && vein.type != EVeinType.Oil)
                        vein.amount = 1000000000;
                    vein.productId = veinProducts[index2];
                    vein.pos = normalized + vector3_4;
                    if (vein.type == EVeinType.Oil)
                        vein.pos = this.planet.aux.RawSnap(vein.pos);
                    vein.minerCount = 0;
                    float num5 = data.QueryHeight(vein.pos);
                    data.EraseVegetableAtPoint(vein.pos);
                    vein.pos = vein.pos.normalized * num5;
                    if (this.planet.waterItemId == 0 || (double)num5 >= (double)this.planet.radius)
                    {
                        this.planet.veinAmounts[(int)veinVectorType] += (long)vein.amount;
                        ++this.planet.veinGroups[index1].count;
                        this.planet.veinGroups[index1].amount += (long)vein.amount;
                        data.AddVeinData(vein);
                    }
                }
            }
            this.tmp_vecs.Clear();
        }
    }

    public static void CalcLandPercent(PlanetData _planet)
    {
        PlanetRawData data = _planet.data;
        int stride = data.stride;
        int num1 = stride / 2;
        int dataLength = data.dataLength;
        ushort[] heightData = data.heightData;
        float num2 = (float)((double)_planet.radius * 100.0 - 20.0);
        if (_planet.type == EPlanetType.Gas)
        {
            _planet.landPercent = 0.0f;
        }
        else
        {
            int num3 = 0;
            int num4 = 0;
            for (int index = 0; index < dataLength; ++index)
            {
                int num5 = index % stride;
                int num6 = index / stride;
                if (num5 > num1)
                    --num5;
                if (num6 > num1)
                    --num6;
                if ((num5 & 1) == 1 && (num6 & 1) == 1)
                {
                    if ((double)heightData[index] >= (double)num2)
                        ++num4;
                    else if (data.GetModLevel(index) == 3)
                        ++num4;
                    ++num3;
                }
            }
            _planet.landPercent = num3 <= 0 ? 0.0f : (float)num4 / (float)num3;
        }
    }
}
