using System;
using AngleManager.Direction;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AngleManagerTest.Direction
{
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
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.POSITIVE_Y_AXIS);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.FIRST);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.CLOCKWISE);
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
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.POSITIVE_Y_AXIS);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.SECOND);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.CLOCKWISE);
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
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.POSITIVE_Y_AXIS);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.THIRD);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.CLOCKWISE);
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
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.POSITIVE_Y_AXIS);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.FOURTH);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.CLOCKWISE);
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
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.POSITIVE_Y_AXIS);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.FIRST);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.CLOCKWISE);
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
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.POSITIVE_Y_AXIS);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.FOURTH);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.CLOCKWISE);
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
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.POSITIVE_Y_AXIS);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.THIRD);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.CLOCKWISE);
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
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.POSITIVE_Y_AXIS);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.SECOND);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.CLOCKWISE);
        }

        [TestMethod]
        [Ignore("This could potentially be a Design Flaw OR the Upper and Lower Limit values OR the formula to solve the direction casting")]
        public void TestCompassDirectionCastingFromMathematicalDirectionInRadiansForAngleInFirstQuadrant()
        {
            // Arrange
            var firstQuadrantAngle = new AngleManager.Angle.RadianAngle(ConvertToRadian(30));
            MathematicalDirection mathematicalDirection = new MathematicalDirection(firstQuadrantAngle);

            //Act
            var result = (CompassDirection)mathematicalDirection;

            // Assert
            result.Angle.ShouldBeOfType<AngleManager.Angle.DegreeAngle>();
            result.Angle.Value.ShouldBe(ConvertToRadian(60));
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.POSITIVE_Y_AXIS);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.FIRST);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.CLOCKWISE);
        }
        #endregion
    }
}
