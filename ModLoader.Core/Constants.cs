using System;
using System.Collections.Generic;
using System.Reflection;

namespace ModLoader.Core
{
    internal class GlobalVars
    {
        public static string modPath = ""; // Loaded by ModLoaderLibrary in init
        public static int numMods = 0;
        public static List<Tuple<string, Assembly>> modAssemblies = new List<Tuple<string, Assembly>>();
    }
}