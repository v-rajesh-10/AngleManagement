
namespace AngleManager.Direction
{
    /// <summary>
    /// Represents Direction in the system.
    /// </summary>
    public abstract class Direction
    {
        public enum Axis
        {
            PositiveYAxis,
            NegativeYAxis,
            PositiveXAxis,
            NegativeXAxis
        };

        public enum Movement
        {
            Clockwise,
            CounterClockwise
        };

        public enum Quadrant
        {
            First,
            Second,
            Third,
            Fourth
        };

        #region Direction ReadOnly Values
        public Angle.Angle Angle { get; }
        public Axis AxisType { get; }
        public Movement MovementType { get; }
        public Quadrant QuadrantType { get; }
        #endregion

        #region Direction Constructor

        /// <summary>
        /// Serves as the default constructor for the derived classes
        /// </summary>
        /// <param name="angle">the angle of the direction as represented by <code>Angle</code></param>
        /// <param name="axisType">the type of the axis with one of the value from <code>Axis</code> enum</param>
        /// <param name="movementType">the type of the movement with one of the value from <code>Movement</code> enum</param>
        protected Direction(Angle.Angle angle, Axis axisType, Movement movementType)
        {
            Angle = angle;
            AxisType = axisType;
            MovementType = movementType;

            if (Angle.SineValue >= 0)
            {
                // First or Fourth Quadrant
                QuadrantType = (Angle.CosValue >= 0) ? Quadrant.First : Quadrant.Second;
            }
            else
            {
                // Second or Third Quadrant
                QuadrantType = (Angle.CosValue >= 0) ? Quadrant.Fourth : Quadrant.Third;
            }
        }

        #endregion
    }
}
