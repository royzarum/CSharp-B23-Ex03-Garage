using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{

    public enum eVehicleType
    {
        RegularCar,
        ElectricCar,
        RegularMotorcycle,
        ElectricMotorcycle,
        Truck
    };


    public class GarageLogicManager
    {
        private Dictionary<string, CustomerDetails> m_DictionaryOfVehiclesInGarage = new Dictionary<string, CustomerDetails>();

        public void RemoveCustomerDetailsFromMap(string i_LicenseNumber)
        {
            m_DictionaryOfVehiclesInGarage.Remove(i_LicenseNumber);
        }

        public bool IsLicenseNumberAlreadyInTheGarage(string i_LicenseNumber)
        {
            bool v_IsLicenseNumberAlreadyInTheGarage = false;

            if (m_DictionaryOfVehiclesInGarage.ContainsKey(i_LicenseNumber))
            {
                v_IsLicenseNumberAlreadyInTheGarage = true;
            }

            return v_IsLicenseNumberAlreadyInTheGarage;
        }

        public CustomerDetails AddVehicleToTheGarage(string i_LicenseNumber, string i_VehicleType)
        {
            CustomerDetails newVehicleToAddToTheGarage = new CustomerDetails();
            eVehicleType vehicleType = (eVehicleType)Enum.Parse(typeof(eVehicleType), i_VehicleType);

            switch (vehicleType)
            {
                case eVehicleType.RegularCar:
                    newVehicleToAddToTheGarage.Vehicle = new Car();
                    break;
                case eVehicleType.ElectricCar:
                    newVehicleToAddToTheGarage.Vehicle = new Car(eMechanismType.Electric);
                    break;
                case eVehicleType.RegularMotorcycle:
                    newVehicleToAddToTheGarage.Vehicle = new Motorcycle();
                    break;
                case eVehicleType.ElectricMotorcycle:
                    newVehicleToAddToTheGarage.Vehicle = new Motorcycle(eMechanismType.Electric);
                    break;
                case eVehicleType.Truck:
                    newVehicleToAddToTheGarage.Vehicle = new Truck();
                    break;
                default:
                    break; ///throw- wrong input
            }

            m_DictionaryOfVehiclesInGarage.Add(i_LicenseNumber, newVehicleToAddToTheGarage);

            return newVehicleToAddToTheGarage;
        }

        public void PrintAllLicenseNumbersOfVehiclesInTheGarage()
        {
            foreach (KeyValuePair<string, CustomerDetails> item in m_DictionaryOfVehiclesInGarage)
            {
                Console.WriteLine(item.Key);
            }
        }

        public void PrintLicenseNumbersOfVehiclesInTheGarageByState(string i_VehicleState)
        {
            eCurrentStateOfTheVehicle eDesierdStateToPrint = (eCurrentStateOfTheVehicle)Enum.Parse(typeof(eCurrentStateOfTheVehicle), i_VehicleState);

            foreach (KeyValuePair<string, CustomerDetails> item in m_DictionaryOfVehiclesInGarage)
            {
                if (item.Value.CurrentStateOfTheVehicle.Equals(eDesierdStateToPrint))
                {
                    Console.WriteLine(item.Key);
                }
            }
        }

        public bool ChangeStateOfVehicleInTheGarage(string i_LicenseNumber, string i_NewStateOfVehicle)
        {
            CustomerDetails vehicleInTheGarage = null;
            bool v_LicensNumberFound = true;

            if (m_DictionaryOfVehiclesInGarage.TryGetValue(i_LicenseNumber, out vehicleInTheGarage))
            {
                vehicleInTheGarage.CurrentStateOfTheVehicle = (eCurrentStateOfTheVehicle)Enum.Parse(typeof(eCurrentStateOfTheVehicle), i_NewStateOfVehicle);  
            }
            else
            {
                v_LicensNumberFound = false;
            }

            return v_LicensNumberFound;
        }

        public bool AirInflationInTheWheelsToTheMaximum(string i_LicenseNumber)
        {
            CustomerDetails vehicleInTheGarage = null;
            bool v_LicensNumberFound = true;

            if (m_DictionaryOfVehiclesInGarage.TryGetValue(i_LicenseNumber, out vehicleInTheGarage))
            {
                vehicleInTheGarage.Vehicle.AirInflationInTheWheelsArrayToTheMaximum();
            }
            else
            {
                v_LicensNumberFound = false;
            }

            return v_LicensNumberFound;
        }

        public bool RefuelingVehicleWithFuel(string i_LicenseNumber, string i_GasType, string i_AmountOfGasToFill)
        {
            CustomerDetails vehicleInTheGarage = null;
            bool v_LicensNumberFound = true;

            if (m_DictionaryOfVehiclesInGarage.TryGetValue(i_LicenseNumber, out vehicleInTheGarage))
            {
                vehicleInTheGarage.Vehicle.RefuelingVehicleWithFuel(i_GasType, i_AmountOfGasToFill);
            }
            else
            {
                v_LicensNumberFound = false;
            }

            return v_LicensNumberFound;
        }

        public bool RechargingVehicleWithElectricity(string i_LicenseNumber, string i_AmountOfHoursToCharge)
        {
            CustomerDetails vehicleInTheGarage = null;
            bool v_LicensNumberFound = true;

            if (m_DictionaryOfVehiclesInGarage.TryGetValue(i_LicenseNumber, out vehicleInTheGarage))
            {
                vehicleInTheGarage.Vehicle.RechargingVehicleWithElectricity(i_AmountOfHoursToCharge);
            }
            else
            {
                v_LicensNumberFound = false;
            }

            return v_LicensNumberFound;
        }

        public CustomerDetails GetObjectOfCustomerDetails(string i_LicenseNumber)
        {
            CustomerDetails vehicleInTheGarage = null;

            m_DictionaryOfVehiclesInGarage.TryGetValue(i_LicenseNumber, out vehicleInTheGarage);

            return vehicleInTheGarage;
        }
    }
}
