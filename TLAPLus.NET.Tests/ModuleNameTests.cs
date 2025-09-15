using TLAPlus.NET.Modules;
using TLAPLus.NET.Tests.Seeders.Module;

namespace TLAPLus.NET.Tests;

public class ModuleNameTests
{
    [Fact]
    public void ModuleName_WhenNull_ShouldFail()
    {
        // Arrange & Act
        ArgumentException ex = Assert.Throws<ArgumentException>(
            () => new ModuleName(null!)
        );

        // Assert
        Assert.NotNull(ex);
        Assert.StartsWith("Module name must not be null.", ex.Message);
    }

    [Fact]
    public void ModuleName_ImplicitStringCast_WhenNull_ShouldFail()
    {
        // Arrange & Act
        ArgumentException ex = Assert.Throws<ArgumentException>(
            () =>
            {
                string s = new ModuleName(null!);
            }
        );

        // Assert
        Assert.NotNull(ex);
        Assert.StartsWith("Module name must not be null.", ex.Message);
    }

    [Theory]
    [ClassData(typeof(WhitespaceStringData))]
    public void ModuleName_WhenNameIsNullOrWhitespace_ShouldFail(string? name)
    {
        // Arrange & Act
        ArgumentException ex = Assert.Throws<ArgumentException>(
            () => new ModuleName(name!)
        );

        // Assert
        Assert.NotNull(ex);
        Assert.StartsWith("Module name must not contain any whitespace characters.", ex.Message);
    }

    [Theory]
    [ClassData(typeof(WhitespaceStringData))]
    public void ModuleName_ImplicitStringCast_WhenNameIsNullOrWhitespace_ShouldFail(string? name)
    {
        // Arrange & Act
        ArgumentException ex = Assert.Throws<ArgumentException>(
            () =>
            {
                string s = new ModuleName(name!);
            }
        );

        // Assert
        Assert.NotNull(ex);
        Assert.StartsWith("Module name must not contain any whitespace characters.", ex.Message);
    }

    [Theory]
    [ClassData(typeof(InvisibleCharacterData))]
    public void ModuleName_WhenNameContainsInvisibleCharacter_ShouldFail(string? name)
    {
        // Arrange & Act
        ArgumentException ex = Assert.Throws<ArgumentException>(
            () => new ModuleName(name!)
        );

        // Assert
        Assert.NotNull(ex);
        Assert.StartsWith("Module name must not contain any invisible characters.", ex.Message);
    }

    [Theory]
    [ClassData(typeof(InvisibleCharacterData))]
    public void ModuleName_ImplicitStringCast_WhenNameContainsInvisibleCharacter_ShouldFail(string? name)
    {
        // Arrange & Act
        ArgumentException ex = Assert.Throws<ArgumentException>(
            () => new ModuleName(name!)
        );

        // Assert
        Assert.NotNull(ex);
        Assert.StartsWith("Module name must not contain any invisible characters.", ex.Message);
    }

    [Theory]
    [ClassData(typeof(NewlineStringData))]
    public void ModuleName_WhenNameContainsNewline_ShouldFail(string? name)
    {
        // Arrange & Act
        ArgumentException ex = Assert.Throws<ArgumentException>(
            () =>
            {
                string s = new ModuleName(name!);
            }
        );

        // Assert
        Assert.NotNull(ex);
        Assert.StartsWith("Module name must not contain any newlines.", ex.Message);
    }

    [Theory]
    [ClassData(typeof(NewlineStringData))]
    public void ModuleName_ImplicitStringCast_WhenNameContainsNewline_ShouldFail(string? name)
    {
        // Arrange & Act
        ArgumentException ex = Assert.Throws<ArgumentException>(
            () =>
            {
                string s = new ModuleName(name!);
            }
        );

        // Assert
        Assert.NotNull(ex);
        Assert.StartsWith("Module name must not contain any newlines.", ex.Message);
    }
}
