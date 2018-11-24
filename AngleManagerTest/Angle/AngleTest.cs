using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AngleManagerTest.Angle
{
    [TestClass]
    public class AngleTest
    {
        private static AngleManager.Angle.Angle _ValidDegreeAngle = null;
        private static AngleManager.Angle.Angle _ValidRadianAngle = null;
        private static double _ExpectedAddResultInDegrees;
        private static double _ExpectedAddResultInRadians;
        private static double _ExpectedDifferenceResultInDegrees;
        private static double _ExpectedDifferenceResultInRadians;
        private static double _ExpectedMultiplicationResultInDegrees;
        private static double _ExpectedMultiplicationResultInRadians;
        private static double _ExpectedDivisionResultInDegrees;
        private static double _ExpectedDivisionResultInRadians;

        [TestInitialize]
        public void Initialize()
        {
            _ValidDegreeAngle = CreateDegreeAngleByValue(10);
            _ValidRadianAngle = CreateRadianAngleByValue(5);

            _ExpectedAddResultInDegrees = _ValidDegreeAngle.Value + ((180 / Math.PI) * _ValidRadianAngle.Value);

            _ExpectedAddResultInRadians = _ValidRadianAngle.Value + ((Math.PI / 180) * _ValidDegreeAngle.Value);

            _ExpectedDifferenceResultInDegrees = _ValidDegreeAngle.Value - ((180 / Math.PI) * _ValidRadianAngle.Value);

            _ExpectedDifferenceResultInRadians = _ValidRadianAngle.Value - ((Math.PI / 180) * _ValidDegreeAngle.Value);

            _ExpectedMultiplicationResultInDegrees = _ValidDegreeAngle.Value * ((180 / Math.PI) * _ValidRadianAngle.Value);

            _ExpectedMultiplicationResultInRadians = _ValidRadianAngle.Value * ((Math.PI / 180) * _ValidDegreeAngle.Value);

            _ExpectedDivisionResultInDegrees = _ValidDegreeAngle.Value / ((180 / Math.PI) * _ValidRadianAngle.Value);

            _ExpectedDivisionResultInRadians = _ValidRadianAngle.Value / ((Math.PI / 180) * _ValidDegreeAngle.Value);
        }

        #region Angle Addition Tests
        [TestMethod]
        public void TestAddAngleWithFirstAngleInDegreesAndSecondAngleInDegrees()
        {
            // Act
            var result = _ValidDegreeAngle + _ValidDegreeAngle;

            // Assert
            result.Unit.ShouldBe(AngleManager.Angle.AngularUnits.UnitType.DEGREE);
            result.Value.ShouldBe(_ValidDegreeAngle.Value * 2);
        }

        [TestMethod]
        public void TestAddAngleWithFirstAngleInDegreesAndSecondAngleInRadians()
        {
            // Act
            var result = _ValidDegreeAngle + _ValidRadianAngle;

            // Assert
            result.Unit.ShouldBe(AngleManager.Angle.AngularUnits.UnitType.DEGREE);
            result.Value.ShouldBe(_ExpectedAddResultInDegrees);
        }

        [TestMethod]
        public void TestAddAngleWithFirstAngleInRadianAndSecondAngleInDegrees()
        {
            // Act
            var result = _ValidRadianAngle + _ValidDegreeAngle;

            // Assert
            result.Unit.ShouldBe(AngleManager.Angle.AngularUnits.UnitType.RADIAN);
            result.Value.ShouldBe(_ExpectedAddResultInRadians);
        }

        [TestMethod]
        public void TestAddAngleWithFirstAngleInRadianAndSecondAngleInRadians()
        {
            // Act
            var result = _ValidRadianAngle + _ValidRadianAngle;

            // Assert
            result.Unit.ShouldBe(AngleManager.Angle.AngularUnits.UnitType.RADIAN);
            result.Value.ShouldBe(_ValidRadianAngle.Value * 2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "The angle value is not in the expected range[0 , 360].")]
        public void TestAddAngleWithFirstAngleInDegreesAndSecondAngleInDegreesExceedsUpperLimit()
        {
            // Arrange and Act
            var result = CreateDegreeAngleByValue(359) + CreateDegreeAngleByValue(1) + CreateDegreeAngleByValue(1);
        }
        #endregion

        #region Angle Subtraction Tests
        [TestMethod]
        public void SubtractAngleWithFirstAngleInDegreesAndSecondAngleInDegrees()
        {
            // Act
            var result = _ValidDegreeAngle - _ValidDegreeAngle;

            // Assert
            result.Unit.ShouldBe(AngleManager.Angle.AngularUnits.UnitType.DEGREE);
            result.Value.ShouldBe(0);
        }

        [TestMethod]
        public void SubtractAngleWithFirstAngleInDegreesAndSecondAngleInRadians()
        {
            // Act
            var result = CreateDegreeAngleByValue(360) - _ValidRadianAngle;

            // Assert
            result.Unit.ShouldBe(AngleManager.Angle.AngularUnits.UnitType.DEGREE);
            result.Value.ShouldBe(360 - ((180 / Math.PI) * _ValidRadianAngle.Value));
        }

        [TestMethod]
        public void SubtractAngleWithFirstAngleInRadianAndSecondAngleInDegrees()
        {
            // Act
            var result = _ValidRadianAngle - _ValidDegreeAngle;

            // Assert
            result.Unit.ShouldBe(AngleManager.Angle.AngularUnits.UnitType.RADIAN);
            result.Value.ShouldBe(_ExpectedDifferenceResultInRadians);
        }

        [TestMethod]
        public void SubtractAngleWithFirstAngleInRadianAndSecondAngleInRadians()
        {
            // Act
            var result = _ValidRadianAngle - _ValidRadianAngle;

            // Assert
            result.Unit.ShouldBe(AngleManager.Angle.AngularUnits.UnitType.RADIAN);
            result.Value.ShouldBe(0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "The angle value is not in the expected range[0 , 360].")]
        public void SubtractAngleWithFirstAngleInDegreesAndSecondAngleInDegreesExceedsUpperLimit()
        {
            // Arrange and Act
            var result = CreateDegreeAngleByValue(10) - CreateDegreeAngleByValue(5) - CreateDegreeAngleByValue(6);
        }
        #endregion

        #region Angle Multiplication Tests
        [TestMethod]
        public void MultiplyAngleWithFirstAngleInDegreesAndSecondAngleInDegrees()
        {
            // Act
            AngleManager.Angle.Angle result = _ValidDegreeAngle * _ValidDegreeAngle;

            // Assert
            result.Unit.ShouldBe(AngleManager.Angle.AngularUnits.UnitType.DEGREE);
            result.Value.ShouldBe(_ValidDegreeAngle.Value * _ValidDegreeAngle.Value);
        }

        [TestMethod]
        public void MultiplyAngleWithFirstAngleInDegreesAndSecondAngleInRadians()
        {
            // Act
            var result = _ValidDegreeAngle * CreateRadianAngleByValue(0.50);

            // Assert
            result.Unit.ShouldBe(AngleManager.Angle.AngularUnits.UnitType.DEGREE);
            result.Value.ShouldBe(_ValidDegreeAngle.Value * ((180 / Math.PI) * 0.50));
        }

        [TestMethod]
        public void MultiplyAngleWithFirstAngleInDegreesAndSecondAngleInDouble()
        {
            // Act
            var result = _ValidDegreeAngle * _ValidDegreeAngle.Value;

            // Assert
            result.Unit.ShouldBe(AngleManager.Angle.AngularUnits.UnitType.DEGREE);
            result.Value.ShouldBe(_ValidDegreeAngle.Value * _ValidDegreeAngle.Value);
        }

        [TestMethod]
        public void MultiplyAngleWithFirstAngleInDoubleAndSecondAngleInDegrees()
        {
            // Act
            var result = _ValidDegreeAngle.Value * _ValidDegreeAngle;

            // Assert
            result.Unit.ShouldBe(AngleManager.Angle.AngularUnits.UnitType.DEGREE);
            result.Value.ShouldBe(_ValidDegreeAngle.Value * _ValidDegreeAngle.Value);
        }

        [TestMethod]
        public void MultiplyAngleWithFirstAngleInRadianAndSecondAngleInDegrees()
        {
            // Act
            var result = _ValidRadianAngle * _ValidDegreeAngle;

            // Assert
            result.Unit.ShouldBe(AngleManager.Angle.AngularUnits.UnitType.RADIAN);
            result.Value.ShouldBe(_ExpectedMultiplicationResultInRadians);
        }

        [TestMethod]
        public void MultiplyAngleWithFirstAngleInRadianAndSecondAngleInRadians()
        {
            // Act
            var result = _ValidRadianAngle * _ValidRadianAngle;

            // Assert
            result.Unit.ShouldBe(AngleManager.Angle.AngularUnits.UnitType.RADIAN);
            result.Value.ShouldBe(_ValidRadianAngle.Value * _ValidRadianAngle.Value);
        }

        [TestMethod]
        public void MultiplyAngleWithFirstAngleInRadianAndSecondAngleInDouble()
        {
            // Act
            var result = _ValidRadianAngle * _ValidRadianAngle.Value;

            // Assert
            result.Unit.ShouldBe(AngleManager.Angle.AngularUnits.UnitType.RADIAN);
            result.Value.ShouldBe(_ValidRadianAngle.Value * _ValidRadianAngle.Value);
        }

        [TestMethod]
        public void MultiplyAngleWithFirstAngleInDoubleAndSecondAngleInRadian()
        {
            // Act
            var result = _ValidRadianAngle.Value * _ValidRadianAngle;

            // Assert
            result.Unit.ShouldBe(AngleManager.Angle.AngularUnits.UnitType.RADIAN);
            result.Value.ShouldBe(_ValidRadianAngle.Value * _ValidRadianAngle.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "The angle value is not in the expected range[0 , 360].")]
        public void MultiplyAngleWithFirstAngleInDegreesAndSecondAngleInDegreesExceedsUpperLimit()
        {
            // Arrange and Act
            var result = CreateDegreeAngleByValue(10) * CreateDegreeAngleByValue(10) * CreateDegreeAngleByValue(4);
        }
        #endregion

        #region Angle Division Tests
        [TestMethod]
        public void DivisionAngleWithFirstAngleInDegreesAndSecondAngleInDegrees()
        {
            // Act
            var result = _ValidDegreeAngle / _ValidDegreeAngle;

            // Assert
            result.Unit.ShouldBe(AngleManager.Angle.AngularUnits.UnitType.DEGREE);
            result.Value.ShouldBe(_ValidDegreeAngle.Value / _ValidDegreeAngle.Value);
        }

        [TestMethod]
        public void DivisionAngleWithFirstAngleInDegreesAndSecondAngleInRadians()
        {
            // Act
            var result = _ValidDegreeAngle / CreateRadianAngleByValue(0.50);

            // Assert
            result.Unit.ShouldBe(AngleManager.Angle.AngularUnits.UnitType.DEGREE);
            result.Value.ShouldBe(_ValidDegreeAngle.Value / ((180 / Math.PI) * 0.50));
        }

        [TestMethod]
        public void DivisionAngleWithFirstAngleInRadianAndSecondAngleInDegrees()
        {
            // Act
            var result = _ValidRadianAngle / _ValidDegreeAngle;

            // Assert
            result.Unit.ShouldBe(AngleManager.Angle.AngularUnits.UnitType.RADIAN);
            result.Value.ShouldBe(_ExpectedDivisionResultInRadians);
        }

        [TestMethod]
        public void DivisionAngleWithFirstAngleInRadianAndSecondAngleInRadians()
        {
            // Act
            var result = _ValidRadianAngle / _ValidRadianAngle;

            // Assert
            result.Unit.ShouldBe(AngleManager.Angle.AngularUnits.UnitType.RADIAN);
            result.Value.ShouldBe(_ValidRadianAngle.Value / _ValidRadianAngle.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "The angle value is not in the expected range[0 , 360].")]
        public void DivisionAngleWithFirstAngleInDegreesAndSecondAngleInDegreesExceedsUpperLimit()
        {
            // Arrange and Act
            var result = CreateDegreeAngleByValue(1000) / CreateDegreeAngleByValue(1) / CreateDegreeAngleByValue(2);
        }
        #endregion

        private AngleManager.Angle.Angle CreateDegreeAngleByValue(double value)
        {
            return AngleManager.Angle.AngleBuilder.Create().WithValue(value).WithUnit(ConfigurationManager.AppSettings["AngularUnitTypeDegree"]).Build();
        }

        private AngleManager.Angle.Angle CreateRadianAngleByValue(double value)
        {
            return AngleManager.Angle.AngleBuilder.Create().WithValue(value).WithUnit(ConfigurationManager.AppSettings["AngularUnitTypeRadian"]).Build();
        }
    }
}
