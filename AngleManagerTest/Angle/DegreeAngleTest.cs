using System;
using AngleManager.Angle;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AngleManagerTest.Angle
{
    [TestClass]
    public class DegreeAngleTest
    {
        #region Casting Tests
        [TestMethod]
        public void AngleInDegreesExplicitCastedToAngleInRadians()
        {
            // Arrange
            var firstAngleInDegree = new DegreeAngle(10);

            // Act
            RadianAngle castedInstance = (RadianAngle)firstAngleInDegree;

            // Assert
            castedInstance.Value.ShouldBe(ConvertToRadian(10));
        }

        [TestMethod]
        public void AngleInRadianExplicitCastedToAngleInDegree()
        {
            // Arrange
            var firstAngleInRadian = new RadianAngle(5);

            // Act
            DegreeAngle castedInstance = (DegreeAngle)firstAngleInRadian;

            // Assert
            castedInstance.Value.ShouldBe(ConvertToDegree(5));
        }
        #endregion

        private double ConvertToRadian(double degreeValue)
        {
            return ((Math.PI / 180) * degreeValue);
        }

        private double ConvertToDegree(double radianValue)
        {
            return ((180 / Math.PI) * radianValue);
        }
    }
}
