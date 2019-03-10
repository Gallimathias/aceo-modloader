using System;
using System.Collections.Generic;
using System.Text;
using Mono.Cecil;

namespace ModLoader.Core.DefaultPatches
{
    public class OverridePatch : Patch
    {
        public override TypeDefinition Type { get; protected set; }

        public override void Merge(TypeDefinition type) => throw new NotImplementedException();
    }
}
