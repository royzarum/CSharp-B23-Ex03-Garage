using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        public float MaxValue { get; set; }
        public float MinValue { get; set; }

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue) 
        {
            MaxValue = i_MaxValue;
            MinValue = i_MinValue;
        }
    }
}
