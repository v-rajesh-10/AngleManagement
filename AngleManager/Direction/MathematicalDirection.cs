namespace AngleManager.Direction
{
    using AngleManager.Angle;
    /// <summary>
    /// Represents a Mathematical Direction which is the angle measured from Positive X Axis in Counter Clockwise direction.
    /// </summary>
    public class MathematicalDirection : Direction
    {
        #region MathematicalDirection Constructor

        /// <summary>
        /// MathematicalDirection injected with an angle.
        /// </summary>
        /// <param name="angle">the angle associated with the direction represented by <code>Angle</code></param>
        public MathematicalDirection(Angle angle) : base(angle, Axis.PositiveXAxis, Movement.CounterClockwise) { }

        #endregion

        #region Casting Operations
        public static explicit operator MathematicalDirection(CompassDirection direction)
        {
            var convertedCompassValue = (450 - direction.Angle.To<DegreeAngle>().Value) % 360;
            Angle convertedCompassAngle = new DegreeAngle(convertedCompassValue);
            if (!direction.Angle.GetType().Equals(typeof(DegreeAngle)))
            {
                // Forced to create an Angle Instance when casting directions to angles...Hence converting it back to 
                // previous type...yes..this involves an additional objects creation
                convertedCompassAngle = convertedCompassAngle.Create(convertedCompassValue, direction.Angle.GetType());
            }
            return new MathematicalDirection(convertedCompassAngle);
        }
        #endregion
    }
}
