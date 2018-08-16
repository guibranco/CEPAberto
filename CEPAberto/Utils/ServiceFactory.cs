// ***********************************************************************
// Assembly         : CEPAberto
// Author           : Guilherme Branco Stracini
// Created          : 2018-08-15
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 2018-08-16
// ***********************************************************************
// <copyright file="ServiceFactory.cs" company="Guilherme Branco Stracini">
//     Copyright © 2018 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CEPAberto.Utils
{
    using GoodPractices;
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Transport;

    internal sealed class ServiceFactory
    {
        #region Private fields

        /// <summary>
        /// The service end point
        /// </summary>
        private const String ServiceEndPoint = "http://www.cepaberto.com/api/v3/";

        /// <summary>
        /// The configure await flag.
        /// </summary>
        private readonly Boolean _configureAwait;

        #endregion

        #region ~Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceFactory"/> class.
        /// </summary>
        /// <param name="configureAwait">if set to <c>true</c> [configure await].</param>
        public ServiceFactory(Boolean configureAwait = false)
        {
            _configureAwait = configureAwait;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Executes the request in the specified HTTP <paramref name="method"/>.
        /// </summary>
        /// <typeparam name="TOut">The type of the out.</typeparam>
        /// <typeparam name="TIn">The type of the in.</typeparam>
        /// <param name="method">The request HTTP method.</param>
        /// <param name="requestObject">The request object.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns the response as <typeparamref name="TOut"/></returns>
        private async Task<TOut> Execute<TOut, TIn>(ActionMethod method, TIn requestObject, CancellationToken cancellationToken) where TIn : BaseRequest
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServiceEndPoint);
                client.DefaultRequestHeaders.ExpectContinue = false;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (!String.IsNullOrEmpty(requestObject.Token))
                    client.DefaultRequestHeaders.Add("Authorization", String.Concat("Token token=", requestObject.Token));
                var endpoint = String.Concat(requestObject.GetRequestEndPoint(),
                                             requestObject.GetRequestAdditionalParameter(method));
                try
                {
                    HttpResponseMessage response;
                    switch (method)
                    {
                        case ActionMethod.GET:
                            response = await client.GetAsync(endpoint, cancellationToken).ConfigureAwait(_configureAwait);
                            break;
                        default:
                            throw new HttpRequestException($"Requested method {method} not implemented in V3");
                    }
                    return await response.Content.ReadAsAsync<TOut>(cancellationToken).ConfigureAwait(_configureAwait);
                }
                catch (HttpRequestException e)
                {
                    throw new CEPAbertoAPIException(requestObject.GetRequestEndPoint(), e);
                }
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Gets the specified request object.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <typeparam name="TIn">The type of the t in.</typeparam>
        /// <param name="requestObject">The request object.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;TOut&gt;.</returns>
        public async Task<TOut> Get<TOut, TIn>(TIn requestObject, CancellationToken token) where TIn : BaseRequest
        {
            return await Execute<TOut, TIn>(ActionMethod.GET, requestObject, token).ConfigureAwait(_configureAwait);
        }

        #endregion
    }
}
