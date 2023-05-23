
namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string m_ManifucturName = null;
        private float m_CurrentTirePressure = 0;
        private float m_MaxTirePressure = 0;

        //public Wheel(float i_MaxTirePressire)
        //{
        //    m_ManifucturName = i_ManifucturName;
        //    m_MaxTirePressure = i_MaxTirePressire;
        //}

        public string ManifucturName
        {
            get
            {
                return m_ManifucturName;
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
            if (m_CurrentTirePressure + i_AirPressireToAdd > m_MaxTirePressure)
            {
                //Throw Exception
            }
        }
    }

}
