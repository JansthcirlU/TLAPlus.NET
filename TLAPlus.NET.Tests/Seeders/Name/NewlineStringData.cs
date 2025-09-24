namespace TLAPlus.NET.Tests.Seeders.Name;

public class NewlineStringData : TheoryData<string>
{
    public NewlineStringData()
    {
        foreach (string newlineString in NET.Name.Forbidden.NewlineSequences)
        {
            Add(newlineString);
        }
    }
}
