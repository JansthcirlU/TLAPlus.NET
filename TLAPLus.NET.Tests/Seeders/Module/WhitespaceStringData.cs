using TLAPlus.NET.Modules;

namespace TLAPLus.NET.Tests.Seeders.Module;

public class WhitespaceStringData : TheoryData<string>
{
    public WhitespaceStringData()
    {
        foreach (char whitespaceCharacter in ModuleName.Forbidden.WhitespaceCharacters)
        {
            Add(whitespaceCharacter.ToString());
        }
    }
}
