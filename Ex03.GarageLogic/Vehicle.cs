using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eMechanismType
    {
        Gas,
        Electric
    }

    public abstract class Vehicle
    {
        protected string m_ModelName = null;
        protected string m_LicenseNumber = null;
        protected float m_EnergyBalanceInPrecentage = 0;
        protected Wheel[] m_WheelsArray = null;
        protected CarMechanism m_CarMechanism = null;
        protected string[] m_RequiredDetailsForCreating = null;


        public abstract string[] ShowTheRequiredDataFromTheUser();
        public abstract void GetTheRequiredDataFromTheUser(string[] i_RequiredDataArray);

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"License Number: {m_LicenseNumber}");
            stringBuilder.AppendLine($"Model Name: {m_ModelName}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("Mechanism:");
            stringBuilder.Append(m_CarMechanism.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendLine();
            int i = 1;
            foreach (Wheel wheel in m_WheelsArray)
            {
                stringBuilder.AppendLine($"Wheel No.{i}:");
                stringBuilder.Append(wheel.ToString());
                stringBuilder.AppendLine();
                ++i;
            }

            return stringBuilder.ToString();
        }

        /////////////////Gets And Sets/////////////////
        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
        }

        //public CarMechanism CarMechanism
        //{
        //    get
        //    {
        //        return m_CarMechanism;
        //    }
        //    protected set
        //    {
        //        m_CarMechanism = value;
        //    }
        //}

        protected void CreateCarMechanism(eMechanismType i_MechanismType, float i_MaxEnergyCapacity, FuelMechanism.eGasType i_GasType = FuelMechanism.eGasType.Octan95)
        {
            if (i_MechanismType == eMechanismType.Gas)
            {
                m_CarMechanism = new FuelMechanism(i_GasType, i_MaxEnergyCapacity);
            }
            else
            {
                m_CarMechanism = new ElectricMechanism(i_MaxEnergyCapacity);
            }
        }

        public float EnergyBalanceInPrecentage
        {
            get
            {
                m_EnergyBalanceInPrecentage = (m_CarMechanism.CurrentAmountOfEnergyUnits / m_CarMechanism.MaxAmountOfEnergyUnits);
                return m_EnergyBalanceInPrecentage;
            }
            protected set
            {
                m_EnergyBalanceInPrecentage = value;
            }
        }
        public string[] RequiredDetailsForCreating
        {
            get
            {
                return m_RequiredDetailsForCreating;
            }
        }

        //public Wheel[] WheelsArray
        //{
        //    get
        //    {
        //        return m_WheelsArray;
        //    }
        //    protected set
        //    {
        //        m_WheelsArray = value;
        //    }
        //}

        protected Wheel[] createWheelsArray(uint i_NumberOfWheels, float i_MaxTirePressure)
        {

            Wheel[] wheelsArray = new Wheel[i_NumberOfWheels];
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                wheelsArray[i] = new Wheel();
                wheelsArray[i].MaxTirePressure = i_MaxTirePressure;
            }

            return wheelsArray;
        }



        public void AirInflationInTheWheelsArrayToTheMaximum()
        {
            foreach (Wheel wheel in m_WheelsArray)
            {
                wheel.AirInflationInToTheMaximum();
            }
        }

        public void AirInflationToWheels(float i_AirToAdd)
        {
            foreach (Wheel wheel in m_WheelsArray)
            {
                wheel.CurrentTirePressure += i_AirToAdd;
            }
        }

        public void RefuelingVehicleWithFuel(string i_GasType, string i_AmountOfGasToFill)
        {
            FuelMechanism fuelMecanism = m_CarMechanism as FuelMechanism;

            if (fuelMecanism != null)
            {
                fuelMecanism.Refueling(i_GasType, i_AmountOfGasToFill);
            }
            else
            {
                throw new ArgumentException("the vehicle is electric!");
            }
        }

        public void RechargingVehicleWithElectricity(string i_AmountOfHoursToCharge)
        {
            ElectricMechanism fuelMecanism = m_CarMechanism as ElectricMechanism;

            if (fuelMecanism != null)
            {
                fuelMecanism.ReCharging(i_AmountOfHoursToCharge);
            }
            else
            {
                throw new ArgumentException();
            }
        }



    }
}
