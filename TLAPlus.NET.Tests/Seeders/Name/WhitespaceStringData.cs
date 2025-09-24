namespace TLAPlus.NET.Tests.Seeders.Name;

public class WhitespaceStringData : TheoryData<string>
{
    public WhitespaceStringData()
    {
        foreach (char whitespaceCharacter in NET.Name.Forbidden.WhitespaceCharacters)
        {
            Add(whitespaceCharacter.ToString());
        }
    }
}
