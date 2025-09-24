namespace TLAPlus.NET.Modules;

public record Module
{
    public Name Name { get; }

    public Module(string name)
    {
        Name = name;
    }
}
