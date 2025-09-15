using TLAPlus.NET.Modules;

namespace TLAPlus.NET.Tests.Seeders.Identifier;

public class ReservedWordsData : TheoryData<string>
{
    public ReservedWordsData()
    {
        foreach (string reservedWord in TLAPlus.NET.Identifier.Forbidden.ReservedWords)
        {
            Add(reservedWord);
        }
    }
}
