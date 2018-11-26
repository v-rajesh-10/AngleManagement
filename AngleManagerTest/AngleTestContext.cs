
namespace AngleManagerTest
{
    using System;

    public class AngleTestContext
    {
        protected double ConvertToRadian(double degreeValue)
        {
            return ((Math.PI / 180) * degreeValue);
        }

        protected double ConvertToDegree(double radianValue)
        {
            return ((180 / Math.PI) * radianValue);
        }

        protected AngleManager.Angle.Angle CreateDegreeAngleByValue(double value)
        {
            return new AngleManager.Angle.DegreeAngle(value);
        }

        protected AngleManager.Angle.Angle CreateRadianAngleByValue(double value)
        {
            return new AngleManager.Angle.RadianAngle(value);
        }
    }
}
