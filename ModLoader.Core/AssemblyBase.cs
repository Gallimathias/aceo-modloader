using Mono.Cecil;
using System.IO;

namespace ModLoader.Core
{
    public abstract class AssemblyBase
    {
        public string FullName { get; }

        protected FileStream internalFileStream;
        protected AssemblyDefinition assembly;

        public AssemblyBase(string fullname)
        {
            FullName = fullname;
        }

        public abstract void Load();
    }
}