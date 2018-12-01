namespace AngleManager.Angle
{
    using System;

    public static class AngleExtensions
    {
        /// <summary>
        ///  Creates an Instance of an angle based on the Type
        /// </summary>
        /// <param name="angleValue">the angle value in double</param>
        /// <param name="type">the type as represented by <code>Type</code></param>
        /// <returns>the instance of the angle represented by <code>Angle</code></returns>
        public static Angle Create(double angleValue, Type type)
        {
            if (type.Equals(typeof(DegreeAngle)) || type.Equals(typeof(RadianAngle)))
            {
                return type.GetConstructor(new Type[] { typeof(double) }).Invoke(new object[] { angleValue }) as Angle;
            }
            throw new NotImplementedException("The current type is not supported yet for AngleExtension");
        }

        /// <summary>
        /// Creates an Instance of an angle based on the Type
        /// </summary>
        /// <param name="angle">the angle instance representd by <code>Angle</code></param>
        /// <param name="angleValue">the angle value in double</param>
        /// <param name="type">the type of the angle to be created</param>
        /// <returns>the instance of the angle represented by <code>Angle</code></returns>
        public static Angle Create(this Angle angle, double angleValue, Type type)
        {
            double convertAngleValue = angleValue;
            if (type.Equals(typeof(RadianAngle)))
            {
                if (angle.GetType().Equals(typeof(DegreeAngle)))
                {
                    convertAngleValue = (Math.PI / 180) * angleValue;
                }
            }
            if (type.Equals(typeof(DegreeAngle)))
            {
                if (angle.GetType().Equals(typeof(RadianAngle)))
                {
                    convertAngleValue = (180 / Math.PI) * angleValue;
                }
            }
            return Create(convertAngleValue, type);
        }

        /// <summary>
        /// Extension Method for converting among different angle types.
        /// </summary>
        /// <typeparam name="T">the type of the angle</typeparam>
        /// <param name="angle">the instance represented by <code>Angle</code></param>
        /// <returns></returns>
        public static Angle To<T>(this Angle angle)
        {
            double convertAngleValue = angle.Value;
            if (typeof(T).Equals(typeof(RadianAngle)))
            {
                if (angle.GetType().Equals(typeof(DegreeAngle)))
                {
                    convertAngleValue = (Math.PI / 180) * angle.Value;
                }
            }
            if (typeof(T).Equals(typeof(DegreeAngle)))
            {
                if (angle.GetType().Equals(typeof(RadianAngle)))
                {
                    convertAngleValue = (180 / Math.PI) * angle.Value;
                }
            }
            return Create(convertAngleValue, typeof(T));
        }
    }
}
