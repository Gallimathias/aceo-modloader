using System;
using System.IO;

namespace ModLoader.Core
{
    public static class MLUtils
    {
        public static Sprite LoadSpriteFromFile(string modName, string filename, float pixelsPerUnit = 100.0f)
        {
            string fullPath = Path.Combine(GlobalVars.modPath, modName, filename);
            Texture2D texture = null;
            Logger.Log($"Loading sprite from {fullPath}", Logger.LogType.Debug);
            if (File.Exists(fullPath))
            {
                texture = new Texture2D(2, 2);
                texture.LoadImage(File.ReadAllBytes(fullPath));
            }
            if (texture != null)
                return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0),
                    pixelsPerUnit);
            Logger.Log($"Sprite {filename} from {modName} could not be loaded.", Logger.LogType.Warning);
            return null;
        }

        public static void RestartGameWithML()
        {
            // Add restart file flag so ModLoader knows what to do
            var fs = File.Open(Path.Combine(Application.dataPath, "RESTARTFLAG"), FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            fs.Close();
            fs.Dispose();
            File.SetLastWriteTimeUtc(Path.Combine(Application.dataPath, "RESTARTFLAG"), DateTime.Now);

            // Quit the game
            Utils.QuitGame();
        }
    }
}