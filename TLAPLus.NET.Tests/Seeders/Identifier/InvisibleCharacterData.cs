namespace TLAPLus.NET.Tests.Seeders.Identifier;

public class InvisibleCharacterData : TheoryData<string>
{
    public InvisibleCharacterData()
    {
        foreach (char invisibleCharacter in TLAPlus.NET.Identifier.Forbidden.InvisibleCharacters)
        {
            Add(invisibleCharacter.ToString());
        }
    }
}