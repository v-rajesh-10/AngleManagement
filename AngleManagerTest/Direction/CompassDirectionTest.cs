
namespace AngleManagerTest.Direction
{
    using AngleManager.Direction;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Shouldly;

    [TestClass]
    public class CompassDirectionTest : AngleTestContext
    {
        #region Constructor Tests
        [TestMethod]
        public void TestCompassDirectionCreationInFirstQuadrantReturnsValidInstance()
        {
            // Arrange
            var firstQuadrantAngle = new AngleManager.Angle.DegreeAngle(30);

            //Act
            var result = new CompassDirection(firstQuadrantAngle);

            // Assert
            result.Angle.ShouldBeSameAs(firstQuadrantAngle);
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.PositiveYAxis);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.First);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.Clockwise);
        }

        [TestMethod]
        public void TestCompassDirectionCreationInSecondQuadrantReturnsValidInstance()
        {
            // Arrange
            var secondQuadrantAngle = new AngleManager.Angle.DegreeAngle(120);

            //Act
            var result = new CompassDirection(secondQuadrantAngle);

            // Assert
            result.Angle.ShouldBeSameAs(secondQuadrantAngle);
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.PositiveYAxis);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.Second);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.Clockwise);
        }

        [TestMethod]
        public void TestCompassDirectionCreationInThirdQuadrantReturnsValidInstance()
        {
            // Arrange
            var secondQuadrantAngle = new AngleManager.Angle.DegreeAngle(250);

            //Act
            var result = new CompassDirection(secondQuadrantAngle);

            // Assert
            result.Angle.ShouldBeSameAs(secondQuadrantAngle);
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.PositiveYAxis);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.Third);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.Clockwise);
        }

        [TestMethod]
        public void TestCompassDirectionCreationInFourthQuadrantReturnsValidInstance()
        {
            // Arrange
            var secondQuadrantAngle = new AngleManager.Angle.DegreeAngle(320);

            //Act
            var result = new CompassDirection(secondQuadrantAngle);

            // Assert
            result.Angle.ShouldBeSameAs(secondQuadrantAngle);
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.PositiveYAxis);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.Fourth);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.Clockwise);
        }
        #endregion

        #region Casting Tests
        [TestMethod]
        public void TestCompassDirectionCastingFromMathematicalDirectionInDegreesForAngleInFirstQuadrant()
        {
            // Arrange
            var firstQuadrantAngle = new AngleManager.Angle.DegreeAngle(30);
            MathematicalDirection mathematicalDirection = new MathematicalDirection(firstQuadrantAngle);

            //Act
            var result = (CompassDirection) mathematicalDirection;

            // Assert
            result.Angle.ShouldBeOfType<AngleManager.Angle.DegreeAngle>();
            result.Angle.Value.ShouldBe(60);
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.PositiveYAxis);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.First);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.Clockwise);
        }

        [TestMethod]
        public void TestCompassDirectionCastingFromMathematicalDirectionInDegreesForAngleInSecondQuadrant()
        {
            // Arrange
            var firstQuadrantAngle = new AngleManager.Angle.DegreeAngle(120);
            MathematicalDirection mathematicalDirection = new MathematicalDirection(firstQuadrantAngle);

            //Act
            var result = (CompassDirection)mathematicalDirection;

            // Assert
            result.Angle.ShouldBeOfType<AngleManager.Angle.DegreeAngle>();
            result.Angle.Value.ShouldBe(330);
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.PositiveYAxis);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.Fourth);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.Clockwise);
        }

        [TestMethod]
        public void TestCompassDirectionCastingFromMathematicalDirectionInDegreesForAngleInThirdQuadrant()
        {
            // Arrange
            var firstQuadrantAngle = new AngleManager.Angle.DegreeAngle(240);
            MathematicalDirection mathematicalDirection = new MathematicalDirection(firstQuadrantAngle);

            //Act
            var result = (CompassDirection)mathematicalDirection;

            // Assert
            result.Angle.ShouldBeOfType<AngleManager.Angle.DegreeAngle>();
            result.Angle.Value.ShouldBe(210);
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.PositiveYAxis);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.Third);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.Clockwise);
        }

        [TestMethod]
        public void TestCompassDirectionCastingFromMathematicalDirectionInDegreesForAngleInFourthQuadrant()
        {
            // Arrange
            var firstQuadrantAngle = new AngleManager.Angle.DegreeAngle(320);
            MathematicalDirection mathematicalDirection = new MathematicalDirection(firstQuadrantAngle);

            //Act
            var result = (CompassDirection)mathematicalDirection;

            // Assert
            result.Angle.ShouldBeOfType<AngleManager.Angle.DegreeAngle>();
            result.Angle.Value.ShouldBe(130);
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.PositiveYAxis);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.Second);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.Clockwise);
        }

        #endregion
    }
}
