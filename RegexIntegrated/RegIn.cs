
using System.Text.RegularExpressions;
namespace RegexIntegrated;

public static class RegIn
{
    public static string AnyChar(this string source)
        => source + ".";

    public static string AnyCharAround(this string source, string pattern) 
        => AnyChar(source) + pattern + AnyChar(source);
    
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

    public static string Optional(this string source, string optionalPattern)
        => Grouping(source, optionalPattern).Optional();

    public static string Grouping(this string source, string pattern)
    {
        string result = "(" + pattern + ")";
        
        return source + result;
    }

    public static string Star(this string source) => source + "*";

    public static string Star(this string source, string pattern)
        => Grouping(source, pattern).Star();

    public static string Many(this string source)
        => source + "+";

    public static string Many(this string source, string pattern)
        => Grouping(source, pattern).Many();

    public static string Range(this string source, uint min, uint? max = null)
    {
        if (max == null)
            return source + "{" + min + ",}";
        return source + "{" + min + "," + max + "}";
    }
    
    public static string Range(this string source, string pattern, uint min, uint? max = null)
        => Grouping(source, pattern).Range(min, max);
    
    public static string Repeat(this string source, uint count)
        => source + "{" + count + "}";

    public static string Repeat(this string source, string pattern, uint count)
        => Grouping(source, pattern).Repeat(count);

    public static string StartWith(this string source)
        => "^" + source;

    public static string StartWith(this string source, string pattern)
        => pattern.StartWith() + source;
}