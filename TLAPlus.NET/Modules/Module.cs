namespace TLAPlus.NET.Modules;

public record Module
{
    public Identifier Name { get; }

    public Module(string name)
    {
        Name = name;
    }
}
