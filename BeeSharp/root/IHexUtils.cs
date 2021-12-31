using System;

namespace BeeSharp.root
{
    public interface IHexUtils
    {
        /// <summary>
        ///     Converts a hex string to a byte array.
        /// </summary>
        /// <param name="hex">The hex string to convert (all lowercase).</param>
        /// <returns>The byte array.</returns>
        /// <exception cref="ArgumentException">Thrown when the hex string is not processable.</exception>
        byte[] HexStringToByteArray(string hex);
    }
}