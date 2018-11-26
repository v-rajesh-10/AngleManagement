
namespace AngleManagerTest.Angle
{
    using AngleManager.Angle;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Shouldly;

    [TestClass]
    public class DegreeAngleTest : AngleTestContext
    {
        #region Casting Tests
        [TestMethod]
        public void AngleInRadianExplicitCastToAngleInDegree()
        {
            // Arrange
            var firstAngleInRadian = new RadianAngle(5);

            // Act
            var castInstance = (DegreeAngle)firstAngleInRadian;

            // Assert
            castInstance.ShouldBeOfType<DegreeAngle>();
            castInstance.Value.ShouldBe(ConvertToDegree(5));
        }
        #endregion
    }
}
