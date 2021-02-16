using System;

public enum EPlanetType
{
    None,
    Vocano,
    Ocean,
    Desert,
    Ice,
    Gas,
}


[Flags]
public enum EPlanetSingularity
{
    None = 0,
    TidalLocked = 1,
    TidalLocked2 = 2,
    TidalLocked4 = 4,
    LaySide = 8,
    ClockwiseRotate = 16, // 0x00000010
    MultipleSatellites = 32, // 0x00000020
}

public enum EStarType
{
    MainSeqStar,
    GiantStar,
    WhiteDwarf,
    NeutronStar,
    BlackHole,
}


public enum ESpectrType
{
    M,
    K,
    G,
    F,
    A,
    B,
    O,
    X,
}


public enum EThemeDistribute
{
    Default,
    Birth,
    Interstellar,
    Rare,
}

public enum EVeinType : byte
{
    None,
    Iron,
    Copper,
    Silicium,
    Titanium,
    Stone,
    Coal,
    Oil,
    Fireice,
    Diamond,
    Fractal,
    Crysrub,
    Grat,
    Bamboo,
    Mag,
    Max,
}
