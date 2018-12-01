
namespace AngleManagerTest.Direction
{
    using AngleManager.Direction;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Shouldly;

    [TestClass]
    public class MathematicalDirectionTest : AngleTestContext
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
            result.AxisType.ShouldBe(Direction.Axis.PositiveXAxis);
            result.QuadrantType.ShouldBe(Direction.Quadrant.First);
            result.MovementType.ShouldBe(Direction.Movement.CounterClockwise);
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
            result.AxisType.ShouldBe(Direction.Axis.PositiveXAxis);
            result.QuadrantType.ShouldBe(Direction.Quadrant.Second);
            result.MovementType.ShouldBe(Direction.Movement.CounterClockwise);
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
            result.AxisType.ShouldBe(Direction.Axis.PositiveXAxis);
            result.QuadrantType.ShouldBe(Direction.Quadrant.Third);
            result.MovementType.ShouldBe(Direction.Movement.CounterClockwise);
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
            result.AxisType.ShouldBe(Direction.Axis.PositiveXAxis);
            result.QuadrantType.ShouldBe(Direction.Quadrant.Fourth);
            result.MovementType.ShouldBe(Direction.Movement.CounterClockwise);
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
            result.AxisType.ShouldBe(Direction.Axis.PositiveXAxis);
            result.QuadrantType.ShouldBe(Direction.Quadrant.First);
            result.MovementType.ShouldBe(Direction.Movement.CounterClockwise);
        }

        [TestMethod]
        public void TestCompassDirectionCastingFromMathematicalDirectionInRadianForAngleInFirstQuadrant()
        {
            // Arrange
            var firstQuadrantAngle = new AngleManager.Angle.RadianAngle(ConvertToRadian(60));
            CompassDirection mathematicalDirection = new CompassDirection(firstQuadrantAngle);

            //Act
            var result = (MathematicalDirection)mathematicalDirection;

            // Assert
            result.Angle.ShouldBeOfType<AngleManager.Angle.RadianAngle>();
            result.Angle.Value.ShouldBe(ConvertToRadian(30));
            result.AxisType.ShouldBe(Direction.Axis.PositiveXAxis);
            result.QuadrantType.ShouldBe(Direction.Quadrant.First);
            result.MovementType.ShouldBe(Direction.Movement.CounterClockwise);
        }

        [TestMethod]
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
            result.AxisType.ShouldBe(Direction.Axis.PositiveXAxis);
            result.QuadrantType.ShouldBe(Direction.Quadrant.Fourth);
            result.MovementType.ShouldBe(Direction.Movement.CounterClockwise);
        }

        [TestMethod]
        public void TestCompassDirectionCastingFromMathematicalDirectionInRadiansForAngleInSecondQuadrant()
        {
            // Arrange
            var firstQuadrantAngle = new AngleManager.Angle.RadianAngle(ConvertToRadian(120));
            CompassDirection mathematicalDirection = new CompassDirection(firstQuadrantAngle);

            //Act
            var result = (MathematicalDirection)mathematicalDirection;

            // Assert
            result.Angle.ShouldBeOfType<AngleManager.Angle.RadianAngle>();
            result.Angle.Value.ShouldBe(ConvertToRadian(330));
            result.AxisType.ShouldBe(Direction.Axis.PositiveXAxis);
            result.QuadrantType.ShouldBe(Direction.Quadrant.Fourth);
            result.MovementType.ShouldBe(Direction.Movement.CounterClockwise);
        }

        [TestMethod]
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
            result.AxisType.ShouldBe(Direction.Axis.PositiveXAxis);
            result.QuadrantType.ShouldBe(Direction.Quadrant.Third);
            result.MovementType.ShouldBe(Direction.Movement.CounterClockwise);
        }

        [TestMethod]
        public void TestCompassDirectionCastingFromMathematicalDirectionInRadianForAngleInThirdQuadrant()
        {
            // Arrange
            var firstQuadrantAngle = new AngleManager.Angle.RadianAngle(ConvertToRadian(240));
            CompassDirection mathematicalDirection = new CompassDirection(firstQuadrantAngle);

            //Act
            var result = (MathematicalDirection)mathematicalDirection;

            // Assert
            result.Angle.ShouldBeOfType<AngleManager.Angle.RadianAngle>();
            result.Angle.Value.ShouldBe(ConvertToRadian(210), 0.0000000000000005);
            result.AxisType.ShouldBe(Direction.Axis.PositiveXAxis);
            result.QuadrantType.ShouldBe(Direction.Quadrant.Third);
            result.MovementType.ShouldBe(Direction.Movement.CounterClockwise);
        }

        [TestMethod]
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
            result.AxisType.ShouldBe(Direction.Axis.PositiveXAxis);
            result.QuadrantType.ShouldBe(Direction.Quadrant.Second);
            result.MovementType.ShouldBe(Direction.Movement.CounterClockwise);
        }

        [TestMethod]
        public void TestCompassDirectionCastingFromMathematicalDirectionInRadianForAngleInFourthQuadrant()
        {
            // Arrange
            var firstQuadrantAngle = new AngleManager.Angle.RadianAngle(ConvertToRadian(320));
            CompassDirection mathematicalDirection = new CompassDirection(firstQuadrantAngle);

            //Act
            var result = (MathematicalDirection)mathematicalDirection;

            // Assert
            result.Angle.ShouldBeOfType<AngleManager.Angle.RadianAngle>();
            result.Angle.Value.ShouldBe(ConvertToRadian(130));
            result.AxisType.ShouldBe(Direction.Axis.PositiveXAxis);
            result.QuadrantType.ShouldBe(Direction.Quadrant.Second);
            result.MovementType.ShouldBe(Direction.Movement.CounterClockwise);
        }
        #endregion
    }
}
