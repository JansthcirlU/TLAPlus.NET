namespace TLAPlus.NET.Tests.Seeders.Identifier;

public class NewlineStringData : TheoryData<string>
{
    public NewlineStringData()
    {
        foreach (string newlineString in NET.Identifier.Forbidden.NewlineSequences)
        {
            Add(newlineString);
        }
    }
}
