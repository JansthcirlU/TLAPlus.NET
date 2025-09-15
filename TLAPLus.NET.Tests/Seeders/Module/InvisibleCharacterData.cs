using TLAPlus.NET.Modules;

namespace TLAPLus.NET.Tests.Seeders.Module;

public class InvisibleCharacterData : TheoryData<string>
{
    public InvisibleCharacterData()
    {
        foreach (char invisibleCharacter in ModuleName.Forbidden.InvisibleCharacters)
        {
            Add(invisibleCharacter.ToString());
        }
    }
}