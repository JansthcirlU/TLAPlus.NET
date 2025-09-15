using TLAPlus.NET.Modules;

namespace TLAPLus.NET.Tests.Seeders.Module;

public class NewlineStringData : TheoryData<string>
{
    public NewlineStringData()
    {
        foreach (string newlineString in ModuleName.Forbidden.NewlineSequences)
        {
            Add(newlineString);
        }
    }
}