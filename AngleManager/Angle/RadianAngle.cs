using System;
using System.Collections.Generic;
using System.Text;

namespace AngleManager.Angle
{
    public class RadianAngle : Angle
    {
        private static readonly double RADIAN_UPPER_LIMIT = ConvertToRadian(DegreeAngle.DEGREE_VALUE_UPPER_LIMIT);
        #region RadianAngle construction

        /// <summary>
        /// Creates an instance of Radian Angle based on the provided value
        /// </summary>
        /// <param name="value">the value of the angle</param>
        /// <exception cref="InvalidOperationException">value not in range of 0 to 360</exception>
        public RadianAngle(double value)
        {
            Value = value;
            if (!IsValid())
            {
                throw new InvalidOperationException("The radian angle value is not in the expected range[ " + ANGLE_VALUE_LOWER_LIMIT + ", " + RADIAN_UPPER_LIMIT + " ].");
            }
        }

        #endregion

        #region Override IAngleOperations

        public override bool IsValid()
        {
            if (Value >= ANGLE_VALUE_LOWER_LIMIT && Value <= RADIAN_UPPER_LIMIT)
            {
                return true;
            }
            return false;
        }

        public override Angle Sum(Angle angle)
        {
            double addRadianValue = angle.Value;
            if (!IsSameUnit(angle))
            {
                addRadianValue = ConvertToRadian(angle.Value);
            }
            return new RadianAngle(this.Value + addRadianValue);
        }

        public override Angle Difference(Angle angle)
        {
            double subtractRadianValue = angle.Value;
            if (!IsSameUnit(angle))
            {
                subtractRadianValue = ConvertToRadian(angle.Value);
            }
            return new RadianAngle(this.Value - subtractRadianValue);
        }

        public override Angle Multiply(Angle angle)
        {
            double multiplyRadianValue = angle.Value;
            if (!IsSameUnit(angle))
            {
                multiplyRadianValue = ConvertToRadian(angle.Value);
            }
            return Multiply(multiplyRadianValue);
        }

        public override Angle Multiply(double angleValue)
        {
            return new RadianAngle(this.Value * angleValue);
        }

        public override Angle Divide(Angle angle)
        {
            double divideRadianValue = angle.Value;
            if (!IsSameUnit(angle))
            {
                divideRadianValue = ConvertToRadian(angle.Value);
            }
            if (this.Value <= 0 || angle.Value <= 0)
            {
                throw new InvalidOperationException("The angle radian value is not in the range for division.");
            }
            return Divide(divideRadianValue);
        }

        public override Angle Divide(double angleValue)
        {
            return new RadianAngle(this.Value / angleValue);
        }
        #endregion

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
