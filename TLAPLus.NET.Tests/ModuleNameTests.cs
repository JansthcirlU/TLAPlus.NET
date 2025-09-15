using TLAPlus.NET;
using TLAPLus.NET.Tests.Seeders.Identifier;

namespace TLAPLus.NET.Tests;

public class IdentifierTests
{
    [Fact]
    public void Identifier_WhenNull_ShouldFail()
    {
        // Arrange
        Action<string?> constructor = name => new Identifier(name!);
        Action<string?> implicitStringCast = name =>
        {
            Identifier identifier = name!;
        };
        string messageStart = "Identifier must not be null.";

        // Act
        ArgumentException constructorEx = Assert.Throws<ArgumentException>(() => constructor(null!));
        ArgumentException implicitStringCastEx = Assert.Throws<ArgumentException>(() => implicitStringCast(null!));

        // Assert
        Assert.NotNull(constructorEx);
        Assert.StartsWith(messageStart, constructorEx.Message);
        Assert.NotNull(implicitStringCastEx);
        Assert.StartsWith(messageStart, implicitStringCastEx.Message);
    }

    [Theory]
    [ClassData(typeof(WhitespaceStringData))]
    public void Identifier_WhenNameContainsWhitespace_ShouldFail(string name)
    {
        // Arrange
        Action constructor = () => new Identifier(name);
        Action implicitStringCast = () =>
        {
            Identifier identifier = name;
        };
        string messageStart = "Identifier must not contain any whitespace characters.";

        // Act
        ArgumentException constructorEx = Assert.Throws<ArgumentException>(constructor);
        ArgumentException implicitStringCastEx = Assert.Throws<ArgumentException>(implicitStringCast);

        // Assert
        Assert.NotNull(constructorEx);
        Assert.StartsWith(messageStart, constructorEx.Message);
        Assert.NotNull(implicitStringCastEx);
        Assert.StartsWith(messageStart, implicitStringCastEx.Message);
    }

    [Theory]
    [ClassData(typeof(InvisibleCharacterData))]
    public void Identifier_WhenNameContainsInvisibleCharacter_ShouldFail(string name)
    {
        // Arrange
        Action constructor = () => new Identifier(name);
        Action implicitStringCast = () =>
        {
            Identifier identifier = name;
        };
        string messageStart = "Identifier must not contain any invisible characters.";

        // Act
        ArgumentException constructorEx = Assert.Throws<ArgumentException>(constructor);
        ArgumentException implicitStringCastEx = Assert.Throws<ArgumentException>(implicitStringCast);

        // Assert
        Assert.NotNull(constructorEx);
        Assert.StartsWith(messageStart, constructorEx.Message);
        Assert.NotNull(implicitStringCastEx);
        Assert.StartsWith(messageStart, implicitStringCastEx.Message);
    }

    [Theory]
    [ClassData(typeof(NewlineStringData))]
    public void Identifier_WhenNameContainsNewline_ShouldFail(string name)
    {
        // Arrange
        Action constructor = () => new Identifier(name);
        Action implicitStringCast = () =>
        {
            Identifier identifier = name;
        };
        string messageStart = "Identifier must not contain any newlines.";

        // Act
        ArgumentException constructorEx = Assert.Throws<ArgumentException>(constructor);
        ArgumentException implicitStringCastEx = Assert.Throws<ArgumentException>(implicitStringCast);

        // Assert
        Assert.NotNull(constructorEx);
        Assert.StartsWith(messageStart, constructorEx.Message);
        Assert.NotNull(implicitStringCastEx);
        Assert.StartsWith(messageStart, implicitStringCastEx.Message);
    }

    [Theory]
    [ClassData(typeof(ReservedWordsData))]
    public void Identifier_WhenNameIsReservedWord_ShouldFail(string name)
    {
        // Arrange
        Action constructor = () => new Identifier(name);
        Action implicitStringCast = () =>
        {
            Identifier identifier = name;
        };
        string messageStart = $"Identifier must not be a reserved word: {name}";

        // Act
        ArgumentException constructorEx = Assert.Throws<ArgumentException>(constructor);
        ArgumentException implicitStringCastEx = Assert.Throws<ArgumentException>(implicitStringCast);

        // Assert
        Assert.NotNull(constructorEx);
        Assert.StartsWith(messageStart, constructorEx.Message);
        Assert.NotNull(implicitStringCastEx);
        Assert.StartsWith(messageStart, implicitStringCastEx.Message);
    }

    [Theory]
    [ClassData(typeof(ReservedPrefixesData))]
    public void Identifier_WhenNameStartsWithReservedPrefix_ShouldFail(string prefix, string name)
    {
        // Arrange
        Action constructor = () => new Identifier(name);
        Action implicitStringCast = () =>
        {
            Identifier identifier = name;
        };
        string messageStart = $"Identifier must not start with a reserved prefix: {prefix}";

        // Act
        ArgumentException constructorEx = Assert.Throws<ArgumentException>(constructor);
        ArgumentException implicitStringCastEx = Assert.Throws<ArgumentException>(implicitStringCast);

        // Assert
        Assert.NotNull(constructorEx);
        Assert.StartsWith(messageStart, constructorEx.Message);
        Assert.NotNull(implicitStringCastEx);
        Assert.StartsWith(messageStart, implicitStringCastEx.Message);
    }

    [Theory]
    [ClassData(typeof(GuidWithUnderscoresData))]
    public void Identifier_WhenContainsAlphanumericalCharactersOrUnderscores_ShouldSucceed(string lowerWithUnderscores, string upperWithUnderscores)
    {
        // Act
        Identifier lowerConstructor = new(lowerWithUnderscores);
        Identifier upperConstructor = new(upperWithUnderscores);
        Identifier lowerImplicit = lowerWithUnderscores;
        Identifier upperImplicit = upperWithUnderscores;

        // Assert
        Assert.Equal(lowerWithUnderscores, (string)lowerConstructor);
        Assert.Equal(upperWithUnderscores, (string)upperConstructor);
        Assert.Equal(lowerWithUnderscores, (string)lowerImplicit);
        Assert.Equal(upperWithUnderscores, (string)upperImplicit);
        Assert.Equal(lowerWithUnderscores, lowerConstructor.ToString());
        Assert.Equal(upperWithUnderscores, upperConstructor.ToString());
        Assert.Equal(lowerWithUnderscores, lowerImplicit.ToString());
        Assert.Equal(upperWithUnderscores, upperImplicit.ToString());
    }
}
