using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private const int k_MotorcycleNumberOfWheels = 2;
        private const float k_MaxAirPressure = 30f;
        private const float k_MaxTankLiter = 6f;
        private const float k_MaxBatteryInHours = 1.8f;
        private const eFuelType k_MotorcycleFuelType = eFuelType.Octan98;
        private int m_EngineVolumeCC;
        private eMotorcycleLicenseType m_TypeOfLicense;
        private float m_EnergyPercentageRemain;

        public Motorcycle(string i_ModelName, string i_LicenseNumber, bool i_IsElectric, int i_EngineVolumeCC, eMotorcycleLicenseType i_LicenseType, VehicleOwner i_Owner)
           : base(i_ModelName, i_LicenseNumber, i_IsElectric, i_Owner)
        {
            m_EngineVolumeCC = i_EngineVolumeCC;
            m_TypeOfLicense = i_LicenseType;
        }

        public int EngineVolumeCC
        {
            get
            {
                return m_EngineVolumeCC;
            }

            set
            {
                m_EngineVolumeCC = value;
            }
        }

        public eMotorcycleLicenseType TypeOfLicense
        {
            get
            {
                return m_TypeOfLicense;
            }

            set
            {
                m_TypeOfLicense = value;
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
            if (this.IsElectric)
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
                    this.FuelTankOfVehicle.FuelType = k_MotorcycleFuelType;
                }            
            }
        }

        public override void InitVehicleWheels(string i_NameOfManufacturer, float i_AirPressurePresent)
        {
            this.CollectionOfWheels = new List<Wheel>(k_MotorcycleNumberOfWheels);

            for(int i = 1; i <= k_MotorcycleNumberOfWheels; i++)
            {
                this.CollectionOfWheels.Add(new Wheel(i_NameOfManufacturer, i_AirPressurePresent, k_MaxAirPressure));
            }
        }

        internal override string ToStringVehicleWheelsDetails()
        {
            StringBuilder motorcycleWheelsStrBuild = new StringBuilder();
            motorcycleWheelsStrBuild.Append("====================\n");
            string motorcycleWheelsStr = string.Format("The details of the motorcycle wheels:{0}", Environment.NewLine);
            motorcycleWheelsStrBuild.Append(motorcycleWheelsStr);
            motorcycleWheelsStrBuild.Append("====================\n");
            motorcycleWheelsStrBuild.Append(this.CollectionOfWheels[0].ToStringWheel());
            return motorcycleWheelsStrBuild.ToString();
        }

        public override string VehicleToString()
        {
            StringBuilder motorcycleStrBuild = new StringBuilder();
            motorcycleStrBuild.Append("====================\n");
            string detailsMotorcycleStr = string.Format("The details of the motorcycle:{0}", Environment.NewLine);
            motorcycleStrBuild.Append(detailsMotorcycleStr);
            motorcycleStrBuild.Append("====================\n");
            string licenseNumberStr = string.Format("The license number: {0}{1}", this.LicenseNumber, Environment.NewLine);
            motorcycleStrBuild.Append(licenseNumberStr);
            string vehicleModelStr = string.Format("The vehicle model: {0}{1}", this.ModelName, Environment.NewLine);
            motorcycleStrBuild.Append(vehicleModelStr);
            string ownerNameStr = string.Format("The owner name: {0}{1}", this.Owner.OwnerName, Environment.NewLine);
            motorcycleStrBuild.Append(ownerNameStr);
            string stateInGarageStr = string.Format("The state in garage: {0}{1}", this.VehicleStatusInGarage, Environment.NewLine);
            motorcycleStrBuild.Append(stateInGarageStr);
            motorcycleStrBuild.Append(ToStringVehicleWheelsDetails());
            if (this.IsElectric)
            {
                motorcycleStrBuild.Append(this.BatteryOfVehicle.ToString());
            }
            else
            {
                motorcycleStrBuild.Append(this.FuelTankOfVehicle.ToString());
            }

            string spacielFeature = string.Format("The details of the spaciel features: {0}", Environment.NewLine);
            motorcycleStrBuild.Append("====================\n");
            motorcycleStrBuild.Append(spacielFeature);
            motorcycleStrBuild.Append("====================\n");
            string typeOfLicenseStr = string.Format("The type of the license: {0}{1}", m_TypeOfLicense, Environment.NewLine);
            motorcycleStrBuild.Append(typeOfLicenseStr);
            string engineVolumeCCStr = string.Format("The engine volume in CC: {0}{1}", m_EngineVolumeCC, Environment.NewLine);
            motorcycleStrBuild.Append(engineVolumeCCStr);
            return motorcycleStrBuild.ToString();
        }
    }
}
