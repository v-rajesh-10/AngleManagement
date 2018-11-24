using System;
using System.Collections.Generic;
using System.Text;
using static AngleManager.Angle.AngularUnits;

namespace AngleManager.Angle
{
    /// <summary>
    /// Represents the Degree Angle which extends the Angle base class exposed to the consumer
    /// </summary>
    internal sealed class DegreeAngle : Angle
    {
        private static readonly UnitType DEGREE_TYPE = UnitType.DEGREE;

        #region DegreeAngle construction

        /// <summary>
        /// Constructor declared internal to prevent direct instantiation by external consumers outside the assembly
        /// </summary>
        /// <param name="value">the value of the angle</param>
        /// <exception cref="InvalidOperationException"></exception>
        internal DegreeAngle(double value)
        {
            Value = value;
            Unit = DEGREE_TYPE;
            Validate();
        }

        #endregion

        #region Override IAngleOperations

        public override Angle Sum(Angle angle)
        {
            double addDegreeValue = angle.Value;
            if (!IsUnitTypeSame(angle))
            {
                addDegreeValue = ConvertorsUtil.RadianToDegree(angle.Value);
            }
            return new DegreeAngle(this.Value + addDegreeValue);
        }

        public override Angle Difference(Angle angle)
        {
            double subtractDegreeValue = angle.Value;
            if (!IsUnitTypeSame(angle))
            {
                subtractDegreeValue = ConvertorsUtil.RadianToDegree(angle.Value);
            }
            return new DegreeAngle(this.Value - subtractDegreeValue);
        }

        public override Angle Multiply(Angle angle)
        {
            double multiplyDegreeValue = angle.Value;
            if (!IsUnitTypeSame(angle))
            {
                multiplyDegreeValue = ConvertorsUtil.RadianToDegree(angle.Value);
            }
            return Multiply(multiplyDegreeValue);
        }

        public override Angle Multiply(double angleValue)
        {
            return new DegreeAngle(this.Value * angleValue);
        }

        public override Angle Divide(Angle angle)
        {
            double divideDegreeValue = angle.Value;
            if (!IsUnitTypeSame(angle))
            {
                divideDegreeValue = ConvertorsUtil.RadianToDegree(angle.Value);
            }
            if (this.Value <= 0 || angle.Value <= 0)
            {
                throw new InvalidOperationException("The angle degree value is not in the range for division.");
            }
            return Divide(divideDegreeValue);
        }

        public override Angle Divide(double angleValue)
        {
            return new DegreeAngle(this.Value / angleValue);
        }
        #endregion

        public override string ToString()
        {
            return base.ToString();
        }

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
