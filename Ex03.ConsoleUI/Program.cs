using System;
using Ex03.GarageLogic;


namespace Ex03.ConsoleUI
{
    public class Program
    {
        static GarageLogicManager m_GLM = new GarageLogicManager();

        public const int FINISH = 0;
        public const int ONE = 1;
        public const int TWO = 2;
        public const int THREE = 3;
        public const int FOUR = 4;
        public const int FIVE = 5;
        public const int SIX = 6;
        public const int SEVEN = 7;

        public static void Main()
        {

            string getChoiceFromUser = null;
            uint userChoice = 0;

            do
            {
                PrintTheGarageServicesMenu();
                getChoiceFromUser = Console.ReadLine();
                userChoice = uint.Parse(getChoiceFromUser);   //validation
                DoTheUserChoice(userChoice);
            }
            while (!IsUserChooseToFinish(userChoice));

        }

        public static bool IsUserChooseToFinish(uint i_UserChoice)
        {
            return i_UserChoice == FINISH;
        }

        public static void PrintTheGarageServicesMenu()
        {
            Console.WriteLine("The following are the garage services: \n 1. Bringing a new vehicle into the garage. \n 2. Display the list of vehicle license numbers in the garage. \n 3. Changing vehicle mode. \n 4. Air inflation in the wheels to a maximum of. \n 5. Refueling a fuel-powered vehicle. \n 6. Charging an electric vehicle. \n 7. View complete vehicle data.\n8.Exit.");
            Console.WriteLine("Please enter your choice (a number between 1-7)");
        }

        public static void DoTheUserChoice(uint i_UserChoice)
        {
            switch (i_UserChoice)
            {
                case ONE:
                    DoChoiceOne();
                    break;
                case TWO:
                    DoChoiceTwo();
                    break;
                case THREE:
                    DoChoiceThree();
                    break;
                case FOUR:
                    DoChoiceFour();
                    break;
                case FIVE:
                    DoChoiceFive();
                    break;
                case SIX:
                    DoChoiceSix();
                    break;
                case SEVEN:
                    DoChoiceSeven();
                    break;
                default:
                    break;
            }
        }

        public static void DoChoiceOne()
        {
            CustomerDetails customerDetails = null;
            string[] requiredDetailesFromUserArray = null;
            string licenseNumber = null;
            string modelName = null;
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
                    modelName = Console.ReadLine();
                    customerDetails = m_GLM.AddVehicleToTheGarage(licenseNumber, modelName);   //methode in GarageLogicManager.
                    requiredDetailesFromUserArray = customerDetails.Vehicle.ShowTheRequiredDataFromTheUser(modelName);
                    Console.WriteLine($"Enter the next required detailes:");
                    PrintTheRequiredDataArray(requiredDetailesFromUserArray);
                    ReadTheRequiredDataFromTheUserToTheArray(requiredDetailesFromUserArray, licenseNumber, modelName);
                    customerDetails.Vehicle.GetTheRequiredDataFromTheUser(requiredDetailesFromUserArray);
                    Console.WriteLine("Enter owner name");
                    vehicleOwnerName = Console.ReadLine();
                    Console.WriteLine("Enter telephone number");
                    vehicleOwnerTelephone = Console.ReadLine();
                    customerDetails.VehicleOwnerName = vehicleOwnerName;
                    customerDetails.VehicleOwnerTelephone = vehicleOwnerTelephone;
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
                if(i == 0)
                {
                    i++;
                    continue;
                }
                Console.WriteLine($"{i}.{item}");
                i++;
            }
        }

        public static void ReadTheRequiredDataFromTheUserToTheArray(string[] i_RequiredDataArray, string i_LicenseNumber, string i_ModelName)
        {
           
            i_RequiredDataArray[0] = i_LicenseNumber;

            for (int i = 1; i < i_RequiredDataArray.Length; i++)
            {
                i_RequiredDataArray[i] = Console.ReadLine();
            }
        }

        public static void DoChoiceTwo()
        {
            string getChoiceFromUser = null;
            uint userChoice = 0;

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
                    Console.WriteLine($"What State you wish? ({Enum.GetValues(typeof(eCurrentStateOfTheVehicle))})");
                    //Console.WriteLine($"What State you wish? ({eCurrentStateOfTheVehicle.InRepair}/{eCurrentStateOfTheVehicle.Repaired}/{eCurrentStateOfTheVehicle.Paid})");
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

        public static void DoChoiceThree()
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

        public static void DoChoiceFour()
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

        public static void DoChoiceFive()
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

        public static void DoChoiceSix()
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
            catch(ArgumentException argumentException)
            {
                Console.WriteLine("The vehicle is not electric!");
            }
        }

        public static void DoChoiceSeven()
        {
            string licenseNumber = null;      
            CustomerDetails customerDetails = null;

            Console.WriteLine("Enter license number:");
            licenseNumber = Console.ReadLine();
            customerDetails = m_GLM.GetObjectOfCustomerDetails(licenseNumber);
            Console.WriteLine(customerDetails.VehicleOwnerName);
            Console.WriteLine(customerDetails.VehicleOwnerTelephone);
            PrintTheRequiredDataArray(customerDetails.Vehicle.ShowTheVehicleData());
            Console.WriteLine((customerDetails.CurrentStateOfTheVehicle).ToString());           
        }
    }
}
