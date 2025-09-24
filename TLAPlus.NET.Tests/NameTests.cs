using TLAPlus.NET.Tests.Seeders.Name;

namespace TLAPlus.NET.Tests;

public class NameTests
{
    [Fact]
    public void Name_WhenNull_ShouldFail()
    {
        // Arrange
        Action<string?> constructor = value => new Name(value!);
        Action<string?> implicitStringCast = value =>
        {
            Name name = value!;
        };
        string messageStart = "Name must not be null.";

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
    public void Name_WhenNameContainsWhitespace_ShouldFail(string value)
    {
        // Arrange
        Action constructor = () => new Name(value);
        Action implicitStringCast = () =>
        {
            Name name = value;
        };
        string messageStart = "Name must not contain any whitespace characters.";

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
    public void Name_WhenNameContainsInvisibleCharacter_ShouldFail(string value)
    {
        // Arrange
        Action constructor = () => new Name(value);
        Action implicitStringCast = () =>
        {
            Name name = value;
        };
        string messageStart = "Name must not contain any invisible characters.";

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
    public void Name_WhenNameContainsNewline_ShouldFail(string value)
    {
        // Arrange
        Action constructor = () => new Name(value);
        Action implicitStringCast = () =>
        {
            Name name = value;
        };
        string messageStart = "Name must not contain any newlines.";

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
    public void Name_WhenNameStartsWithReservedPrefix_ShouldFail(string prefix, string value)
    {
        // Arrange
        Action constructor = () => new Name(value);
        Action implicitStringCast = () =>
        {
            Name name = value;
        };
        string messageStart = $"Name must not start with a reserved prefix: {prefix}";

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
    [ClassData(typeof(InvalidNamesData))]
    public void Name_WhenDoesNotContainLetter_ShouldFail(string value)
    {
        // Arrange
        Action constructor = () => new Name(value);
        Action implicitStringCast = () =>
        {
            Name name = value;
        };
        string messageStart = "Name must contain at least one letter.";

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
    public void Name_WhenContainsAlphanumericalCharactersOrUnderscores_ShouldSucceed(string lowerWithUnderscores, string upperWithUnderscores)
    {
        // Act
        Name lowerConstructor = new(lowerWithUnderscores);
        Name upperConstructor = new(upperWithUnderscores);
        Name lowerImplicit = lowerWithUnderscores;
        Name upperImplicit = upperWithUnderscores;

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
