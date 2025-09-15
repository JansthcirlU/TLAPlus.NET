using TLAPlus.NET.Modules;

namespace TLAPLus.NET.Tests.Seeders.Identifier;

public class WhitespaceStringData : TheoryData<string>
{
    public WhitespaceStringData()
    {
        foreach (char whitespaceCharacter in TLAPlus.NET.Identifier.Forbidden.WhitespaceCharacters)
        {
            Add(whitespaceCharacter.ToString());
        }
    }
}
