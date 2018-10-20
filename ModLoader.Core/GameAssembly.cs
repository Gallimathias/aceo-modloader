using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModLoader.Core
{
    public class GameAssembly
    {
        public string FullName { get; }

        private FileStream internalFileStream;
        private AssemblyDefinition assembly;

        public GameAssembly(string fullName)
        {
            FullName = fullName;
        }

        public void Load()
        {
            internalFileStream = File.Open(FullName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            var resolver = new DefaultAssemblyResolver();
            resolver.AddSearchDirectory(new FileInfo(FullName).Directory.FullName);

            assembly = AssemblyDefinition.ReadAssembly(internalFileStream, new ReaderParameters()
            {
                AssemblyResolver = resolver
            });
        }

        public void Copy(string targetFullName)
        {
            File.Copy(FullName, targetFullName);
        }

        public void Save()
        {
            assembly.Write();
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
