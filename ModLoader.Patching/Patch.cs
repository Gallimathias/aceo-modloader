using System;
using Mono.Cecil;

namespace ModLoader.Patching
{
    public abstract class Patch
    {
        public TypeDefinition Type { get; protected set; }

        public abstract void Merge(TypeDefinition type);
    }
}