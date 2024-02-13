using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using NW.Shared.Validation;

namespace NW.Shared.Serialization.JsonSerializerConverters
{
    /// <summary>A converter for <see cref="JsonSerializerOptions"/> to serialize <see cref="DateTime"/> to date.</summary>
    public class DateTimeToDateConverter : JsonConverter<DateTime>
    {

        #region Fields
        #endregion

        #region Properties

        public static string DefaultDateFormat { get; } = "yyyy-MM-dd";
        public string DateFormat { get; }

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="DateTimeToDateConverter"/> instance using <see cref="DefaultDateFormat"/>.</summary>
        public DateTimeToDateConverter() 
        {

            DateFormat = DefaultDateFormat;

        }

        /// <summary>Initializes a <see cref="DateTimeToDateConverter"/> instance.</summary>
        /// <exception cref="ArgumentNullException"/>
        public DateTimeToDateConverter(string dateFormat) 
        {

            Validator.ValidateObject(dateFormat, nameof(dateFormat));

            DateFormat = dateFormat;

        }

        #endregion

        #region Methods_public

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            string raw = reader.GetString();
            DateTime value = DateTime.ParseExact(raw, DateFormat, CultureInfo.InvariantCulture);

            return value;

        }
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(DateFormat));

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 13.02.2024
*/