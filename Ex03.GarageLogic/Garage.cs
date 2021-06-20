using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, Vehicle> m_VehicalsInGarage;
        private Dictionary<string, eVehicleStatusInGarage> m_VehicalStatusInGarage;

        public Garage()
        {
            m_VehicalsInGarage = new Dictionary<string, Vehicle>();
            m_VehicalStatusInGarage = new Dictionary<string, eVehicleStatusInGarage>();
        }

        public void EnterNewVehicle(string i_LicenseNumber, Vehicle i_NewVehicleToEnter)
        {
            Vehicle newVehicleToAddToGarage = i_NewVehicleToEnter;

            if(CheckIfVehicleExists(i_LicenseNumber))
            {
                UpdateVehicleStatusInGarage(i_LicenseNumber, eVehicleStatusInGarage.InRepair);
            }
            else
            {
                this.m_VehicalsInGarage.Add(newVehicleToAddToGarage.LicenseNumber, newVehicleToAddToGarage);
                this.m_VehicalStatusInGarage.Add(newVehicleToAddToGarage.LicenseNumber, newVehicleToAddToGarage.VehicleStatusInGarage);
            }
        }

       private bool CheckIfVehicleExists(string i_LicenseNumber)
        {
            bool vehicleIsExists = false;
            if(GetVehicleInGarage(i_LicenseNumber) != null)
            {
                vehicleIsExists = true;
            }

            return vehicleIsExists;
        }

        private Vehicle GetVehicleInGarage(string i_LicenseNumber)
        {
            Vehicle vehicleInGarage = null;

            if(this.m_VehicalsInGarage.TryGetValue(i_LicenseNumber, out vehicleInGarage))
            { 
            }

            return vehicleInGarage;
        }

        public void UpdateVehicleStatusInGarage(string i_LicenseNumber, eVehicleStatusInGarage i_NewStatusOfVehicle)
        {
            Vehicle CurrentVehicleUpdateStatus = GetVehicleInGarage(i_LicenseNumber);
            CurrentVehicleUpdateStatus.VehicleStatusInGarage = i_NewStatusOfVehicle;
            if(this.m_VehicalStatusInGarage.ContainsKey(CurrentVehicleUpdateStatus.LicenseNumber))
            {
                this.m_VehicalStatusInGarage[CurrentVehicleUpdateStatus.LicenseNumber] = CurrentVehicleUpdateStatus.VehicleStatusInGarage;
            }
            else
            {
                throw new ArgumentException("Try Again! the vehicle you want to change his status does not exist in the garage");
            }
        }

        public string ShowVehicleStatusInGarage(eVehicleStatusInGarage i_WantedStatusOfVehicles)
        {
            StringBuilder listOfVehiclesByStatus = new StringBuilder();
            listOfVehiclesByStatus.Append(string.Format("The list of vehicles that are in status: {0}{1}", i_WantedStatusOfVehicles, Environment.NewLine));
            foreach(string licenseNumber in m_VehicalStatusInGarage.Keys)
            {
                if(m_VehicalStatusInGarage[licenseNumber] == i_WantedStatusOfVehicles)
                {
                    listOfVehiclesByStatus.Append(licenseNumber);
                    listOfVehiclesByStatus.Append(Environment.NewLine);
                    listOfVehiclesByStatus.Append("==========");
                }
            }

            return listOfVehiclesByStatus.ToString();
        }

        public void InfaltingWheelsToMaximum(string i_LicenseNumber)
        {
            if(!CheckIfVehicleExists(i_LicenseNumber))
            {
                throw new ArgumentException("Try Again! the vehicle you want to inflate his wheels to maximum does not exist in the garage");
            }
            else
            {
                Vehicle CurrentVehicleToInflateWheelsToMax = GetVehicleInGarage(i_LicenseNumber);
                for(int i = 0; i < CurrentVehicleToInflateWheelsToMax.CollectionOfWheels.Count; i++)
                {
                    CurrentVehicleToInflateWheelsToMax.CollectionOfWheels[i].InfaltingAWheelToMax();
                }
            }
        }

        public void fuelTunkOfVehicle(string i_LicenseNumber, float i_AmountOfFuelToAdd)
        {
            if(!CheckIfVehicleExists(i_LicenseNumber))
            {
                throw new ArgumentException("Try Again! the vehicle you want to fuel his tank does not exist in the garage");
            }
            else
            {
                Vehicle CurrentVehicleTofuelTunk = GetVehicleInGarage(i_LicenseNumber);
                CurrentVehicleTofuelTunk.FuelTank(i_AmountOfFuelToAdd, CurrentVehicleTofuelTunk.FuelType);
            }
        }

        public void ChargeBatteryOfVehicle(string i_LicenseNumber, int i_AmountOfMinuteToCharge)
        {
            if(!CheckIfVehicleExists(i_LicenseNumber))
            {
                throw new ArgumentException("Try Again! the vehicle you want to charge his battery does not exist in the garage");
            }
            else
            {
                Vehicle CurrentVehicleTofuelTunk = GetVehicleInGarage(i_LicenseNumber);
                CurrentVehicleTofuelTunk.ChargeBattery(i_AmountOfMinuteToCharge);
            }
        }

        public string ShowDetailsOfVehicle(string i_LicenseNumber)
        {
            string strCurrentVehicleToShowDetails;
            if (!CheckIfVehicleExists(i_LicenseNumber))
            {
                throw new ArgumentException("Try Again! the vehicle you want to show his details does not exist in the garage");
            }
            else
            {
                Vehicle CurrentVehicleToShowDetails = GetVehicleInGarage(i_LicenseNumber);
                strCurrentVehicleToShowDetails = CurrentVehicleToShowDetails.VehicleToString();
            }

            return strCurrentVehicleToShowDetails;
        }
    }
}
