namespace Ex03.GarageLogic
{
    public class VehicleTypeGenerator
    {
        public static Vehicle AddMotorcycleType(string i_ModelName, string i_LicenseNumber, bool i_IsElectric, int i_MotorcycleEngineVolCC, eMotorcycleLicenseType I_MotorcycleLicenseType, VehicleOwner i_Owner, eVehicleType i_TypeOfVehicle, float i_VehicleBatteryOrFuelTankState, string i_WheelNameManufacturer, float i_WheelAirPressurePresent)
        {
            Vehicle newMotorcycle = null;
            newMotorcycle = new Motorcycle(i_ModelName, i_LicenseNumber, i_IsElectric, i_MotorcycleEngineVolCC, I_MotorcycleLicenseType, i_Owner);
            newMotorcycle.InitFuelTankOrBattery(i_VehicleBatteryOrFuelTankState);
            newMotorcycle.InitVehicleWheels(i_WheelNameManufacturer, i_WheelAirPressurePresent);
            return newMotorcycle;
        }

        public static Vehicle AddCarType(string i_ModelName, string i_LicenseNumber, bool i_IsElectric, eCarColor i_CarColor, eCarDoorQuantity i_CarDoorQuantity, VehicleOwner i_Owner, eVehicleType i_TypeOfVehicle, float i_VehicleBatteryOrFuelTankState, string i_WheelNameManufacturer, float i_WheelAirPressurePresent)
        {
            Vehicle newCar = null;
            newCar = new Car(i_ModelName, i_LicenseNumber, i_IsElectric, i_CarColor, i_CarDoorQuantity, i_Owner);
            newCar.InitFuelTankOrBattery(i_VehicleBatteryOrFuelTankState);
            newCar.InitVehicleWheels(i_WheelNameManufacturer, i_WheelAirPressurePresent);
            return newCar;
        }

        public static Vehicle AddTruckType(string i_ModelName, string i_LicenseNumber, bool i_IsElectric, bool i_IsContainHazardousMaterials, float i_MaxCarryingWeight, VehicleOwner i_Owner, eVehicleType i_TypeOfVehicle, float i_VehicleBatteryOrFuelTankState, string i_WheelNameManufacturer, float i_WheelAirPressurePresent)
        {
            Vehicle newTruck = null;
            newTruck = new Truck(i_ModelName, i_LicenseNumber, i_IsElectric, i_IsContainHazardousMaterials, i_MaxCarryingWeight, i_Owner);
            newTruck.InitFuelTankOrBattery(i_VehicleBatteryOrFuelTankState);
            newTruck.InitVehicleWheels(i_WheelNameManufacturer, i_WheelAirPressurePresent);
            return newTruck;
        }
    }
}
