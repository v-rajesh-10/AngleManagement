namespace AngleManager.Direction
{
    using AngleManager.Angle;
    /// <summary>
    /// Represents a Compass Direction which is the angle measured from Positive Y Axis in Clockwise direction.
    /// </summary>
    public class CompassDirection : Direction
    {
        #region CompassDirection Constructor

        /// <summary>
        /// CompassDirection injected with an angle.
        /// </summary>
        /// <param name="angle">the angle associated with the direction represented by <code>Angle</code></param>
        public CompassDirection(Angle angle) : base(angle, Axis.PositiveYAxis, Movement.Clockwise) { }

        #endregion

        #region Casting Operations
        public static explicit operator CompassDirection(MathematicalDirection direction)
        {
            // Forced to create an Angle Instance when casting directions
            var convertedCompassValue = (450 - direction.Angle.To<DegreeAngle>().Value) % 360;
            return new CompassDirection(new DegreeAngle(convertedCompassValue));
        }
        #endregion
    }
}
