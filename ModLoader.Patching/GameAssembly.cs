﻿using Mono.Cecil;
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
            var type = assembly.MainModule.Types.FirstOrDefault(p => p.FullName == patch.Type.FullName);
            if (type == null)
            {
                assembly.MainModule.Types.Add(patch.Type);
                type = patch.Type;
            }

            patch.Merge(type);
        }
    }
}
