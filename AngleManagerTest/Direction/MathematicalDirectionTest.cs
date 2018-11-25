using System;
using AngleManager.Direction;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AngleManagerTest.Direction
{
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
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.POSITIVE_X_AXIS);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.FIRST);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.COUNTER_CLOCKWISE);
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
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.POSITIVE_X_AXIS);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.SECOND);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.COUNTER_CLOCKWISE);
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
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.POSITIVE_X_AXIS);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.THIRD);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.COUNTER_CLOCKWISE);
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
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.POSITIVE_X_AXIS);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.FOURTH);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.COUNTER_CLOCKWISE);
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
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.POSITIVE_X_AXIS);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.FIRST);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.COUNTER_CLOCKWISE);
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
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.POSITIVE_X_AXIS);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.FOURTH);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.COUNTER_CLOCKWISE);
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
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.POSITIVE_X_AXIS);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.THIRD);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.COUNTER_CLOCKWISE);
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
            result.AxisType.ShouldBe(AngleManager.Direction.Direction.Axis.POSITIVE_X_AXIS);
            result.QuadrantType.ShouldBe(AngleManager.Direction.Direction.Quadrant.SECOND);
            result.MovementType.ShouldBe(AngleManager.Direction.Direction.Movement.COUNTER_CLOCKWISE);
        }
        #endregion
    }
}
