using System;
using Ex03.GarageLogic;
using Ex02.ConsoleUtils;



namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            string getChoiceFromUser = null;
            eMenuOptions userChoice;

            do
            {
                Screen.Clear();
                ImplementationOfTheUserInterface.PrintTheGarageServicesMenu();
                getChoiceFromUser = Console.ReadLine();
                if (Enum.TryParse<eMenuOptions>(getChoiceFromUser, out userChoice))
                {
                    Screen.Clear();
                    ImplementationOfTheUserInterface.DoTheUserChoice(userChoice);
                }
                else
                {
                    Console.WriteLine(@"Invalid menu choice!
Press any key to return to the menu");
                    Console.ReadKey();
                    userChoice = eMenuOptions.Invalid;
                }

            }
            while (!ImplementationOfTheUserInterface.IsUserChooseToFinish(userChoice));

        }

    }
}
