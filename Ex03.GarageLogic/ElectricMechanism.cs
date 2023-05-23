
using static Ex03.GarageLogic.FuelMechanism;
using System;

namespace Ex03.GarageLogic
{
    internal class ElectricMechanism : CarMechanism
    {

        public ElectricMechanism(float i_MaxAmountOfElectricUnitsInBattery)
            : base(i_MaxAmountOfElectricUnitsInBattery)
        { }



        public void ReCharging(string i_AmountOfHoursToCharge)
        {      
            float amountOfHoursToCharge;

           
                amountOfHoursToCharge = float.Parse(i_AmountOfHoursToCharge);  //validation
                CurrentAmountOfEnergyUnits = amountOfHoursToCharge;  //set do +=                              
        }
    }
}
