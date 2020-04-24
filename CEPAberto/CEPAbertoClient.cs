// ***********************************************************************
// Assembly         : CEPAberto
// Author           : Guilherme Branco Stracini
// Created          : 2018-08-15
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 2018-08-16
// ***********************************************************************
// <copyright file="CEPAbertoClient.cs" company="Guilherme Branco Stracini">
//     Copyright © 2018 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CEPAberto
{
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
        private readonly string _token;

        /// <summary>
        /// The configure await
        /// </summary>
        private readonly bool _configureAwait;

        #endregion

        #region ~Ctor

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

        #endregion

        #region Implementation of ICEPAbertoClient

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="postalCode">The postal code.</param>
        /// <returns></returns>
        public PostalCodeData GetData(string postalCode)
        {
            return GetDataAsync(postalCode, CancellationToken.None).Result;
        }

        /// <summary>
        /// Gets the data asynchronous.
        /// </summary>
        /// <param name="postalCode">The postal code.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns></returns>
        public async Task<PostalCodeData> GetDataAsync(string postalCode, CancellationToken token)
        {
            var data = new PostalCodeRequest
            {
                Token = _token,
                PostalCode = postalCode
            };
            var result = await _service.Get<PostalCodeData, PostalCodeRequest>(data, token).ConfigureAwait(_configureAwait);
            if (!string.IsNullOrEmpty(result.PostalCode))
                result.Success = true;
            return result;
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <returns></returns>
        public PostalCodeData GetData(string latitude, string longitude)
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
        public async Task<PostalCodeData> GetDataAsync(string latitude, string longitude, CancellationToken token)
        {
            var data = new NearestRequest
            {
                Token = _token,
                Latitude = latitude,
                Longitude = longitude
            };
            var result = await _service.Get<PostalCodeData, NearestRequest>(data, token).ConfigureAwait(_configureAwait);
            if (!string.IsNullOrEmpty(result.PostalCode))
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
        public PostalCodeData GetData(string stateInitials, string city, string neighborhood, string street)
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
        public async Task<PostalCodeData> GetDataAsync(string stateInitials, string city, string neighborhood, string street, CancellationToken token)
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
            if (!string.IsNullOrEmpty(result.PostalCode))
                result.Success = true;
            return result;
        }

        /// <summary>
        /// Gets the cities.
        /// </summary>
        /// <param name="stateInitials">The state initials.</param>
        /// <returns></returns>
        public CitiesData GetCities(string stateInitials)
        {
            return GetCitiesAsync(stateInitials, CancellationToken.None).Result;
        }

        /// <summary>
        /// Gets the cities asynchronous.
        /// </summary>
        /// <param name="stateInitials">The state initials.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns></returns>
        public async Task<CitiesData> GetCitiesAsync(string stateInitials, CancellationToken token)
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

