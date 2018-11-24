using System;
using System.Collections.Generic;
using System.Text;

namespace AngleManager
{
    internal static class ConvertorsUtil
    {
        public static double DegreeToRadian(double degreeValue)
        {
            return ((Math.PI / 180) * degreeValue);
        }

        public static double RadianToDegree(double radianValue)
        {
            return ((180 / Math.PI) * radianValue);
        }
    }
}
