using System.Text.Json;

namespace BeeSharp.root.Helper
{
    public static class Utf8JsonReaderHelper
    {
        public static void ReadToken(ref Utf8JsonReader reader, JsonTokenType tokenType, bool readToken)
        {
            if (reader.TokenType != tokenType)
                throw new JsonException($"Unexpected token: Expected {tokenType} but got {reader.TokenType}!");
            if (!readToken) return;
            if (!reader.Read()) throw new JsonException("Unexpected end of sequence!");
        }
    }
}