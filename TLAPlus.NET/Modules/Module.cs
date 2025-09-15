namespace TLAPlus.NET.Modules;

public record Module
{
    public ModuleName Name { get; }

    public Module(string name)
    {
        Name = name;
    }
}
