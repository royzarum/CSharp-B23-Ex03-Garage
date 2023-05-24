
using System;
using System.Text;


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
        private eLicenceType Value { get; set; }

        public static LicenceType Parse(string i_Str)
        {
            LicenceType licenceType = new LicenceType();

            licenceType.Value = (eLicenceType)Enum.Parse(typeof(eLicenceType), i_Str);

            return licenceType;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

    }
    internal class Motorcycle : Vehicle
    {
        private LicenceType m_LicenceType;
        private int m_EngineCapacity = 0;

        public const uint k_NumberOfRequiresForCreating = 7;
        public const uint k_NumberOfWheels = 2;
        public const float k_MaxTirePressure = 31f;
        //Fuel
        public const float k_MaxGasInTank = 46f;
        public const FuelMechanism.eGasType k_GasType = FuelMechanism.eGasType.Octan98;
        //Electric
        public const float k_MaxElectricUnitInBattery = 2.6f;


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



        /////////////////Properties///////////////////

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Motorcycle engine capasity must be possitive number.");
                }
                m_EngineCapacity = value;
            }
        }

        public override string[] ShowTheRequiredDataFromTheUser()
        {
            m_RequiredDetailsForCreating[0] = "License Number";
            m_RequiredDetailsForCreating[1] = "Model Name";
            m_RequiredDetailsForCreating[2] = "License type";
            m_RequiredDetailsForCreating[3] = "Engine capacity";
            m_RequiredDetailsForCreating[4] = "Current amount of energy units in the vehicle";
            m_RequiredDetailsForCreating[5] = "Wheels manufacturer name";
            m_RequiredDetailsForCreating[6] = "Current amount of air in the wheels in the vehicle";

            return m_RequiredDetailsForCreating;
        }

        public override void GetTheRequiredDataFromTheUser(string[] i_RequiredDataArray)
        {
            m_LicenseNumber = i_RequiredDataArray[0];
            m_ModelName = i_RequiredDataArray[1];
            m_LicenceType = LicenceType.Parse(i_RequiredDataArray[2]);
            EngineCapacity = int.Parse(i_RequiredDataArray[3]);
            m_CarMechanism.CurrentAmountOfEnergyUnits = float.Parse(i_RequiredDataArray[4]);
            foreach (Wheel wheel in m_WheelsArray)
            {
                wheel.ManufacturerName = i_RequiredDataArray[5];
            }
            AirInflationToWheels(float.Parse(i_RequiredDataArray[6]));
        }
        

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(base.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"License Type: {m_LicenceType.ToString()}");
            stringBuilder.Append($"Engine Capacity: {m_EngineCapacity}");

            return stringBuilder.ToString();
        }
    }
}
