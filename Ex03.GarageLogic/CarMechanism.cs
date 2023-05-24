
namespace Ex03.GarageLogic
{


    public abstract class CarMechanism
    {
        protected float m_CurrentAmountOfEnergyUnits = 0f;
        protected readonly float m_MaxAmountOfEnergyUnits = 0f;
        public string EnergyUnit { get; protected set; }

        public CarMechanism(float i_MaxAmountOfEnergyUnits, string i_EnergyUnit)
        {
            m_MaxAmountOfEnergyUnits = i_MaxAmountOfEnergyUnits;
            EnergyUnit = i_EnergyUnit;
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

            if (i_EnergyUnitsToAdd < 0 || i_EnergyUnitsToAdd > maxValueToAdd)
            {
                throw new ValueOutOfRangeException(maxValueToAdd, 0);
            }
        }

        public override string ToString()
        {
            return string.Format($"{CurrentAmountOfEnergyUnits} out of {MaxAmountOfEnergyUnits} {EnergyUnit}s in storage");
        }
    }
}
