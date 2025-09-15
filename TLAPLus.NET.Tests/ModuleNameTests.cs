using TLAPlus.NET.Modules;
using TLAPLus.NET.Tests.Seeders.Module;

namespace TLAPLus.NET.Tests;

public class ModuleNameTests
{
    [Fact]
    public void ModuleName_WhenNull_ShouldFail()
    {
        // Arrange
        Action<string?> constructor = name => new ModuleName(name!);
        Action<string?> implicitStringCast = name =>
        {
            ModuleName moduleName = name!;
        };
        string messageStart = "Module name must not be null.";

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
    public void ModuleName_WhenNameContainsWhitespace_ShouldFail(string name)
    {
        // Arrange
        Action constructor = () => new ModuleName(name);
        Action implicitStringCast = () =>
        {
            ModuleName moduleName = name;
        };
        string messageStart = "Module name must not contain any whitespace characters.";

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
    public void ModuleName_WhenNameContainsInvisibleCharacter_ShouldFail(string name)
    {
        // Arrange
        Action constructor = () => new ModuleName(name);
        Action implicitStringCast = () =>
        {
            ModuleName moduleName = name;
        };
        string messageStart = "Module name must not contain any invisible characters.";

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
    public void ModuleName_WhenNameContainsNewline_ShouldFail(string name)
    {
        // Arrange
        Action constructor = () => new ModuleName(name);
        Action implicitStringCast = () =>
        {
            ModuleName moduleName = name;
        };
        string messageStart = "Module name must not contain any newlines.";

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
    public void ModuleName_WhenNameIsReservedWord_ShouldFail(string name)
    {
        // Arrange
        Action constructor = () => new ModuleName(name);
        Action implicitStringCast = () =>
        {
            ModuleName moduleName = name;
        };
        string messageStart = $"Module name must not be a reserved word: {name}";

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
    public void ModuleName_WhenNameStartsWithReservedPrefix_ShouldFail(string prefix, string name)
    {
        // Arrange
        Action constructor = () => new ModuleName(name);
        Action implicitStringCast = () =>
        {
            ModuleName moduleName = name;
        };
        string messageStart = $"Module name must not start with a reserved prefix: {prefix}";

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
    public void ModuleName_WhenContainsAlphanumericalCharactersOrUnderscores_ShouldSucceed(string lowerWithUnderscores, string upperWithUnderscores)
    {
        // Act
        ModuleName lowerConstructor = new(lowerWithUnderscores);
        ModuleName upperConstructor = new(upperWithUnderscores);
        ModuleName lowerImplicit = lowerWithUnderscores;
        ModuleName upperImplicit = upperWithUnderscores;

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
