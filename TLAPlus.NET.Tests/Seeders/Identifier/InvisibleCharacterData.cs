namespace TLAPlus.NET.Tests.Seeders.Identifier;

public class InvisibleCharacterData : TheoryData<string>
{
    public InvisibleCharacterData()
    {
        foreach (char invisibleCharacter in NET.Identifier.Forbidden.InvisibleCharacters)
        {
            Add(invisibleCharacter.ToString());
        }
    }
}
