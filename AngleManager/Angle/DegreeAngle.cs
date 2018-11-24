using System;
using System.Collections.Generic;
using System.Text;

namespace AngleManager.Angle
{
    /// <summary>
    /// Represents the Degree Angle which extends the Angle base class exposed to the consumer
    /// </summary>
    public class DegreeAngle : Angle
    {
        public static readonly double DEGREE_VALUE_UPPER_LIMIT = 360;

        #region DegreeAngle construction

        /// <summary>
        /// Creates an instance of Radian Angle based on the provided value
        /// </summary>
        /// <param name="value">the value of the angle</param>
        /// <exception cref="InvalidOperationException">value not in range of 0 to 360</exception>
        public DegreeAngle(double value)
        {
            Value = value;
            if (!IsValid())
            {
                throw new InvalidOperationException("The degree angle value is not in the expected range[ " + ANGLE_VALUE_LOWER_LIMIT + ", " + DEGREE_VALUE_UPPER_LIMIT + " ].");
            }
        }

        #endregion

        #region Override IAngleOperations

        public override bool IsValid()
        {
            if (Value >= ANGLE_VALUE_LOWER_LIMIT && Value <= DEGREE_VALUE_UPPER_LIMIT)
            {
                return true;
            }
            return false;
        }

        public override Angle Sum(Angle angle)
        {
            double addDegreeValue = angle.Value;
            if (!IsSameUnit(angle))
            {
                addDegreeValue = ConvertToDegree(angle.Value);
            }
            return new DegreeAngle(this.Value + addDegreeValue);
        }

        public override Angle Difference(Angle angle)
        {
            double subtractDegreeValue = angle.Value;
            if (!IsSameUnit(angle))
            {
                subtractDegreeValue = ConvertToDegree(angle.Value);
            }
            return new DegreeAngle(this.Value - subtractDegreeValue);
        }

        public override Angle Multiply(Angle angle)
        {
            double multiplyDegreeValue = angle.Value;
            if (!IsSameUnit(angle))
            {
                multiplyDegreeValue = ConvertToDegree(angle.Value);
            }
            return Multiply(multiplyDegreeValue);
        }

        public override Angle Multiply(double angleValue)
        {
            return new DegreeAngle(this.Value * angleValue);
        }

        public override Angle Divide(Angle angle)
        {
            double divideDegreeValue = angle.Value;
            if (!IsSameUnit(angle))
            {
                divideDegreeValue = ConvertToDegree(angle.Value);
            }
            return Divide(divideDegreeValue);
        }

        public override Angle Divide(double angleValue)
        {
            if (this.Value <= 0 || angleValue <= 0)
            {
                throw new InvalidOperationException("The angle degree value is not in the range for division.");
            }
            return new DegreeAngle(this.Value / angleValue);
        }

        public override int CompareTo(Angle angle)
        {
            double angleValue = angle.Value;
            if (!IsSameUnit(angle))
            {
                angleValue = ConvertToDegree(angle.Value);
            }
            return this.Value.CompareTo(angleValue);
        }
        #endregion

        public override bool Equals(Angle other)
        {
            double otherValue = other.Value;
            if (!IsSameUnit(other))
            {
                otherValue = ConvertToDegree(other.Value);
            }
            return (0 == this.Value.CompareTo(otherValue));
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
