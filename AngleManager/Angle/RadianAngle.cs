using System;
using System.Collections.Generic;
using System.Text;

namespace AngleManager.Angle
{
    public class RadianAngle : Angle
    {
        private static readonly double RADIAN_UPPER_LIMIT = ((Math.PI / 180) * 360);
        #region RadianAngle construction

        /// <summary>
        /// Creates an instance of Radian Angle based on the provided value
        /// </summary>
        /// <param name="value">the value of the angle</param>
        /// <exception cref="InvalidOperationException">value not in range of 0 to 360</exception>
        public RadianAngle(double value) : base(value)
        {
            if (!IsValid())
            {
                throw new InvalidOperationException("The radian angle value is not in the expected range[ " + ANGLE_VALUE_LOWER_LIMIT + ", " + RADIAN_UPPER_LIMIT + " ].");
            }
        }

        #endregion

        #region Override IAngleOperations

        protected override Angle Sum(Angle angle)
        {
            return new RadianAngle(this.Value + angle.ToRadian());
        }

        protected override Angle Difference(Angle angle)
        {
            return new RadianAngle(this.Value - angle.ToRadian());
        }

        protected override Angle Multiply(Angle angle)
        {
            return Multiply(angle.ToRadian());
        }

        protected override Angle Multiply(double angleValue)
        {
            return new RadianAngle(this.Value * angleValue);
        }

        protected override Angle Divide(Angle angle)
        {
            double divideRadianValue = angle.ToRadian();
            if (this.Value <= 0 || divideRadianValue <= 0)
            {
                throw new InvalidOperationException("The angle radian value is not in the range for division.");
            }
            return Divide(divideRadianValue);
        }

        protected override Angle Divide(double angleValue)
        {
            return new RadianAngle(this.Value / angleValue);
        }

        protected override int CompareTo(Angle angle)
        {
            return this.Value.CompareTo(angle.ToRadian());
        }

        protected override Angle Modulus(Angle angle)
        {
            return new RadianAngle(this.Value - Math.Floor(this.Value / angle.ToRadian()) * angle.ToRadian());
        }

        public override double ToDegree()
        {
            return ((180 / Math.PI) * this.Value);
        }

        public override bool IsValid()
        {
            if (Value >= ANGLE_VALUE_LOWER_LIMIT && Value <= RADIAN_UPPER_LIMIT)
            {
                return true;
            }
            return false;
        }
        #endregion

        public override bool Equals(Angle other)
        {
            return this.Value.Equals(other.ToRadian());
        }
    }
}
