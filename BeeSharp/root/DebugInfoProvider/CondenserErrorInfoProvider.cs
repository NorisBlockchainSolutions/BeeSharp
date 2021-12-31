using System;

namespace BeeSharp.root.DebugInfoProvider
{
    public delegate void CondenserErrorEventHandler(object sender, CondenserErrorEventArgs e);

    public class CondenserErrorEventArgs : EventArgs
    {
        public string NodeUrl { get; }
        public int ErrorCode { get; }
        public string? Message { get; }

        public CondenserErrorEventArgs(string nodeUrl, int errorCode, string? message = null)
        {
            NodeUrl = nodeUrl;
            ErrorCode = errorCode;
            Message = message;
        }
    }

    public static class CondenserErrorInfoProvider
    {
        public static event CondenserErrorEventHandler CondenserError = null!;

        internal static void OnConnectionError(object sender, CondenserErrorEventArgs e)
        {
            CondenserErrorEventHandler handler = CondenserError;
            if (CondenserError != null)
            {
                handler.Invoke(sender, e);
            }
        }
    }
}