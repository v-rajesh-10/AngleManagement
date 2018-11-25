using System;
using System.Collections.Generic;
using System.Text;

namespace AngleManager.Direction
{
    public class CompassDirection : Direction
    {
        #region CompassDirection Constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle"></param>
        public CompassDirection(Angle.Angle angle) : base(angle, Axis.POSITIVE_Y_AXIS, Movement.CLOCKWISE) { }

        #endregion

        #region Casting Operations
        public static explicit operator CompassDirection(MathematicalDirection direction)
        {
            //TODO : Revisit this logic since this is forcing to create an Angle Instance
            double convertedCompassValue = (450 - direction.Angle.ToDegree()) % 360;
            return new CompassDirection(new Angle.DegreeAngle(convertedCompassValue));
        }
        #endregion
    }
}
