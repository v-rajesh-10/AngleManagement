using System;
using System.Collections.Generic;
using System.Text;
using static AngleManager.Angle.AngularUnits;

namespace AngleManager.Angle
{
    internal sealed class RadianAngle : Angle
    {
        private static readonly UnitType RADIAN_TYPE = UnitType.RADIAN;
        
        #region RadianAngle construction

        /// <summary>
        /// Constructor declared internal to prevent direct instantiation by external consumers outside the assembly
        /// </summary>
        /// <param name="value">the value of the angle</param>
        /// <exception cref="InvalidOperationException"></exception>
        internal RadianAngle(double value)
        {
            Value = value;
            Unit = RADIAN_TYPE;
            Validate();
        }

        #endregion

        #region Override IAngleOperations

        public override Angle Sum(Angle angle)
        {
            double addRadianValue = angle.Value;
            if (!IsUnitTypeSame(angle))
            {
                addRadianValue = ConvertorsUtil.DegreeToRadian(angle.Value);
            }
            return new RadianAngle(this.Value + addRadianValue);
        }

        public override Angle Difference(Angle angle)
        {
            double subtractRadianValue = angle.Value;
            if (!IsUnitTypeSame(angle))
            {
                subtractRadianValue = ConvertorsUtil.DegreeToRadian(angle.Value);
            }
            return new RadianAngle(this.Value - subtractRadianValue);
        }

        public override Angle Multiply(Angle angle)
        {
            double multiplyRadianValue = angle.Value;
            if (!IsUnitTypeSame(angle))
            {
                multiplyRadianValue = ConvertorsUtil.DegreeToRadian(angle.Value);
            }
            return Multiply(multiplyRadianValue);
        }

        public override Angle Multiply(double angleValue)
        {
            return new RadianAngle(this.Value * angleValue);
        }

        public override Angle Divide(Angle angle)
        {
            double divideRadianValue = angle.Value;
            if (!IsUnitTypeSame(angle))
            {
                divideRadianValue = ConvertorsUtil.DegreeToRadian(angle.Value);
            }
            if (this.Value <= 0 || angle.Value <= 0)
            {
                throw new InvalidOperationException("The angle radian value is not in the range for division.");
            }
            return Divide(divideRadianValue);
        }

        public override Angle Divide(double angleValue)
        {
            return new RadianAngle(this.Value / angleValue);
        }
        #endregion

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return base.ToString();
        }

    }
}
