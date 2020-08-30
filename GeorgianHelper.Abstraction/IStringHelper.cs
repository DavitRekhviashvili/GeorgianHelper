using System;

namespace GeorgianHelper.Abstraction
{
    public interface IStringHelper
    {
        string GeoUnicodeToLat(string text);
        string GetNumberName(long number, string separator = "");
    }
}
