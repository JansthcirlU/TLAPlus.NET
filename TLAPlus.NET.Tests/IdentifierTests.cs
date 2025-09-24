using TLAPlus.NET.Tests.Seeders.Identifier;

namespace TLAPlus.NET.Tests;

public class IdentifierTests
{
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
}
