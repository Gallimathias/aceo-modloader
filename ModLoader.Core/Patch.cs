using System;
using Mono.Cecil;

namespace ModLoader.Core
{
    public abstract class Patch
    {
        public abstract TypeDefinition Type { get; protected set; }

        public virtual void Generate() { }

        public abstract void Merge(TypeDefinition type);
    }
}