using System.Text;

namespace TLAPlus.NET.Tests.Seeders.Identifier;

public class InvalidIdentifiersData : TheoryData<string>
{
    const string NonLetterIdentifierCharacters = "0123456789_";

    public InvalidIdentifiersData()
    {
        foreach (int _ in Enumerable.Range(0, 20))
        {
            string prefix = PickRandom((byte)Random.Shared.Next(20), NonLetterIdentifierCharacters);
            string suffix = PickRandom((byte)Random.Shared.Next(20), NonLetterIdentifierCharacters);
            Add(prefix + suffix);
        }
    }
    
    public static string PickRandom(byte count, string from)
    {
        if (count == 0)
        {
            return "";
        }

        StringBuilder sb = new();
        for (int i = 0; i < count; i++)
        {
            sb.Append(from[Random.Shared.Next(from.Length)]);
        }
        return sb.ToString();
    }
}
