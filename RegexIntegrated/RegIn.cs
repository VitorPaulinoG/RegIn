
using System.Text.RegularExpressions;
namespace RegexIntegrated;

public static class RegIn
{
    public static string AnyChar(this string source)
        => source + ".";

    public static string AnyCharStatic() => AnyChar(string.Empty);
    
    public static string AnyCharAround(this string source, string pattern) 
        => AnyChar(source) + pattern + AnyChar(source);
    
    public static string AnyCharAroundStatic(string pattern)
        => AnyCharAround(string.Empty, pattern);    
    
    public static string AllowedChars(this string source, params char[] chars)
    {
        string? result = "[" + string.Concat(chars) + "]";
 
        return source + result;
    }
    
    public static string AllowedCharsStatic(params char[] chars)
        => AllowedChars(string.Empty, chars);

    public static string ForbiddenChars(this string source, params char[] chars)
    {
        string? result = "[^" + string.Concat(chars) + "]";
        
        return source + result;
    }
    
    public static string ForbiddenCharsStatic(params char[] chars)
        => ForbiddenChars(string.Empty, chars);

    private static string Optional(this string source) => source + "?";
    
    public static string Optional(this string source, string optionalPattern)
        => Grouping(source, optionalPattern).Optional();
    
    public static string OptionalStatic (string optionalPattern)
        => Optional(string.Empty, optionalPattern);

    public static string NonGreedyOptional(this string source, string optionalPattern)
        => Optional(source, optionalPattern).Optional();
    public static string NonGreedyOptionalStatic(string optionalPattern)
        => NonGreedyOptional(string.Empty, optionalPattern);
    
    public static string Grouping(this string source, string pattern)
    {
        string result = "(" + pattern + ")";
        
        return source + result;
    }
    
    public static string GroupingStatic(string pattern)
        => Grouping(string.Empty, pattern);

    private static string Star(this string source) => source + "*";

    public static string Star(this string source, string pattern)
        => Grouping(source, pattern).Star();

    public static string StarStatic(string pattern)
        => Star(string.Empty, pattern);
    
    public static string NonGreedyStar(this string source, string pattern)
        => Star(source, pattern).Optional();
    
    public static string NonGreedyStarStatic(string pattern)
        => NonGreedyStar(string.Empty, pattern);

    private static string Many(this string source)
        => source + "+";

    public static string Many(this string source, string pattern)
        => Grouping(source, pattern).Many();

    public static string ManyStatic(string pattern)
        => Many(string.Empty, pattern);
    
    public static string NonGreedyMany(this string source, string pattern)
        => Many(source, pattern).Optional();

    public static string NonGreedyManyStatic(string pattern)
        => NonGreedyMany(string.Empty, pattern);
    
    private static string Range(this string source, uint min, uint? max = null)
    {
        if (max == null)
            return source + "{" + min + ",}";
        return source + "{" + min + "," + max + "}";
    }
    
    public static string Range(this string source, string pattern, uint min, uint? max = null)
        => Grouping(source, pattern).Range(min, max);

    public static string RangeStatic(string pattern, uint min, uint? max = null)
        => Range(string.Empty, pattern, min, max);

    public static string NonGreedyRange(this string source, string pattern, uint min, uint? max = null)
        => Range(source, pattern, min, max).Optional();
    
    public static string NonGreedyRangeStatic(this string pattern, uint min, uint? max = null)
        => NonGreedyRange(string.Empty, pattern, min, max);
    
    private static string Repeat(this string source, uint count)
        => source + "{" + count + "}";

    public static string Repeat(this string source, string pattern, uint count)
        => Grouping(source, pattern).Repeat(count);

    public static string RepeatStatic(string pattern, uint count)
        => Repeat(string.Empty, pattern, count);
    
    private static string Start(this string source)
        => "^" + source;

    public static string Start(this string source, string pattern)
        => pattern.Start() + source;
    
    public static string StartStatic(string pattern)
        => Start(string.Empty, pattern);
    
    private static string End(this string source)
        => source + "$";

    public static string End(this string source, string pattern)
        => source + pattern.End();

    public static string EndStatic(string pattern)
        => End(string.Empty, pattern);
    
    private static string BorderStart(this string source)
        => @"\b" + source;

    public static string BorderStart(this string source, string pattern)
        => Grouping(source, pattern).BorderStart();

    public static string BorderStartStatic(string pattern)
        => BorderStart(string.Empty, pattern);
    
    private static string BorderEnd(this string source)
        => source + @"\b";

    public static string BorderEnd(this string source, string pattern)
        => Grouping(source, pattern).BorderEnd();

    public static string BorderEndStatic(string pattern)
        => BorderEnd(string.Empty, pattern);
    
    public static string BorderAround(this string source, string pattern)
        => Grouping(source, pattern).BorderStart().BorderEnd();
    
    public static string BorderAroundStatic(string pattern)
        => BorderAround(string.Empty, pattern);
    
    private static string Escape(this string source)
        => source + @"\";
    public static string Escape(this string source, char character)
        => source.Escape() + character.ToString();
    
    public static string EscapeStatic (char character)
        => Escape(string.Empty, character);

    public static string ExactPhrase(this string source, string phrase)
        => source + Regex.Escape(phrase);
    
    public static string ExactPhraseStatic(string phrase)
        => ExactPhrase(string.Empty, phrase);

    public static string Or(this string source, string firstPattern, string secondPattern)
    {
        string result = firstPattern + "|" + secondPattern;
        return Grouping(source, result);
    }
    
    public static string OrStatic (string firstPattern, string secondPattern)
        => Or(string.Empty, firstPattern, secondPattern);

    public static string BackReference(this string source, byte reference)
        => source + $@"\{reference}";
}