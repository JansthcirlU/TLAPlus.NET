using System.Collections.Immutable;

namespace TLAPlus.NET;

public record Identifier
{
    private readonly Name _name;

    public Identifier(Name name)
    {
        if (ReservedWords.Contains(name))
        {
            throw new ArgumentException($"Identifier must not be a reserved word: {name}.", nameof(name));
        }

        _name = name;
    }

    public static implicit operator Identifier(Name name) => new(name);
    public static implicit operator Name(Identifier identifier) => identifier._name;
    public static implicit operator string(Identifier identifier) => (Name)identifier;
    public static implicit operator Identifier(string value) => new((Name)value);

    public override string ToString() => (string)this;

    public static readonly ImmutableHashSet<string> ReservedWords = [
            "ASSUME",
            "ASSUMPTION",
            "AXIOM",
            "CASE",
            "CHOOSE",
            "CONSTANT",
            "CONSTANTS",
            "DOMAIN",
            "ELSE",
            "ENABLED",
            "EXCEPT",
            "EXTENDS",
            "IF",
            "IN",
            "INSTANCE",
            "LET",
            "LOCAL",
            "MODULE",
            "OTHER",
            "SF_",
            "SUBSET",
            "THEN",
            "THEOREM",
            "UNCHANGED",
            "UNION",
            "VARIABLE",
            "VARIABLES",
            "WF_",
            "WITH"
        ];
}
