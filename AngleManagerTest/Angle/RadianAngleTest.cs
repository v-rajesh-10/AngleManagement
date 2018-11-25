using System;
using AngleManager.Angle;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AngleManagerTest.Angle
{
    [TestClass]
    public class RadianAngleTest : AngleTestContext
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

        #endregion
    }
}
