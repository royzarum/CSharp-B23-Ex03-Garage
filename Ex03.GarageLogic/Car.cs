using System;
using static Ex03.GarageLogic.FuelMechanism;

namespace Ex03.GarageLogic
{
    public enum eNumberOfDoors
    {
        two = 2,
        three,
        four,
        five
    }

    internal class NumberOfDoors
    {
        private eNumberOfDoors m_Value;

        public static NumberOfDoors Parse(string i_Str)
        {
            NumberOfDoors numberOfDoors = new NumberOfDoors();
            numberOfDoors.m_Value = (eNumberOfDoors)Enum.Parse(typeof(eNumberOfDoors), i_Str);
            return numberOfDoors;

        }
    }

    internal class Car : Vehicle
    {
        private string m_Color = null;
        private NumberOfDoors m_NumberOfDoors;

        public const uint k_NumberOfRequiresForCreating = 6;
        public const uint k_NumberOfWheels = 5;
        public const float k_MaxTirePressure = 33f;
        public const float k_MaxGasInTank = 46f;
        public const FuelMechanism.eGasType k_GasType = FuelMechanism.eGasType.Octan95;
        public const float k_MaxElectricUnitInBattery = 5.2f;

        public Car(eMechanismType i_MechanismType = eMechanismType.Gas)
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

        public string[] RequiredDetailsForCreating
        {
            get
            {
                m_RequiredDetailsForCreating[0] = "License Number";
                m_RequiredDetailsForCreating[1] = "Model Name";
                m_RequiredDetailsForCreating[2] = "Color";
                m_RequiredDetailsForCreating[3] = "Number of doors";
                m_RequiredDetailsForCreating[4] = "Current amount of energy units in the vehicle";
                m_RequiredDetailsForCreating[5] = "Current amount of air in the wheels in the vehicle";
                

                return m_RequiredDetailsForCreating;
            }
            set
            {
                m_ModelName = value[0];
                m_LicenseNumber = value[1];
                m_Color = value[2];
                m_NumberOfDoors = NumberOfDoors.Parse(value[3]);
                m_CarMechanism.CurrentAmountOfEnergyUnits = float.Parse(value[4]);
                AirInflationToWheels(float.Parse(value[5]));
            }
        }
        public override string[] ShowTheRequiredDataFromTheUser(string i_ModelName)
        {

            m_RequiredDetailsForCreating[0] = "License Number";
            m_RequiredDetailsForCreating[1] = "Model Name";
            m_RequiredDetailsForCreating[2] = "Color";
            m_RequiredDetailsForCreating[3] = "Number of doors";
            m_RequiredDetailsForCreating[4] = "Current amount of energy units in the vehicle";
            m_RequiredDetailsForCreating[5] = "Current amount of air in the wheels in the vehicle";

            return m_RequiredDetailsForCreating;
        }

        public override void GetTheRequiredDataFromTheUser(string[] i_RequiredDataArray)
        {
            
            m_LicenseNumber = i_RequiredDataArray[0];
            m_ModelName = i_RequiredDataArray[1];
            m_Color = i_RequiredDataArray[2];
            m_NumberOfDoors = NumberOfDoors.Parse(i_RequiredDataArray[3]);
            m_CarMechanism.CurrentAmountOfEnergyUnits = float.Parse(i_RequiredDataArray[4]);
            AirInflationToWheels(float.Parse(i_RequiredDataArray[5]));
        }

        public override string[] ShowTheVehicleData()
        {
            if (m_CarMechanism is FuelMechanism)
            {
                m_RequiredDetailsForCreating[4] = $"gas type: {k_GasType} with {EnergyBalanceInPrecentage} of remaind energy.";
            }
            else
            {
                m_RequiredDetailsForCreating[4] = $"{EnergyBalanceInPrecentage} of remaind energy.";
            }
            m_RequiredDetailsForCreating[5] = $"Wheels manifuctur name: {m_WheelsArray[0].ManifucturName} and tire pressure is {m_WheelsArray[0].CurrentTirePressure} from {m_WheelsArray[0].MaxTirePressure}";

            return m_RequiredDetailsForCreating;
        }




        //public Car(string i_ModelName, string i_LicenseNumber, string i_Color, string i_NumberOfDoors, string i_MechanismType, float i_CurrentEnergyUnits, string i_CurrentTirePressure)
        //    : base(i_ModelName, i_LicenseNumber, k_NumberOfWheels, k_WheelMaxAirPressire, i_CurrentTirePressure)
        //{
        //    try
        //    {
        //        m_Color = i_Color;
        //        m_NumberOfDoors = NumberOfDoors.Parse(i_NumberOfDoors);
        //        base.CarMechanism = createCarMechanism(i_MechanismType, i_CurrentEnergyUnits);
        //    }
        //    catch (Exception e)
        //    {
        //        //Throw
        //    }




        //private CarMechanism createCarMechanism(string i_MechanismType, float i_CurrentEnergyUnits)
        //{
        //    try
        //    {
        //        CarMechanism carMechanism = null;
        //        eModelName mechanismType = (eModelName)Enum.Parse(typeof(eModelName), i_MechanismType);

        //        if (mechanismType == eModelName.RegularCar || mechanismType == eModelName.RegularMotorcycle)
        //        {
        //            carMechanism = new FuelMechanism(k_GasType, k_MaxGasInTank, i_CurrentEnergyUnits);
        //        }
        //        else //mechanismType == electric
        //        {
        //            carMechanism = new ElectricMechanism(k_MaxElectricUnitInBattery, i_CurrentEnergyUnits);
        //        }

        //        return carMechanism;
        //    }
        //    catch (Exception e)
        //    {
        //        //Throw
        //    }

        //    return null;
        //}
    }



}
