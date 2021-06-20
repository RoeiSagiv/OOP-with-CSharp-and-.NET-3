using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private const int k_CarNumberOfWheels = 4;
        private const float k_MaxAirPressure = 32f;
        private const float k_MaxTankLiter = 45f;
        private const float k_MaxBatteryInHours = 3.2f;
        private const eFuelType k_CarFuelType = eFuelType.Octan95;
        private eCarColor m_CarColor;
        private eCarDoorQuantity m_CarDoorQuantity;
        private float m_EnergyPercentageRemain;

        internal Car(string i_ModelName, string i_LicenseNumber, bool i_IsElectric, eCarColor i_CarColor, eCarDoorQuantity i_CarDoorQuantity, VehicleOwner i_Owner)
           : base(i_ModelName, i_LicenseNumber, i_IsElectric, i_Owner)
        {
            m_CarColor = i_CarColor;
            m_CarDoorQuantity = i_CarDoorQuantity;
        }

        internal eCarColor CarColor
        {
            get
            {
                return m_CarColor;
            }

            set
            {
                m_CarColor = value;
            }
        }

        internal eCarDoorQuantity CarDoorQuantity
        {
            get
            {
                return m_CarDoorQuantity;
            }

            set
            {
                m_CarDoorQuantity = value;
            }
        }

        internal override float EnergyPercentageRemain
        {
            get 
            {
                return m_EnergyPercentageRemain;
            }

            set 
            {
                m_EnergyPercentageRemain = value;
            }
        }

        public override void InitFuelTankOrBattery(float i_AmountOfFuelOrBatteryEntredToGarage) 
        {
            if(this.IsElectric)
            {
                float AmountOfBatteryEntredToGarage = i_AmountOfFuelOrBatteryEntredToGarage;
                if(AmountOfBatteryEntredToGarage > k_MaxBatteryInHours)
                {
                    throw new ValueOutOfRangeException(k_MaxBatteryInHours, 0);
                }
                else
                {
                    this.BatteryOfVehicle.CurrentBatteryInHours = AmountOfBatteryEntredToGarage;
                    this.BatteryOfVehicle.MaxBatteryInHours = k_MaxBatteryInHours;
                    this.BatteryOfVehicle.BatteryPercentageRemain = (AmountOfBatteryEntredToGarage / k_MaxBatteryInHours) * 100;
                    EnergyPercentageRemain = this.BatteryOfVehicle.BatteryPercentageRemain;
                }
            }
            else
            {
                float AmountOfFuelEntredToGarage = i_AmountOfFuelOrBatteryEntredToGarage;
                if(AmountOfFuelEntredToGarage > k_MaxTankLiter)
                {
                    throw new ValueOutOfRangeException(k_MaxTankLiter, 0);
                }
                else
                {
                    this.FuelTankOfVehicle.CurrentFuelTankInLiters = AmountOfFuelEntredToGarage;
                    this.FuelTankOfVehicle.MaxFuelTankInLiters = k_MaxTankLiter;
                    this.FuelTankOfVehicle.FuelPercentageRemainInTank = (AmountOfFuelEntredToGarage / k_MaxTankLiter) * 100;
                    EnergyPercentageRemain = this.FuelTankOfVehicle.FuelPercentageRemainInTank;
                    this.FuelTankOfVehicle.FuelType = k_CarFuelType;
                }
            }
        }

        public override void InitVehicleWheels(string i_NameOfManufacturer, float i_AirPressurePresent)
        {
            this.CollectionOfWheels = new List<Wheel>(k_CarNumberOfWheels);

            for(int i = 1; i <= k_CarNumberOfWheels; i++)
            {
                this.CollectionOfWheels.Add(new Wheel(i_NameOfManufacturer, i_AirPressurePresent, k_MaxAirPressure));
            }
        }

        internal override string ToStringVehicleWheelsDetails()
        {
            StringBuilder carWheelsStrBuild = new StringBuilder();
            carWheelsStrBuild.Append("====================\n");
            string carWheelsDetailsStr = string.Format("The details of the car wheels:{0}", Environment.NewLine);
            carWheelsStrBuild.Append(carWheelsDetailsStr);
            carWheelsStrBuild.Append("====================\n");
            carWheelsStrBuild.Append(this.CollectionOfWheels[0].ToStringWheel());
            return carWheelsStrBuild.ToString();
        }

        public override string VehicleToString()
        {
            StringBuilder carStrBuild = new StringBuilder();
            string detailsCarStr = string.Format("The details of the car:{0}", Environment.NewLine);
            carStrBuild.Append("====================\n");
            carStrBuild.Append(detailsCarStr);
            carStrBuild.Append("====================\n");
            string licenseNumber = string.Format("The license number: {0}{1}", this.LicenseNumber, Environment.NewLine);
            carStrBuild.Append(licenseNumber);
            string vehicleModel = string.Format("The vehicle model: {0}{1}", this.ModelName, Environment.NewLine);
            carStrBuild.Append(vehicleModel);
            string ownerName = string.Format("The owner name: {0}{1}", this.Owner.OwnerName, Environment.NewLine);
            carStrBuild.Append(ownerName);
            string stateInGarage = string.Format("The state in garage: {0}{1}", this.VehicleStatusInGarage, Environment.NewLine);
            carStrBuild.Append(stateInGarage);
            carStrBuild.Append(ToStringVehicleWheelsDetails());
            if(this.IsElectric)
            {
                carStrBuild.Append(this.BatteryOfVehicle.ToString());
            }
            else
            {
                carStrBuild.Append(this.FuelTankOfVehicle.ToString());
            }

            string spacielFeature = string.Format("The details of the spaciel features: {0}", Environment.NewLine);
            carStrBuild.Append("====================\n");
            carStrBuild.Append(spacielFeature);
            carStrBuild.Append("====================\n");
            string carColor = string.Format("The color of the car is: {0}{1}", m_CarColor, Environment.NewLine);
            carStrBuild.Append(carColor);
            string carCountDoors = string.Format("The number of doors the car have: {0}{1}", m_CarDoorQuantity, Environment.NewLine);
            carStrBuild.Append(carCountDoors);
            return carStrBuild.ToString();
        }
    }
}
