using System;
using System.Collections.Generic;
using System.Text;

namespace AngleManager.Direction
{
    /// <summary>
    /// Represents a Compass Direction which is the angle measured from Postive Y Axis in Clockwise direction.
    /// </summary>
    public class CompassDirection : Direction
    {
        #region CompassDirection Constructor

        /// <summary>
        /// CompassDirection injected with an angle.
        /// </summary>
        /// <param name="angle">the angle associated with the direction represented by <code>Angle</code></param>
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
