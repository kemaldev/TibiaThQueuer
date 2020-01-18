using Common.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Common.Helpers
{
    [TestClass]
    public class TestEnsure
    {
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void NotNull_NullProvided_ExceptionThrown()
        {
            // Arrange
            string test = null;

            // Act
            Ensure.NotNull(test);

            // Assert
            // ArgumentNullException thrown.
        }

        [TestMethod]
        public void NotNull_NonNullValueProvided_ExceptionNotThrown()
        {
            // Arrange
            string test = "hello";

            // Act
            Ensure.NotNull(test);

            // Assert
            Assert.AreEqual("hello", test);
        }

        [ExpectedException(typeof(ArgumentNullException), "test was null.")]
        [TestMethod]
        public void NotNullWithErrorMessage_NullProvided_ExceptionThrown()
        {
            // Arrange
            string test = null;

            // Act
            Ensure.NotNull(test, $"{nameof(test)} was null.");

            // Assert
            // ArgumentNullException thrown with specified error message.
        }

        [TestMethod]
        public void NotNullWithErrorMessage_NonNullValueProvided_ExceptionNotThrown()
        {
            // Arrange
            string test = "hello";

            // Act
            Ensure.NotNull(test, $"{nameof(test)} was null.");

            // Assert
            Assert.AreEqual("hello", test);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void NotNullOrWhiteSpace_NullProvided_ExceptionThrown()
        {
            // Arrange
            string test = null;

            // Act
            Ensure.NotNullOrWhiteSpace(test);

            // Assert
            // ArgumentNullException thrown.
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void NotNullOrWhiteSpace_EmptyString_ExceptionThrown()
        {
            // Arrange
            string test = "";

            // Act
            Ensure.NotNullOrWhiteSpace(test);

            // Assert
            // ArgumentNullException thrown.
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void NotNullOrWhiteSpace_WhiteSpaceProvided_ExceptionThrown()
        {
            // Arrange
            string test = "        ";

            // Act
            Ensure.NotNullOrWhiteSpace(test);

            // Assert
            // ArgumentNullException thrown.
        }

        [TestMethod]
        public void NotNullOrWhiteSpace_ValidString_NoExceptionThrown()
        {
            // Arrange
            string test = "hello";

            // Act
            Ensure.NotNullOrWhiteSpace(test);

            // Assert
            Assert.AreEqual("hello", test);
        }

        [ExpectedException(typeof(ArgumentException), "test was null or whitespace")]
        [TestMethod]
        public void NotNullOrWhiteSpaceWithErrorMessage_NullProvided_ExceptionThrown()
        {
            // Arrange
            string test = null;

            // Act
            Ensure.NotNullOrWhiteSpace(test, $"{test} was null or whitespace");

            // Assert
            // ArgumentNullException thrown.
        }

        [ExpectedException(typeof(ArgumentException), "test was null or whitespace")]
        [TestMethod]
        public void NotNullOrWhiteSpaceWithErrorMessage_EmptyString_ExceptionThrown()
        {
            // Arrange
            string test = "";

            // Act
            Ensure.NotNullOrWhiteSpace(test, $"{test} was null or whitespace");

            // Assert
            // ArgumentNullException thrown.
        }

        [ExpectedException(typeof(ArgumentException), "test was null or whitespace")]
        [TestMethod]
        public void NotNullOrWhiteSpaceWithErrorMessage_WhiteSpaceProvided_ExceptionThrown()
        {
            // Arrange
            string test = "        ";

            // Act
            Ensure.NotNullOrWhiteSpace(test, $"{test} was null or whitespace");

            // Assert
            // ArgumentNullException thrown.
        }

        [TestMethod]
        public void NotNullOrWhiteSpaceWithErrorMessage_ValidString_NoExceptionThrown()
        {
            // Arrange
            string test = "hello";

            // Act
            Ensure.NotNullOrWhiteSpace(test, $"{test} was null or whitespace");

            // Assert
            Assert.AreEqual("hello", test);
        }


    }
}
