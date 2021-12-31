using System;

namespace BeeSharp.root.DebugInfoProvider
{
    public delegate void UnregisteredTypeEventHandler(object sender, UnregisteredTypeEventArgs e);

    public class UnregisteredTypeEventArgs : EventArgs
    {
        public string Director { get; }
        public string Message { get; }

        public UnregisteredTypeEventArgs(string director, string message)
        {
            Director = director;
            Message = message;
        }
    }

    public static class DirectorInfoProvider
    {
        public static event UnregisteredTypeEventHandler UnregisteredTypeRequested = null!;

        public static void OnUnregisteredTypeRequested(object sender, UnregisteredTypeEventArgs e)
        {
            var handler = UnregisteredTypeRequested;
            if (UnregisteredTypeRequested != null)
            {
                handler?.Invoke(sender, e);
            }
        }
    }
}