using System;
using System.Collections.Generic;
using System.Text;

namespace AngleManager.Direction
{
    public class MathematicalDirection : Direction
    {
        #region MathematicalDirection Constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle"></param>
        public MathematicalDirection(Angle.Angle angle) : base(angle, Axis.POSITIVE_X_AXIS, Movement.COUNTER_CLOCKWISE) { }

        #endregion

        #region Casting Operations
        public static explicit operator MathematicalDirection(CompassDirection direction)
        {
            //TODO : Revisit this logic since this is forcing to create an Angle Instance
            double convertedCompassValue = (450 - direction.Angle.ToDegree()) % 360;
            return new MathematicalDirection(new Angle.DegreeAngle(convertedCompassValue));
        }
        #endregion
    }
}
