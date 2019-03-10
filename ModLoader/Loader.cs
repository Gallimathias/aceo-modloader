using ModLoader.Core;
using ModLoader.Core.DefaultPatches;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModLoader
{
    public class Loader
    {
        private readonly DirectoryInfo gameDirectory;
        private GameAssembly gameAssembly;

        public Loader(string gamePath)
        {
            gameDirectory = new DirectoryInfo(gamePath);
        }

        public void Load()
        {
            var file = gameDirectory.GetFiles("Assembly-CSharp.dll", SearchOption.AllDirectories).FirstOrDefault();

            if (file != null && file.Exists)
            {
                gameAssembly = new GameAssembly(file.FullName);
            }

        }

        public void LoadMod(string fullName)
        {
            var assembly = new ModAssembly(fullName);
            assembly.Load();
            assembly.GetOverridePatches();
        }

        public void Patch()
        {
            var file = new FileInfo(gameAssembly.FullName);
            var targetFile = new FileInfo(Path.Combine(file.Directory.FullName, "~" + file.Name));

            if (!targetFile.Exists)
                gameAssembly.Copy(targetFile.FullName);

            gameAssembly.Load();

            var modifiedPatch = new ModifiedPatch();
            modifiedPatch.Generate();
            gameAssembly.AddPatch(modifiedPatch);
            
        }

        public void Save()
        {
            gameAssembly.Save();
        }
    }
}
