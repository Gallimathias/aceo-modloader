using System;
using System.Collections.Generic;
using System.IO;

namespace ModLoader.Core
{
    public class Logger
    {
        public enum LogType { Info, Warning, Error, Debug };
        private static StreamWriter _file;
        private static bool _ready = false, _isDebug;
        private static DateTime _gameStartTime;

        public static void Initialize(bool verbosity)
        {
            _file = new StreamWriter("ModLoader/MLLoutput.log");
            _ready = true;
            _isDebug = verbosity;
            _gameStartTime = DateTime.Now;
        }

        private static TimeSpan GetTimeFromStart()
        {
            return DateTime.Now - _gameStartTime;
        }

        public static void Log(string message, LogType type = LogType.Info)
        {
            if (!_ready)
                throw new Exception("Logger not initialized!");

            string finalMessage = "[" + GetTimeFromStart().Minutes + ":" + GetTimeFromStart().Seconds + ":" + GetTimeFromStart().Milliseconds + "]";
            switch (type)
            {
                case LogType.Info:
                    finalMessage += " [INFO] " + message;
                    break;
                case LogType.Warning:
                    finalMessage += " [WARNING] " + message;
                    break;
                case LogType.Error:
                    finalMessage += " [ERROR] " + message;
                    break;
                case LogType.Debug:
                    if (!_isDebug)
                        return;
                    else
                        finalMessage += " [DEBUG] " + message;
                    break;
            }
            _file.WriteLine(finalMessage);
            _file.Flush();
        }

        public static void DisposeFirst()
        {
            _ready = false;
            _file.Close();
        }
    }
}