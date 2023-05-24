using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName = null;
        private float m_CurrentTirePressure = 0;
        private float m_MaxTirePressure = 0;


        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }
            set
            {
                m_ManufacturerName = value;
            }
        }

        public float MaxTirePressure
        {
            get
            {
                return m_MaxTirePressure;
            }
            set
            {
                m_MaxTirePressure = value;
            }
        }

        public float CurrentTirePressure
        {
            get
            {
                return m_CurrentTirePressure;
            }
            //The 'set' method Adds the given value (in energy units)
            //to the current amount of air pressire units.
            set
            {
                checkValidationOfAmountOfAirPressireUnitsToAdd(value);
                m_CurrentTirePressure += value;
            }
        }

        public void AirInflationInToTheMaximum()
        {
            m_CurrentTirePressure = m_MaxTirePressure;
        }

        private void checkValidationOfAmountOfAirPressireUnitsToAdd(float i_AirPressireToAdd)
        {
            if (i_AirPressireToAdd < 0 || m_CurrentTirePressure + i_AirPressireToAdd > m_MaxTirePressure)
            {
                throw new ValueOutOfRangeException(MaxTirePressure - CurrentTirePressure, 0);
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Manufacturer: {m_ManufacturerName}");
            stringBuilder.Append($"Tire Pressure: {CurrentTirePressure} out of {MaxTirePressure}");

            return stringBuilder.ToString();

        }
    }

}
