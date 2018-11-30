namespace AngleManager.Angle
{
    using System;
    /// <summary>
    /// Represents the Degree Angle which extends the Angle base class exposed to the consumer
    /// </summary>
    public class DegreeAngle : Angle
    {
        private const double DegreeValueUpperLimit = 360;

        #region DegreeAngle Constructor

        /// <summary>
        /// Creates an instance of Degree Angle based on the provided value
        /// </summary>
        /// <param name="value">the value of the angle</param>
        /// <exception cref="InvalidOperationException">value not in range of 0 to 360</exception>
        public DegreeAngle(double value) : base(value)
        {
            if (!IsValid())
            {
                throw new InvalidOperationException("The degree angle value is not in the expected range[ " + AngleValueLowerLimit + ", " + DegreeValueUpperLimit + " ].");
            }
        }

        #endregion

        #region Angle Overrides

        protected override Angle Sum(Angle angle)
        {
            return new DegreeAngle(Value + angle.To<DegreeAngle>().Value);
        }

        protected override Angle Difference(Angle angle)
        {
            return new DegreeAngle(Value - angle.To<DegreeAngle>().Value);
        }

        protected override Angle Multiply(Angle angle)
        {
            return Multiply(angle.To<DegreeAngle>().Value);
        }

        protected override Angle Multiply(double angleValue)
        {
            return new DegreeAngle(Value * angleValue);
        }

        protected override Angle Divide(Angle angle)
        {
            return Divide(angle.To<DegreeAngle>().Value);
        }

        protected override Angle Divide(double angleValue)
        {
            if (Value <= 0 || angleValue <= 0)
            {
                throw new InvalidOperationException("The angle degree value is not in the range for division.");
            }
            return new DegreeAngle(Value / angleValue);
        }

        protected override int CompareTo(Angle angle)
        {
            return Value.CompareTo(angle.To<DegreeAngle>().Value);
        }

        protected override Angle Modulus(Angle angle)
        {
            return new DegreeAngle(Value - (Math.Floor(Value / angle.To<DegreeAngle>().Value) * angle.To<DegreeAngle>().Value));
        }

        #endregion

        #region Angle Virtual Overrides

        public override bool IsValid()
        {
            if (Value >= AngleValueLowerLimit && Value <= DegreeValueUpperLimit)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region Casting Operations
        public static explicit operator DegreeAngle(RadianAngle angle)
        {
            return new DegreeAngle(angle.To<DegreeAngle>().Value);
        }
        #endregion

        #region Angle IEquatable Overrides
        public override bool Equals(Angle other)
        {
            return other != null && 0 == Value.CompareTo(other.To<DegreeAngle>().Value);
        }
        #endregion
    }
}
