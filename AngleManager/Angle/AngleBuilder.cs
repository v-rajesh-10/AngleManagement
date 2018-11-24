using System;
using System.Collections.Generic;
using System.Text;
using static AngleManager.Angle.AngularUnits;

namespace AngleManager.Angle
{
    public class AngleBuilder : AbstractExpressionBuilder
    {
        private double _value;

        private UnitType _unit = UnitType.NOT_SUPPORTED_BY_VERSION;

        public double Value { get => _value; private set => _value = value; }
        public UnitType Unit { get => _unit; private set => _unit = value; }

        /// <summary>
        /// Constructor declared private to prevent direct instantiation by external consumers
        /// </summary>
        private AngleBuilder() { }

        /// <summary>
        /// Creates a new angle builder instance
        /// </summary>
        /// <returns></returns>
        public static AngleBuilder Create() { return new AngleBuilder(); }

        public AngleBuilder WithValue(double value)
        {
            VerifyBuildingState();
            Value = value;
            return this;
        }

        public AngleBuilder WithUnit(string type)
        {
            VerifyBuildingState();
            try
            {
                Unit = (UnitType)Enum.Parse(typeof(UnitType), type, true);
            }
            catch (Exception exception) { OnBuildError(exception); }
            return this;
        }

        /// <summary>
        /// Builds the Angle instance based on the provided input attributes by the consumers.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="NotImplementedException"></exception>
        public Angle Build()
        {
            SetBuildingComplete();
            switch(_unit)
            {
                case UnitType.DEGREE:
                    {
                        return new DegreeAngle(this.Value);
                    }
                case UnitType.RADIAN:
                    {
                        return new RadianAngle(this.Value);
                    }
                /**
                 * Add future supported angular units here...
                 * */
                default:
                    {
                        break;
                    }
            }
            throw new NotImplementedException("The angle unit is not in this version");
        }

        private void OnBuildError(Exception exception)
        {
            // Log the exception trace using the argument..
        }
    }
}
