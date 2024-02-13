using System;
using NW.Shared.Serialization.JsonSerializerConverters;
using NW.Shared.Serialization.UnitTests.Utilities;
using NUnit.Framework;

namespace NW.Shared.Serialization.UnitTests.JsonSerializerConverters
{
    [TestFixture]
    public class DateTimeToDateConverterTests
    {

        #region Fields

        private static TestCaseData[] dateTimeToDateConverterExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                        () => new DateTimeToDateConverter(dateFormat: null)),
                typeof(ArgumentNullException),
                new ArgumentNullException("dateFormat").Message
                ).SetArgDisplayNames($"{nameof(dateTimeToDateConverterExceptionTestCases)}_01"),

        };

        #endregion

        #region Tests

        [TestCaseSource(nameof(dateTimeToDateConverterExceptionTestCases))]
        public void Serializer_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [Test]
        public void DateTimeToDateConverter_ShouldCreateAnObjectOfTypeDateTimeToDateConverter_WhenInvoked()
        {

            // Arrange
            // Act
            DateTimeToDateConverter actual1 = new DateTimeToDateConverter();
            DateTimeToDateConverter actual2 = new DateTimeToDateConverter(dateFormat: DateTimeToDateConverter.DefaultDateFormat);

            // Assert
            Assert.That(actual1, Is.InstanceOf<DateTimeToDateConverter>());
            Assert.That(actual1.DateFormat, Is.InstanceOf<string>());

            Assert.That(actual2, Is.InstanceOf<DateTimeToDateConverter>());
            Assert.That(actual2.DateFormat, Is.InstanceOf<string>());

            Assert.That(DateTimeToDateConverter.DefaultDateFormat, Is.InstanceOf<string>());

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 13.02.2024
*/