using System.Text;


namespace Ex03.GarageLogic
{
    internal class ElectricMechanism : CarMechanism
    {
        public const string k_ElectricUnit = "Hour";

        public ElectricMechanism(float i_MaxAmountOfElectricUnitsInBattery)
            : base(i_MaxAmountOfElectricUnitsInBattery, k_ElectricUnit)
        { }

        public void ReCharging(string i_AmountOfHoursToCharge)
        {
            float amountOfHoursToCharge;


            amountOfHoursToCharge = float.Parse(i_AmountOfHoursToCharge);  
            CurrentAmountOfEnergyUnits = amountOfHoursToCharge;  //set do +=                              
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Mechanism Type: Electric");
            stringBuilder.Append(base.ToString());

            return stringBuilder.ToString();
        }
    }
}
