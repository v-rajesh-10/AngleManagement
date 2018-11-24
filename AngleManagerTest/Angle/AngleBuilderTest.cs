using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using Shouldly;

namespace AngleManagerTest.Angle
{
    [TestClass]
    public class AngleBuilderTest
    {
        private static string DEGREE_UNIT_VALUE = ConfigurationManager.AppSettings["AngularUnitTypeDegree"];
        private static string RADIAN_UNIT_VALUE = ConfigurationManager.AppSettings["AngularUnitTypeRadian"];

        #region Not Supported By Version Angle Builder Tests
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException), "The angle unit is not in this version.")]
        public void TestAngleBuilderWithUnitTypeInvalidThrowsNotImplementedException()
        {
            // Arrange and Act
            var firstAngle = AngleManager.Angle.Angle.Builder().WithValue(10).WithUnit("InvalidUnitType").Build();
        }
        #endregion

        #region Degree Angle Builder Tests
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "The angle value is not in the expected range[0 , 360].")]
        public void TestDegreeAngleBuilderWithValueLessThanLowerLimitThrowsInvalidOperationException()
        {
            // Arrange and Act
            var firstAngle = AngleManager.Angle.Angle.Builder().WithValue(-1).WithUnit(DEGREE_UNIT_VALUE).Build();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "The angle value is not in the expected range[0 , 360].")]
        public void TestDegreeAngleBuilderWithValueGreaterThanUpperLimitThrowsInvalidOperationException()
        {
            // Arrange and Act
            var firstAngle = AngleManager.Angle.Angle.Builder().WithValue(361).WithUnit(DEGREE_UNIT_VALUE).Build();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestDegreeAngleBuilderWithValueModifiedAfterBuilderCreationThrowsInvalidOperationException()
        {
            // Arrange and Act
            var angleBuilder = AngleManager.Angle.Angle.Builder();
            var firstAngle = angleBuilder.WithValue(99).WithUnit(DEGREE_UNIT_VALUE).Build();
            // attempting to change the value even afer the angle object is created...throws an exception
            angleBuilder.WithValue(100);
        }

        [TestMethod]
        public void TestDegreeAngleBuilderWithValidValueCreatesValidAngleInstance()
        {
            // Arrange
            var value = 10;

            // Act
            var firstAngle = AngleManager.Angle.Angle.Builder().WithValue(value).WithUnit(DEGREE_UNIT_VALUE).Build();

            // Assert
            firstAngle.Value.ShouldBe(value);
            firstAngle.Unit.ShouldBe(AngleManager.Angle.AngularUnits.UnitType.DEGREE);
        }
        #endregion

        #region Radian Angle Builder Tests
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "The angle value is not in the expected range[0 , 360].")]
        public void TestRadianAngleBuildertWithValueLessThanLowerLimitThrowsInvalidOperationException()
        {
            // Arrange and Act
            var firstAngle = AngleManager.Angle.Angle.Builder().WithValue(-1).WithUnit(RADIAN_UNIT_VALUE).Build();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "The angle value is not in the expected range[0 , 360].")]
        public void TestRadianAngleBuildertWithValueGreaterThanUpperLimitThrowsInvalidOperationException()
        {
            // Arrange and Act
            var firstAngle = AngleManager.Angle.Angle.Builder().WithValue(361).WithUnit(RADIAN_UNIT_VALUE).Build();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestRadianAngleBuilderWithValueModifiedAfterBuilderCreationThrowsInvalidOperationException()
        {
            // Arrange and Act
            var angleBuilder = AngleManager.Angle.Angle.Builder();
            var firstAngle = angleBuilder.WithValue(99).WithUnit(RADIAN_UNIT_VALUE).Build();
            // attempting to change the value even afer the angle object is created...throws an exception
            angleBuilder.WithValue(100);
        }

        [TestMethod]
        public void TestRadianAngleBuilderWithValidValueCreatesValidAngleInstance()
        {
            // Arrange
            var value = 10;

            // Act
            var firstAngle = AngleManager.Angle.Angle.Builder().WithValue(value).WithUnit(RADIAN_UNIT_VALUE).Build();

            // Assert
            firstAngle.Value.ShouldBe(value);
            firstAngle.Unit.ShouldBe(AngleManager.Angle.AngularUnits.UnitType.RADIAN);
        }
        #endregion
    }
}
