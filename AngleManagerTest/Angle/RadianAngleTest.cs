
namespace AngleManagerTest.Angle
{
    using AngleManager.Angle;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Shouldly;

    [TestClass]
    public class RadianAngleTest : AngleTestContext
    {
        #region Casting Tests
        [TestMethod]
        public void AngleInDegreesExplicitCastToAngleInRadians()
        {
            // Arrange
            var firstAngleInDegree = new DegreeAngle(10);

            // Act
            var castInstance = (RadianAngle)firstAngleInDegree;

            // Assert
            castInstance.ShouldBeOfType<RadianAngle>();
            castInstance.Value.ShouldBe(ConvertToRadian(10));
        }

        #endregion
    }
}
