
using System;
using static Ex03.GarageLogic.FuelMechanism;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private float m_CargoCapacity = 0f;
        private bool v_IsCarringHazaradousMatirials = false;

        public const uint k_NumberOfRequiresForCreating = 6;
        public const uint k_NumberOfWheels = 14;
        public const float k_MaxTirePressure = 26f;
        public const float k_MaxAmountOfGas = 135f;
        public const FuelMechanism.eGasType k_GasType = FuelMechanism.eGasType.Soler;



        public Truck(eMechanismType i_MechanismType = eMechanismType.Gas)
        {
            CreateCarMechanism(i_MechanismType, k_MaxAmountOfGas, k_GasType);
            m_WheelsArray = createWheelsArray(k_NumberOfWheels, k_MaxTirePressure);
            m_RequiredDetailsForCreating = new string[k_NumberOfRequiresForCreating];
        }

        public override string[] ShowTheRequiredDataFromTheUser(string i_ModelName)
        {
            m_RequiredDetailsForCreating[0] = "License Number";
            m_RequiredDetailsForCreating[1] = "Model Name";
            m_RequiredDetailsForCreating[2] = "cargo capacity";
            m_RequiredDetailsForCreating[3] = "is carring hazaradous matirials?";
            m_RequiredDetailsForCreating[4] = "current amount of fuel in the vehicle";
            m_RequiredDetailsForCreating[5] = "current amount of air in the wheels in the vehicle";

            return m_RequiredDetailsForCreating;
        }

        public override void GetTheRequiredDataFromTheUser(string[] i_RequiredDataArray)
        {
            m_LicenseNumber = i_RequiredDataArray[0];
            m_ModelName = i_RequiredDataArray[1];
            m_CargoCapacity = float.Parse(i_RequiredDataArray[2]);
            v_IsCarringHazaradousMatirials = bool.Parse(i_RequiredDataArray[3]);
            m_CarMechanism.CurrentAmountOfEnergyUnits = float.Parse(i_RequiredDataArray[4]);
            AirInflationToWheels(float.Parse(i_RequiredDataArray[5]));
        }

        public override string[] ShowTheVehicleData()
        {
            m_RequiredDetailsForCreating[4] = $"gas type: Soler with {EnergyBalanceInPrecentage} of remaind energy.";
            m_RequiredDetailsForCreating[5] = $"wheels manifuctur name: {m_WheelsArray[0].ManifucturName} and tire pressure is {m_WheelsArray[0].CurrentTirePressure} from {m_WheelsArray[0].MaxTirePressure}";

            return m_RequiredDetailsForCreating;
        }
    }
}
