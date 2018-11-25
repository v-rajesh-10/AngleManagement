using System;
using System.Collections.Generic;
using System.Text;

namespace AngleManager.Direction
{
    /// <summary>
    /// Represents Direction in the system.
    /// </summary>
    public abstract class Direction
    {
        public enum Axis
        {
            POSITIVE_Y_AXIS,
            NEGATIVE_Y_AXIS,
            POSITIVE_X_AXIS,
            NEGATIVE_X_AXIS
        };

        public enum Movement
        {
            CLOCKWISE,
            COUNTER_CLOCKWISE
        };

        public enum Quadrant
        {
            FIRST,
            SECOND,
            THIRD,
            FOURTH
        };

        public Angle.Angle Angle { get; }
        public Axis AxisType { get; }
        public Movement MovementType { get; }
        public Quadrant QuadrantType { get; private set; }

        #region Direction Constructor

        /// <summary>
        /// Prevent access to invoking default contrcutor from the dervied classes
        /// </summary>
        private Direction() { }

        /// <summary>
        /// Serves as the default constructor for the dervied classes_
        /// </summary>
        /// <param name="angle">the angle of the direction as representd by <code>Angle</code></param>
        /// <param name="axisType">the type of the axis with one of the value from <code>Axis</code> enum</param>
        /// <param name="movementType">the type of the movement with one of the value from <code>Movement</code> enum</param>
        public Direction(Angle.Angle angle, Axis axisType, Movement movementType)
        {
            Angle = angle;
            AxisType = axisType;
            MovementType = movementType;

            if (Angle.SineValue >= 0)
            {
                // First or Fourth Quadrant
                QuadrantType = (Angle.CosValue >= 0) ? Quadrant.FIRST : Quadrant.SECOND;
            }
            else
            {
                // Second or Third Quadrant
                QuadrantType = (Angle.CosValue >= 0) ? Quadrant.FOURTH : Quadrant.THIRD;
            }
        }

        #endregion
    }
}
