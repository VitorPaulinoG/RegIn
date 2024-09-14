
using System.Text.RegularExpressions;
namespace RegexIntegrated;

public static class RegIn
{
    public static string AnyChar(this string source)
        => source + ".";
    
    public static string AllowedChars(this string source, params char[] chars)
    {
        string? result = "[" + string.Concat(chars) + "]";
 
        return source + result;
    }

    public static string ForbiddenChars(this string source, params char[] chars)
    {
        string? result = "[^" + string.Concat(chars) + "]";
        
        return source + result;
    }

    public static string Optional(this string source) => source + "?";

    // public static string Optional(this string source, string optionalGroup) 
    
    
}