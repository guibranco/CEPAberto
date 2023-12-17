namespace CEPAberto.Tests;

public class CEPAbertoClientTest
{
    private const string Token = "97bd98aa2ab0bab41140a06a7f7742a4";

    private readonly CEPAbertoClient _client = new(Token);

    [Fact]
    public void TestSearchCep()
    {
        // Arrange

        // Act
        var result = _client.GetData("40010000");

        // Assert
        result.Success.Should().BeTrue();
        result.Altitude.Should().Be(7);
        result.PostalCode.Should().Be("40010000");
        result.Latitude.Should().Be("-12.967192");
        result.Longitude.Should().Be("-38.5101976");
        result.Street.Should().Be("Avenida da França");
        result.Neighborhood.Should().Be("Comércio");
        result.City.AreaCode.Should().Be(71);
        result.City.FiscalCode.Should().Be(2927408);
        result.City.Name.Should().Be("Salvador");
        result.State.Initials.Should().Be("BA");
    }

    [Fact]
    public void TestSearchNearest()
    {
        // Arrange

        // Act
        var result = _client.GetData("-20.55", "-43.63");

        // Assert
        result.Success.Should().BeTrue();
        result.Altitude.Should().Be(1072.4);
        result.PostalCode.Should().Be("36420000");
        result.Latitude.Should().Be("-20.5236387");
        result.Longitude.Should().Be("-43.691412");
        result.Street.Should().BeNull();
        result.Neighborhood.Should().BeNull();
        result.City.AreaCode.Should().Be(31);
        result.City.FiscalCode.Should().Be(3145901);
        result.City.Name.Should().Be("Ouro Branco");
        result.State.Initials.Should().Be("MG");
    }

    [Fact]
    public void TestSearchFullAddress()
    {
        // Arrange

        // Act
        var result = _client.GetData("SP", "Ubatuba", string.Empty, string.Empty);

        // Assert
        result.Success.Should().BeTrue();
        result.Altitude.Should().Be(4.8);
        result.PostalCode.Should().Be("11680000");
        result.Latitude.Should().Be("-23.4336578");
        result.Longitude.Should().Be("-45.0838481");
        result.Street.Should().BeNull();
        result.Neighborhood.Should().BeNull();
        result.City.AreaCode.Should().Be(12);
        result.City.FiscalCode.Should().Be(3555406);
        result.City.Name.Should().Be("Ubatuba");
        result.State.Initials.Should().Be("SP");
    }

    [Fact]
    public void TestSearchCities()
    {
        // Arrange

        // Act
        var result = _client.GetCities("AM");

        // Assert
        result.Success.Should().BeTrue();
        result.Cities.Should().NotBeEmpty();
        result.Cities.Should().HaveCount(62);
        result.Cities.Should().Contain(x => x.Name == "Manaus");
        result.Cities.First().Name.Should().Be("Agrovila São Sebastião do Caburi (Parintins)");
    }

    [Fact]
    public void TestUpdate()
    {
        // Arrange
        var postalCodeList = new[] { "03177010", "36420000" };

        // Act
        var result = _client.Update(postalCodeList);

        // Assert
        result.Success.Should().BeTrue();
    }

    [Fact]
    public void TestUpdateWrongData()
    {
        // Arrange
        var postalCodeList = new[] { "03177010", "0012" };

        // Act
        var result = _client.Update(postalCodeList);

        // Assert
        result.Success.Should().BeFalse();
    }
}
