namespace AngleManager.Angle
{
    using System;

    public static class AngleExtensions
    {
        /// <summary>
        /// Extension Method for converting among different angle types.
        /// </summary>
        /// <typeparam name="T">the type of the angle</typeparam>
        /// <param name="angle">the instance represented by <code>Angle</code></param>
        /// <returns></returns>
        public static Angle To<T>(this Angle angle)
        {
            double angleValue = angle.Value;
            if (typeof(T).Equals(typeof(RadianAngle)))
            {
                if (angle.GetType().Equals(typeof(DegreeAngle)))
                {
                    return new RadianAngle((Math.PI / 180) * angle.Value);
                }
                /*
                * Add the conversion from Radian to other angle types here
                */
            }

            if (typeof(T).Equals(typeof(DegreeAngle)))
            {
                if (angle.GetType().Equals(typeof(RadianAngle)))
                {
                    return new DegreeAngle((180 / Math.PI) * angle.Value);
                }
                /*
                * Add the conversion from Degree to other angle types here
                */
            }
            /*
             * Add the conversion from other types here...
            */
            return angle;
        }
    }
}
