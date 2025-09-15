namespace TLAPlus.NET.Tests.Seeders.Identifier;

public class ReservedWordsData : TheoryData<string>
{
    public ReservedWordsData()
    {
        foreach (string reservedWord in NET.Identifier.Forbidden.ReservedWords)
        {
            Add(reservedWord);
        }
    }
}
