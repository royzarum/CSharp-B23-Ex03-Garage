

using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public static class CreateNewVehicleClasses
    {
        public static CustomerDetails CreateAndAddVehicleToTheGarage(string i_LicenseNumber, string i_VehicleType, Dictionary<string, CustomerDetails> i_DictionaryOfVehiclesInGarage)
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
                    break;
            }

            i_DictionaryOfVehiclesInGarage.Add(i_LicenseNumber, newVehicleToAddToTheGarage);

            return newVehicleToAddToTheGarage;
        }
    }
}
