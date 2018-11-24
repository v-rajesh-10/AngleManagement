using System;
using System.Collections.Generic;
using System.Text;

namespace AngleManager.Angle
{
    /// <summary>
    /// Represents an Angle in the system.
    /// </summary>
    public abstract class Angle : IEquatable<Angle>
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

        /// <summary>
        /// Compare the angle from an existing instance
        /// </summary>
        /// <param name="angle">the angle to the compared</param>
        /// <returns>Positive if the angle is greater and Negative otherwise</returns>
        public abstract int CompareTo(Angle angle);

        #endregion

        #region Base Comparison Implementation
        public override bool Equals(object obj)
        {
            Angle angle = obj as Angle;
            if (angle != null)
            {
                return false;
            }
            return Equals(angle);
        }

        public override int GetHashCode()
        {
            var hashCode = 1571931217;
            hashCode = hashCode * -1521134295 + _value.GetHashCode();
            return hashCode;
        }

        public virtual bool Equals(Angle other)
        {
            return true;
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

        public static Angle operator/ (Angle firstAngle, double secondValue)
        {
            return firstAngle.Divide(secondValue);
        }

        public static Angle operator/ (double firstValue, Angle secondAngle)
        {
            return secondAngle.Divide(firstValue);
        }

        public static bool operator== (Angle firstAngle, Angle secondAngle)
        {
            if (object.ReferenceEquals(firstAngle, secondAngle)) return true;
            if (object.ReferenceEquals(firstAngle, null)) return false;
            if (object.ReferenceEquals(secondAngle, null)) return false;

            return firstAngle.Equals(secondAngle);
        }

        public static bool operator!= (Angle firstAngle, Angle secondAngle)
        {
            if (object.ReferenceEquals(firstAngle, secondAngle)) return false;
            if (object.ReferenceEquals(firstAngle, null)) return true;
            if (object.ReferenceEquals(secondAngle, null)) return true;

            return !firstAngle.Equals(secondAngle);
        }

        public static bool operator< (Angle firstAngle, Angle secondAngle)
        {
            return (0 > firstAngle.CompareTo(secondAngle));
        }

        public static bool operator> (Angle firstAngle, Angle secondAngle)
        {
            return (0 < firstAngle.CompareTo(secondAngle));
        }
        #endregion

    }
}
