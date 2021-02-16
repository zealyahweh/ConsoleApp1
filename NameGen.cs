using System;

public static class NameGen
{
    public static string[] con0 = new string[39]
    {
    "p",
    "t",
    "c",
    "k",
    "b",
    "d",
    "g",
    "f",
    "ph",
    "s",
    "sh",
    "th",
    "h",
    "v",
    "z",
    "th",
    "r",
    "ch",
    "tr",
    "dr",
    "m",
    "n",
    "l",
    "y",
    "w",
    "sp",
    "st",
    "sk",
    "sc",
    "sl",
    "pl",
    "cl",
    "bl",
    "gl",
    "fr",
    "fl",
    "pr",
    "br",
    "cr"
    };
    public static string[] con1 = new string[16]
    {
    "thr",
    "ex",
    "ec",
    "el",
    "er",
    "ev",
    "il",
    "is",
    "it",
    "ir",
    "up",
    "ut",
    "ur",
    "un",
    "gt",
    "phr"
    };
    public static string[] vow0 = new string[7]
    {
    "a",
    "an",
    "am",
    "al",
    "o",
    "u",
    "xe"
    };
    public static string[] vow1 = new string[23]
    {
    "ea",
    "ee",
    "ie",
    "i",
    "e",
    "a",
    "er",
    "a",
    "u",
    "oo",
    "u",
    "or",
    "o",
    "oa",
    "ar",
    "a",
    "ei",
    "ai",
    "i",
    "au",
    "ou",
    "ao",
    "ir"
    };
    public static string[] vow2 = new string[7]
    {
    "y",
    "oi",
    "io",
    "iur",
    "ur",
    "ac",
    "ic"
    };
    public static string[] ending = new string[18]
    {
    "er",
    "n",
    "un",
    "or",
    "ar",
    "o",
    "o",
    "ans",
    "us",
    "ix",
    "us",
    "iurs",
    "a",
    "eo",
    "urn",
    "es",
    "eon",
    "y"
    };
    public static string[] roman = new string[21]
    {
    string.Empty,
    "I",
    "II",
    "III",
    "IV",
    "V",
    "VI",
    "VII",
    "VIII",
    "IX",
    "X",
    "XI",
    "XII",
    "XIII",
    "XIV",
    "XV",
    "XVI",
    "XVII",
    "XVIII",
    "XIX",
    "XX"
    };
    public static string[] constellations = new string[88]
    {
    "Andromedae",
    "Antliae",
    "Apodis",
    "Aquarii",
    "Aquilae",
    "Arae",
    "Arietis",
    "Aurigae",
    "Bootis",
    "Caeli",
    "Camelopardalis",
    "Cancri",
    "Canum Venaticorum",
    "Canis Majoris",
    "Canis Minoris",
    "Capricorni",
    "Carinae",
    "Cassiopeiae",
    "Centauri",
    "Cephei",
    "Ceti",
    "Chamaeleontis",
    "Circini",
    "Columbae",
    "Comae Berenices",
    "Coronae Australis",
    "Coronae Borealis",
    "Corvi",
    "Crateris",
    "Crucis",
    "Cygni",
    "Delphini",
    "Doradus",
    "Draconis",
    "Equulei",
    "Eridani",
    "Fornacis",
    "Geminorum",
    "Gruis",
    "Herculis",
    "Horologii",
    "Hydrae",
    "Hydri",
    "Indi",
    "Lacertae",
    "Leonis",
    "Leonis Minoris",
    "Leporis",
    "Librae",
    "Lupi",
    "Lyncis",
    "Lyrae",
    "Mensae",
    "Microscopii",
    "Monocerotis",
    "Muscae",
    "Normae",
    "Octantis",
    "Ophiuchii",
    "Orionis",
    "Pavonis",
    "Pegasi",
    "Persei",
    "Phoenicis",
    "Pictoris",
    "Piscium",
    "Piscis Austrini",
    "Puppis",
    "Pyxidis",
    "Reticuli",
    "Sagittae",
    "Sagittarii",
    "Scorpii",
    "Sculptoris",
    "Scuti",
    "Serpentis",
    "Sextantis",
    "Tauri",
    "Telescopii",
    "Trianguli",
    "Trianguli Australis",
    "Tucanae",
    "Ursae Majoris",
    "Ursae Minoris",
    "Velorum",
    "Virginis",
    "Volantis",
    "Vulpeculae"
    };
    public static string[] alphabeta = new string[11]
    {
    "Alpha",
    "Beta",
    "Gamma",
    "Delta",
    "Epsilon",
    "Zeta",
    "Eta",
    "Theta",
    "Iota",
    "Kappa",
    "Lambda"
    };
    public static string[] alphabeta_letter = new string[11]
    {
    "α",
    "β",
    "γ",
    "δ",
    "ε",
    "ζ",
    "η",
    "θ",
    "ι",
    "κ",
    "λ"
    };
    public static string[] raw_star_names = new string[425]
    {
    "Acamar",
    "Achernar",
    "Achird",
    "Acrab",
    "Acrux",
    "Acubens",
    "Adhafera",
    "Adhara",
    "Adhil",
    "Agena",
    "Aladfar",
    "Albaldah",
    "Albali",
    "Albireo",
    "Alchiba",
    "Alcor",
    "Alcyone",
    "Alderamin",
    "Aldhibain",
    "Aldib",
    "Alfecca",
    "Alfirk",
    "Algedi",
    "Algenib",
    "Algenubi",
    "Algieba",
    "Algjebbath",
    "Algol",
    "Algomeyla",
    "Algorab",
    "Alhajoth",
    "Alhena",
    "Alifa",
    "Alioth",
    "Alkaid",
    "Alkalurops",
    "Alkaphrah",
    "Alkes",
    "Alkhiba",
    "Almach",
    "Almeisan",
    "Almuredin",
    "AlNa'ir",
    "Alnasl",
    "Alnilam",
    "Alnitak",
    "Alniyat",
    "Alphard",
    "Alphecca",
    "Alpheratz",
    "Alrakis",
    "Alrami",
    "Alrescha",
    "AlRijil",
    "Alsahm",
    "Alsciaukat",
    "Alshain",
    "Alshat",
    "Alshemali",
    "Alsuhail",
    "Altair",
    "Altais",
    "Alterf",
    "Althalimain",
    "AlTinnin",
    "Aludra",
    "AlulaAustralis",
    "AlulaBorealis",
    "Alwaid",
    "Alwazn",
    "Alya",
    "Alzirr",
    "AmazonStar",
    "Ancha",
    "Anchat",
    "AngelStern",
    "Angetenar",
    "Ankaa",
    "Anser",
    "Antecanis",
    "Apollo",
    "Arich",
    "Arided",
    "Arietis",
    "Arkab",
    "ArkebPrior",
    "Arneb",
    "Arrioph",
    "AsadAustralis",
    "Ascella",
    "Aschere",
    "AsellusAustralis",
    "AsellusBorealis",
    "AsellusPrimus",
    "Ashtaroth",
    "Asmidiske",
    "Aspidiske",
    "Asterion",
    "Asterope",
    "Asuia",
    "Athafiyy",
    "Atik",
    "Atlas",
    "Atria",
    "Auva",
    "Avior",
    "Azelfafage",
    "Azha",
    "Azimech",
    "BatenKaitos",
    "Becrux",
    "Beid",
    "Bellatrix",
    "Benatnasch",
    "Biham",
    "Botein",
    "Brachium",
    "Bunda",
    "Cajam",
    "Calbalakrab",
    "Calx",
    "Canicula",
    "Capella",
    "Caph",
    "Castor",
    "Castula",
    "Cebalrai",
    "Ceginus",
    "Celaeno",
    "Chara",
    "Chertan",
    "Choo",
    "Clava",
    "CorCaroli",
    "CorHydrae",
    "CorLeonis",
    "Cornu",
    "CorScorpii",
    "CorSepentis",
    "CorTauri",
    "Coxa",
    "Cursa",
    "Cymbae",
    "Cynosaura",
    "Dabih",
    "DenebAlgedi",
    "DenebDulfim",
    "DenebelOkab",
    "DenebKaitos",
    "DenebOkab",
    "Denebola",
    "Dhalim",
    "Dhur",
    "Diadem",
    "Difda",
    "DifdaalAuwel",
    "Dnoces",
    "Dubhe",
    "Dziban",
    "Dzuba",
    "Edasich",
    "ElAcola",
    "Elacrab",
    "Electra",
    "Elgebar",
    "Elgomaisa",
    "ElKaprah",
    "ElKaridab",
    "Elkeid",
    "ElKhereb",
    "Elmathalleth",
    "Elnath",
    "ElPhekrah",
    "Eltanin",
    "Enif",
    "Erakis",
    "Errai",
    "FalxItalica",
    "Fidis",
    "Fomalhaut",
    "Fornacis",
    "FumAlSamakah",
    "Furud",
    "Gacrux",
    "Gallina",
    "GarnetStar",
    "Gemma",
    "Genam",
    "Giausar",
    "GiedePrime",
    "Giedi",
    "Gienah",
    "Gienar",
    "Gildun",
    "Girtab",
    "Gnosia",
    "Gomeisa",
    "Gorgona",
    "Graffias",
    "Hadar",
    "Hamal",
    "Haris",
    "Hasseleh",
    "Hastorang",
    "Hatysa",
    "Heka",
    "Hercules",
    "Heze",
    "Hoedus",
    "Homam",
    "HyadumPrimus",
    "Icalurus",
    "Iclarkrav",
    "Izar",
    "Jabbah",
    "Jewel",
    "Jugum",
    "Juza",
    "Kabeleced",
    "Kaff",
    "Kaffa",
    "Kaffaljidma",
    "Kaitain",
    "KalbalAkrab",
    "Kat",
    "KausAustralis",
    "KausBorealis",
    "KausMedia",
    "Keid",
    "KeKouan",
    "Kelb",
    "Kerb",
    "Kerbel",
    "KiffaBoraelis",
    "Kitalpha",
    "Kochab",
    "Kornephoros",
    "Kraz",
    "Ksora",
    "Kuma",
    "Kurhah",
    "Kursa",
    "Lesath",
    "Maasym",
    "Maaz",
    "Mabsuthat",
    "Maia",
    "Marfik",
    "Markab",
    "Marrha",
    "Matar",
    "Mebsuta",
    "Megres",
    "Meissa",
    "Mekbuda",
    "Menkalinan",
    "Menkar",
    "Menkent",
    "Menkib",
    "Merak",
    "Meres",
    "Merga",
    "Meridiana",
    "Merope",
    "Mesartim",
    "Metallah",
    "Miaplacidus",
    "Mimosa",
    "Minelauva",
    "Minkar",
    "Mintaka",
    "Mirac",
    "Mirach",
    "Miram",
    "Mirfak",
    "Mirzam",
    "Misam",
    "Mismar",
    "Mizar",
    "Muhlifain",
    "Muliphein",
    "Muphrid",
    "Muscida",
    "NairalSaif",
    "NairalZaurak",
    "Naos",
    "Nash",
    "Nashira",
    "Navi",
    "Nekkar",
    "Nicolaus",
    "Nihal",
    "Nodus",
    "Nunki",
    "Nusakan",
    "OculusBoreus",
    "Okda",
    "Osiris",
    "OsPegasi",
    "Palilicium",
    "Peacock",
    "Phact",
    "Phecda",
    "Pherkad",
    "PherkadMinor",
    "Pherkard",
    "Phoenice",
    "Phurad",
    "Pishpai",
    "Pleione",
    "Polaris",
    "Pollux",
    "Porrima",
    "Postvarta",
    "Praecipua",
    "Procyon",
    "Propus",
    "Protrygetor",
    "Pulcherrima",
    "Rana",
    "RanaSecunda",
    "Rasalas",
    "Rasalgethi",
    "Rasalhague",
    "Rasalmothallah",
    "RasHammel",
    "Rastaban",
    "Reda",
    "Regor",
    "Regulus",
    "Rescha",
    "RigilKentaurus",
    "RiglalAwwa",
    "Rotanen",
    "Ruchba",
    "Ruchbah",
    "Rukbat",
    "Rutilicus",
    "Saak",
    "Sabik",
    "Sadachbia",
    "Sadalbari",
    "Sadalmelik",
    "Sadalsuud",
    "Sadatoni",
    "Sadira",
    "Sadr",
    "Saidak",
    "Saiph",
    "Salm",
    "Sargas",
    "Sarin",
    "Sartan",
    "Sceptrum",
    "Scheat",
    "Schedar",
    "Scheddi",
    "Schemali",
    "Scutulum",
    "SeatAlpheras",
    "Segin",
    "Seginus",
    "Shaula",
    "Shedir",
    "Sheliak",
    "Sheratan",
    "Singer",
    "Sirius",
    "Sirrah",
    "Situla",
    "Skat",
    "Spica",
    "Sterope",
    "Subra",
    "Suha",
    "Suhail",
    "SuhailHadar",
    "SuhailRadar",
    "Suhel",
    "Sulafat",
    "Superba",
    "Svalocin",
    "Syrma",
    "Tabit",
    "Tais",
    "Talitha",
    "TaniaAustralis",
    "TaniaBorealis",
    "Tarazed",
    "Tarf",
    "TaTsun",
    "Taygeta",
    "Tegmen",
    "Tejat",
    "TejatPrior",
    "Terebellum",
    "Theemim",
    "Thuban",
    "Tolimann",
    "Tramontana",
    "Tsih",
    "Tureis",
    "Unukalhai",
    "Vega",
    "Venabulum",
    "Venator",
    "Vendemiatrix",
    "Vespertilio",
    "Vildiur",
    "Vindemiatrix",
    "Wasat",
    "Wazn",
    "YedPosterior",
    "YedPrior",
    "Zaniah",
    "Zaurak",
    "Zavijava",
    "ZenithStar",
    "Zibel",
    "Zosma",
    "Zubenelakrab",
    "ZubenElgenubi",
    "Zubeneschamali",
    "ZubenHakrabi",
    "Zubra"
    };
    public static string[] raw_giant_names = new string[60]
    {
    "AH Scorpii",
    "Aldebaran",
    "Alpha Herculis",
    "Antares",
    "Arcturus",
    "AV Persei",
    "BC Cygni",
    "Betelgeuse",
    "BI Cygni",
    "BO Carinae",
    "Canopus",
    "CE Tauri",
    "CK Carinae",
    "CW Leonis",
    "Deneb",
    "Epsilon Aurigae",
    "Eta Carinae",
    "EV Carinae",
    "IX Carinae",
    "KW Sagittarii",
    "KY Cygni",
    "Mira",
    "Mu Cephei",
    "NML Cygni",
    "NR Vulpeculae",
    "PZ Cassiopeiae",
    "R Doradus",
    "R Leporis",
    "Rho Cassiopeiae",
    "Rigel",
    "RS Persei",
    "RT Carinae",
    "RU Virginis",
    "RW Cephei",
    "S Cassiopeiae",
    "S Cephei",
    "S Doradus",
    "S Persei",
    "SU Persei",
    "TV Geminorum",
    "U Lacertae",
    "UY Scuti",
    "V1185 Scorpii",
    "V354 Cephei",
    "V355 Cepheus",
    "V382 Carinae",
    "V396 Centauri",
    "V437 Scuti",
    "V509 Cassiopeiae",
    "V528 Carinae",
    "V602 Carinae",
    "V648 Cassiopeiae",
    "V669 Cassiopeiae",
    "V838 Monocerotis",
    "V915 Scorpii",
    "VV Cephei",
    "VX Sagittarii",
    "VY Canis Majoris",
    "WOH G64",
    "XX Persei"
    };
    public static string[] giant_name_formats = new string[7]
    {
    "HD {0:0000}{1:00}",
    "HDE {0:0000}{1:00}",
    "HR {0:0000}",
    "HV {0:0000}",
    "LBV {0:0000}-{1:00}",
    "NSV {0:0000}",
    "YSC {0:0000}-{1:00}"
    };
    public static string[] neutron_star_name_formats = new string[2]
    {
    "NTR J{0:00}{1:00}+{2:00}",
    "NTR J{0:00}{1:00}-{2:00}"
    };
    public static string[] black_hole_name_formats = new string[2]
    {
    "DSR J{0:00}{1:00}+{2:00}",
    "DSR J{0:00}{1:00}-{2:00}"
    };

    public static string RandomName(int seed)
    {
        Random random = new Random(seed);
        int num = (int)(random.NextDouble() * 1.8 + 2.3);
        string str1 = string.Empty;
        for (int index = 0; index < num; ++index)
        {
            if (random.NextDouble() < 0.0500000007450581 && index == 0)
            {
                str1 += NameGen.vow0[random.Next(NameGen.vow0.Length)];
            }
            else
            {
                string str2 = random.NextDouble() < 0.970000028610229 || num >= 4 ? str1 + NameGen.con0[random.Next(NameGen.con0.Length)] : str1 + NameGen.con1[random.Next(NameGen.con1.Length)];
                str1 = index != num - 1 || random.NextDouble() >= 0.899999976158142 ? (random.NextDouble() >= 0.970000028610229 ? str2 + NameGen.vow2[random.Next(NameGen.vow2.Length)] : str2 + NameGen.vow1[random.Next(NameGen.vow1.Length)]) : str2 + NameGen.ending[random.Next(NameGen.ending.Length)];
            }
        }
        if (str1.IndexOf("uu") >= 0)
            str1 = str1.Replace("uu", "u");
        if (str1.IndexOf("ooo") >= 0)
            str1 = str1.Replace("ooo", "oo");
        if (str1.IndexOf("eee") >= 0)
            str1 = str1.Replace("eee", "ee");
        if (str1.IndexOf("eea") >= 0)
            str1 = str1.Replace("eea", "ea");
        if (str1.IndexOf("aa") >= 0)
            str1 = str1.Replace("aa", "a");
        if (str1.IndexOf("yy") >= 0)
            str1 = str1.Replace("yy", "y");
        return str1.Substring(0, 1).ToUpper() + str1.Substring(1);
    }

    public static string RandomStarName(int seed, StarData starData, GalaxyData galaxy)
    {
        Random random = new Random(seed);
        int num = 0;
        while (num++ < 256)
        {
            string str = NameGen._RandomStarName(random.Next(), starData);
            bool flag = false;
            for (int index = 0; index < galaxy.starCount; ++index)
            {
                if (galaxy.stars[index] != null && galaxy.stars[index].name.Equals(str))
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
                return str;
        }
        return "XStar";
    }

    private static string _RandomStarName(int seed, StarData starData)
    {
        Random random = new Random(seed);
        int seed1 = random.Next();
        double num1 = random.NextDouble();
        double num2 = random.NextDouble();
        if (starData.type == EStarType.GiantStar)
        {
            if (num2 < 0.400000005960464)
                return NameGen.RandomGiantStarNameFromRawNames(seed1);
            return num2 < 0.699999988079071 ? NameGen.RandomGiantStarNameWithConstellationAlpha(seed1) : NameGen.RandomGiantStarNameWithFormat(seed1);
        }
        if (starData.type == EStarType.NeutronStar)
            return NameGen.RandomNeutronStarNameWithFormat(seed1);
        if (starData.type == EStarType.BlackHole)
            return NameGen.RandomBlackHoleNameWithFormat(seed1);
        if (num1 < 0.600000023841858)
            return NameGen.RandomStarNameFromRawNames(seed1);
        return num1 < 0.930000007152557 ? NameGen.RandomStarNameWithConstellationAlpha(seed1) : NameGen.RandomStarNameWithConstellationNumber(seed1);
    }

    public static string RandomStarNameFromRawNames(int seed)
    {
        int index = new Random(seed).Next() % NameGen.raw_star_names.Length;
        return NameGen.raw_star_names[index];
    }

    public static string RandomStarNameWithConstellationAlpha(int seed)
    {
        Random random = new Random(seed);
        int num1 = random.Next();
        int num2 = random.Next();
        int index1 = num1 % NameGen.constellations.Length;
        int index2 = num2 % NameGen.alphabeta.Length;
        string constellation = NameGen.constellations[index1];
        return constellation.Length > 10 ? NameGen.alphabeta_letter[index2] + " " + constellation : NameGen.alphabeta[index2] + " " + constellation;
    }

    public static string RandomStarNameWithConstellationNumber(int seed)
    {
        Random random = new Random(seed);
        int num1 = random.Next();
        int num2 = random.Next(27, 75);
        int index = num1 % NameGen.constellations.Length;
        return num2.ToString() + " " + NameGen.constellations[index];
    }

    public static string RandomGiantStarNameFromRawNames(int seed)
    {
        int index = new Random(seed).Next() % NameGen.raw_giant_names.Length;
        return NameGen.raw_giant_names[index];
    }

    public static string RandomGiantStarNameWithConstellationAlpha(int seed)
    {
        Random random = new Random(seed);
        int num1 = random.Next();
        int num2 = random.Next(15, 26);
        int num3 = random.Next(0, 26);
        int index = num1 % NameGen.constellations.Length;
        return ((int)(char)(65 + num2) + (int)(char)(65 + num3)).ToString() + " " + NameGen.constellations[index];
    }

    public static string RandomGiantStarNameWithFormat(int seed)
    {
        Random random = new Random(seed);
        int num1 = random.Next();
        int num2 = random.Next(10000);
        int num3 = random.Next(100);
        int index = num1 % NameGen.giant_name_formats.Length;
        return string.Format(NameGen.giant_name_formats[index], (object)num2, (object)num3);
    }

    public static string RandomNeutronStarNameWithFormat(int seed)
    {
        Random random = new Random(seed);
        int num1 = random.Next();
        int num2 = random.Next(24);
        int num3 = random.Next(60);
        int num4 = random.Next(0, 60);
        int index = num1 % NameGen.neutron_star_name_formats.Length;
        return string.Format(NameGen.neutron_star_name_formats[index], (object)num2, (object)num3, (object)num4);
    }

    public static string RandomBlackHoleNameWithFormat(int seed)
    {
        Random random = new Random(seed);
        int num1 = random.Next();
        int num2 = random.Next(24);
        int num3 = random.Next(60);
        int num4 = random.Next(0, 60);
        int index = num1 % NameGen.black_hole_name_formats.Length;
        return string.Format(NameGen.black_hole_name_formats[index], (object)num2, (object)num3, (object)num4);
    }
}
