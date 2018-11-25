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
        /// Creates an instance of Degree Angle based on the provided value
        /// </summary>
        /// <param name="value">the value of the angle</param>
        /// <exception cref="InvalidOperationException">value not in range of 0 to 360</exception>
        public DegreeAngle(double value) : base(value)
        {
            if (!IsValid())
            {
                throw new InvalidOperationException("The degree angle value is not in the expected range[ " + ANGLE_VALUE_LOWER_LIMIT + ", " + DEGREE_VALUE_UPPER_LIMIT + " ].");
            }
        }

        #endregion

        #region Override IAngleOperations

        protected override Angle Sum(Angle angle)
        {
            return new DegreeAngle(this.Value + angle.ToDegree());
        }

        protected override Angle Difference(Angle angle)
        {
            return new DegreeAngle(this.Value - angle.ToDegree());
        }

        protected override Angle Multiply(Angle angle)
        {
            return Multiply(angle.ToDegree());
        }

        protected override Angle Multiply(double angleValue)
        {
            return new DegreeAngle(this.Value * angleValue);
        }

        protected override Angle Divide(Angle angle)
        {
            return Divide(angle.ToDegree());
        }

        protected override Angle Divide(double angleValue)
        {
            if (this.Value <= 0 || angleValue <= 0)
            {
                throw new InvalidOperationException("The angle degree value is not in the range for division.");
            }
            return new DegreeAngle(this.Value / angleValue);
        }

        protected override int CompareTo(Angle angle)
        {
            return this.Value.CompareTo(angle.ToDegree());
        }

        protected override Angle Modulus(Angle angle)
        {
            return new DegreeAngle(this.Value - Math.Floor(this.Value / angle.ToDegree()) * angle.ToDegree());
        }

        public override double ToRadian()
        {
            return ((Math.PI / 180) * Value);
        }

        public override bool IsValid()
        {
            if (Value >= ANGLE_VALUE_LOWER_LIMIT && Value <= DEGREE_VALUE_UPPER_LIMIT)
            {
                return true;
            }
            return false;
        }
        #endregion

        public override bool Equals(Angle other)
        {
            return (0 == this.Value.CompareTo(other.ToDegree()));
        }
    }
}
