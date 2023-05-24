using System;
using System.Text;

namespace Ex03.GarageLogic
{


    public class FuelMechanism : CarMechanism
    {
        public enum eGasType
        {
            Soler,
            Octan95 = 95,
            Octan96 = 96,
            Octan98 = 98
        }

        private eGasType m_GasType;
        public const string k_GasUnit = "Liter";

        //gets & sets
        public eGasType GasType
        {
            get
            {
                return m_GasType;
            }
        }

        public FuelMechanism(eGasType i_GasType, float i_MaxGasCapacity) : base(i_MaxGasCapacity, k_GasUnit)
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

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Mechanism Type: Fuel");
            stringBuilder.Append($"Gas Type: {GasType}, ");
            stringBuilder.Append(base.ToString());

            return stringBuilder.ToString();
        }
    }
}
