using TLAPlus.NET.Modules;

namespace TLAPLus.NET.Tests.Seeders.Module;

public class ReservedWordsData : TheoryData<string>
{
    public ReservedWordsData()
    {
        foreach (string reservedWord in ModuleName.Forbidden.ReservedWords)
        {
            Add(reservedWord.ToString());
        }
    }
}