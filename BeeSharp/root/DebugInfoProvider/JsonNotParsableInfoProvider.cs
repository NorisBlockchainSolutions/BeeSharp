using System;

namespace BeeSharp.root.DebugInfoProvider
{
    public delegate void JsonNotParsableEventHandler(object sender, JsonNotParsableEventArgs e);

    public class JsonNotParsableEventArgs : EventArgs
    {
        public string Instance { get; }
        public string Message { get; }

        public JsonNotParsableEventArgs(string instance, string message)
        {
            Instance = instance;
            Message = message;
        }
    }

    public static class JsonNotParsableInfoProvider
    {
        public static event JsonNotParsableEventHandler JsonNotParsable = null!;

        internal static void OnJsonNotParsable(object sender, JsonNotParsableEventArgs e)
        {
            JsonNotParsableEventHandler handler = JsonNotParsable;
            if (JsonNotParsable != null)
            {
                handler.Invoke(sender, e);
            }
        }
    }
}