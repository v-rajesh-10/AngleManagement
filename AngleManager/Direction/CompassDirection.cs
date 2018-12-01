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
            var convertedCompassValue = (450 - direction.Angle.To<DegreeAngle>().Value) % 360;
            Angle convertedCompassAngle = new DegreeAngle(convertedCompassValue);
            if (!direction.Angle.GetType().Equals(typeof(DegreeAngle)))
            {
                // Forced to create an Angle Instance when casting directions to angles...Hence converting it back to 
                // previous type...yes..this involves an additional objects creation
                convertedCompassAngle = convertedCompassAngle.Create(convertedCompassValue, direction.Angle.GetType());
            }
            return new CompassDirection(convertedCompassAngle);
        }
        #endregion
    }
}
