
using static Ex03.GarageLogic.FuelMechanism;
using System;

namespace Ex03.GarageLogic
{

    public enum eLicenceType
    {
        A1,
        A2,
        AA,
        B1
    }
    internal class LicenceType
    {
        private eLicenceType m_Value;

        public static LicenceType Parse(string i_Str)
        {
            LicenceType licenceType = new LicenceType();
            licenceType.m_Value = (eLicenceType)Enum.Parse(typeof(eLicenceType), i_Str);
            return licenceType;

        }
    }
    internal class Motorcycle : Vehicle
    {
        private LicenceType m_LicenceType;  //Enum not string
        private int m_EngineCapacity = 0;

        public const uint k_NumberOfRequiresForCreating = 6;
        public const uint k_NumberOfWheels = 2;
        public const float k_MaxTirePressure = 31f;
        public const float k_MaxGasInTank = 46f;
        public const FuelMechanism.eGasType k_GasType = FuelMechanism.eGasType.Octan98;
        public const float k_MaxElectricUnitInBattery = 5.2f;

        //public Motorcycle(string i_ModelName, string i_LicenseNumber, string i_MechanismType, float i_CurrentEnergyUnits, string i_LicenceType, string i_CurrentTirePressure)
        //    : base(i_ModelName, i_LicenseNumber, k_NumberOfWheels, k_WheelMaxAirPressire, i_CurrentTirePressure)
        //{
        //    try
        //    {
        //        m_LicenceType = LicenceType.Parse(i_LicenceType);
        //        base.CarMechanism = createCarMechanism(i_MechanismType, i_CurrentEnergyUnits);

        //    }
        //    catch (Exception e)
        //    {
        //        //Throw
        //    }
        //}

        public Motorcycle(eMechanismType i_MechanismType = eMechanismType.Gas)
        {
            if (i_MechanismType == eMechanismType.Gas)
            {
                CreateCarMechanism(i_MechanismType, k_MaxGasInTank, k_GasType);
            }
            else
            {
                CreateCarMechanism(i_MechanismType, k_MaxElectricUnitInBattery);
            }
            m_WheelsArray = createWheelsArray(k_NumberOfWheels, k_MaxTirePressure);
            m_RequiredDetailsForCreating = new string[k_NumberOfRequiresForCreating];
        }


        public override string[] ShowTheRequiredDataFromTheUser(string i_ModelName)
        {
            m_RequiredDetailsForCreating[0] = "License Number";
            m_RequiredDetailsForCreating[1] = "Model Name";
            m_RequiredDetailsForCreating[2] = "License type";
            m_RequiredDetailsForCreating[3] = "Engine capacity";
            m_RequiredDetailsForCreating[4] = "Current amount of energy units in the vehicle";
            m_RequiredDetailsForCreating[5] = "Current amount of air in the wheels in the vehicle";

            return m_RequiredDetailsForCreating;
        }

        public override void GetTheRequiredDataFromTheUser(string[] i_RequiredDataArray)
        {
            m_LicenseNumber = i_RequiredDataArray[0];
            m_ModelName = i_RequiredDataArray[1];
            m_LicenceType = LicenceType.Parse(i_RequiredDataArray[2]);
            m_EngineCapacity = int.Parse(i_RequiredDataArray[3]);
            m_CarMechanism.CurrentAmountOfEnergyUnits = float.Parse(i_RequiredDataArray[4]);
            AirInflationToWheels(float.Parse(i_RequiredDataArray[5]));
        }

        public override string[] ShowTheVehicleData()
        {
            if (m_CarMechanism is FuelMechanism)
            {
                m_RequiredDetailsForCreating[4] = $"gas type: Octan98 with {EnergyBalanceInPrecentage} of remaind energy.";
            }
            else
            {
                m_RequiredDetailsForCreating[4] = $"{EnergyBalanceInPrecentage} of remaind energy.";
            }
            m_RequiredDetailsForCreating[5] = $"wheels: manifuctur name: {m_WheelsArray[0].ManifucturName} and tire pressure is {m_WheelsArray[0].CurrentTirePressure} from {m_WheelsArray[0].MaxTirePressure}";

            return m_RequiredDetailsForCreating;
        }

    }
}
