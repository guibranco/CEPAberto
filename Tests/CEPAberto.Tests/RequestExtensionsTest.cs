using CEPAberto.Utils;

namespace CEPAberto.Tests;

public class RequestHelpersTest
{
    [Fact]
    public void RequestEndPoint()
    {
        // Arrange
        const string expected = "cep?cep=12345678";
        var postalCode = new PostalCodeRequest { PostalCode = "12345678" };

        // Act
        var result = postalCode.GetRequestEndPoint();

        // Assert
        result.Should().Be(expected, "The endpoint was not resolves as expected");
    }

    [Fact]
    public void RequestEndPointWithMultipleParameters()
    {
        // Arrange
        const string expected = "nearest?lat=10&lng=-20";
        var nearest = new NearestRequest { Latitude = "10", Longitude = "-20" };

        // Act
        var result = nearest.GetRequestEndPoint();

        // Assert
        result.Should().Be(expected, "The endpoint was not resolves as expected");
    }

    [Fact]
    public void RequestEndPointWithNullValues()
    {
        // Arrange
        var address = new AddressRequest { StateInitials = "SP", City = "São Paulo" };

        // Act
        var result = address.GetRequestAdditionalParameter(ActionMethod.GET);

        // Assert
        result.Should().Be(string.Empty, "The endpoint was not resolves as expected");
    }

    [Fact]
    public void RequestAdditionalParameterAsQueryString()
    {
        // Arrage
        const string expected = "&bairro=Centro&logradouro=Se";
        var address = new AddressRequest
        {
            StateInitials = "SP",
            City = "São Paulo",
            Neighborhood = "Centro",
            Street = "Se"
        };

        // Act
        var result = address.GetRequestAdditionalParameter(ActionMethod.GET).Replace("/?", "&");

        // Assert
        result.Should().Be(expected, "The additional parameter should be query string");
    }

    [Fact]
    public void ValidateToKeyValue_MetaTokenIsNull_ReturnsEmptyDictionary()
    {
        // Arrange

        // Act
        var result = ((object)null).ToKeyValue();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Dictionary<string, string>>();
        result.Count.Should().Be(0);
    }
}
