using System;
using System.Collections.Generic;
using System.Text;

namespace AngleManager.Direction
{
    public class CompassDirection : Direction
    {
        #region CompassDirection construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle"></param>
        public CompassDirection(Angle.Angle angle) : base(angle, Axis.POSITIVE_Y_AXIS, Movement.CLOCKWISE) { }

        #endregion

        #region Casting Operations
        public static explicit operator CompassDirection(MathematicalDirection direction)
        {
            double convertedCompassValue = (450 - direction.Angle.ToDegree()) % 360;
            //TODO : Need to understand what needs to be done to be same to create the "same" type of angle as part of this cast
            // after the value conversion...
            return new CompassDirection(new Angle.DegreeAngle(convertedCompassValue));
        }
        #endregion
    }
}
