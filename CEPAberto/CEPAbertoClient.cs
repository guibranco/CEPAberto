namespace CEPAberto
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Transport;
    using Utils;
    using ValueObject;

    public sealed class CEPAbertoClient : ICEPAbertoClient
    {
        #region Private fields

        /// <summary>
        /// The service
        /// </summary>
        private readonly ServiceFactory _service;

        /// <summary>
        /// The token
        /// </summary>
        private readonly String _token;

        /// <summary>
        /// The configure await
        /// </summary>
        private readonly Boolean _configureAwait;

        #endregion

        #region ~Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="CEPAbertoClient"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="configureAwait">if set to <c>true</c> [configure await].</param>
        public CEPAbertoClient(String token, Boolean configureAwait = true)
        {
            _token = token;
            _configureAwait = configureAwait;
            _service = new ServiceFactory(_configureAwait);
        }

        #endregion

        #region Implementation of ICEPAbertoClient

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="postalCode">The postal code.</param>
        /// <returns></returns>
        public PostalCodeData GetData(String postalCode)
        {
            return GetDataAsync(postalCode, CancellationToken.None).Result;
        }

        /// <summary>
        /// Gets the data asynchronous.
        /// </summary>
        /// <param name="postalCode">The postal code.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns></returns>
        public async Task<PostalCodeData> GetDataAsync(String postalCode, CancellationToken token)
        {
            var data = new PostalCodeRequest
            {
                Token = _token,
                PostalCode = postalCode
            };
            var result = await _service.Get<PostalCodeData, PostalCodeRequest>(data, token).ConfigureAwait(_configureAwait);
            if (!String.IsNullOrEmpty(result.PostalCode))
                result.Success = true;
            return result;
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <returns></returns>
        public PostalCodeData GetData(String latitude, String longitude)
        {
            return GetDataAsync(latitude, longitude, CancellationToken.None).Result;
        }

        /// <summary>
        /// Gets the data asynchronous.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns></returns>
        public async Task<PostalCodeData> GetDataAsync(String latitude, String longitude, CancellationToken token)
        {
            var data = new NearestRequest
            {
                Token = _token,
                Latitude = latitude,
                Longitude = longitude
            };
            var result = await _service.Get<PostalCodeData, NearestRequest>(data, token).ConfigureAwait(_configureAwait);
            if (!String.IsNullOrEmpty(result.PostalCode))
                result.Success = true;
            return result;
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="stateInitials">The state initials.</param>
        /// <param name="city">The city.</param>
        /// <param name="neighborhood">The neighborhood.</param>
        /// <param name="street">The street.</param>
        /// <returns></returns>
        public PostalCodeData GetData(String stateInitials, String city, String neighborhood, String street)
        {
            return GetDataAsync(stateInitials, city, neighborhood, street, CancellationToken.None).Result;
        }

        /// <summary>
        /// Gets the data asynchronous.
        /// </summary>
        /// <param name="stateInitials">The state initials.</param>
        /// <param name="city">The city.</param>
        /// <param name="neighborhood">The neighborhood.</param>
        /// <param name="street">The street.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns></returns>
        public async Task<PostalCodeData> GetDataAsync(String stateInitials, String city, String neighborhood, String street, CancellationToken token)
        {
            var data = new AddressRequest
            {
                Token = _token,
                StateInitials = stateInitials,
                City = city,
                Neighborhood = neighborhood,
                Street = street
            };
            var result = await _service.Get<PostalCodeData, AddressRequest>(data, token).ConfigureAwait(_configureAwait);
            if (!String.IsNullOrEmpty(result.PostalCode))
                result.Success = true;
            return result;
        }

        /// <summary>
        /// Gets the cities.
        /// </summary>
        /// <param name="stateInitials">The state initials.</param>
        /// <returns></returns>
        public CitiesData GetCities(String stateInitials)
        {
            return GetCitiesAsync(stateInitials, CancellationToken.None).Result;
        }

        /// <summary>
        /// Gets the cities asynchronous.
        /// </summary>
        /// <param name="stateInitials">The state initials.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns></returns>
        public async Task<CitiesData> GetCitiesAsync(String stateInitials, CancellationToken token)
        {
            var data = new CitiesRequest
            {
                Token = _token,
                StateInitials = stateInitials,

            };
            var results = await _service.Get<City[], CitiesRequest>(data, token).ConfigureAwait(_configureAwait);
            return new CitiesData
            {
                Cities = results,
                StateInitials = stateInitials,
                Success = results.Any()
            };
        }

        #endregion
    }
}

