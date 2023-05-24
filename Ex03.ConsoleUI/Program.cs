using System;
using Ex03.GarageLogic;
using Ex02.ConsoleUtils;


namespace Ex03.ConsoleUI
{
    public class Program
    {
        static GarageLogicManager m_GLM = new GarageLogicManager();

        public enum eMenuOptions
        {
            AddNewVehicle = 1,
            PrintGarageLicenseNumbers,
            ChangeVehicleStatus,
            TiresAirInflateToMax,
            Fueling,
            Recharging,
            PrintVehicle,
            Exit,
            Invalid
        }

        public static void Main()
        {

            string getChoiceFromUser = null;
            eMenuOptions userChoice;

            do
            {
                Screen.Clear();
                PrintTheGarageServicesMenu();
                getChoiceFromUser = Console.ReadLine();
                //userChoice = uint.Parse(getChoiceFromUser);   //validation
                if (Enum.TryParse<eMenuOptions>(getChoiceFromUser, out userChoice))
                {
                    Screen.Clear();
                    DoTheUserChoice(userChoice);
                }
                else
                {
                    Console.WriteLine(@"Invalid menu choice!
Press any key to return to the menu");
                    Console.ReadKey();
                    userChoice = eMenuOptions.Invalid;
                }

            }
            while (!IsUserChooseToFinish(userChoice));

        }

        public static bool IsUserChooseToFinish(eMenuOptions i_UserChoice)
        {
            return i_UserChoice == eMenuOptions.Exit;
        }

        public static void PrintTheGarageServicesMenu()
        {
            Console.WriteLine($@"The following are the garage services:
{Convert.ToInt32(eMenuOptions.AddNewVehicle)}. Bringing a new vehicle into the garage.
{Convert.ToInt32(eMenuOptions.PrintGarageLicenseNumbers)}. Display the list of vehicle license numbers in the garage.
{Convert.ToInt32(eMenuOptions.ChangeVehicleStatus)}. Changing vehicle status in garage.
{Convert.ToInt32(eMenuOptions.TiresAirInflateToMax)}. inflate a vehicle's wheels to maximum.
{Convert.ToInt32(eMenuOptions.Fueling)}. Refueling a fuel-powered vehicle.
{Convert.ToInt32(eMenuOptions.Recharging)}. Recharging an electric vehicle.
{Convert.ToInt32(eMenuOptions.PrintVehicle)}. View complete vehicle data.
{Convert.ToInt32(eMenuOptions.Exit)}. Exit.");
            Console.WriteLine("Please enter your choice (a number between 1 - 8)");


        }

        public static void DoTheUserChoice(eMenuOptions i_UserChoice)
        {
            switch (i_UserChoice)
            {
                case eMenuOptions.AddNewVehicle:
                    AddNewVehicleToGarage();
                    break;
                case eMenuOptions.PrintGarageLicenseNumbers:
                    PrintGarageLicenseNumbers();
                    break;
                case eMenuOptions.ChangeVehicleStatus:
                    ChangeVehicleStatus();
                    break;
                case eMenuOptions.TiresAirInflateToMax:
                    AirInflateAllTireOfVehicleToMax();
                    break;
                case eMenuOptions.Fueling:
                    RefuelVehicle();
                    break;
                case eMenuOptions.Recharging:
                    RechargeVehicle();
                    break;
                case eMenuOptions.PrintVehicle:
                    PrintVehicle();
                    break;
                case eMenuOptions.Exit:
                    break;
                default:
                    Console.WriteLine("Invalid menu choice!");
                    break;
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        public static void AddNewVehicleToGarage()
        {
            CustomerDetails customerDetails = null;
            string[] requiredDetailesFromUserArray = null;
            string licenseNumber = null;
            string strVehicleTypeFromUser = null;
            string vehicleOwnerName = null;
            string vehicleOwnerTelephone = null;

            try
            {
                Console.WriteLine("Enter license number");
                licenseNumber = Console.ReadLine();
                if (m_GLM.IsLicenseNumberAlreadyInTheGarage(licenseNumber))   //methode in GarageLogicManager.
                {
                    m_GLM.ChangeStateOfVehicleInTheGarage(licenseNumber, eCurrentStateOfTheVehicle.InRepair.ToString());
                }
                else
                {
                    Console.WriteLine($"Enter vehicle type:");
                    foreach (eVehicleType value in Enum.GetValues(typeof(eVehicleType)))
                    {
                        Console.WriteLine("* {0}", value.ToString());
                    }

                    strVehicleTypeFromUser = Console.ReadLine();
                    customerDetails = m_GLM.AddVehicleToTheGarage(licenseNumber, strVehicleTypeFromUser);   //methode in GarageLogicManager.
                    requiredDetailesFromUserArray = customerDetails.Vehicle.ShowTheRequiredDataFromTheUser();
                    Console.WriteLine("Enter the next required detailes:");
                    PrintTheRequiredDataArray(requiredDetailesFromUserArray);
                    ReadTheRequiredDataFromTheUserToTheArray(requiredDetailesFromUserArray, licenseNumber);
                    customerDetails.Vehicle.GetTheRequiredDataFromTheUser(requiredDetailesFromUserArray);
                    Console.WriteLine("--------Customer Details--------");
                    Console.WriteLine("Enter owner name:");
                    vehicleOwnerName = Console.ReadLine();
                    Console.WriteLine("Enter telephone number:");
                    vehicleOwnerTelephone = Console.ReadLine();
                    customerDetails.VehicleOwnerName = vehicleOwnerName;
                    customerDetails.VehicleOwnerTelephone = vehicleOwnerTelephone;
                    Console.WriteLine("Your vehicle has been successfully received!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("One or more of your inputs is invalid!");
                m_GLM.RemoveCustomerDetailsFromMap(licenseNumber);
            }
        }

        public static void PrintTheRequiredDataArray(string[] i_RequiredDataArray)
        {
            int i = 0;

            foreach (string item in i_RequiredDataArray)
            {
                if (i == 0)
                {
                    i++;
                    continue;
                }
                Console.WriteLine($"{i}.{item}");
                i++;
            }
        }

        public static void ReadTheRequiredDataFromTheUserToTheArray(string[] i_RequiredDataArray, string i_LicenseNumber)
        {

            i_RequiredDataArray[0] = i_LicenseNumber;

            for (int i = 1; i < i_RequiredDataArray.Length; i++)
            {
                i_RequiredDataArray[i] = Console.ReadLine();
            }
        }


        public static void PrintGarageLicenseNumbers()
        {
            string getChoiceFromUser = null;

            Console.WriteLine("Would you like to choose a specific state? (Y/N)");
            getChoiceFromUser = Console.ReadLine();

            if (getChoiceFromUser == "N")
            {
                m_GLM.PrintAllLicenseNumbersOfVehiclesInTheGarage();
            }
            else if (getChoiceFromUser == "Y")
            {
                try
                { 
                    Console.WriteLine($"What State you wish? ({eCurrentStateOfTheVehicle.InRepair}/{eCurrentStateOfTheVehicle.Repaired}/{eCurrentStateOfTheVehicle.Paid})");
                    string state = Console.ReadLine();
                    m_GLM.PrintLicenseNumbersOfVehiclesInTheGarageByState(state);
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine("The state is invalid!");
                }
            }
            else
            {
                Console.WriteLine("Wrong input!");
            }
        }

        public static void ChangeVehicleStatus()
        {
            string licenseNumber = null;
            string newStateOfVehicle = null;
            bool v_isInputValid = true;

            try
            {
                do
                {
                    Console.WriteLine("Enter license number:");
                    licenseNumber = Console.ReadLine();
                    Console.WriteLine("Enter new state of the vehicle:");
                    foreach (eCurrentStateOfTheVehicle value in Enum.GetValues(typeof(eCurrentStateOfTheVehicle)))
                    {
                        Console.WriteLine($"* {value.ToString()}");
                    }
                    newStateOfVehicle = Console.ReadLine();
                    v_isInputValid = m_GLM.ChangeStateOfVehicleInTheGarage(licenseNumber, newStateOfVehicle);
                    if (!v_isInputValid)
                    {
                        Console.WriteLine("License number is not exist in the system! Try again.");

                    }
                } while (!v_isInputValid);
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine("The state is invalid!");
            }
        }

        public static void AirInflateAllTireOfVehicleToMax()
        {
            string licenseNumber = null;
            bool v_isInputValid = true;

            do
            {
                Console.WriteLine("Enter license number:");
                licenseNumber = Console.ReadLine();
                v_isInputValid = m_GLM.AirInflationInTheWheelsToTheMaximum(licenseNumber);
                if (!v_isInputValid)
                {
                    Console.WriteLine("License number is not exist in the system! Try again.");
                }
            }
            while (!v_isInputValid);
        }

        public static void RefuelVehicle()
        {
            string licenseNumber = null;
            string gasType = null;
            string amountOfGasToFill = null;
            bool v_isInputValid = true;

            try
            {
                do
                {
                    Console.WriteLine("Enter license number:");
                    licenseNumber = Console.ReadLine();
                    Console.WriteLine("Enter gas type:");
                    gasType = Console.ReadLine();
                    Console.WriteLine("Enter amount of gas to fill:");
                    amountOfGasToFill = Console.ReadLine();
                    v_isInputValid = m_GLM.RefuelingVehicleWithFuel(licenseNumber, gasType, amountOfGasToFill);
                    if (!v_isInputValid)
                    {
                        Console.WriteLine("License number is not exist in the system! Try again.");

                    }
                }
                while (!v_isInputValid);

            }
            catch (ValueOutOfRangeException valueOutOfRangeException)
            {
                Console.WriteLine($@"The amount of gas to fill is out of range!
The possible range is {valueOutOfRangeException.MinValue} - {valueOutOfRangeException.MaxValue}.");
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine($"invalid input! {argumentException.Message}");
            }
        }

        public static void RechargeVehicle()
        {
            string licenseNumber = null;
            string amountOfHoursToCharge = null;
            bool v_isInputValid = true;

            try
            {
                do
                {
                    Console.WriteLine("Enter license number:");
                    licenseNumber = Console.ReadLine();
                    Console.WriteLine("Enter amount of electricity hours to charge:");
                    amountOfHoursToCharge = Console.ReadLine();
                    v_isInputValid = m_GLM.RechargingVehicleWithElectricity(licenseNumber, amountOfHoursToCharge);
                    if (!v_isInputValid)
                    {
                        Console.WriteLine("License number is not exist in the system! Try again.");

                    }
                }
                while (!v_isInputValid);
            }
            catch (ValueOutOfRangeException valueOutOfRangeException)
            {
                Console.WriteLine($@"The amount of hours to charge is out of range!
The possible range is {valueOutOfRangeException.MinValue} - {valueOutOfRangeException.MaxValue}.");
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine("The vehicle is not electric!");
            }
        }

        public static void PrintVehicle()
        {
            string licenseNumber = null;
            CustomerDetails customerDetails = null;

            Console.WriteLine("Enter license number:");
            licenseNumber = Console.ReadLine();
            customerDetails = m_GLM.GetObjectOfCustomerDetails(licenseNumber);
            Console.WriteLine(customerDetails.ToString());
        }
    }
}
