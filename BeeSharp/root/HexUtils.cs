using System;

namespace BeeSharp.root
{
    public class HexUtils : IHexUtils
    {
        // Originates from: https://stackoverflow.com/a/9995303
        /// <summary>
        ///     Converts a hex string to a byte array.
        /// </summary>
        /// <param name="hex">The hex string to convert (all lowercase).</param>
        /// <returns>The byte array.</returns>
        /// <exception cref="ArgumentException">Thrown when the hex string is not processable.</exception>
        public byte[] HexStringToByteArray(string hex)
        {
            if (hex.Length % 2 == 1)
                throw new ArgumentException("The binary key cannot have an odd number of digits", nameof(hex));

            byte[] arr = new byte[hex.Length >> 1];

            for (var i = 0; i < hex.Length >> 1; ++i)
                arr[i] = (byte) ((GetHexVal(hex[i << 1]) << 4) + GetHexVal(hex[(i << 1) + 1]));

            return arr;
        }

        private static int GetHexVal(char hex)
        {
            int val = hex;
            //For uppercase A-F letters:
            //return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            // return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }
    }
}