using TLAPlus.NET.Modules;

namespace TLAPLus.NET.Tests.Seeders.Module;

public class ReservedPrefixesData : TheoryData<string, string>
{
    public ReservedPrefixesData()
    {
        foreach (string reservedPrefix in ModuleName.Forbidden.ReservedPrefixes)
        {
            Add(reservedPrefix, $"{reservedPrefix}{Guid.NewGuid()}");
        }
    }
}