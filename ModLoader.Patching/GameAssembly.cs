using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModLoader.Patching
{
    public class GameAssembly
    {
        private AssemblyDefinition assembly;
        private readonly string fullName;

        public GameAssembly(string fullName)
        {
            this.fullName = fullName;
        }

        public void Load()
        {
            assembly = AssemblyDefinition.ReadAssembly(fullName);
        }

        public void Copy(string targetFullName)
        {
            File.Copy(fullName, targetFullName);
        }

        public void Save()
        {
            if (File.Exists(fullName))
                File.Delete(fullName);

            assembly.Write(fullName);
        }

        public void AddPatch(Patch patch)
        {
            if (!assembly.MainModule.Types.Any(p => p.FullName == patch.Type.FullName))
                assembly.MainModule.Types.Add(patch.Type);

            //Todo: else merge....
        }
    }
}
