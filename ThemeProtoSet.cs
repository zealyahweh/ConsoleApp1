﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Xml;
using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.8.3928.0.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
public partial class @int
{

    private int valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public int Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
public partial class @float
{

    private float valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public float Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class ThemeProtoSet
{

    private string nameField;

    private string hideFlagsField;

    private string tableNameField;

    private ThemeProtoSetDataArrayThemeProto[] dataArrayField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string hideFlags
    {
        get
        {
            return this.hideFlagsField;
        }
        set
        {
            this.hideFlagsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string TableName
    {
        get
        {
            return this.tableNameField;
        }
        set
        {
            this.tableNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("ThemeProto", typeof(ThemeProtoSetDataArrayThemeProto), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
    public ThemeProtoSetDataArrayThemeProto[] dataArray
    {
        get
        {
            return this.dataArrayField;
        }
        set
        {
            this.dataArrayField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ThemeProtoSetDataArrayThemeProto
{

    private string nameField;

    private int idField;

    private string sIDField;

    private string nameField1;

    private string sidField;

    private string displayNameField;

    private EPlanetType planetTypeField;

    private string materialPathField;

    private double temperatureField;

    private EThemeDistribute distributeField;

    private bool useHeightForBuildField;

    private float windField;

    private float ionHeightField;

    private float waterHeightField;

    private int waterItemIdField;

    private string sFXPathField;

    private string sFXVolumeField;

    private string cullingRadiusField;

    private ThemeProtoSetDataArrayThemeProtoAlgos algosField;

    private ThemeProtoSetDataArrayThemeProtoModX modXField;

    private ThemeProtoSetDataArrayThemeProtoModY modYField;

    private @int[] vegetables0Field;

    private @int[] vegetables1Field;

    private @int[] vegetables2Field;

    private @int[] vegetables3Field;

    private @int[] vegetables4Field;

    private @int[] vegetables5Field;

    private @int[] veinSpotField;

    private @float[] veinCountField;

    private @float[] veinOpacityField;

    private @int[] rareVeinsField;

    private @float[] rareSettingsField;

    private int[] gasItemsField;

    private float[] gasSpeedsField;

    private @int[] musicsField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public int ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string SID
    {
        get
        {
            return this.sIDField;
        }
        set
        {
            this.sIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string name
    {
        get
        {
            return this.nameField1;
        }
        set
        {
            this.nameField1 = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sid
    {
        get
        {
            return this.sidField;
        }
        set
        {
            this.sidField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string DisplayName
    {
        get
        {
            return this.displayNameField;
        }
        set
        {
            this.displayNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public EPlanetType PlanetType
    {
        get
        {
            return this.planetTypeField;
        }
        set
        {
            this.planetTypeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string MaterialPath
    {
        get
        {
            return this.materialPathField;
        }
        set
        {
            this.materialPathField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double Temperature
    {
        get
        {
            return this.temperatureField;
        }
        set
        {
            this.temperatureField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public EThemeDistribute Distribute
    {
        get
        {
            return this.distributeField;
        }
        set
        {
            this.distributeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public bool UseHeightForBuild
    {
        get
        {
            return this.useHeightForBuildField;
        }
        set
        {
            this.useHeightForBuildField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public float Wind
    {
        get
        {
            return this.windField;
        }
        set
        {
            this.windField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public float IonHeight
    {
        get
        {
            return this.ionHeightField;
        }
        set
        {
            this.ionHeightField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public float WaterHeight
    {
        get
        {
            return this.waterHeightField;
        }
        set
        {
            this.waterHeightField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public int WaterItemId
    {
        get
        {
            return this.waterItemIdField;
        }
        set
        {
            this.waterItemIdField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string SFXPath
    {
        get
        {
            return this.sFXPathField;
        }
        set
        {
            this.sFXPathField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string SFXVolume
    {
        get
        {
            return this.sFXVolumeField;
        }
        set
        {
            this.sFXVolumeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string CullingRadius
    {
        get
        {
            return this.cullingRadiusField;
        }
        set
        {
            this.cullingRadiusField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Algos", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public ThemeProtoSetDataArrayThemeProtoAlgos Algos
    {
        get
        {
            return this.algosField;
        }
        set
        {
            this.algosField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ModX", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public ThemeProtoSetDataArrayThemeProtoModX ModX
    {
        get
        {
            return this.modXField;
        }
        set
        {
            this.modXField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ModY", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public ThemeProtoSetDataArrayThemeProtoModY ModY
    {
        get
        {
            return this.modYField;
        }
        set
        {
            this.modYField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("int", typeof(@int))]
    public @int[] Vegetables0
    {
        get
        {
            return this.vegetables0Field;
        }
        set
        {
            this.vegetables0Field = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("int", typeof(@int))]
    public @int[] Vegetables1
    {
        get
        {
            return this.vegetables1Field;
        }
        set
        {
            this.vegetables1Field = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("int", typeof(@int))]
    public @int[] Vegetables2
    {
        get
        {
            return this.vegetables2Field;
        }
        set
        {
            this.vegetables2Field = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("int", typeof(@int))]
    public @int[] Vegetables3
    {
        get
        {
            return this.vegetables3Field;
        }
        set
        {
            this.vegetables3Field = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("int", typeof(@int))]
    public @int[] Vegetables4
    {
        get
        {
            return this.vegetables4Field;
        }
        set
        {
            this.vegetables4Field = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("int", typeof(@int))]
    public @int[] Vegetables5
    {
        get
        {
            return this.vegetables5Field;
        }
        set
        {
            this.vegetables5Field = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("int", typeof(@int))]
    public @int[] VeinSpot
    {
        get
        {
            return this.veinSpotField;
        }
        set
        {
            this.veinSpotField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("float", typeof(@float))]
    public @float[] VeinCount
    {
        get
        {
            return this.veinCountField;
        }
        set
        {
            this.veinCountField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("float", typeof(@float))]
    public @float[] VeinOpacity
    {
        get
        {
            return this.veinOpacityField;
        }
        set
        {
            this.veinOpacityField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("int", typeof(@int))]
    public @int[] RareVeins
    {
        get
        {
            return this.rareVeinsField;
        }
        set
        {
            this.rareVeinsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("float", typeof(@float))]
    public @float[] RareSettings
    {
        get
        {
            return this.rareSettingsField;
        }
        set
        {
            this.rareSettingsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //[System.Xml.Serialization.XmlArrayItemAttribute("int", typeof(@int))]
    public int[] GasItems
    {
        get
        {
            return this.gasItemsField;
        }
        set
        {
            this.gasItemsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //[System.Xml.Serialization.XmlArrayItemAttribute("float", typeof(@float))]
    public float[] GasSpeeds
    {
        get
        {
            return this.gasSpeedsField;
        }
        set
        {
            this.gasSpeedsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("int", typeof(@int))]
    public @int[] Musics
    {
        get
        {
            return this.musicsField;
        }
        set
        {
            this.musicsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ThemeProtoSetDataArrayThemeProtoAlgos
{

    private string intField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string @int
    {
        get
        {
            return this.intField;
        }
        set
        {
            this.intField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ThemeProtoSetDataArrayThemeProtoModX
{

    private double xField;

    private double yField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double x
    {
        get
        {
            return this.xField;
        }
        set
        {
            this.xField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double y
    {
        get
        {
            return this.yField;
        }
        set
        {
            this.yField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ThemeProtoSetDataArrayThemeProtoModY
{

    private double xField;

    private double yField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double x
    {
        get
        {
            return this.xField;
        }
        set
        {
            this.xField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double y
    {
        get
        {
            return this.yField;
        }
        set
        {
            this.yField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class NewDataSet
{

    private object[] itemsField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ThemeProtoSet", typeof(ThemeProtoSet))]
    [System.Xml.Serialization.XmlElementAttribute("float", typeof(@float), IsNullable = true)]
    [System.Xml.Serialization.XmlElementAttribute("int", typeof(@int), IsNullable = true)]
    public object[] Items
    {
        get
        {
            return this.itemsField;
        }
        set
        {
            this.itemsField = value;
        }
    }
}
