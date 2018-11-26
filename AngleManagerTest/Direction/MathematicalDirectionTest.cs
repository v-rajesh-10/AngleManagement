
namespace AngleManagerTest.Direction
{
    using AngleManager.Direction;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Shouldly;

    [TestClass]
    public class MathematicalDirectionTest
    {
        #region Constructor Tests
        [TestMethod]
        public void TestCompassDirectionCreationInFirstQuadrantReturnsValidInstance()
        {
            // Arrange
            var firstQuadrantAngle = new AngleManager.Angle.DegreeAngle(30);

            //Act
            var result = new MathematicalDirection(firstQuadrantAngle);

            // Assert
            result.Angle.ShouldBeSameAs(firstQuadrantAngle);
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.PositiveXAxis);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.First);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.CounterClockwise);
        }

        [TestMethod]
        public void TestCompassDirectionCreationInSecondQuadrantReturnsValidInstance()
        {
            // Arrange
            var secondQuadrantAngle = new AngleManager.Angle.DegreeAngle(120);

            //Act
            var result = new MathematicalDirection(secondQuadrantAngle);

            // Assert
            result.Angle.ShouldBeSameAs(secondQuadrantAngle);
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.PositiveXAxis);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.Second);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.CounterClockwise);
        }

        [TestMethod]
        public void TestCompassDirectionCreationInThirdQuadrantReturnsValidInstance()
        {
            // Arrange
            var secondQuadrantAngle = new AngleManager.Angle.DegreeAngle(250);

            //Act
            var result = new MathematicalDirection(secondQuadrantAngle);

            // Assert
            result.Angle.ShouldBeSameAs(secondQuadrantAngle);
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.PositiveXAxis);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.Third);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.CounterClockwise);
        }

        [TestMethod]
        public void TestCompassDirectionCreationInFourthQuadrantReturnsValidInstance()
        {
            // Arrange
            var secondQuadrantAngle = new AngleManager.Angle.DegreeAngle(320);

            //Act
            var result = new MathematicalDirection(secondQuadrantAngle);

            // Assert
            result.Angle.ShouldBeSameAs(secondQuadrantAngle);
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.PositiveXAxis);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.Fourth);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.CounterClockwise);
        }
        #endregion

        #region Casting Tests
        [TestMethod]
        public void TestCompassDirectionCastingFromMathematicalDirectionInDegreesForAngleInFirstQuadrant()
        {
            // Arrange
            var firstQuadrantAngle = new AngleManager.Angle.DegreeAngle(60);
            CompassDirection mathematicalDirection = new CompassDirection(firstQuadrantAngle);

            //Act
            var result = (MathematicalDirection)mathematicalDirection;

            // Assert
            result.Angle.ShouldBeOfType<AngleManager.Angle.DegreeAngle>();
            result.Angle.Value.ShouldBe(30);
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.PositiveXAxis);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.First);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.CounterClockwise);
        }

        public void TestCompassDirectionCastingFromMathematicalDirectionInDegreesForAngleInSecondQuadrant()
        {
            // Arrange
            var firstQuadrantAngle = new AngleManager.Angle.DegreeAngle(120);
            CompassDirection mathematicalDirection = new CompassDirection(firstQuadrantAngle);

            //Act
            var result = (MathematicalDirection)mathematicalDirection;

            // Assert
            result.Angle.ShouldBeOfType<AngleManager.Angle.DegreeAngle>();
            result.Angle.Value.ShouldBe(330);
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.PositiveXAxis);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.Fourth);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.CounterClockwise);
        }

        public void TestCompassDirectionCastingFromMathematicalDirectionInDegreesForAngleInThirdQuadrant()
        {
            // Arrange
            var firstQuadrantAngle = new AngleManager.Angle.DegreeAngle(240);
            CompassDirection mathematicalDirection = new CompassDirection(firstQuadrantAngle);

            //Act
            var result = (MathematicalDirection)mathematicalDirection;

            // Assert
            result.Angle.ShouldBeOfType<AngleManager.Angle.DegreeAngle>();
            result.Angle.Value.ShouldBe(210);
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.PositiveXAxis);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.Third);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.CounterClockwise);
        }

        public void TestCompassDirectionCastingFromMathematicalDirectionInDegreesForAngleInFourthQuadrant()
        {
            // Arrange
            var firstQuadrantAngle = new AngleManager.Angle.DegreeAngle(320);
            CompassDirection mathematicalDirection = new CompassDirection(firstQuadrantAngle);

            //Act
            var result = (MathematicalDirection)mathematicalDirection;

            // Assert
            result.Angle.ShouldBeOfType<AngleManager.Angle.DegreeAngle>();
            result.Angle.Value.ShouldBe(130);
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.PositiveXAxis);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.Second);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.CounterClockwise);
        }
        #endregion
    }
}
