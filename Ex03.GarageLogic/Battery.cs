using System;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Battery
    {
        private float m_BatteryPercentageRemain;
        private float m_MaxBatteryInHours;
        private float m_CurrentBatteryInHours;

        internal Battery(float i_MaxBatteryInHours, float i_CurrentBatteryInHours) 
        {
            m_MaxBatteryInHours = i_MaxBatteryInHours;
            m_CurrentBatteryInHours = i_CurrentBatteryInHours;
            m_BatteryPercentageRemain = (m_CurrentBatteryInHours / m_MaxBatteryInHours) * 100;
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

        internal float CurrentBatteryInHours
        {
            get
            {
                return m_CurrentBatteryInHours;
            }

            set
            {
                m_CurrentBatteryInHours = value;
            }
        }

        internal float BatteryPercentageRemain
        {
            get
            {
                return m_BatteryPercentageRemain;
            }

            set
            {
                m_BatteryPercentageRemain = value;
            }
        }

        internal void ChargeBattery(int i_MinutesToAddToBattery) 
        {
            float hoursToAddToBattery = i_MinutesToAddToBattery / 60;
            if((hoursToAddToBattery + m_CurrentBatteryInHours) > m_MaxBatteryInHours)
            {
                throw new ValueOutOfRangeException(m_MaxBatteryInHours - m_CurrentBatteryInHours, 0);
            }
            else
            {
                m_CurrentBatteryInHours += hoursToAddToBattery;
                m_BatteryPercentageRemain = (m_CurrentBatteryInHours / m_MaxBatteryInHours) * 100;
            }
        }

        internal string ToString()
        {
            StringBuilder battery = new StringBuilder();
            string detailsBattery = string.Format("The details of the battery:{0}", Environment.NewLine);
            battery.Append("====================\n");
            battery.Append(detailsBattery);
            battery.Append("====================\n");
            string batteryPercentageRemain = string.Format("The battery remain in %: {0}{1}", m_BatteryPercentageRemain, Environment.NewLine);
            battery.Append(batteryPercentageRemain);
            string maxBatteryInHours = string.Format("The max battery in hours: {0}{1}", m_MaxBatteryInHours, Environment.NewLine);
            battery.Append(maxBatteryInHours);
            string currentBatteryInHours = string.Format("The current battery in hours: {0}{1}", m_CurrentBatteryInHours, Environment.NewLine);
            battery.Append(currentBatteryInHours);

            return battery.ToString();
        }
    }
}
