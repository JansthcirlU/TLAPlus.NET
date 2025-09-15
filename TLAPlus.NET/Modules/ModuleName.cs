using System.Buffers;
using System.Collections.Immutable;

namespace TLAPlus.NET.Modules;

public record ModuleName
{
    private readonly string _value;

    private static readonly SearchValues<char> WhitespaceCharacters = SearchValues.Create(Forbidden.WhitespaceCharacters.AsSpan());
    private static readonly SearchValues<char> InvisibleCharacters = SearchValues.Create(Forbidden.InvisibleCharacters.AsSpan());
    private static readonly SearchValues<string> NewlineSequences = SearchValues.Create(Forbidden.NewlineSequences.AsSpan(), StringComparison.OrdinalIgnoreCase);

    public ModuleName(string name)
    {
        if (name is null) throw new ArgumentException("Module name must not be null.", nameof(name));
        if (name.AsSpan().ContainsAny(NewlineSequences)) throw new ArgumentException("Module name must not contain any newlines.", nameof(name));
        if (name.AsSpan().ContainsAny(WhitespaceCharacters)) throw new ArgumentException("Module name must not contain any whitespace characters.", nameof(name));
        if (name.AsSpan().ContainsAny(InvisibleCharacters)) throw new ArgumentException("Module name must not contain any invisible characters.", nameof(name));

        _value = name;
    }

    public static implicit operator ModuleName(string name) => new(name);
    public static implicit operator string(ModuleName moduleName) => moduleName._value;

    public static class Forbidden
    {
        public static readonly ImmutableArray<char> WhitespaceCharacters = [
            '\t',     // CHARACTER TABULATION (TAB)
            '\u000B', // LINE TABULATION (VERTICAL TAB)
            '\u000C', // FORM FEED (FF)
            ' ',      // SPACE
            '\u00A0', // NO-BREAK SPACE
            '\u1680', // OGHAM SPACE MARK
            '\u2000', // EN QUAD
            '\u2001', // EM QUAD
            '\u2002', // EN SPACE
            '\u2003', // EM SPACE
            '\u2004', // THREE-PER-EM SPACE
            '\u2005', // FOUR-PER-EM SPACE
            '\u2006', // SIX-PER-EM SPACE
            '\u2007', // FIGURE SPACE
            '\u2008', // PUNCTUATION SPACE
            '\u2009', // THIN SPACE
            '\u200A', // HAIR SPACE
            '\u202F', // NARROW NO-BREAK SPACE
            '\u205F', // MEDIUM MATHEMATICAL SPACE
            '\u3000'  // IDEOGRAPHIC SPACE
        ];

        public static readonly ImmutableArray<char> InvisibleCharacters = [
            '\u200B', // ZERO WIDTH SPACE
            '\u200C', // ZERO WIDTH NON-JOINER
            '\u200D', // ZERO WIDTH JOINER
            '\u2060', // WORD JOINER
            '\uFEFF', // ZERO WIDTH NO-BREAK SPACE (BOM)
            '\u00AD', // SOFT HYPHEN
            '\u034F', // COMBINING GRAPHEME JOINER
            '\u200E', // LEFT-TO-RIGHT MARK
            '\u200F', // RIGHT-TO-LEFT MARK
            '\u202A', // LEFT-TO-RIGHT EMBEDDING
            '\u202B', // RIGHT-TO-LEFT EMBEDDING
            '\u202C', // POP DIRECTIONAL FORMATTING
            '\u202D', // LEFT-TO-RIGHT OVERRIDE
            '\u202E', // RIGHT-TO-LEFT OVERRIDE
            '\u2066', // LEFT-TO-RIGHT ISOLATE
            '\u2067', // RIGHT-TO-LEFT ISOLATE
            '\u2068', // FIRST STRONG ISOLATE
            '\u2069', // POP DIRECTIONAL ISOLATE
            '\u061C', // ARABIC LETTER MARK
            '\u180E', // MONGOLIAN VOWEL SEPARATOR
            '\u17B4', // KHMER VOWEL INHERENT AQ
            '\u17B5', // KHMER VOWEL INHERENT AA
            '\u1160', // HANGUL JUNGSEONG FILLER
            '\u3164', // HANGUL FILLER
            '\uFFA0'  // HALFWIDTH HANGUL FILLER
        ];

        public static readonly ImmutableArray<string> NewlineSequences = [
            "\n",     // LINE FEED (LF)
            "\r",     // CARRIAGE RETURN (CR)
            "\u0085", // NEXT LINE (NEL)
            "\u2028", // LINE SEPARATOR
            "\u2029", // PARAGRAPH SEPARATOR
            "\r\n",   // CRLF - Windows standard
            "\n\r",   // LFCR - rare but possible
            "\r\u0085", // CR + NEL
            "\n\u2028", // LF + LINE SEPARATOR
            "\u2028\u2029"  // LINE SEPARATOR + PARAGRAPH SEPARATOR
        ];
    }
}