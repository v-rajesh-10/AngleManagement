using System;
using System.Collections.Generic;
using System.Text;

namespace AngleManager.Direction
{
    public class MathematicalDirection : Direction
    {
        #region MathematicalDirection construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle"></param>
        public MathematicalDirection(Angle.Angle angle) : base(angle, Axis.POSITIVE_X_AXIS, Movement.COUNTER_CLOCKWISE) { }

        #endregion

        #region Casting Operations
        public static explicit operator MathematicalDirection(CompassDirection direction)
        {
            double convertedCompassValue = (450 - direction.Angle.ToDegree()) % 360;
            //TODO : Need to understand what needs to be done to be same to create the "same" type of angle as part of this cast
            // after the value conversion...
            return new MathematicalDirection(new Angle.DegreeAngle(convertedCompassValue));
        }
        #endregion
    }
}
