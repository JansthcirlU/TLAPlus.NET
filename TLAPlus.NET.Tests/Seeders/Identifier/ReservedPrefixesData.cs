namespace TLAPlus.NET.Tests.Seeders.Identifier;

public class ReservedPrefixesData : TheoryData<string, string>
{
    public ReservedPrefixesData()
    {
        foreach (string reservedPrefix in NET.Identifier.Forbidden.ReservedPrefixes)
        {
            Add(reservedPrefix, $"{reservedPrefix}{Guid.NewGuid()}");
        }
    }
}