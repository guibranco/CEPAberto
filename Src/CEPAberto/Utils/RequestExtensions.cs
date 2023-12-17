using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace CEPAberto.Utils;

/// <summary>
/// Class Extensions.
/// </summary>
public static class RequestHelpers
{
    /// <summary>
    /// Converts to key value.
    /// </summary>
    /// <param name="metaToken">The meta token.</param>
    /// <returns>IDictionary&lt;System.String, System.String&gt;.</returns>
    public static IDictionary<string, string> ToKeyValue(this object metaToken)
    {
        while (true)
        {
            if (metaToken == null)
            {
                return new Dictionary<string, string>();
            }

            var token = metaToken as JToken;
            if (token == null)
            {
                metaToken = JObject.FromObject(metaToken);
                continue;
            }

            if (token.HasValues)
            {
                var contentData = new Dictionary<string, string>();
                foreach (var child in token.Children().ToList())
                {
                    var childContent = child.ToKeyValue();
                    if (childContent != null)
                    {
                        contentData = contentData
                            .Concat(childContent)
                            .ToDictionary(k => k.Key, v => v.Value);
                    }
                }

                return contentData;
            }

            var jValue = token as JValue;
            if (jValue?.Value == null)
            {
                return new Dictionary<string, string>();
            }

            var value =
                jValue.Type == JTokenType.Date
                    ? jValue.ToString("o", CultureInfo.InvariantCulture)
                    : jValue.ToString(CultureInfo.InvariantCulture);

            return new Dictionary<string, string> { { token.Path, value } };
        }
    }
}
