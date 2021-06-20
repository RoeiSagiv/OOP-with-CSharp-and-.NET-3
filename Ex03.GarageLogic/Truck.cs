using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private const int k_TruckNumberOfWheels = 16;
        private const float k_MaxAirPressure = 26f;
        private const float k_MaxTankLiter = 120f;
        private const float k_MaxBatteryInHours = 0f;
        private const eFuelType k_TruckFuelType = eFuelType.Soler;
        private bool m_IsContainHazardousMaterials;
        private float m_MaxCarryingWeight;
        private float m_EnergyPercentageRemain;

        internal Truck(string i_ModelName, string i_LicenseNumber, bool i_IsElectric, bool i_IsContainHazardousMaterials, float i_MaxCarryingWeight, VehicleOwner i_Owner)
           : base(i_ModelName, i_LicenseNumber, i_IsElectric, i_Owner)
        {
            m_IsContainHazardousMaterials = i_IsContainHazardousMaterials;
            m_MaxCarryingWeight = i_MaxCarryingWeight;
        }

        internal float MaxCarryingWeight
        {
            get
            {
                return m_MaxCarryingWeight;
            }

            set
            {
                m_MaxCarryingWeight = value;
            }
        }

        internal bool IsContainHazardousMaterials
        {
            get
            {
                return m_IsContainHazardousMaterials;
            }

            set
            {
                m_IsContainHazardousMaterials = value;
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
            float AmountOfFuelEntredToGarage = i_AmountOfFuelOrBatteryEntredToGarage;
            if (AmountOfFuelEntredToGarage > k_MaxTankLiter)
            {
                throw new ValueOutOfRangeException(k_MaxTankLiter, 0);
            }
            else
            {
                this.FuelTankOfVehicle.CurrentFuelTankInLiters = AmountOfFuelEntredToGarage;
                this.FuelTankOfVehicle.MaxFuelTankInLiters = k_MaxTankLiter;
                this.FuelTankOfVehicle.FuelPercentageRemainInTank = (AmountOfFuelEntredToGarage / k_MaxTankLiter) * 100;
                EnergyPercentageRemain = this.FuelTankOfVehicle.FuelPercentageRemainInTank;
                this.FuelTankOfVehicle.FuelType = k_TruckFuelType;
            }   
        }

        public override void InitVehicleWheels(string i_NameOfManufacturer, float i_AirPressurePresent)
        {
            this.CollectionOfWheels = new List<Wheel>(k_TruckNumberOfWheels);

            for (int i = 1; i <= k_TruckNumberOfWheels; i++)
            {
                this.CollectionOfWheels.Add(new Wheel(i_NameOfManufacturer, i_AirPressurePresent, k_MaxAirPressure));
            }
        }

        internal override string ToStringVehicleWheelsDetails()
        {
            StringBuilder truckWheelsStrBuild = new StringBuilder();
            truckWheelsStrBuild.Append("====================\n");
            string truckWheelsStr = string.Format("The details of the truck wheels:{0}", Environment.NewLine);
            truckWheelsStrBuild.Append(truckWheelsStr);
            truckWheelsStrBuild.Append("====================\n");
            truckWheelsStrBuild.Append(this.CollectionOfWheels[0].ToStringWheel());
            return truckWheelsStrBuild.ToString();
        }

        public override string VehicleToString()
        {
            StringBuilder truckStrBuild = new StringBuilder();
            string detailstruckStr = string.Format("The details of the truck:{0}", Environment.NewLine);
            truckStrBuild.Append("====================\n");
            truckStrBuild.Append(detailstruckStr);
            truckStrBuild.Append("====================\n");
            string licenseNumberStr = string.Format("The license number: {0}{1}", this.LicenseNumber, Environment.NewLine);
            truckStrBuild.Append(licenseNumberStr);
            string vehicleModelStr = string.Format("The vehicle model: {0}{1}", this.ModelName, Environment.NewLine);
            truckStrBuild.Append(vehicleModelStr);
            string ownerNameStr = string.Format("The owner name: {0}{1}", this.Owner.OwnerName, Environment.NewLine);
            truckStrBuild.Append(ownerNameStr);
            string stateInGarageStr = string.Format("The state in garage: {0}{1}", this.VehicleStatusInGarage, Environment.NewLine);
            truckStrBuild.Append(stateInGarageStr);
            truckStrBuild.Append(ToStringVehicleWheelsDetails());
            truckStrBuild.Append(this.FuelTankOfVehicle.ToString());
            string spacielFeature = string.Format("The details of the spaciel features: {0}", Environment.NewLine);
            truckStrBuild.Append("====================\n");
            truckStrBuild.Append(spacielFeature);
            truckStrBuild.Append("====================\n");
            string isContainHazardousMaterialsStr = string.Format("Is contain hazardous materials? {0}{1}", m_IsContainHazardousMaterials, Environment.NewLine);
            truckStrBuild.Append(isContainHazardousMaterialsStr);
            string maxCarryingWeightStr = string.Format("The max carrying weight: {0}{1}", m_MaxCarryingWeight, Environment.NewLine);
            truckStrBuild.Append(maxCarryingWeightStr);
            return truckStrBuild.ToString();
        }
    }
}
