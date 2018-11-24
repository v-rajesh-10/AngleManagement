using System;
using System.Collections.Generic;
using System.Text;
using static AngleManager.Angle.AngularUnits;

namespace AngleManager.Angle
{
    /// <summary>
    /// Represents an Angle in the system.
    /// </summary>
    public abstract class Angle : IBasicOperations
    {
        private static readonly double VALUE_LOWER_LIMIT = 0;
        private static readonly double VALUE_UPPER_LIMIT = 360;

        /// the value of the angle
        private double _value;

        /// the angular unit reprsented by <code>Unit</code>
        private UnitType _unit;

        public double Value { get => _value; protected set => _value = value; }
        public UnitType Unit { get => _unit; protected set => _unit = value; }

        #region Angle Builder and Validation

        /// <summary>
        /// Builds the Agent Builder which can be directly invoked by the consumer using a builder pattern.
        /// <seealso cref="AngleBuilder"/>
        /// </summary>
        /// <returns>the builder instance represented by <code>AngleBuilder</code></returns>
        public static AngleBuilder Builder()
        {
            return AngleBuilder.Create();
        }

        public abstract Angle Sum(Angle angle);

        public abstract Angle Difference(Angle angle);

        public abstract Angle Multiply(Angle angle);

        public abstract Angle Multiply(double angleValue);

        public abstract Angle Divide(Angle angle);

        public abstract Angle Divide(double angleValue);

        protected void Validate()
        {
            if (Value > VALUE_UPPER_LIMIT || Value < VALUE_LOWER_LIMIT)
            {
                throw new InvalidOperationException("The angle value is not in the expected range[ " + VALUE_LOWER_LIMIT + ", " + VALUE_UPPER_LIMIT + " ].");
            }
        }

        protected bool IsUnitTypeSame(Angle targetAngle)
        {
            return this.Unit == targetAngle.Unit;
        }
        #endregion

        #region Angle Operations
        public static Angle operator+ (Angle firstAngle, Angle secondAngle)
        {
            return firstAngle.Sum(secondAngle);
        }

        public static Angle operator- (Angle firstAngle, Angle secondAngle)
        {
            return firstAngle.Difference(secondAngle);
        }

        public static Angle operator* (Angle firstAngle, Angle secondAngle)
        {
            return firstAngle.Multiply(secondAngle);
        }

        public static Angle operator* (Angle firstAngle, double secondValue)
        {
            return firstAngle.Multiply(secondValue);
        }

        public static Angle operator* (double firstValue, Angle secondAngle)
        {
            return secondAngle.Multiply(firstValue);
        }

        public static Angle operator/ (Angle firstAngle, Angle secondAngle)
        {
            return firstAngle.Divide(secondAngle);
        }

        public static Angle operator /(Angle firstAngle, double secondValue)
        {
            return firstAngle.Divide(secondValue);
        }
        #endregion
    }
}
