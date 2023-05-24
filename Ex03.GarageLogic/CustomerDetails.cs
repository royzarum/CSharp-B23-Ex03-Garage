using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{

    public enum eCurrentStateOfTheVehicle
    {
        InRepair,
        Repaired,
        Paid
    }

    public class CustomerDetails
    {
        private string m_VehicleOwnerName = null;
        private string m_VehicleOwnerTelephone = null;
        private eCurrentStateOfTheVehicle m_CurrentStateOfTheVehicle = eCurrentStateOfTheVehicle.InRepair;
        private Vehicle m_Vehicle = null;


        //gets & sets
        public string VehicleOwnerName
        {
            get
            {
                return m_VehicleOwnerName;
            }
            set
            {
                m_VehicleOwnerName = value;
            }
        }

        public string VehicleOwnerTelephone
        {
            get
            {
                return m_VehicleOwnerTelephone;
            }
            set
            {
                m_VehicleOwnerTelephone = value;
            }
        }

        public eCurrentStateOfTheVehicle CurrentStateOfTheVehicle
        {
            get
            {
                return m_CurrentStateOfTheVehicle;
            }
            set
            {
                m_CurrentStateOfTheVehicle = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
            set
            {
                m_Vehicle = value;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Owner: {VehicleOwnerName}");
            stringBuilder.AppendLine($"Telephone: {VehicleOwnerTelephone}");
            stringBuilder.AppendLine("---------");
            stringBuilder.AppendLine(Vehicle.ToString());
            stringBuilder.AppendLine("---------");
            stringBuilder.Append($"Status: {CurrentStateOfTheVehicle.ToString()}");

            return stringBuilder.ToString();
        }

    }
}
