using System;
using System.Collections.Generic;
using System.Text;

namespace AngleManager.Angle
{
    /// <summary>
    /// Represents an Angle in the system.
    /// </summary>
    public abstract class Angle
    {
        public static readonly double ANGLE_VALUE_LOWER_LIMIT = 0;
        /// the value of the angle
        private double _value;

        public double Value { get => _value; protected set => _value = value; }

        #region Angle Common Impmentation For Derived Classes
        public static double ConvertToRadian(double degreeValue)
        {
            return ((Math.PI / 180) * degreeValue);
        }

        public static double ConvertToDegree(double radianValue)
        {
            return ((180 / Math.PI) * radianValue);
        }

        protected bool IsSameUnit(Angle targetAngle)
        {
            return GetType().Equals(targetAngle.GetType());
        }

        #endregion

        #region Angle Overrides

        /// <summary>
        /// Validates the Angle Instance 
        /// </summary>
        /// <returns>true if the instance is valid, false otherwise</returns>
        public abstract bool IsValid();

        /// <summary>
        /// Adds the angle to an existing instance.
        /// </summary>
        /// <param name="angle">the angle to the added</param>
        /// <returns>new instance of angle with values added represented by <code>Angle</code></returns>
        public abstract Angle Sum(Angle angle);

        /// <summary>
        /// Subtract the angle from an existing instance.
        /// </summary>
        /// <param name="angle">the angle to the subtracted</param>
        /// <returns>new instance of angle with value subtracted represented by <code>Angle</code></returns>
        public abstract Angle Difference(Angle angle);

        /// <summary>
        /// Multiply the angle to an existing instance
        /// </summary>
        /// <param name="angle">the angle to the multiplied</param>
        /// <returns>new instance of angle with value multiplied represented by <code>Angle</code></returns>
        public abstract Angle Multiply(Angle angle);

        /// <summary>
        /// Multiply the angle to an existing literal
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>new instance of angle with value multiplied represented by <code>Angle</code></returns>
        public abstract Angle Multiply(double angleValue);

        /// <summary>
        /// Divide the angle from an existing instance
        /// </summary>
        /// <param name="angle">the angle to the divided</param>
        /// <returns>new instance of angle with value divided represented by <code>Angle</code></returns>
        public abstract Angle Divide(Angle angle);

        /// <summary>
        /// Divide the angle from an existing literal
        /// </summary>
        /// <param name="angle">the angle to the divided</param>
        /// <returns>new instance of angle with value divided represented by <code>Angle</code></returns>
        public abstract Angle Divide(double angleValue);
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

        public static Angle operator/ (Angle firstAngle, double secondValue)
        {
            return firstAngle.Divide(secondValue);
        }

        public static Angle operator /(double firstValue, Angle secondAngle)
        {
            return secondAngle.Divide(firstValue);
        }
        #endregion

    }
}
