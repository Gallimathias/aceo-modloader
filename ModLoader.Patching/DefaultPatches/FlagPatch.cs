using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModLoader.Patching.DefaultPatches
{
    public class FlagPatch : Patch
    {
        public FlagPatch()
        {
            Type = new TypeDefinition("", "ModLoaderFlagg", TypeAttributes.Abstract);
        }
    }
}
