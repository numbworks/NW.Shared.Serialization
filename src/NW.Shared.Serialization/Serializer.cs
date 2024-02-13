using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;
using NW.Shared.Serialization.JsonSerializerConverters;
using System.Text.Json.Serialization;
using NW.Shared.Validation;

namespace NW.Shared.Serialization
{
    /// <inheritdoc cref="ISerializer{T}"/>
    public class Serializer<T> : ISerializer<T>
    {

        #region Fields

        #endregion

        #region Properties

        public JsonSerializerOptions JsonSerializerOptions { get; }

        /// <summary>Uses <see cref="JsonStringEnumConverter"/> and <see cref="DateTimeToDateConverter"/>.</summary>
        public static JsonSerializerOptions DefaultJsonSerializerOptions { get; } = CreateDefaultJsonSerializerOptions();
        public static List<T> Default { get; } = null;

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="Serializer{T}"/> instance.</summary>	
        public Serializer(JsonSerializerOptions jsonSerializerOptions)
        {

            Validator.ValidateObject(jsonSerializerOptions, nameof(jsonSerializerOptions));

            JsonSerializerOptions = jsonSerializerOptions;

        }

        /// <summary>Initializes a <see cref="Serializer{T}"/> instance using <see cref="DefaultJsonSerializerOptions"/>.</summary>	
        public Serializer()
            : this(jsonSerializerOptions: DefaultJsonSerializerOptions) { }

        #endregion

        #region Methods_public

        public string Serialize(T obj)
        {

            Validator.ValidateObject(obj, nameof(obj));

            string json = JsonSerializer.Serialize(obj, JsonSerializerOptions);

            return json;

        }
        public string Serialize(List<T> objects)
        {

            Validator.ValidateList(objects, nameof(objects));

            string json = JsonSerializer.Serialize(objects, JsonSerializerOptions);

            return json;

        }
        
        public List<T> DeserializeManyOrDefault(string json)
        {

            try
            {

                List<T> objects = JsonSerializer.Deserialize<List<T>>(json, JsonSerializerOptions);

                if (objects.Count == 0)
                    return Default;

                return objects;

            }
            catch
            {

                return Default;

            }

        }
        public T DeserializeOrDefault(string json)
        {

            try
            {

                T obj = JsonSerializer.Deserialize<T>(json, JsonSerializerOptions);

                return obj;

            }
            catch
            {

                return default(T);

            }

        }

        #endregion

        #region Methods_private

        private static JsonSerializerOptions CreateDefaultJsonSerializerOptions()
        {

            JsonSerializerOptions options = new JsonSerializerOptions();

            options.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            options.Converters.Add(new JsonStringEnumConverter());
            options.Converters.Add(new DateTimeToDateConverter());
            options.WriteIndented = true;

            return options;

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 13.02.2024
*/