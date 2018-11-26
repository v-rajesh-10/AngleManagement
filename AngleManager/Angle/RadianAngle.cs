namespace AngleManager.Angle
{
    using System;
    public class RadianAngle : Angle
    {
        private const double RadianUpperLimit = (Math.PI / 180) * 360;

        #region RadianAngle Constructor

        /// <summary>
        /// Creates an instance of Radian Angle based on the provided value
        /// </summary>
        /// <param name="value">the value of the angle</param>
        /// <exception cref="T:System.InvalidOperationException">value not in range of 0 to 360</exception>
        public RadianAngle(double value) : base(value)
        {
            if (!IsValid())
            {
                throw new InvalidOperationException("The radian angle value is not in the expected range[ " + AngleValueLowerLimit + ", " + RadianUpperLimit + " ].");
            }
        }

        #endregion

        #region Angle Overrides

        protected override Angle Sum(Angle angle)
        {
            return new RadianAngle(Value + angle.ToRadian());
        }

        protected override Angle Difference(Angle angle)
        {
            return new RadianAngle(Value - angle.ToRadian());
        }

        protected override Angle Multiply(Angle angle)
        {
            return Multiply(angle.ToRadian());
        }

        protected override Angle Multiply(double angleValue)
        {
            return new RadianAngle(Value * angleValue);
        }

        protected override Angle Divide(Angle angle)
        {
            var divideRadianValue = angle.ToRadian();
            if (Value <= 0 || divideRadianValue <= 0)
            {
                throw new InvalidOperationException("The angle radian value is not in the range for division.");
            }
            return Divide(divideRadianValue);
        }

        protected override Angle Divide(double angleValue)
        {
            return new RadianAngle(Value / angleValue);
        }

        protected override int CompareTo(Angle angle)
        {
            return Value.CompareTo(angle.ToRadian());
        }

        protected override Angle Modulus(Angle angle)
        {
            return new RadianAngle(Value - (Math.Floor(Value / angle.ToRadian()) * angle.ToRadian()));
        }

        #endregion

        #region Angle Virtual Overrides

        public override double ToDegree()
        {
            return (180 / Math.PI) * Value;
        }

        public override bool IsValid()
        {
            return Value >= AngleValueLowerLimit && Value <= RadianUpperLimit;
        }

        #endregion

        #region Casting Operations
        public static explicit operator RadianAngle(DegreeAngle angle)
        {
            return new RadianAngle(angle.ToRadian());
        }
        #endregion

        #region Angle IEquatable Overrides
        public override bool Equals(Angle other)
        {
            return other != null && Value.Equals(other.ToRadian());
        }
        #endregion
    }
}
