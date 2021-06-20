using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_EnergyPercentageRemain;
        private bool m_IsElectric;
        private int m_VehicleNumOfWheels;
        private float m_MaxTankLiter;
        private float m_MaxBatteryInHours;
        private float m_MaxAirPressure;
        private eFuelType m_FuelType;
        private eVehicleStatusInGarage m_VehicleStatusInGarage;
        private List<Wheel> m_CollectionOfWheels;
        private VehicleOwner m_Owner;
        private Battery m_BatteryOfVehicle;
        private FuelTank m_fuelTankOfVehicle;

        public Vehicle(string i_ModelName, string i_LicenseNumber, bool i_IsElectric, VehicleOwner i_Owner)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_EnergyPercentageRemain = 100;
            m_IsElectric = i_IsElectric;
            m_Owner = i_Owner;
            m_VehicleStatusInGarage = eVehicleStatusInGarage.InRepair;
            if (!m_IsElectric)
            {
                m_fuelTankOfVehicle = new FuelTank(0f, 0, 0);
            }
            else
            {
                m_BatteryOfVehicle = new Battery(0f, 0);
            }

            m_CollectionOfWheels = new List<Wheel>();
        }

        internal string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }

            set
            {
                m_LicenseNumber = value;
            }
        }

        internal string ModelName
        {
            get
            {
                return m_ModelName;
            }

            set
            {
                m_ModelName = value;
            }
        }

        internal abstract float EnergyPercentageRemain
        {
            get;
            set;
        }

        internal int VehicleNumOfWheels
        {
            get
            {
                return m_VehicleNumOfWheels;
            }

            set
            {
                m_VehicleNumOfWheels = value;
            }
        }

        internal float TankLiter
        {
            get
            {
                return m_MaxTankLiter;
            }

            set
            {
                m_MaxTankLiter = value;
            }
        }

        internal float MaxBatteryInHours
        {
            get
            {
                return m_MaxBatteryInHours;
            }

            set
            {
                m_MaxBatteryInHours = value;
            }
        }

        internal float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }

            set
            {
                m_MaxAirPressure = value;
            }
        }

        internal bool IsElectric
        {
            get
            {
                return m_IsElectric;
            }

            set
            {
                m_IsElectric = value;
            }
        }

        internal eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }

            set
            {
                m_FuelType = value;
            }
        }

        internal eVehicleStatusInGarage VehicleStatusInGarage
        {
            get
            {
                return m_VehicleStatusInGarage;
            }

            set
            {
                m_VehicleStatusInGarage = value;
            }
        }

        internal FuelTank FuelTankOfVehicle
        {
            get
            {
                return m_fuelTankOfVehicle;
            }

            set
            {
                m_fuelTankOfVehicle = value;
            }
        }

        internal Battery BatteryOfVehicle
        {
            get
            {
                return m_BatteryOfVehicle;
            }

            set
            {
                m_BatteryOfVehicle = value;
            }
        }
        
        internal VehicleOwner Owner
        {
            get
            {
                return m_Owner;
            }

            set
            {
                m_Owner = value;
            }
        }

        internal List<Wheel> CollectionOfWheels
        {
            get
            {
                return m_CollectionOfWheels;
            }

            set
            {
                m_CollectionOfWheels = value;
            }
        }

        public abstract void InitFuelTankOrBattery(float i_AmountOfFuelOrBatteryEntredToGarage);

        public abstract void InitVehicleWheels(string i_NameOfManufacturer, float i_AirPressurePresent);

        internal abstract string ToStringVehicleWheelsDetails();

        public abstract string VehicleToString();

        internal void FuelTank(float i_AmountOfFuelToAdd, eFuelType i_FuelTypeToAdd) 
        {
            if(m_FuelType == i_FuelTypeToAdd)
            {
                m_fuelTankOfVehicle.FuelTheTank(i_AmountOfFuelToAdd);
            }
            else
            {
                throw new ArgumentException("Notice! please check you entered the currect fuel type");
            }
        }

        internal void ChargeBattery(int i_AmountOfMinutesToAdd)
        {
            m_BatteryOfVehicle.ChargeBattery(i_AmountOfMinutesToAdd);
        }

        internal class Wheel
        {
            private string m_NameOfManufacturer;
            private float m_AirPressurePresent;
            private float m_MaxAirPressureByManufacturer;

            internal Wheel(string i_NameOfManufacturer, float i_AirPressurePresent, float i_MaxAirPressureByManufacturer)
            {
                m_NameOfManufacturer = i_NameOfManufacturer;
                m_AirPressurePresent = i_AirPressurePresent;
                m_MaxAirPressureByManufacturer = i_MaxAirPressureByManufacturer;
            }

            internal string NameOfManufacturer
            {
                get
                {
                    return m_NameOfManufacturer;
                }

                set
                {
                    m_NameOfManufacturer = value;
                }
            }

            internal float AirPressurePresent
            {
                get
                {
                    return m_AirPressurePresent;
                }

                set
                {
                    m_AirPressurePresent = value;
                }
            }

            internal float MaxAirPressureByManufacturer
            {
                get
                {
                    return m_MaxAirPressureByManufacturer;
                }

                set
                {
                    m_MaxAirPressureByManufacturer = value;
                }
            }

            internal void InfaltingAWheel(float i_AmountOfAirToAddToWheel)
            {
                float amountOfAirToAddToWheel = i_AmountOfAirToAddToWheel;
                if ((amountOfAirToAddToWheel + m_AirPressurePresent) > m_MaxAirPressureByManufacturer)
                {
                    throw new ValueOutOfRangeException(m_MaxAirPressureByManufacturer - m_AirPressurePresent, 0);
                }
                else
                {
                    m_AirPressurePresent += amountOfAirToAddToWheel;
                }
            }

            internal void InfaltingAWheelToMax()
            {
                float amountToAdd = m_MaxAirPressureByManufacturer - m_AirPressurePresent;
                m_AirPressurePresent += amountToAdd;
            }

            internal string ToStringWheel() 
            {
                StringBuilder wheel = new StringBuilder();
                string nameOfManufacturer = string.Format("The name of the manufacturer: {0}{1}", m_NameOfManufacturer, Environment.NewLine);
                wheel.Append(nameOfManufacturer);
                string airPressurePresent = string.Format("The present air pressure: {0}{1}", m_AirPressurePresent, Environment.NewLine);
                wheel.Append(airPressurePresent);
                string maxAirPressureByManufacturer = string.Format("The max air pressure by the manufacturer: {0}{1}", m_MaxAirPressureByManufacturer, Environment.NewLine);
                wheel.Append(maxAirPressureByManufacturer);

                return wheel.ToString();
            }
        }
    }
} 
