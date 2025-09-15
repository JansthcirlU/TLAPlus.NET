namespace TLAPlus.NET.Tests.Seeders.Identifier;

public class WhitespaceStringData : TheoryData<string>
{
    public WhitespaceStringData()
    {
        foreach (char whitespaceCharacter in NET.Identifier.Forbidden.WhitespaceCharacters)
        {
            Add(whitespaceCharacter.ToString());
        }
    }
}
