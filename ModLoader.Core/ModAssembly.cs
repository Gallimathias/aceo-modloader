using ModLoader.Core.DefaultPatches;
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModLoader.Core
{
    public class ModAssembly : AssemblyBase
    {

        public ModAssembly(string fullName) : base(fullName)
        {
        }

        public override void Load()
        {
            internalFileStream = File.Open(FullName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            var resolver = new DefaultAssemblyResolver();
            resolver.AddSearchDirectory(new FileInfo(FullName).Directory.FullName);

            assembly = AssemblyDefinition.ReadAssembly(internalFileStream, new ReaderParameters()
            {
                AssemblyResolver = resolver
            });
        }

        public List<OverridePatch> GetOverridePatches()
        {
            var patchedTypes = assembly
                .MainModule
                .GetTypes()
                .Where(t => t.BaseType != null && t.BaseType.FullName == "Aceo.Sdk.Patching.Patch")
                .ToList();

            return null;
        }
    }
}
