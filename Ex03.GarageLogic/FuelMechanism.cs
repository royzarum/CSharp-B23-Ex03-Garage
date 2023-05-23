using System;

namespace Ex03.GarageLogic
{


    public class FuelMechanism : CarMechanism
    {
        public enum eGasType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        private eGasType m_GasType;


        //gets & sets
        public eGasType GasType
        {
            get
            {
                return m_GasType;
            }
        }

        public FuelMechanism(eGasType i_GasType, float i_MaxGasCapacity) : base(i_MaxGasCapacity)
        {
            m_GasType = i_GasType;
        }

        public void Refueling(string i_GasType, string i_AmountOfGasToFill)
        {
            eGasType gasType;
            float amountOfGasToFill;

            gasType = (eGasType)Enum.Parse(typeof(eGasType), i_GasType); //validation
            amountOfGasToFill = float.Parse(i_AmountOfGasToFill);  //validation
            if (gasType == m_GasType)
            {
                CurrentAmountOfEnergyUnits = amountOfGasToFill;  //set do += 
            }
            else
            {
                throw new ArgumentException("the gas type is different from the vehicle gas type.");
            }           
        }
    }
}
