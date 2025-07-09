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
    public static IDictionary<string, string> ToKeyValue(this object metaToken)
    {
        if (metaToken == null)
        {
            return new Dictionary<string, string>();
        }

        var token = EnsureJToken(metaToken);

        if (!token.HasValues)
        {
            return ProcessLeafToken(token);
        }

        return ProcessContainerToken(token);
    }

    private static JToken EnsureJToken(object metaToken)
    {
        return metaToken as JToken ?? JObject.FromObject(metaToken);
    }

    private static IDictionary<string, string> ProcessLeafToken(JToken token)
    {
        var jValue = token as JValue;
        if (jValue?.Value == null)
        {
            return new Dictionary<string, string>();
        }

        var value = FormatTokenValue(jValue);
        return new Dictionary<string, string> { { token.Path, value } };
    }

    private static string FormatTokenValue(JValue jValue)
    {
        return jValue.Type == JTokenType.Date
            ? jValue.ToString("o", CultureInfo.InvariantCulture)
            : jValue.ToString(CultureInfo.InvariantCulture);
    }

    private static IDictionary<string, string> ProcessContainerToken(JToken token)
    {
        var contentData = new Dictionary<string, string>();

        foreach (var child in token.Children().ToList())
        {
            var childContent = child.ToKeyValue();
            if (childContent != null)
            {
                MergeDictionaries(contentData, childContent);
            }
        }

        return contentData;
    }

    private static void MergeDictionaries(
        IDictionary<string, string> target,
        IDictionary<string, string> source
    )
    {
        foreach (var kvp in source)
        {
            target[kvp.Key] = kvp.Value;
        }
    }
}
