namespace Services.Logging
{
    public static class Logger
    {
        public static bool IsDebugActive { get; private set; }
        public static bool ShowTimestamps { get; set; } = true;
        private enum LogMessageTypes
        {
            Classic = 0,
            Info,
            Warning,
            Error,
            Fatal
        }

        static Logger()
        {
#if DEBUG
            IsDebugActive = true;
#else
            IsDebugActive = false;
#endif
        }

        private static readonly object LogOutputSync = new object();

        private static void PrintMessageLog(string WhoSends, string message, LogMessageTypes messageType)
        {
            lock (LogOutputSync)
            {
                if (!IsDebugActive) return;

                Console.Write("[SW_LOG - ");
                switch (messageType)
                {
                    case LogMessageTypes.Classic:
                        Console.Write("Log");
                        break;
                    case LogMessageTypes.Info:
                        Console.Write("Info");
                        break;
                    case LogMessageTypes.Warning:
                        Console.Write("Warning");
                        break;
                    case LogMessageTypes.Error:
                        Console.Write("Error");
                        break;
                    case LogMessageTypes.Fatal:
                        Console.Write("FATAL");
                        break;
                    default:
                        Console.Write("Log");
                        break;
                }
                Console.Write(" # ");
                Console.WriteLine($"<{WhoSends}>] {message}");
            }
        }

        public static void Log(string WhoSends, string Message, params object[] args)
        {
            string format = Message;
            if (args.Length > 0)
                format = string.Format(Message, args);
            PrintMessageLog(WhoSends, format, LogMessageTypes.Classic);
        }

        public static void LogInfo(string WhoSends, string Message, params object[] args)
        {
            string format = Message;
            if (args.Length > 0)
                format = string.Format(Message, args);
            PrintMessageLog(WhoSends, format, LogMessageTypes.Info);
        }

        public static void LogError(string WhoSends, string Message, params object[] args)
        {
            string format = Message;
            if (args.Length > 0)
                format = string.Format(Message, args);
            PrintMessageLog(WhoSends, format, LogMessageTypes.Error);
        }

        public static void LogFatal(string WhoSends, string Message, params object[] args)
        {
            string format = Message;
            if (args.Length > 0)
                format = string.Format(Message, args);
            PrintMessageLog(WhoSends, format, LogMessageTypes.Fatal);
        }

        public static void LogWarning(string WhoSends, string Message, params object[] args)
        {
            string format = Message;
            if (args.Length > 0)
                format = string.Format(Message, args);
            PrintMessageLog(WhoSends, format, LogMessageTypes.Warning);
        }
    }
}
