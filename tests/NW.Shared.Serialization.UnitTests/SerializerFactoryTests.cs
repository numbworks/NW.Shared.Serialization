using NW.NGramTextClassification.LabeledExamples;
using NUnit.Framework;

namespace NW.Shared.Serialization.UnitTests
{
    [TestFixture]
    public class SerializerFactoryTests
    {

        #region Fields

        #endregion

        #region SetUp

        #endregion

        #region Tests

        [Test]
        public void Create_ShouldCreateExpectedInstanceOfISerializer_WhenTypeIsLabeledExample()
        {

            // Arrange
            // Act
            ISerializer<LabeledExample> serializer = new SerializerFactory().Create<LabeledExample>();

            // Assert
            Assert.That(serializer, Is.InstanceOf<ISerializer<LabeledExample>>());

        }

        [Test]
        public void SerializerFactory_ShouldCreateAnInstanceOfThisType_WhenInvoked()
        {

            // Arrange
            // Act
            SerializerFactory serializerFactory = new SerializerFactory();

            // Assert
            Assert.That(serializerFactory, Is.InstanceOf<SerializerFactory>());

        }

        #endregion

        #region TearDown

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 13.02.2024
*/