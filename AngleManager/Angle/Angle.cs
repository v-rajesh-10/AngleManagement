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

        #region Angle Constructor

        /// <summary>
        /// Serves as the default constructor for the dervied classes
        /// </summary>
        /// <param name="value">the angular value</param>
        public Angle(double value)
        {
            Value = value;
        }
        #endregion

        #region Angle ReadOnly Values

        public double Value { get; }

        public double SineValue
        {
            get
            {
                return Math.Sin(ToRadian());
            }
        }

        public double ArcSinValue
        {
            get
            {
                return Math.Asin(ToRadian());
            }
        }

        public double CosValue
        {
            get
            {
                return Math.Cos(ToRadian());
            }
        }

        public double ArcCosValue()
        {
            return Math.Acos(ToRadian());
        }

        public double TanValue
        {
            get
            {
                return Math.Tan(ToRadian());
            }
        }

        public double ArcTanValue
        {
            get
            {
                return Math.Atan(ToRadian());
            }

        }

        #endregion

        #region Angle Virtual Members

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

        #region Basic Trignometric Functions

        /// <summary>
        /// Sin of an angle
        /// </summary>
        /// <returns>A new instance <code>RadianAngle</code>with a sine value</returns>
        public Angle Sin()
        {
            return new RadianAngle(Math.Sin(ToRadian()));
        }

        /// <summary>
        /// ArcSin of an angle
        /// </summary>
        /// <returns>A new instance <code>RadianAngle</code>with an arcsine value</returns>
        public Angle ArcSin()
        {
            return new RadianAngle(Math.Asin(ToRadian()));
        }

        /// <summary>
        /// Cos of an angle
        /// </summary>
        /// <returns>A new instance <code>RadianAngle</code>with an cos value</returns>
        public Angle Cos()
        {
            return new RadianAngle(Math.Cos(ToRadian()));
        }

        /// <summary>
        /// ArcCos of an angle
        /// </summary>
        /// <returns>A new instance <code>RadianAngle</code>with an arccos value</returns>
        public Angle ArcCos()
        {
            return new RadianAngle(Math.Acos(ToRadian()));
        }

        /// <summary>
        /// Tan of an angle
        /// </summary>
        /// <returns>A new instance <code>RadianAngle</code>with an tan value</returns>
        public Angle Tan()
        {
            return new RadianAngle(Math.Tan(ToRadian()));
        }

        /// <summary>
        /// ArcTan of an angle
        /// </summary>
        /// <returns>A new instance <code>RadianAngle</code>with an arctan value</returns>
        public Angle ArcTan()
        {
            return new RadianAngle(Math.Atan(ToRadian()));
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

        #region Angle IEquatable Declarations

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
            hashCode = hashCode * -1521134295 + Value.GetHashCode();
            return hashCode;
        }

        public virtual bool Equals(Angle other)
        {
            return true;
        }

        #endregion

        #region Angle Supported Operations

        /// <summary>
        /// Addition operation on angles
        /// </summary>
        /// <param name="firstAngle">lhs of the operand</param>
        /// <param name="secondAngle">rhs of the operand</param>
        /// <returns>new instance of angle with values added represented by <code>Angle</code></returns>
        /// <seealso cref="Angle.Sum(Angle)"/>
        public static Angle operator+ (Angle firstAngle, Angle secondAngle)
        {
            return firstAngle.Sum(secondAngle);
        }

        /// <summary>
        /// Subtraction operation of angles
        /// </summary>
        /// <param name="firstAngle">lhs of the operand</param>
        /// <param name="secondAngle">rhs of the operand</param>
        /// <returns>new instance of angle with values subtracted represented by <code>Angle</code></returns>
        /// <seealso cref="Angle.Difference(Angle)"/>
        public static Angle operator- (Angle firstAngle, Angle secondAngle)
        {
            return firstAngle.Difference(secondAngle);
        }

        /// <summary>
        /// Multiplication operation on angles
        /// </summary>
        /// <param name="firstAngle">lhs of the operand</param>
        /// <param name="secondAngle">rhs of the operand</param>
        /// <returns>new instance of angle with values multiplication represented by <code>Angle</code></returns>
        /// <seealso cref="Angle.Multiply(Angle)"/>
        public static Angle operator* (Angle firstAngle, Angle secondAngle)
        {
            return firstAngle.Multiply(secondAngle);
        }

        /// <summary>
        /// Multiplication operation on angles
        /// </summary>
        /// <param name="firstAngle">lhs of the operand</param>
        /// <param name="secondValue">double value</param>
        /// <returns>new instance of angle with values multiplication represented by <code>Angle</code></returns>
        /// <seealso cref="Angle.Multiply(double)"/>
        public static Angle operator* (Angle firstAngle, double secondValue)
        {
            return firstAngle.Multiply(secondValue);
        }

        /// <summary>
        /// Multiplication operation on angles
        /// </summary>
        /// <param name="firstValue">double value</param>
        /// <param name="secondAngle">rhs of the operand</param>
        /// <returns>new instance of angle with values multiplication represented by <code>Angle</code></returns>
        /// <seealso cref="Angle.Multiply(double)"/>
        public static Angle operator* (double firstValue, Angle secondAngle)
        {
            return secondAngle.Multiply(firstValue);
        }

        /// <summary>
        /// Division operation of angles
        /// </summary>
        /// <param name="firstAngle">double value</param>
        /// <param name="secondAngle">rhs of the operand</param>
        /// <returns>new instance of angle with values divided represented by <code>Angle</code></returns>
        /// <seealso cref="Angle.Divide(Angle)"/>
        public static Angle operator/ (Angle firstAngle, Angle secondAngle)
        {
            return firstAngle.Divide(secondAngle);
        }

        /// <summary>
        /// Division operation on angles
        /// </summary>
        /// <param name="firstAngle">lhs of the operand</param>
        /// <param name="secondValue">double value</param>
        /// <returns>new instance of angle with values divided represented by <code>Angle</code></returns>
        /// <seealso cref="Angle.Divide(double)"/>
        public static Angle operator/ (Angle firstAngle, double secondValue)
        {
            return firstAngle.Divide(secondValue);
        }

        /// <summary>
        /// Division operation of angles
        /// </summary>
        /// <param name="firstValue">double value</param>
        /// <param name="secondAngle">lhs of the operand</param>
        /// <returns>new instance of angle with values divided represented by <code>Angle</code></returns>
        /// <seealso cref="Angle.Divide(double)"/>
        public static Angle operator/ (double firstValue, Angle secondAngle)
        {
            return secondAngle.Divide(firstValue);
        }

        /// <summary>
        /// Equals operation on angles
        /// </summary>
        /// <param name="firstAngle">lhs of the operand</param>
        /// <param name="secondAngle">rhs of the operand</param>
        /// <returns>true if the values of the angle are equal, false otherwise</returns>
        /// <seealso cref="Angle.Equals(Angle)"/>
        public static bool operator== (Angle firstAngle, Angle secondAngle)
        {
            if (object.ReferenceEquals(firstAngle, secondAngle)) return true;
            if (object.ReferenceEquals(firstAngle, null)) return false;
            if (object.ReferenceEquals(secondAngle, null)) return false;

            return firstAngle.Equals(secondAngle);
        }

        /// <summary>
        /// Equals operation on angles
        /// </summary>
        /// <param name="firstAngle">lhs of the operand</param>
        /// <param name="secondAngle">rhs of the operand</param>
        /// <returns>true if the values of the angle are NOT equal, false otherwise</returns>
        /// <seealso cref="Angle.Equals(Angle)"/>
        public static bool operator!= (Angle firstAngle, Angle secondAngle)
        {
            if (object.ReferenceEquals(firstAngle, secondAngle)) return false;
            if (object.ReferenceEquals(firstAngle, null)) return true;
            if (object.ReferenceEquals(secondAngle, null)) return true;

            return !firstAngle.Equals(secondAngle);
        }

        /// <summary>
        /// Lesser than operation on angles
        /// </summary>
        /// <param name="firstAngle">lhs of the operand</param>
        /// <param name="secondAngle">rhs of the operand</param>
        /// <returns>true if the firstAngle is lesser than secondAngle, false otherwise</returns>
        /// <seealso cref="Angle.CompareTo(Angle)"/>
        public static bool operator< (Angle firstAngle, Angle secondAngle)
        {
            return (0 > firstAngle.CompareTo(secondAngle));
        }

        /// <summary>
        /// Greater than operation on angles
        /// </summary>
        /// <param name="firstAngle">lhs of the operand</param>
        /// <param name="secondAngle">rhs of the operand</param>
        /// <returns>true if the firstAngle is greater than secondAngle, false otherwise</returns>
        /// <seealso cref="Angle.CompareTo(Angle)"/>
        public static bool operator> (Angle firstAngle, Angle secondAngle)
        {
            return (0 < firstAngle.CompareTo(secondAngle));
        }

        /// <summary>
        /// Greater than operation on angles
        /// </summary>
        /// <param name="firstAngle">lhs of the operand</param>
        /// <param name="secondAngle">rhs of the operand</param>
        /// <returns>new instance of angle with modulus value represented by <code>Angle</code></returns>
        /// <seealso cref="Angle.Modulus(Angle)"/>
        public static Angle operator% (Angle firstAngle, Angle secondAngle)
        {
            return (firstAngle.Modulus(secondAngle));
        }

        #endregion

    }
}
