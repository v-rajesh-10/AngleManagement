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

        #region Angle Constructor

        /// <summary>
        /// Prevent access to invoking default contrcutor from the dervied classes
        /// </summary>
        private Angle() { }

        /// <summary>
        /// Serves as the default constructor for the dervied classes
        /// </summary>
        /// <param name="value">the angular value</param>
        public Angle(double value)
        {
            _value = value;
        }
        #endregion

        public double Value { get => _value; }

        #region Angle Common Impmentation For Derived Classes
        /// <summary>
        /// Converts Degree to Radian
        /// </summary>
        /// <returns>the radian value</returns>
        /// <see cref="RadianAngle"/>
        public virtual double ToRadian()
        {
            return this.Value;
        }

        /// <summary>
        /// Converts Radian to Degree
        /// </summary>
        /// <returns>the degree value</returns>
        /// <see cref="DegreeAngle"/>
        public virtual double ToDegree()
        {
            return this.Value;
        }

        /// <summary>
        /// Validates the Angle Instance 
        /// </summary>
        /// <returns>true if the instance is valid, false otherwise</returns>
        public virtual bool IsValid()
        {
            return true;
        }
        #endregion

        #region Angle Overrides

        /// <summary>
        /// Adds the angle to an existing instance.
        /// </summary>
        /// <param name="angle">the angle to the added</param>
        /// <returns>new instance of angle with values added represented by <code>Angle</code></returns>
        protected abstract Angle Sum(Angle angle);

        /// <summary>
        /// Subtract the angle from an existing instance.
        /// </summary>
        /// <param name="angle">the angle to the subtracted</param>
        /// <returns>new instance of angle with value subtracted represented by <code>Angle</code></returns>
        protected abstract Angle Difference(Angle angle);

        /// <summary>
        /// Multiply the angle to an existing instance
        /// </summary>
        /// <param name="angle">the angle to the multiplied</param>
        /// <returns>new instance of angle with value multiplied represented by <code>Angle</code></returns>
        protected abstract Angle Multiply(Angle angle);

        /// <summary>
        /// Multiply the angle to an existing literal
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>new instance of angle with value multiplied represented by <code>Angle</code></returns>
        protected abstract Angle Multiply(double angleValue);

        /// <summary>
        /// Divide the angle from an existing instance
        /// </summary>
        /// <param name="angle">the angle to the divided</param>
        /// <returns>new instance of angle with value divided represented by <code>Angle</code></returns>
        protected abstract Angle Divide(Angle angle);

        /// <summary>
        /// Divide the angle from an existing literal
        /// </summary>
        /// <param name="angle">the angle to the divided</param>
        /// <returns>new instance of angle with value divided represented by <code>Angle</code></returns>
        protected abstract Angle Divide(double angleValue);

        /// <summary>
        /// Compare the angle from an existing instance
        /// </summary>
        /// <param name="angle">the angle to the compared</param>
        /// <returns>Positive if the angle is greater and Negative otherwise</returns>
        protected abstract int CompareTo(Angle angle);

        /// <summary>
        /// Perform modulus operation from an existing instance
        /// </summary>
        /// <param name="angle">the angle to the modulus needs to be performed</param>
        /// <returns>new instance of angle with modulus result represented by <code>Angle</code></returns>
        protected abstract Angle Modulus(Angle angle);

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

        public static Angle operator% (Angle firstAngle, Angle secondAngle)
        {
            return (firstAngle.Modulus(secondAngle));
        }

        #endregion

    }
}
