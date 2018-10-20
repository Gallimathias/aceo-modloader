using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModLoader.Core.DefaultPatches
{
    public class ModifiedPatch : Patch
    {
        public override TypeDefinition Type { get; protected set; }

        public ModifiedPatch()
        {

        }

        public override void Generate()
        {
            Type = new TypeDefinition("Aceo.Sdk.ModFlags", "ModifiedFlag", TypeAttributes.Sealed | TypeAttributes.Class);

            base.Generate();
        }

        public override void Merge(TypeDefinition type)
        {
        }
    }
}
