
using System.Text.RegularExpressions;
namespace RegexIntegrated;

public static class RegIn
{
    public static string AnyChar(this string source)
    {
        return source + ".";
    }

    public static string AllowedChars(this string source, params char[] chars)
    {
        string? result = "[" + string.Concat(chars) + "]";
 
        return source + result;
    }
}