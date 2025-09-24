namespace TLAPlus.NET.Tests.Seeders.Name;

public class ReservedPrefixesData : TheoryData<string, string>
{
    public ReservedPrefixesData()
    {
        foreach (string reservedPrefix in NET.Name.Forbidden.ReservedPrefixes)
        {
            Add(reservedPrefix, $"{reservedPrefix}{Guid.NewGuid()}");
        }
    }
}
