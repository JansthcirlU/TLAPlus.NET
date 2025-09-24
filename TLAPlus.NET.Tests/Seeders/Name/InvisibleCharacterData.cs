namespace TLAPlus.NET.Tests.Seeders.Name;

public class InvisibleCharacterData : TheoryData<string>
{
    public InvisibleCharacterData()
    {
        foreach (char invisibleCharacter in NET.Name.Forbidden.InvisibleCharacters)
        {
            Add(invisibleCharacter.ToString());
        }
    }
}
