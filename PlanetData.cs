
using System;
using System.IO;
using UnityEngine;

public class PlanetData
{
    public GalaxyData galaxy;
    public StarData star;
    public int seed;
    public int id;
    public int index;
    public int orbitAround;
    public int number;
    public int orbitIndex;
    public string name = string.Empty;
    public string overrideName = string.Empty;
    public float orbitRadius = 1f;
    public float orbitInclination;
    public float orbitLongitude;
    public double orbitalPeriod = 3600.0;
    public float orbitPhase;
    public float obliquity;
    public double rotationPeriod = 480.0;
    public float rotationPhase;
    public float radius = 200f;
    public float scale = 1f;
    public float sunDistance;
    public float habitableBias;
    public float temperatureBias;
    public float ionHeight;
    public float windStrength;
    public float luminosity;
    public float landPercent;
    public double mod_x;
    public double mod_y;
    public float waterHeight;
    public int waterItemId;
    public bool levelized;
    public EPlanetType type;
    public EPlanetSingularity singularity;
    public int theme;
    public int algoId;
    public PlanetData orbitAroundPlanet;
    public VectorLF3 runtimePosition;
    public VectorLF3 runtimePositionNext;
    public Quaternion runtimeRotation;
    public Quaternion runtimeRotationNext;
    public Quaternion runtimeSystemRotation;
    public Quaternion runtimeOrbitRotation;
    public float runtimeOrbitPhase;
    public float runtimeRotationPhase;
    public VectorLF3 uPosition;
    public VectorLF3 uPositionNext;
    public Vector3 runtimeLocalSunDirection;
    public int[] veinSpotsSketch;
    public long[] veinAmounts;
    public PlanetData.VeinGroup[] veinGroups;
    public byte[] modData;
    public int precision = 160;
    public int segment = 5;
    //public PlanetRawData data;
    public const int kMaxMeshCnt = 100;
    //public GameObject gameObject;
    //public GameObject bodyObject;
    //public Material terrainMaterial;
    //public Material oceanMaterial;
    //public Material atmosMaterial;
    //public Material minimapMaterial;
    //public Material reformMaterial;
    //public RenderTexture heightmap;
    //public AmbientDesc ambientDesc;
    //public AudioClip ambientSfx;
    public float ambientSfxVolume;
    //public Mesh[] meshes = new Mesh[100];
    //public MeshRenderer[] meshRenderers = new MeshRenderer[100];
    //public MeshCollider[] meshColliders = new MeshCollider[100];
    public bool[] dirtyFlags = new bool[100];
    public bool landPercentDirty;
    public int factoryIndex = -1;
    //public PlanetFactory factory;
    //public PlanetPhysics physics;
    //public PlanetAudio audio;
    //public FactoryModel factoryModel;
    //public FactoryAudio factoryAudio;
    //public PlanetAuxData aux;
    public int[] gasItems;
    public float[] gasSpeeds;
    public float[] gasHeatValues;
    public double gasTotalHeat;
    public Vector3 birthPoint;
    public Vector3 birthResourcePoint0;
    public Vector3 birthResourcePoint1;
    public bool loaded;
    public bool wanted;
    public bool loading;
    public bool factoryLoaded;
    public bool factoryLoading;
    public const float kEnterAltitude = 1000f;

    public PlanetData()
    {
        this.veinAmounts = new long[32];
        this.veinGroups = new PlanetData.VeinGroup[0];
    }

    public string displayName => string.IsNullOrEmpty(this.overrideName) ? this.name : this.overrideName;

    public float realRadius => this.radius * this.scale;

    //public event Action<PlanetData> onLoaded;
    //
    //public event Action<PlanetData> onFactoryLoaded;

    public string typeString
    {
        get
        {
            string str = "未知";
            ThemeProtoSet themes = ThemeWorks.GetThemes();
            var themeProto = themes.dataArray[this.theme - 1];
            if (themeProto != null)
                str = themeProto.DisplayName;
            return str;
        }
    }

    public string singularityString
    {
        get
        {
            string empty = string.Empty;
            if (this.orbitAround > 0)
                empty += "卫星";
            if ((this.singularity & EPlanetSingularity.TidalLocked) != EPlanetSingularity.None)
                empty += "潮汐锁定永昼永夜";
            if ((this.singularity & EPlanetSingularity.TidalLocked2) != EPlanetSingularity.None)
                empty += "潮汐锁定1:2";
            if ((this.singularity & EPlanetSingularity.TidalLocked4) != EPlanetSingularity.None)
                empty += "潮汐锁定1:4";
            if ((this.singularity & EPlanetSingularity.LaySide) != EPlanetSingularity.None)
                empty += "横躺自转";
            if ((this.singularity & EPlanetSingularity.ClockwiseRotate) != EPlanetSingularity.None)
                empty += "反向自转";
            if ((this.singularity & EPlanetSingularity.MultipleSatellites) != EPlanetSingularity.None)
                empty += "多卫星";
            return empty;
        }
    }

    //public void NotifyLoaded()
    //{
    //    this.loaded = true;
    //    this.loading = false;
    //    this.wanted = true;
    //    if (this.onLoaded == null)
    //        return;
    //    this.onLoaded(this);
    //}
    //
    //public void NotifyFactoryLoaded()
    //{
    //    this.factoryLoaded = true;
    //    this.factoryLoading = false;
    //    this.wanted = true;
    //    if (this.onFactoryLoaded == null)
    //        return;
    //    this.onFactoryLoaded(this);
    //}

    //private void UnloadData()
    //{
    //    if (this.data == null)
    //        return;
    //    this.data.Free();
    //    this.data = (PlanetRawData)null;
    //}

    //private void UnloadMeshes()
    //{
    //    for (int index = 0; index < this.meshes.Length; ++index)
    //    {
    //        if ((UnityEngine.Object)this.meshes[index] != (UnityEngine.Object)null)
    //        {
    //            UnityEngine.Object.Destroy((UnityEngine.Object)this.meshes[index]);
    //            this.meshes[index] = (Mesh)null;
    //        }
    //    }
    //    if ((UnityEngine.Object)this.gameObject != (UnityEngine.Object)null)
    //    {
    //        UnityEngine.Object.Destroy((UnityEngine.Object)this.gameObject);
    //        this.gameObject = (GameObject)null;
    //    }
    //    if ((UnityEngine.Object)this.terrainMaterial != (UnityEngine.Object)null)
    //    {
    //        UnityEngine.Object.Destroy((UnityEngine.Object)this.terrainMaterial);
    //        this.terrainMaterial = (Material)null;
    //    }
    //    if ((UnityEngine.Object)this.oceanMaterial != (UnityEngine.Object)null)
    //    {
    //        UnityEngine.Object.Destroy((UnityEngine.Object)this.oceanMaterial);
    //        this.oceanMaterial = (Material)null;
    //    }
    //    if ((UnityEngine.Object)this.atmosMaterial != (UnityEngine.Object)null)
    //    {
    //        UnityEngine.Object.Destroy((UnityEngine.Object)this.atmosMaterial);
    //        this.atmosMaterial = (Material)null;
    //    }
    //    if ((UnityEngine.Object)this.minimapMaterial != (UnityEngine.Object)null)
    //    {
    //        UnityEngine.Object.Destroy((UnityEngine.Object)this.minimapMaterial);
    //        this.minimapMaterial = (Material)null;
    //    }
    //    if ((UnityEngine.Object)this.reformMaterial != (UnityEngine.Object)null)
    //    {
    //        UnityEngine.Object.Destroy((UnityEngine.Object)this.reformMaterial);
    //        this.reformMaterial = (Material)null;
    //    }
    //    if (!((UnityEngine.Object)this.heightmap != (UnityEngine.Object)null))
    //        return;
    //    this.heightmap.Release();
    //    UnityEngine.Object.Destroy((UnityEngine.Object)this.heightmap);
    //    this.heightmap = (RenderTexture)null;
    //}

    //public void GenBirthPoints(PlanetRawData rawData, int _birthSeed)
    //{
    //    Random random = new Random(_birthSeed);
    //    Pose pose = this.PredictPose(85.0);
    //    Vector3 vector3_1 = (Vector3)Maths.QInvRotateLF(pose.rotation, this.star.uPosition - (VectorLF3)pose.position * 40000.0);
    //    vector3_1.Normalize();
    //    Vector3 normalized1 = Vector3.Cross(vector3_1, Vector3.up).normalized;
    //    Vector3 normalized2 = Vector3.Cross(normalized1, vector3_1).normalized;
    //    int num1 = 0;
    //    while (num1 < 256)
    //    {
    //        float num2 = (float)(random.NextDouble() * 2.0 - 1.0) * 0.5f;
    //        float num3 = (float)(random.NextDouble() * 2.0 - 1.0) * 0.5f;
    //        Vector3 vector3_2 = vector3_1 + num2 * normalized1 + num3 * normalized2;
    //        vector3_2.Normalize();
    //        this.birthPoint = vector3_2 * (float)((double)rawData.QueryHeight(vector3_2) + 0.200000002980232 + 1.60000002384186);
    //        normalized1 = Vector3.Cross(vector3_2, Vector3.up).normalized;
    //        normalized2 = Vector3.Cross(normalized1, vector3_2).normalized;
    //        bool flag = false;
    //        for (int index = 0; index < 10; ++index)
    //        {
    //            Vector2 vector2_1 = new Vector2((float)(random.NextDouble() * 2.0 - 1.0), (float)(random.NextDouble() * 2.0 - 1.0)).normalized * 0.1f;
    //            Vector2 vector2_2 = -vector2_1;
    //            float num4 = (float)(random.NextDouble() * 2.0 - 1.0) * 0.06f;
    //            float num5 = (float)(random.NextDouble() * 2.0 - 1.0) * 0.06f;
    //            vector2_2.x += num4;
    //            vector2_2.y += num5;
    //            Vector3 normalized3 = (vector3_2 + vector2_1.x * normalized1 + vector2_1.y * normalized2).normalized;
    //            Vector3 normalized4 = (vector3_2 + vector2_2.x * normalized1 + vector2_2.y * normalized2).normalized;
    //            this.birthResourcePoint0 = normalized3.normalized;
    //            this.birthResourcePoint1 = normalized4.normalized;
    //            float num6 = this.realRadius + 0.2f;
    //            if ((double)rawData.QueryHeight(vector3_2) > (double)num6 && (double)rawData.QueryHeight(normalized3) > (double)num6 && (double)rawData.QueryHeight(normalized4) > (double)num6)
    //            {
    //                Vector3 vpos1 = normalized3 + normalized1 * 0.03f;
    //                Vector3 vpos2 = normalized3 - normalized1 * 0.03f;
    //                Vector3 vpos3 = normalized3 + normalized2 * 0.03f;
    //                Vector3 vpos4 = normalized3 - normalized2 * 0.03f;
    //                Vector3 vpos5 = normalized4 + normalized1 * 0.03f;
    //                Vector3 vpos6 = normalized4 - normalized1 * 0.03f;
    //                Vector3 vpos7 = normalized4 + normalized2 * 0.03f;
    //                Vector3 vpos8 = normalized4 - normalized2 * 0.03f;
    //                if ((double)rawData.QueryHeight(vpos1) > (double)num6 && (double)rawData.QueryHeight(vpos2) > (double)num6 && ((double)rawData.QueryHeight(vpos3) > (double)num6 && (double)rawData.QueryHeight(vpos4) > (double)num6) && ((double)rawData.QueryHeight(vpos5) > (double)num6 && (double)rawData.QueryHeight(vpos6) > (double)num6 && ((double)rawData.QueryHeight(vpos7) > (double)num6 && (double)rawData.QueryHeight(vpos8) > (double)num6)))
    //                {
    //                    flag = true;
    //                    break;
    //                }
    //            }
    //        }
    //        if (flag)
    //            break;
    //    }
    //}

    //public void UpdateRuntimePose(double time)
    //{
    //    double num1 = time / this.orbitalPeriod + (double)this.orbitPhase / 360.0;
    //    int num2 = (int)(num1 + 0.1);
    //    double num3 = num1 - (double)num2;
    //    this.runtimeOrbitPhase = (float)num3 * 360f;
    //    double num4 = num3 * (2.0 * Math.PI);
    //    double num5 = time / this.rotationPeriod + (double)this.rotationPhase / 360.0;
    //    int num6 = (int)(num5 + 0.1);
    //    double num7 = (num5 - (double)num6) * 360.0;
    //    this.runtimeRotationPhase = (float)num7;
    //    VectorLF3 vectorLf3_1 = Maths.QRotateLF(this.runtimeOrbitRotation, new VectorLF3((float)Math.Cos(num4) * this.orbitRadius, 0.0f, (float)Math.Sin(num4) * this.orbitRadius));
    //    if (this.orbitAroundPlanet != null)
    //    {
    //        vectorLf3_1.x += this.orbitAroundPlanet.runtimePosition.x;
    //        vectorLf3_1.y += this.orbitAroundPlanet.runtimePosition.y;
    //        vectorLf3_1.z += this.orbitAroundPlanet.runtimePosition.z;
    //    }
    //    this.runtimePosition = vectorLf3_1;
    //    this.runtimeRotation = this.runtimeSystemRotation * Quaternion.AngleAxis((float)num7, Vector3.down);
    //    this.uPosition.x = this.star.uPosition.x + vectorLf3_1.x * 40000.0;
    //    this.uPosition.y = this.star.uPosition.y + vectorLf3_1.y * 40000.0;
    //    this.uPosition.z = this.star.uPosition.z + vectorLf3_1.z * 40000.0;
    //    this.runtimeLocalSunDirection = Maths.QInvRotate(this.runtimeRotation, (Vector3) - vectorLf3_1);
    //    double num8 = time + 1.0 / 60.0;
    //    double num9 = num8 / this.orbitalPeriod + (double)this.orbitPhase / 360.0;
    //    int num10 = (int)(num9 + 0.1);
    //    double num11 = (num9 - (double)num10) * (2.0 * Math.PI);
    //    double num12 = num8 / this.rotationPeriod + (double)this.rotationPhase / 360.0;
    //    int num13 = (int)(num12 + 0.1);
    //    double num14 = (num12 - (double)num13) * 360.0;
    //    VectorLF3 vectorLf3_2 = Maths.QRotateLF(this.runtimeOrbitRotation, new VectorLF3((float)Math.Cos(num11) * this.orbitRadius, 0.0f, (float)Math.Sin(num11) * this.orbitRadius));
    //    if (this.orbitAroundPlanet != null)
    //    {
    //        vectorLf3_2.x += this.orbitAroundPlanet.runtimePositionNext.x;
    //        vectorLf3_2.y += this.orbitAroundPlanet.runtimePositionNext.y;
    //        vectorLf3_2.z += this.orbitAroundPlanet.runtimePositionNext.z;
    //    }
    //    this.runtimePositionNext = vectorLf3_2;
    //    this.runtimeRotationNext = this.runtimeSystemRotation * Quaternion.AngleAxis((float)num14, Vector3.down);
    //    this.uPositionNext.x = this.star.uPosition.x + vectorLf3_2.x * 40000.0;
    //    this.uPositionNext.y = this.star.uPosition.y + vectorLf3_2.y * 40000.0;
    //    this.uPositionNext.z = this.star.uPosition.z + vectorLf3_2.z * 40000.0;
    //    this.galaxy.astroPoses[this.id].uPos = this.uPosition;
    //    this.galaxy.astroPoses[this.id].uRot = this.runtimeRotation;
    //    this.galaxy.astroPoses[this.id].uPosNext = this.uPositionNext;
    //    this.galaxy.astroPoses[this.id].uRotNext = this.runtimeRotationNext;
    //}

    //public Pose PredictPose(double time)
    //{
    //    double num1 = time / this.orbitalPeriod + (double)this.orbitPhase / 360.0;
    //    int num2 = (int)(num1 + 0.1);
    //    double num3 = (num1 - (double)num2) * (2.0 * Math.PI);
    //    double num4 = time / this.rotationPeriod + (double)this.rotationPhase / 360.0;
    //    int num5 = (int)(num4 + 0.1);
    //    double num6 = (num4 - (double)num5) * 360.0;
    //    Vector3 position = Maths.QRotate(this.runtimeOrbitRotation, new Vector3((float)Math.Cos(num3) * this.orbitRadius, 0.0f, (float)Math.Sin(num3) * this.orbitRadius));
    //    if (this.orbitAroundPlanet != null)
    //    {
    //        Pose pose = this.orbitAroundPlanet.PredictPose(time);
    //        position.x += pose.position.x;
    //        position.y += pose.position.y;
    //        position.z += pose.position.z;
    //    }
    //    return new Pose(position, this.runtimeSystemRotation * Quaternion.AngleAxis((float)num6, Vector3.down));
    //}

    //public void PredictUPose(double time, out VectorLF3 uPos, out Quaternion uRot)
    //{
    //    Pose pose = this.PredictPose(time);
    //    uPos.x = (double)pose.position.x * 40000.0 + this.star.uPosition.x;
    //    uPos.y = (double)pose.position.y * 40000.0 + this.star.uPosition.y;
    //    uPos.z = (double)pose.position.z * 40000.0 + this.star.uPosition.z;
    //    uRot = pose.rotation;
    //}

    //public VectorLF3 GetUniversalVelocityAtLocalPoint(double time, Vector3 lpoint)
    //{
    //    double time1 = time;
    //    double time2 = time + 1.0 / 60.0;
    //    VectorLF3 uPos1;
    //    Quaternion uRot1;
    //    this.PredictUPose(time1, out uPos1, out uRot1);
    //    VectorLF3 uPos2;
    //    Quaternion uRot2;
    //    this.PredictUPose(time2, out uPos2, out uRot2);
    //    VectorLF3 vectorLf3 = uPos1 + (VectorLF3)(uRot1 * lpoint);
    //    return (uPos2 + (VectorLF3)(uRot2 * lpoint) - vectorLf3) / (1.0 / 60.0);
    //}

    //private void PredictLocalGeography(
    //  Vector3 local,
    //  double time,
    //  out float sunMaxAngle,
    //  out float sunMinAngle,
    //  out float sunAngle)
    //{
    //    Pose pose = this.PredictPose(time);
    //    float num1 = 90f - Vector3.Angle(pose.rotation * Vector3.up, -pose.position);
    //    float num2 = 90f - Vector3.Angle(Vector3.up, local);
    //    sunMaxAngle = 90f - Mathf.Abs(num1 - num2);
    //    sunMinAngle = 90f - Mathf.Abs(num1 - (180f - num2));
    //    if ((double)sunMinAngle < -180.0)
    //        sunMinAngle += 360f;
    //    if ((double)sunMinAngle > 90.0)
    //        sunMinAngle = 180f - sunMinAngle;
    //    if ((double)sunMinAngle < -90.0)
    //        sunMinAngle = -180f - sunMinAngle;
    //    sunAngle = 90f - Vector3.Angle(pose.rotation * local, -pose.position);
    //}

    //public void GetLocalGeography(
    //  Vector3 local,
    //  double time,
    //  out int summerWinter,
    //  out bool tropical,
    //  out bool polar,
    //  out float sunMaxAngle,
    //  out float sunMinAngle,
    //  out int dayNight,
    //  out float remainTime)
    //{
    //    float num1 = 90f - Vector3.Angle(this.runtimeRotation * Vector3.up, (Vector3) - this.runtimePosition);
    //    float f = 90f - Vector3.Angle(Vector3.up, local);
    //    sunMaxAngle = 90f - Mathf.Abs(num1 - f);
    //    sunMinAngle = 90f - Mathf.Abs(num1 - (180f - f));
    //    if ((double)sunMinAngle < -180.0)
    //        sunMinAngle += 360f;
    //    if ((double)sunMinAngle > 90.0)
    //        sunMinAngle = 180f - sunMinAngle;
    //    if ((double)sunMinAngle < -90.0)
    //        sunMinAngle = -180f - sunMinAngle;
    //    float num2 = 90f - Vector3.Angle(this.runtimeRotation * local, (Vector3) - this.runtimePosition);
    //    dayNight = (double)num2 < 0.0 ? -1 : 1;
    //    remainTime = 1E+07f;
    //    float num3 = Vector3.Angle(this.runtimeRotation * Vector3.up, Vector3.up);
    //    summerWinter = (double)num1 * (double)f < 0.0 ? -1 : 1;
    //    tropical = (double)Mathf.Abs(f) < (double)num3 && (double)sunMaxAngle > 70.0 || (double)sunMaxAngle > 85.0;
    //    polar = (double)sunMaxAngle < 0.0 || (double)sunMinAngle > 0.0;
    //    bool flag1 = false;
    //    int num4 = 0;
    //    double num5 = this.orbitAround != 0 ? this.orbitAroundPlanet.orbitalPeriod : this.orbitalPeriod;
    //    double num6 = this.rotationPeriod;
    //    bool flag2 = Math.Abs(this.rotationPeriod - num5) < 1.0;
    //    if (!flag2)
    //        num6 = 1.0 / (1.0 / this.rotationPeriod - 1.0 / num5);
    //    double num7 = Math.Abs(num6);
    //    if (dayNight >= 0)
    //    {
    //        float sunMaxAngle1 = sunMaxAngle;
    //        float sunMinAngle1 = sunMinAngle;
    //        float sunAngle = num2;
    //        double num8 = time;
    //        double num9 = time + num7 * 0.8;
    //        double num10 = time + num7 * 0.4;
    //    label_10:
    //        if ((double)sunMinAngle1 > 0.0)
    //        {
    //            double num11 = this.orbitAroundPlanet == null ? this.orbitalPeriod : this.orbitAroundPlanet.orbitalPeriod;
    //            num8 = time;
    //            num9 = time + num11 * 0.8;
    //            do
    //            {
    //                double time1 = (num8 + num9) * 0.5;
    //                this.PredictLocalGeography(local, time1, out sunMaxAngle1, out sunMinAngle1, out sunAngle);
    //                if ((double)sunMinAngle1 > 0.0)
    //                    num8 = time1;
    //                else
    //                    num9 = time1;
    //                if (num9 - num8 < 1.0)
    //                {
    //                    num8 = time1;
    //                    num9 = time1 + num7 * 0.8;
    //                    break;
    //                }
    //            }
    //            while (num4++ < 100);
    //        }
    //        do
    //        {
    //            double time1 = (num8 + num9) * 0.5;
    //            this.PredictLocalGeography(local, time1, out sunMaxAngle1, out sunMinAngle1, out sunAngle);
    //            if ((double)sunAngle > 0.0)
    //                num8 = time1;
    //            else
    //                num9 = time1;
    //            if (num9 - num8 < 0.100000001490116)
    //            {
    //                double num11 = num8 - time;
    //                if (num11 > num7 * 0.8 - 0.109999999403954 && !flag1)
    //                {
    //                    flag1 = true;
    //                    if (num4++ < 100)
    //                        goto label_10;
    //                }
    //                remainTime = (float)num11;
    //                break;
    //            }
    //        }
    //        while (num4++ < 100);
    //    }
    //    else
    //    {
    //        float sunMaxAngle1 = sunMaxAngle;
    //        float sunMinAngle1 = sunMinAngle;
    //        float sunAngle = num2;
    //        double num8 = time;
    //        double num9 = time + num7 * 0.8;
    //        double num10 = time + num7 * 0.4;
    //    label_27:
    //        if ((double)sunMaxAngle1 < 0.0)
    //        {
    //            double num11 = this.orbitAroundPlanet == null ? this.orbitalPeriod : this.orbitAroundPlanet.orbitalPeriod;
    //            num8 = time;
    //            num9 = time + num11 * 0.8;
    //            do
    //            {
    //                double time1 = (num8 + num9) * 0.5;
    //                this.PredictLocalGeography(local, time1, out sunMaxAngle1, out sunMinAngle1, out sunAngle);
    //                if ((double)sunMaxAngle1 < 0.0)
    //                    num8 = time1;
    //                else
    //                    num9 = time1;
    //                if (num9 - num8 < 1.0)
    //                {
    //                    num8 = time1;
    //                    num9 = time1 + num7 * 0.8;
    //                    break;
    //                }
    //            }
    //            while (num4++ < 100);
    //        }
    //        do
    //        {
    //            double time1 = (num8 + num9) * 0.5;
    //            this.PredictLocalGeography(local, time1, out sunMaxAngle1, out sunMinAngle1, out sunAngle);
    //            if ((double)sunAngle < 0.0)
    //                num8 = time1;
    //            else
    //                num9 = time1;
    //            if (num9 - num8 < 0.100000001490116)
    //            {
    //                double num11 = num8 - time;
    //                if (num11 > num7 * 0.8 - 0.109999999403954 && !flag1)
    //                {
    //                    flag1 = true;
    //                    if (num4++ < 100)
    //                        goto label_27;
    //                }
    //                remainTime = (float)num11;
    //                break;
    //            }
    //        }
    //        while (num4++ < 100);
    //    }
    //    if (!flag2)
    //        return;
    //    remainTime = 1E+07f;
    //}

    //public void AddHeightMapModLevel(int index, int level)
    //{
    //    if (!this.data.AddModLevel(index, level))
    //        return;
    //    int num1 = this.precision / this.segment;
    //    int num2 = index % this.data.stride;
    //    int num3 = index / this.data.stride;
    //    int num4 = (num2 >= this.data.substride ? 1 : 0) + (num3 >= this.data.substride ? 2 : 0);
    //    int num5 = num2 % this.data.substride;
    //    int num6 = num3 % this.data.substride;
    //    int num7 = (num5 - 1) / num1;
    //    int num8 = (num6 - 1) / num1;
    //    int num9 = num5 / num1;
    //    int num10 = num6 / num1;
    //    if (num9 >= this.segment)
    //        num9 = this.segment - 1;
    //    if (num10 >= this.segment)
    //        num10 = this.segment - 1;
    //    int num11 = num4 * this.segment * this.segment;
    //    int index1 = num7 + num8 * this.segment + num11;
    //    int index2 = num9 + num8 * this.segment + num11;
    //    int index3 = num7 + num10 * this.segment + num11;
    //    int index4 = num9 + num10 * this.segment + num11;
    //    this.dirtyFlags[index1] = true;
    //    this.dirtyFlags[index2] = true;
    //    this.dirtyFlags[index3] = true;
    //    this.dirtyFlags[index4] = true;
    //}

    //public bool UpdateDirtyMeshes()
    //{
    //    bool flag = false;
    //    for (int dirtyIdx = 0; dirtyIdx < this.dirtyFlags.Length; ++dirtyIdx)
    //    {
    //        if (this.UpdateDirtyMesh(dirtyIdx))
    //            flag = true;
    //    }
    //    return flag;
    //}

    //public bool UpdateDirtyMesh(int dirtyIdx)
    //{
    //    if (!this.dirtyFlags[dirtyIdx])
    //        return false;
    //    this.dirtyFlags[dirtyIdx] = false;
    //    int num1 = this.precision / this.segment;
    //    int num2 = this.segment * this.segment;
    //    int num3 = dirtyIdx / num2;
    //    int num4 = num3 % 2;
    //    int num5 = num3 / 2;
    //    int num6 = dirtyIdx % num2;
    //    int num7 = num6 % this.segment * num1 + num4 * this.data.substride;
    //    int num8 = num6 / this.segment * num1 + num5 * this.data.substride;
    //    int stride = this.data.stride;
    //    float num9 = (float)((double)this.radius * (double)this.scale + 0.200000002980232);
    //    Mesh mesh = this.meshes[dirtyIdx];
    //    Vector3[] vertices = mesh.vertices;
    //    Vector3[] normals = mesh.normals;
    //    int index1 = 0;
    //    for (int index2 = num8; index2 <= num8 + num1; ++index2)
    //    {
    //        for (int index3 = num7; index3 <= num7 + num1; ++index3)
    //        {
    //            int index4 = index3 + index2 * stride;
    //            float num10 = (float)this.data.heightData[index4] * 0.01f * this.scale;
    //            float num11 = (float)this.data.GetModLevel(index4) * 0.3333333f;
    //            float num12 = num9;
    //            if ((double)num11 > 0.0)
    //                num12 = (float)this.data.GetModPlane(index4) * 0.01f * this.scale;
    //            float num13 = (float)((double)num10 * (1.0 - (double)num11) + (double)num12 * (double)num11);
    //            vertices[index1].x = this.data.vertices[index4].x * num13;
    //            vertices[index1].y = this.data.vertices[index4].y * num13;
    //            vertices[index1].z = this.data.vertices[index4].z * num13;
    //            normals[index1].x = (float)((double)this.data.normals[index4].x * (1.0 - (double)num11) + (double)this.data.vertices[index4].x * (double)num11);
    //            normals[index1].y = (float)((double)this.data.normals[index4].y * (1.0 - (double)num11) + (double)this.data.vertices[index4].y * (double)num11);
    //            normals[index1].z = (float)((double)this.data.normals[index4].z * (1.0 - (double)num11) + (double)this.data.vertices[index4].z * (double)num11);
    //            normals[index1].Normalize();
    //            ++index1;
    //        }
    //    }
    //    mesh.vertices = vertices;
    //    mesh.normals = normals;
    //    this.meshColliders[dirtyIdx].sharedMesh = (Mesh)null;
    //    this.meshColliders[dirtyIdx].sharedMesh = mesh;
    //    return true;
    //}

    //public void ExportRuntime(BinaryWriter w)
    //{
    //    w.Write(this.modData.Length);
    //    w.Write(this.modData);
    //    w.Write(this.veinAmounts.Length);
    //    for (int index = 0; index < this.veinAmounts.Length; ++index)
    //        w.Write(this.veinAmounts[index]);
    //    w.Write(this.veinGroups.Length);
    //    for (int index = 0; index < this.veinGroups.Length; ++index)
    //    {
    //        w.Write((int)this.veinGroups[index].type);
    //        w.Write(this.veinGroups[index].pos.x);
    //        w.Write(this.veinGroups[index].pos.y);
    //        w.Write(this.veinGroups[index].pos.z);
    //        w.Write(this.veinGroups[index].count);
    //        w.Write(this.veinGroups[index].amount);
    //    }
    //}

    //public void ImportRuntime(BinaryReader r)
    //{
    //    int count = r.ReadInt32();
    //    this.modData = r.ReadBytes(count);
    //    int length1 = r.ReadInt32();
    //    this.veinAmounts = new long[length1];
    //    for (int index = 0; index < length1; ++index)
    //        this.veinAmounts[index] = r.ReadInt64();
    //    int length2 = r.ReadInt32();
    //    this.veinGroups = new PlanetData.VeinGroup[length2];
    //    for (int index = 0; index < length2; ++index)
    //    {
    //        this.veinGroups[index].type = (EVeinType)r.ReadInt32();
    //        this.veinGroups[index].pos.x = r.ReadSingle();
    //        this.veinGroups[index].pos.y = r.ReadSingle();
    //        this.veinGroups[index].pos.z = r.ReadSingle();
    //        this.veinGroups[index].count = r.ReadInt32();
    //        this.veinGroups[index].count = 0;
    //        this.veinGroups[index].amount = r.ReadInt64();
    //        this.veinGroups[index].amount = 0L;
    //    }
    //}

    public struct VeinGroup
    {
        public EVeinType type;
        public Vector3 pos;
        public int count;
        public long amount;
    }
}
