namespace TLAPLus.NET.Tests.Seeders.Module;

public class GuidWithUnderscoresData : TheoryData<string, string>
{
    public GuidWithUnderscoresData()
    {
        foreach (int i in Enumerable.Range(0, 20))
        {
            Guid guid = Guid.NewGuid();
            string guidWithUnderscores = guid.ToString("N").Replace('-', '_');
            string guidWithUnderscoresToUpper = guidWithUnderscores.ToUpperInvariant();
            Add(guidWithUnderscores, guidWithUnderscoresToUpper);
        }
    }
}