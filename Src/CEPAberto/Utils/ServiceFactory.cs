﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using CEPAberto.GoodPractices;
using GuiStracini.SDKBuilder;
using Newtonsoft.Json;
using CEPAbertoBaseRequest = CEPAberto.Transport.CEPAbertoBaseRequest;

namespace CEPAberto.Utils;

/// <summary>
/// Class ServiceFactory. This class cannot be inherited.
/// </summary>
internal sealed class ServiceFactory
{
    /// <summary>
    /// The service end point
    /// </summary>
    private const string ServiceEndPoint = "https://www.cepaberto.com/api/v3/";

    /// <summary>
    /// The configure await flag.
    /// </summary>
    private readonly bool _configureAwait;

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceFactory"/> class.
    /// </summary>
    /// <param name="configureAwait">if set to <c>true</c> [configure await].</param>
    public ServiceFactory(bool configureAwait = false)
    {
        _configureAwait = configureAwait;
    }

    /// <summary>
    /// Executes the request in the specified HTTP <paramref name="method"/>.
    /// </summary>
    /// <typeparam name="TOut">The type of the out.</typeparam>
    /// <typeparam name="TIn">The type of the in.</typeparam>
    /// <param name="method">The request HTTP method.</param>
    /// <param name="requestObject">The request object.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Returns the response as <typeparamref name="TOut"/></returns>
    /// <exception cref="System.Net.Http.HttpRequestException">
    /// Requested method {method} not implemented in V3
    /// </exception>
    /// <exception cref="CEPAberto.GoodPractices.CEPAbertoApiException"></exception>
    private async Task<TOut> Execute<TOut, TIn>(
        ActionMethod method,
        TIn requestObject,
        CancellationToken cancellationToken
    )
        where TIn : CEPAbertoBaseRequest
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(ServiceEndPoint);
            client.DefaultRequestHeaders.ExpectContinue = false;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
            if (!string.IsNullOrEmpty(requestObject.Token))
            {
                client.DefaultRequestHeaders.Add(
                    "Authorization",
                    string.Concat("Token token=", requestObject.Token)
                );
            }

            var endpoint = requestObject.GetRequestEndPoint();
            //TODO fix after updated GuiStracini.SDKBuilder
            //var additional = requestObject.GetRequestAdditionalParameter(method);

            //if (!string.IsNullOrWhiteSpace(additional))
            //{
            //    if (endpoint.IndexOf("?", StringComparison.InvariantCultureIgnoreCase) == -1)
            //    {
            //        endpoint += "?";
            //    }

            //    endpoint += additional.Replace("/?", "&");
            //}

            try
            {
                HttpResponseMessage response;
                switch (method)
                {
                    case ActionMethod.GET:

                        response = await client
                            .GetAsync(endpoint, cancellationToken)
                            .ConfigureAwait(_configureAwait);

                        return await response
                            .Content.ReadAsAsync<TOut>(cancellationToken)
                            .ConfigureAwait(_configureAwait);

                    case ActionMethod.POST:

                        var data = requestObject.ToKeyValue();
                        var content = new FormUrlEncodedContent(data);

                        response = await client
                            .PostAsync(endpoint, content, cancellationToken)
                            .ConfigureAwait(_configureAwait);

                        var result = await response
                            .Content.ReadAsStringAsync()
                            .ConfigureAwait(_configureAwait);

                        if (result.StartsWith("["))
                        {
                            result = "{content: " + result + " }";
                        }

                        return JsonConvert.DeserializeObject<TOut>(result);

                    default:
                        throw new HttpRequestException(
                            $"Requested method {method} not implemented in V3"
                        );
                }
            }
            catch (HttpRequestException e)
            {
                throw new CEPAbertoApiException(requestObject.GetRequestEndPoint(), e);
            }
        }
    }

    /// <summary>
    /// Gets the specified request object.
    /// </summary>
    /// <typeparam name="TOut">The type of the t out.</typeparam>
    /// <typeparam name="TIn">The type of the t in.</typeparam>
    /// <param name="requestObject">The request object.</param>
    /// <param name="token">
    /// The cancellation token that can be used by other objects or threads to receive notice of cancellation.
    /// </param>
    /// <returns>TOut.</returns>
    public async Task<TOut> Get<TOut, TIn>(TIn requestObject, CancellationToken token)
        where TIn : CEPAbertoBaseRequest =>
        await Execute<TOut, TIn>(ActionMethod.GET, requestObject, token)
            .ConfigureAwait(_configureAwait);

    /// <summary>
    /// Posts the specified request object.
    /// </summary>
    /// <typeparam name="TOut">The type of the t out.</typeparam>
    /// <typeparam name="TIn">The type of the t in.</typeparam>
    /// <param name="requestObject">The request object.</param>
    /// <param name="cancellationToken">
    /// The cancellation token that can be used by other objects or threads to receive notice of cancellation.
    /// </param>
    /// <returns>TOut.</returns>
    public async Task<TOut> Post<TOut, TIn>(TIn requestObject, CancellationToken cancellationToken)
        where TIn : CEPAbertoBaseRequest =>
        await Execute<TOut, TIn>(ActionMethod.POST, requestObject, cancellationToken)
            .ConfigureAwait(_configureAwait);
}
