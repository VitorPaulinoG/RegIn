
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

    private static string Optional(this string source) => source + "?";

    public static string Optional(this string source, string optionalPattern)
        => Grouping(source, optionalPattern).Optional();

    public static string Grouping(this string source, string pattern)
    {
        string result = "(" + pattern + ")";
        
        return source + result;
    }

    private static string Star(this string source) => source + "*";

    public static string Star(this string source, string pattern)
        => Grouping(source, pattern).Star();

    private static string Many(this string source)
        => source + "+";

    public static string Many(this string source, string pattern)
        => Grouping(source, pattern).Many();

    private static string Range(this string source, uint min, uint? max = null)
    {
        if (max == null)
            return source + "{" + min + ",}";
        return source + "{" + min + "," + max + "}";
    }
    
    public static string Range(this string source, string pattern, uint min, uint? max = null)
        => Grouping(source, pattern).Range(min, max);
    
    private static string Repeat(this string source, uint count)
        => source + "{" + count + "}";

    public static string Repeat(this string source, string pattern, uint count)
        => Grouping(source, pattern).Repeat(count);

    private static string Start(this string source)
        => "^" + source;

    public static string Start(this string source, string pattern)
        => pattern.Start() + source;
    
    private static string End(this string source)
        => source + "$";

    public static string End(this string source, string pattern)
        => source + pattern.End();

    private static string BorderStart(this string source)
        => @"\b" + source;

    public static string BorderStart(this string source, string pattern)
        => Grouping(source, pattern).BorderStart();

    private static string BorderEnd(this string source)
        => source + @"\b";

    public static string BorderEnd(this string source, string pattern)
        => Grouping(source, pattern).BorderEnd();

    private static string BorderAround(this string source, string pattern)
        => Grouping(source, pattern).BorderStart().BorderEnd();

    private static string Escape(this string source)
        => source + @"\";
    public static string Escape(this string source, char character)
        => source.Escape() + character.ToString();

    public static string ExactPhrase(this string source, string phrase)
        => source + Regex.Escape(phrase);

    public static string Or(this string source, string firstPattern, string secondPattern)
    {
        string result = firstPattern + "|" + secondPattern;
        return Grouping(source, result);
    }

    public static string BackReference(this string source, byte reference)
        => source + $@"\{reference}";
}