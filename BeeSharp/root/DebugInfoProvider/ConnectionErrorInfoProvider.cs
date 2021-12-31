using System;

namespace BeeSharp.root.DebugInfoProvider
{
    public delegate void ConnectionErrorEventHandler(object sender, ConnectionErrorEventArgs e);

    public class ConnectionErrorEventArgs : EventArgs
    {
        public string Instance { get; }
        public string Message { get; }

        public ConnectionErrorEventArgs(string instance, string message)
        {
            Instance = instance;
            Message = message;
        }
    }

    public static class ConnectionErrorInfoProvider
    {
        public static event ConnectionErrorEventHandler ConnectionError = null!;

        internal static void OnConnectionError(object sender, ConnectionErrorEventArgs e)
        {
            ConnectionErrorEventHandler handler = ConnectionError;
            if (ConnectionError != null)
            {
                handler.Invoke(sender, e);
            }
        }
    }
}