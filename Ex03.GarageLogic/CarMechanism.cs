
namespace Ex03.GarageLogic
{
    public abstract class CarMechanism
    {
        protected float m_CurrentAmountOfEnergyUnits = 0f;
        protected readonly float m_MaxAmountOfEnergyUnits = 0f;

        public CarMechanism(float i_MaxAmountOfEnergyUnits)
        {
            m_MaxAmountOfEnergyUnits = i_MaxAmountOfEnergyUnits;
        }

        //gets & sets
        public float CurrentAmountOfEnergyUnits
        {
            get
            {
                return m_CurrentAmountOfEnergyUnits;
            }

            //The 'set' method Adds the given value (in energy units)
            //to the current amount of energy units.
            set
            {
                checkValidationOfAmountOfEnergyUnitsToAdd(value);
                m_CurrentAmountOfEnergyUnits += value;
            }
        }

        public float MaxAmountOfEnergyUnits
        {
            get
            {
                return m_MaxAmountOfEnergyUnits;
            }
        }

        public void checkValidationOfAmountOfEnergyUnitsToAdd(float i_EnergyUnitsToAdd)
        {
            float maxValueToAdd = m_MaxAmountOfEnergyUnits - m_CurrentAmountOfEnergyUnits;

            if ( i_EnergyUnitsToAdd > maxValueToAdd)
            {
                throw new ValueOutOfRangeException(maxValueToAdd, 0);
            }
        }
    }
}
