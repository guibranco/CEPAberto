using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CEPAberto.Transport;
using CEPAberto.Utils;
using CEPAberto.ValueObject;

namespace CEPAberto;

/// <summary>
/// Class CEPAbertoClient. This class cannot be inherited. Implements the <see cref="CEPAberto.ICEPAbertoClient"/>
/// </summary>
/// <seealso cref="CEPAberto.ICEPAbertoClient"/>
public sealed class CEPAbertoClient : ICEPAbertoClient
{
    /// <summary>
    /// The service
    /// </summary>
    private readonly ServiceFactory _service;

    /// <summary>
    /// The token
    /// </summary>
    private readonly string _token;

    /// <summary>
    /// The configure await
    /// </summary>
    private readonly bool _configureAwait;

    /// <summary>
    /// Initializes a new instance of the <see cref="CEPAbertoClient"/> class.
    /// </summary>
    /// <param name="token">The token.</param>
    /// <param name="configureAwait">if set to <c>true</c> [configure await].</param>
    public CEPAbertoClient(string token, bool configureAwait = true)
    {
        _token = token;
        _configureAwait = configureAwait;
        _service = new ServiceFactory(_configureAwait);
    }

    /// <summary>
    /// Gets the data.
    /// </summary>
    /// <param name="postalCode">The postal code.</param>
    /// <returns>PostalCodeData.</returns>
    public PostalCodeData GetData(string postalCode)
    {
        return GetDataAsync(postalCode, CancellationToken.None).Result;
    }

    /// <summary>
    /// Gets the data.
    /// </summary>
    /// <param name="latitude">The latitude.</param>
    /// <param name="longitude">The longitude.</param>
    /// <returns>PostalCodeData.</returns>
    public PostalCodeData GetData(string latitude, string longitude)
    {
        return GetDataAsync(latitude, longitude, CancellationToken.None).Result;
    }

    /// <summary>
    /// Asynchronously retrieves postal code data based on the provided address parameters.
    /// </summary>
    /// <param name="postalCode">The postal code to search for.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
    /// <returns>A task that represents the asynchronous operation, containing the postal code data for the specified address.</returns>
    /// <remarks>
    /// This method constructs an address request using the provided parameters and sends it to a service to retrieve postal code information.
    /// The service call is made asynchronously, allowing for non-blocking execution.
    /// If a valid postal code is returned, the success property of the result is set to true.
    /// The method utilizes a cancellation token to allow for graceful cancellation of the request if necessary.
    /// </remarks>
    public async Task<PostalCodeData> GetDataAsync(
        string postalCode,
        CancellationToken cancellationToken
    )
    {
        var data = new PostalCodeRequest { Token = _token, PostalCode = postalCode };

        var result = await _service
            .Get<PostalCodeData, PostalCodeRequest>(data, cancellationToken)
            .ConfigureAwait(_configureAwait);

        if (!string.IsNullOrEmpty(result.PostalCode))
        {
            result.Success = true;
        }

        return result;
    }

    /// <summary>
    /// Gets the data asynchronous.
    /// </summary>
    /// <param name="latitude">The latitude.</param>
    /// <param name="longitude">The longitude.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>PostalCodeData.</returns>
    public async Task<PostalCodeData> GetDataAsync(
        string latitude,
        string longitude,
        CancellationToken cancellationToken
    )
    {
        var data = new NearestRequest
        {
            Token = _token,
            Latitude = latitude,
            Longitude = longitude,
        };

        var result = await _service
            .Get<PostalCodeData, NearestRequest>(data, cancellationToken)
            .ConfigureAwait(_configureAwait);

        if (!string.IsNullOrEmpty(result.PostalCode))
        {
            result.Success = true;
        }

        return result;
    }

    /// <summary>
    /// Gets the data.
    /// </summary>
    /// <param name="stateInitials">The state initials.</param>
    /// <param name="city">The city.</param>
    /// <param name="neighborhood">The neighborhood.</param>
    /// <param name="street">The street.</param>
    /// <returns>PostalCodeData.</returns>
    public PostalCodeData GetData(
        string stateInitials,
        string city,
        string neighborhood,
        string street
    )
    {
        return GetDataAsync(
            stateInitials,
            city,
            neighborhood,
            street,
            CancellationToken.None
        ).Result;
    }

    /// <summary>
    /// Gets the data asynchronous.
    /// </summary>
    /// <param name="stateInitials">The state initials.</param>
    /// <param name="city">The city.</param>
    /// <param name="neighborhood">The neighborhood.</param>
    /// <param name="street">The street.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>PostalCodeData.</returns>
    public async Task<PostalCodeData> GetDataAsync(
        string stateInitials,
        string city,
        string neighborhood,
        string street,
        CancellationToken cancellationToken
    )
    {
        var data = new AddressRequest
        {
            Token = _token,
            StateInitials = stateInitials,
            City = city,
            Neighborhood = neighborhood,
            Street = street,
        };

        var result = await _service
            .Get<PostalCodeData, AddressRequest>(data, cancellationToken)
            .ConfigureAwait(_configureAwait);

        if (!string.IsNullOrEmpty(result.PostalCode))
        {
            result.Success = true;
        }

        return result;
    }

    /// <summary>
    /// Gets the cities.
    /// </summary>
    /// <param name="stateInitials">The state initials.</param>
    /// <returns>CitiesData.</returns>
    public CitiesData GetCities(string stateInitials)
    {
        return GetCitiesAsync(stateInitials, CancellationToken.None).Result;
    }

    /// <summary>
    /// Asynchronously retrieves a list of cities for a specified state using its initials.
    /// </summary>
    /// <param name="stateInitials">The initials of the state for which to retrieve the cities.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="CitiesData"/> object with the retrieved cities and state information.</returns>
    /// <remarks>
    /// This method constructs a request to fetch city data based on the provided state initials.
    /// It utilizes an asynchronous service call to retrieve the data, ensuring that the operation does not block the calling thread.
    /// The results are wrapped in a <see cref="CitiesData"/> object, which includes the list of cities, the state initials,
    /// and a success flag indicating whether any cities were found.
    /// This method is particularly useful in applications that require dynamic city data based on user input or selections.
    /// </remarks>
    public async Task<CitiesData> GetCitiesAsync(
        string stateInitials,
        CancellationToken cancellationToken
    )
    {
        var data = new CitiesRequest { Token = _token, StateInitials = stateInitials };

        var results = await _service
            .Get<City[], CitiesRequest>(data, cancellationToken)
            .ConfigureAwait(_configureAwait);

        return new CitiesData
        {
            Cities = results,
            StateInitials = stateInitials,
            Success = results.Any(),
        };
    }

    /// <summary>
    /// Updates the specified postal code list.
    /// </summary>
    /// <param name="postalCodeList">The postal code list.</param>
    /// <returns>UpdateData.</returns>
    public UpdateData Update(string[] postalCodeList)
    {
        return UpdateAsync(postalCodeList, CancellationToken.None).Result;
    }

    /// <summary>
    /// Asynchronously updates data based on a list of postal codes.
    /// </summary>
    /// <param name="postalCodeList">An array of postal codes to be updated.</param>
    /// <param name="cancellationToken">A token that can be used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing an <see cref="UpdateData"/> object with the result of the update.</returns>
    /// <remarks>
    /// This method constructs an <see cref="UpdateRequest"/> object with a token and a comma-separated list of postal codes.
    /// It then sends this request to a service using the Post method.
    /// If the response contains an error, it returns an <see cref="UpdateData"/> object indicating failure, along with the error code and message.
    /// If the operation is successful, it returns an <see cref="UpdateData"/> object indicating success and includes the updated postal code list.
    /// This method is designed to be used in scenarios where postal code data needs to be updated asynchronously, allowing for responsive applications.
    /// </remarks>
    public async Task<UpdateData> UpdateAsync(
        string[] postalCodeList,
        CancellationToken cancellationToken
    )
    {
        var data = new UpdateRequest
        {
            Token = _token,
            PostalCodes = string.Join(",", postalCodeList),
        };

        var result = await _service
            .Post<UpdateResponse, UpdateRequest>(data, cancellationToken)
            .ConfigureAwait(_configureAwait);

        if (!string.IsNullOrWhiteSpace(result.Error))
        {
            return new UpdateData
            {
                Success = false,
                ErrorCode = result.Status,
                ErrorMessage = result.Error,
            };
        }

        return new UpdateData { Success = true, PostalCodeList = result.Content };
    }
}
