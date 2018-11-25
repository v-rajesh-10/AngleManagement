using System;
using System.Configuration;
using AngleManager.Angle;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AngleManagerTest.Angle
{
    [TestClass]
    public class AngleTest
    {
        #region Angle Addition Tests
        [TestMethod]
        public void TestAddAngleWithFirstAngleInDegreesAndSecondAngleInDegrees()
        {
            // Act
            var result = CreateDegreeAngleByValue(10) + CreateDegreeAngleByValue(5);

            // Assert
            result.ShouldBeOfType<AngleManager.Angle.DegreeAngle>();
            result.Value.ShouldBe(15);
        }

        [TestMethod]
        public void TestAddAngleWithFirstAngleInDegreesAndSecondAngleInRadians()
        {
            // Act
            var result = CreateDegreeAngleByValue(5) + CreateRadianAngleByValue(1);

            // Assert
            result.ShouldBeOfType<AngleManager.Angle.DegreeAngle>();
            result.Value.ShouldBe(5 + ConvertToDegree(1));
        }

        [TestMethod]
        public void TestAddAngleWithFirstAngleInRadianAndSecondAngleInDegrees()
        {
            // Act
            var result = CreateRadianAngleByValue(5) + CreateDegreeAngleByValue(10);

            // Assert
            result.ShouldBeOfType<AngleManager.Angle.RadianAngle>();
            result.Value.ShouldBe(5 + ConvertToRadian(10));
        }

        [TestMethod]
        public void TestAddAngleWithFirstAngleInRadianAndSecondAngleInRadians()
        {
            // Act
            var result = CreateRadianAngleByValue(5) + CreateRadianAngleByValue(1);

            // Assert
            result.ShouldBeOfType<AngleManager.Angle.RadianAngle>();
            result.Value.ShouldBe(6);
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
            var result = CreateDegreeAngleByValue(5) - CreateDegreeAngleByValue(5);

            // Assert
            result.ShouldBeOfType<AngleManager.Angle.DegreeAngle>();
            result.Value.ShouldBe(0);
        }

        [TestMethod]
        public void SubtractAngleWithFirstAngleInDegreesAndSecondAngleInRadians()
        {
            // Act
            var result = CreateDegreeAngleByValue(360) - CreateRadianAngleByValue(5);

            // Assert
            result.ShouldBeOfType<AngleManager.Angle.DegreeAngle>();
            result.Value.ShouldBe(360 - ConvertToDegree(5));
        }

        [TestMethod]
        public void SubtractAngleWithFirstAngleInRadianAndSecondAngleInDegrees()
        {
            // Act
            var result = CreateRadianAngleByValue(5) - CreateDegreeAngleByValue(10);

            // Assert
            result.ShouldBeOfType<AngleManager.Angle.RadianAngle>();
            result.Value.ShouldBe(5 - ConvertToRadian(10));
        }

        [TestMethod]
        public void SubtractAngleWithFirstAngleInRadianAndSecondAngleInRadians()
        {
            // Act
            var result = CreateRadianAngleByValue(6) - CreateRadianAngleByValue(6);

            // Assert
            result.ShouldBeOfType<AngleManager.Angle.RadianAngle>();
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
            var result = CreateDegreeAngleByValue(10) * CreateDegreeAngleByValue(5);

            // Assert
            result.ShouldBeOfType<AngleManager.Angle.DegreeAngle>();
            result.Value.ShouldBe(50);
        }

        [TestMethod]
        public void MultiplyAngleWithFirstAngleInDegreesAndSecondAngleInRadians()
        {
            // Act
            var result = CreateDegreeAngleByValue(10) * CreateRadianAngleByValue(0.50);

            // Assert
            result.ShouldBeOfType<AngleManager.Angle.DegreeAngle>();
            result.Value.ShouldBe(10 * ConvertToDegree(0.50));
        }

        [TestMethod]
        public void MultiplyAngleWithFirstAngleInDegreesAndSecondAngleInDouble()
        {
            // Act
            var result = CreateDegreeAngleByValue(10) * 5;

            // Assert
            result.ShouldBeOfType<AngleManager.Angle.DegreeAngle>();
            result.Value.ShouldBe(50);
        }

        [TestMethod]
        public void MultiplyAngleWithFirstAngleInDoubleAndSecondAngleInDegrees()
        {
            // Act
            var result = 5 * CreateDegreeAngleByValue(10);

            // Assert
            result.ShouldBeOfType<AngleManager.Angle.DegreeAngle>();
            result.Value.ShouldBe(50);
        }

        [TestMethod]
        public void MultiplyAngleWithFirstAngleInRadianAndSecondAngleInDegrees()
        {
            // Act
            var result = CreateRadianAngleByValue(2) * CreateDegreeAngleByValue(2);

            // Assert
            result.ShouldBeOfType<AngleManager.Angle.RadianAngle>();
            result.Value.ShouldBe(2 * ConvertToRadian(2));
        }

        [TestMethod]
        public void MultiplyAngleWithFirstAngleInRadianAndSecondAngleInRadians()
        {
            // Act
            var result = CreateRadianAngleByValue(2) * CreateRadianAngleByValue(3);

            // Assert
            result.ShouldBeOfType<AngleManager.Angle.RadianAngle>();
            result.Value.ShouldBe(6);
        }

        [TestMethod]
        public void MultiplyAngleWithFirstAngleInRadianAndSecondAngleInDouble()
        {
            // Act
            var result = CreateRadianAngleByValue(2) * 3;

            // Assert
            result.ShouldBeOfType<AngleManager.Angle.RadianAngle>();
            result.Value.ShouldBe(6);
        }

        [TestMethod]
        public void MultiplyAngleWithFirstAngleInDoubleAndSecondAngleInRadian()
        {
            // Act
            var result = 2 * CreateRadianAngleByValue(3);

            // Assert
            result.ShouldBeOfType<AngleManager.Angle.RadianAngle>();
            result.Value.ShouldBe(6);
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
            var result = CreateDegreeAngleByValue(5) / CreateDegreeAngleByValue(5);

            // Assert
            result.ShouldBeOfType<AngleManager.Angle.DegreeAngle>();
            result.Value.ShouldBe(1);
        }

        [TestMethod]
        public void DivisionAngleWithFirstAngleInDegreesAndSecondAngleInRadians()
        {
            // Act
            var result = CreateDegreeAngleByValue(5) / CreateRadianAngleByValue(0.50);

            // Assert
            result.ShouldBeOfType<AngleManager.Angle.DegreeAngle>();
            result.Value.ShouldBe(5 / ConvertToDegree(0.50));
        }

        [TestMethod]
        public void DivisionAngleWithFirstAngleInDegreesAndSecondAngleInDouble()
        {
            // Act
            var result = CreateDegreeAngleByValue(5) / 5;

            // Assert
            result.ShouldBeOfType<AngleManager.Angle.DegreeAngle>();
            result.Value.ShouldBe(1);
        }

        [TestMethod]
        public void DivisionAngleWithFirstAngleInDoubleAndSecondAngleInDegrees()
        {
            // Act
            var result =  5 / CreateDegreeAngleByValue(5);

            // Assert
            result.ShouldBeOfType<AngleManager.Angle.DegreeAngle>();
            result.Value.ShouldBe(1);
        }

        [TestMethod]
        public void DivisionAngleWithFirstAngleInRadianAndSecondAngleInDegrees()
        {
            // Act
            var result = CreateRadianAngleByValue(5) / CreateDegreeAngleByValue(100);

            // Assert
            result.ShouldBeOfType<AngleManager.Angle.RadianAngle>();
            result.Value.ShouldBe(5 / ConvertToRadian(100));
        }

        [TestMethod]
        public void DivisionAngleWithFirstAngleInRadianAndSecondAngleInRadians()
        {
            // Act
            var result = CreateRadianAngleByValue(5) / CreateRadianAngleByValue(5);

            // Assert
            result.ShouldBeOfType<AngleManager.Angle.RadianAngle>();
            result.Value.ShouldBe(1);
        }

        [TestMethod]
        public void DivisionAngleWithFirstAngleInRadianAndSecondAngleInDouble()
        {
            // Act
            var result = CreateRadianAngleByValue(5) / 5;

            // Assert
            result.ShouldBeOfType<AngleManager.Angle.RadianAngle>();
            result.Value.ShouldBe(1);
        }

        [TestMethod]
        public void DivisionAngleWithFirstAngleInDoubleAndSecondAngleInRadian()
        {
            // Act
            var result = 5 / CreateRadianAngleByValue(5);

            // Assert
            result.ShouldBeOfType<AngleManager.Angle.RadianAngle>();
            result.Value.ShouldBe(1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "The angle value is not in the expected range[0 , 360].")]
        public void DivisionAngleWithFirstAngleInDegreesAndSecondAngleInDegreesExceedsUpperLimit()
        {
            // Arrange and Act
            var result = CreateDegreeAngleByValue(1000) / CreateDegreeAngleByValue(1) / CreateDegreeAngleByValue(2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "The angle degree value is not in the range for division.")]
        public void DivisionAngleWithFirstAngleInDegreesZeroAndSecondAngleInDegreesThrowsException()
        {
            // Arrange and Act
            var result = CreateDegreeAngleByValue(0) / CreateDegreeAngleByValue(1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "The angle degree value is not in the range for division.")]
        public void DivisionAngleWithFirstAngleInRadiansZeroAndSecondAngleInDegreesThrowsException()
        {
            // Arrange and Act
            var result = CreateRadianAngleByValue(0) / CreateDegreeAngleByValue(1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "The angle degree value is not in the range for division.")]
        public void DivisionAngleWithFirstAngleZeroAndSecondAngleInDegreesThrowsException()
        {
            // Arrange and Act
            var result = 0 / CreateDegreeAngleByValue(1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "The angle degree value is not in the range for division.")]
        public void DivisionAngleWithFirstAngleZeroAndSecondAngleInRadianThrowsException()
        {
            // Arrange and Act
            var result = 0 / CreateRadianAngleByValue(1);
        }

        #endregion

        #region Comparison Tests
        [TestMethod]
        public void FirstAngleInDegreesEqualToSecondAngleInDegrees()
        {
            // Act
            var result = CreateDegreeAngleByValue(5) == CreateDegreeAngleByValue(5);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void FirstAngleInDegreesEqualToSecondAngleInRadian()
        {
            // Act
            var result = CreateDegreeAngleByValue(5) == CreateRadianAngleByValue(ConvertToRadian(5));

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void FirstAngleInRadianEqualToSecondAngleInDegrees()
        {
            // Act
            var result = CreateRadianAngleByValue(5) == CreateDegreeAngleByValue(ConvertToDegree(5));

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void FirstAngleInRadianEqualToSecondAngleInRadian()
        {
            // Act
            var result = CreateRadianAngleByValue(5) == CreateRadianAngleByValue(5);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void FirstAngleInDegreesNotEqualToSecondAngleInDegrees()
        {
            // Act
            var result = CreateDegreeAngleByValue(5) != CreateDegreeAngleByValue(6);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void FirstAngleInDegreesNotEqualToSecondAngleInRadian()
        {
            // Act
            var result = CreateDegreeAngleByValue(5) != CreateRadianAngleByValue(ConvertToRadian(6));

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void FirstAngleInRadianNotEqualToSecondAngleInDegrees()
        {
            // Act
            var result = CreateRadianAngleByValue(5) != CreateDegreeAngleByValue(ConvertToDegree(6));

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void FirstAngleInRadianNotEqualToSecondAngleInRadian()
        {
            // Act
            var result = CreateRadianAngleByValue(5) != CreateRadianAngleByValue(6);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void FirstAngleInDegreesGreaterThanSecondAngleInDegrees()
        {
            // Act
            var result = CreateDegreeAngleByValue(5) > CreateDegreeAngleByValue(4);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void FirstAngleInDegreesGreaterThanSecondAngleInRadian()
        {
            // Act
            var result = CreateDegreeAngleByValue(5) > CreateRadianAngleByValue(ConvertToRadian(4));

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void FirstAngleInRadianGreaterThanSecondAngleInDegrees()
        {
            // Act
            var result = CreateRadianAngleByValue(5) > CreateDegreeAngleByValue(ConvertToDegree(4));

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void FirstAngleInRadianGreaterThanSecondAngleInRadian()
        {
            // Act
            var result = CreateRadianAngleByValue(5) > CreateRadianAngleByValue(4);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void FirstAngleInDegreesLesserThanSecondAngleInDegrees()
        {
            // Act
            var result = CreateDegreeAngleByValue(5) < CreateDegreeAngleByValue(6);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void FirstAngleInDegreesLesserThanSecondAngleInRadian()
        {
            // Act
            var result = CreateDegreeAngleByValue(5) < CreateRadianAngleByValue(ConvertToRadian(6));

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void FirstAngleInRadianLesserThanSecondAngleInDegrees()
        {
            // Act
            var result = CreateRadianAngleByValue(5) < CreateDegreeAngleByValue(ConvertToDegree(6));

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void FirstAngleInRadianLesserThanSecondAngleInRadian()
        {
            // Act
            var result = CreateRadianAngleByValue(5) < CreateRadianAngleByValue(6);

            // Assert
            result.ShouldBeTrue();
        }

        #endregion

        #region Modulus Tests
        [TestMethod]
        public void FirstAngleInDegreesModulusToSecondAngleInDegrees()
        {
            // Act
            var result = CreateDegreeAngleByValue(10) % CreateDegreeAngleByValue(2.55);

            // Assert
            result.ShouldBeOfType<DegreeAngle>();
            result.Value.ShouldBe(2.35, 0.0000000000000005);
        }

        [TestMethod]
        public void FirstAngleInDegreesModulusToSecondAngleInRadian()
        {
            // Act
            var result = CreateDegreeAngleByValue(10) % CreateRadianAngleByValue(ConvertToRadian(2.55));

            // Assert
            result.ShouldBeOfType<DegreeAngle>();
            result.Value.ShouldBe(2.35, 0.0000000000000005);
        }

        [TestMethod]
        public void FirstAngleInRadianModulusToSecondAngleInDegrees()
        {
            // Act
            var result = CreateRadianAngleByValue(0.174) % CreateDegreeAngleByValue(ConvertToDegree(0.045));

            // Assert
            result.ShouldBeOfType<RadianAngle>();
            result.Value.ShouldBe(0.039, 0.0000000000000005);
        }

        [TestMethod]
        public void FirstAngleInRadianModulusToSecondAngleInRadian()
        {
            // Act
            var result = CreateRadianAngleByValue(0.174) % CreateRadianAngleByValue(0.045);

            // Assert
            result.ShouldBeOfType<RadianAngle>();
            result.Value.ShouldBe(0.039, 0.0000000000000005);
        }
        #endregion

        private AngleManager.Angle.Angle CreateDegreeAngleByValue(double value)
        {
            return new AngleManager.Angle.DegreeAngle(value);
        }

        private AngleManager.Angle.Angle CreateRadianAngleByValue(double value)
        {
            return new AngleManager.Angle.RadianAngle(value);
        }

        private double ConvertToRadian(double degreeValue)
        {
            return ((Math.PI / 180) * degreeValue);
        }

        private double ConvertToDegree(double radianValue)
        {
            return ((180 / Math.PI) * radianValue);
        }
    }
}
