using Common.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Common.Helpers
{
    [TestClass]
    public class TestUriHelper
    {
        [TestMethod]
        public void FormatTibiaCharacterUrl_CharNameWithoutSpace_ReturnsUrlWithoutPlus()
        {
            // Arrange
            string charName = "Rektrim";

            // Act
            var url = UrlHelper.FormatTibiaCharacterUrl(charName);

            // Assert
            Assert.AreEqual("https://www.tibia.com/community/?subtopic=characters&name=Rektrim", url);
        }

        [TestMethod]
        public void FormatTibiaCharacterUrl_CharNameWithSpace_ReturnsUrlWithPlus()
        {
            // Arrange
            string charName = "Relentless Rektrim";

            // Act
            var url = UrlHelper.FormatTibiaCharacterUrl(charName);

            // Assert
            Assert.AreEqual("https://www.tibia.com/community/?subtopic=characters&name=Relentless+Rektrim", url);
        }

        [TestMethod]
        public void FormatTibiaCharacterUrl_CharNameWithForeignLetters_ReturnsEncodedUrl()
        {
            // Arrange
            string charName = "Hälge";

            // Act
            var url = UrlHelper.FormatTibiaCharacterUrl(charName);

            // Assert
            Assert.AreEqual("https://www.tibia.com/community/?subtopic=characters&name=H%e4lge", url);
        }
    }
}
