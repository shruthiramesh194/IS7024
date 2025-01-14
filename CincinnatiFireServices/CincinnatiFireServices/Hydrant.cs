﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickTypeHydrant;
//
//    var hydrant = Hydrant.FromJson(jsonString);

namespace QuickTypeHydrant
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Hydrant
    {
        [JsonProperty("objectid")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Objectid { get; set; }

        [JsonProperty("assetid")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Assetid { get; set; }

        [JsonProperty("lifecyclestatus")]
        public string Lifecyclestatus { get; set; }

        [JsonProperty("servicearea")]
        public string Servicearea { get; set; }

        [JsonProperty("staticpressure")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Staticpressure { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("neighborhood")]
        public string Neighborhood { get; set; }
    }

    public partial class Hydrant
    {
        public static List<Hydrant> FromJson(string json) => JsonConvert.DeserializeObject<List<Hydrant>>(json, QuickTypeHydrant.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<Hydrant> self) => JsonConvert.SerializeObject(self, QuickTypeHydrant.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
