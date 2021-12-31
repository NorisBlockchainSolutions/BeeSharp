using System;

namespace BeeSharp.root.Helper
{
    public static class ByteHelper
    {
        // Altered version based on https://stackoverflow.com/a/9995303
        private static int GetHexVal(char hex)
        {
            var val = (int) hex;
            //For uppercase A-F letters:
            //return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            //return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            return val - (val < 58 ? 48 : val < 97 ? 55 : 87);
        }

        /// <summary>
        ///     Convert hexstring to byte array using little endian.
        /// </summary>
        /// <param name="hex">The hex string to convert.</param>
        /// <returns>The byte array.</returns>
        /// <exception cref="ArgumentException">Thrown when the hex string has an odd number of digits.</exception>
        public static byte[] StringToByteArray(string hex)
        {
            if (hex.Length % 2 == 1)
                throw new ArgumentException("The binary key cannot have an odd number of digits", nameof(hex));

            byte[] arr = new byte[hex.Length >> 1];

            for (var i = 0; i < hex.Length >> 1; ++i)
                arr[i] = (byte) ((GetHexVal(hex[i << 1]) << 4) + GetHexVal(hex[(i << 1) + 1]));

            return arr;
        }

        /// <summary>
        ///     Convert an integer to its binary representation. Only use as many bytes as needed.
        /// </summary>
        /// <param name="value">The integer value to convert.</param>
        /// <returns>The byte array representation.</returns>
        /// <exception cref="ArgumentException">Thrown when the value is negative.</exception>
        public static byte[] IntToShortestUnsignedByteArray(int value)
        {
            if (value < 0) throw new ArgumentException("Cannot convert int with negative value!", nameof(value));

            // Find out how many bytes are required to represent value
            byte[] result = value switch
            {
                <= byte.MaxValue => new[] {(byte) value},
                <= ushort.MaxValue => BitConverter.GetBytes((ushort) value),
                _ => BitConverter.GetBytes(value)
            };

            return result;
        }

        /// <summary>
        ///     Convert a long integer to its binary representation. Only use as many bytes as needed.
        /// </summary>
        /// <param name="value">The integer value to convert.</param>
        /// <returns>The byte array representation.</returns>
        /// <exception cref="ArgumentException">Thrown when the value is negative.</exception>
        public static byte[] LongToShortestUnsignedByteArray(long value)
        {
            if (value < 0) throw new ArgumentException("Cannot convert long with negative value!", nameof(value));

            // Find out how many bytes are required to represent value
            byte[] result = value switch
            {
                <= byte.MaxValue => new[] {(byte) value},
                <= ushort.MaxValue => BitConverter.GetBytes((ushort) value),
                <= uint.MaxValue => BitConverter.GetBytes((uint) value),
                _ => BitConverter.GetBytes(value)
            };

            return result;
        }
    }
}