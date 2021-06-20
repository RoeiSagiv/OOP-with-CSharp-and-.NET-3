using System;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class FuelTank
    {
        private float m_FuelPercentageRemainInTank;
        private float m_MaxFuelTankInLiters;
        private float m_CurrentFuelTankInLiters;
        private eFuelType m_FuelType;

        internal FuelTank(float i_MaxFuelTankInLiters, float i_CurrentFuelTankInLiters, eFuelType i_FuelType)
        {
            m_MaxFuelTankInLiters = i_MaxFuelTankInLiters;
            m_CurrentFuelTankInLiters = i_CurrentFuelTankInLiters;
            m_FuelPercentageRemainInTank = (m_CurrentFuelTankInLiters / m_MaxFuelTankInLiters) * 100;
            m_FuelType = i_FuelType;
        }

        internal float MaxFuelTankInLiters
        {
            get
            {
                return m_MaxFuelTankInLiters;
            }

            set
            {
                m_MaxFuelTankInLiters = value;
            }
        }

        internal float CurrentFuelTankInLiters
        {
            get
            {
                return m_CurrentFuelTankInLiters;
            }

            set
            {
                m_CurrentFuelTankInLiters = value;
            }
        }

        internal float FuelPercentageRemainInTank
        {
            get
            {
                return m_FuelPercentageRemainInTank;
            }

            set
            {
                m_FuelPercentageRemainInTank = value;
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

        internal void FuelTheTank(float i_LitersToAddToTheFuelTank)
        {
            float litersToAddToFuelTank = i_LitersToAddToTheFuelTank;
            if((litersToAddToFuelTank + m_CurrentFuelTankInLiters) > m_MaxFuelTankInLiters)
            {
                throw new ValueOutOfRangeException(m_MaxFuelTankInLiters - m_CurrentFuelTankInLiters, 0);
            }
            else
            {
                m_CurrentFuelTankInLiters += litersToAddToFuelTank;
                m_FuelPercentageRemainInTank = (m_CurrentFuelTankInLiters / m_MaxFuelTankInLiters) * 100;
            }
        }

        internal string ToString()
        {
            StringBuilder fuelTank = new StringBuilder();
            string detailsFuelTank = string.Format("The details of the fuel tank:{0}", Environment.NewLine);
            fuelTank.Append("====================\n");
            fuelTank.Append(detailsFuelTank);
            fuelTank.Append("====================\n");
            string fuelPercentageRemainInTank = string.Format("The fuel remain in the tank in %: {0}{1}", m_FuelPercentageRemainInTank, Environment.NewLine);
            fuelTank.Append(fuelPercentageRemainInTank);
            string maxFuelTankInLiters = string.Format("The max fuel tank in liters: {0}{1}", m_MaxFuelTankInLiters, Environment.NewLine);
            fuelTank.Append(maxFuelTankInLiters);
            string currentFuelTankInLiters = string.Format("The current fuel tank in liters: {0}{1}", m_CurrentFuelTankInLiters, Environment.NewLine);
            fuelTank.Append(currentFuelTankInLiters);
            string fuelType = string.Format("The fuel type: {0}{1}", m_FuelType, Environment.NewLine);
            fuelTank.Append(fuelType);
            return fuelTank.ToString();
        }
    }
}
