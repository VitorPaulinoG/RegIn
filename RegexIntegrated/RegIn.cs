﻿
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
}