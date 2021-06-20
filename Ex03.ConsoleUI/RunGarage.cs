using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class RunGarage
    {
        private Garage m_Garage = new Garage();
        
        internal void Run()
        {
            GarageInterface.WelcomeToGarage();
            int operationFromUser = 0;
          
            while(true)
            {
                try
                {
                    operationFromUser = GarageInterface.GetGarageOperationFromUser();
                    switch (operationFromUser)
                    {
                        case 1:
                            enterNewVehicle();
                            Messages.PrintIfSuccessfully(operationFromUser);
                            break;

                        case 2:
                            showVehicleStatusInGarage();
                            Messages.PrintIfSuccessfully(operationFromUser);
                            break;
                        case 3:
                            updateVehicleStatusInGarage();
                            Messages.PrintIfSuccessfully(operationFromUser);
                            break;
                        case 4:
                            infaltingWheelsToMaximum();
                            Messages.PrintIfSuccessfully(operationFromUser);
                            break;
                        case 5:
                            fuelTunkOfVehicle();
                            Messages.PrintIfSuccessfully(operationFromUser);
                            break;
                        case 6:
                            chargeBatteryOfVehicle();
                            Messages.PrintIfSuccessfully(operationFromUser);
                            break;
                        case 7:
                            showDetailsOfVehicle();
                            Messages.PrintIfSuccessfully(operationFromUser);
                            break;
                    } 
                }
                catch(FormatException errorMessages)
                {
                    Console.WriteLine(errorMessages);
                }
                catch (ValueOutOfRangeException errorMessages)
                {
                    Console.WriteLine(string.Format("Notice! the number you have entered is out of the range:{0} - {1}", errorMessages.MinValue, errorMessages.MaxValue));
                }
            }
        }

        internal void enterNewVehicle()
        {
            bool isSuccess = false;
            while (!isSuccess)
            {
                try
                {
                    bool isElectric = false;
                    float vehicleBatteryOrFuelTankState = 0f;
                    string modelName = GarageInterface.GetModelName();
                    string licenseNumber = GarageInterface.GetLicenseNumber();
                    if(modelName != "Truck")
                    {
                        isElectric = GarageInterface.GetIfVehicleIsElectric();
                        if(isElectric)
                        {
                            vehicleBatteryOrFuelTankState = GarageInterface.GetBatteryStateWhenVehicleEntred();
                        }
                        else
                        {
                            vehicleBatteryOrFuelTankState = GarageInterface.GetFuelTankStateWhenVehicleEntred();
                        }
                    }
                    else 
                    {
                        vehicleBatteryOrFuelTankState = GarageInterface.GetFuelTankStateWhenVehicleEntred();
                    }

                    string nameOfOwner = GarageInterface.GetOwnerName();
                    string phoneNumberOfOwner = GarageInterface.GetOwnerPhoneNumber();
                    VehicleOwner ownerOfVehicle = new VehicleOwner(nameOfOwner, phoneNumberOfOwner);
                    string wheelNameManufacturer = GarageInterface.GetWheelManufacturerName();
                    float wheelAirPressurePresent = GarageInterface.GetWheelAirPressureWhenEnterd();
                    eVehicleType vehicleType = convertToeVehicleType(modelName);
                    Vehicle newVehicleToEnter = null;
                    if (eVehicleType.Motorcycle.Equals(vehicleType))
                    {
                        int motorcycleEngineVolCC = 0;
                        eMotorcycleLicenseType motorcycleLicenseType = GarageInterface.GetMotorcycleSpecialFeatures(out motorcycleEngineVolCC);
                        newVehicleToEnter = VehicleTypeGenerator.AddMotorcycleType(modelName, licenseNumber, isElectric, motorcycleEngineVolCC, motorcycleLicenseType, ownerOfVehicle, vehicleType, vehicleBatteryOrFuelTankState, wheelNameManufacturer, wheelAirPressurePresent);
                    }
                    else if (eVehicleType.Car.Equals(vehicleType))
                    {
                        eCarColor colorOfCar = 0;
                        eCarDoorQuantity carDoorQuantity = GarageInterface.GetCarSpecialFeatures(out colorOfCar);
                        newVehicleToEnter = VehicleTypeGenerator.AddCarType(modelName, licenseNumber, isElectric, colorOfCar, carDoorQuantity, ownerOfVehicle, vehicleType, vehicleBatteryOrFuelTankState, wheelNameManufacturer, wheelAirPressurePresent);
                    }
                    else if (eVehicleType.Truck.Equals(vehicleType))
                    {
                        bool isContainHazardousMaterials = false;
                        float truckMaxCarryingWeight = GarageInterface.GetTruckSpecialFeatures(out isContainHazardousMaterials);
                        newVehicleToEnter = VehicleTypeGenerator.AddTruckType(modelName, licenseNumber, isElectric, isContainHazardousMaterials, truckMaxCarryingWeight, ownerOfVehicle, vehicleType, vehicleBatteryOrFuelTankState, wheelNameManufacturer, wheelAirPressurePresent);
                    }

                    m_Garage.EnterNewVehicle(licenseNumber, newVehicleToEnter);

                    isSuccess = true;
                }
                catch (FormatException errorMessages)
                {
                    Console.WriteLine(errorMessages);
                }
                catch (ArgumentException errorMessages)
                {
                    Console.WriteLine(errorMessages);
                }
                catch (ValueOutOfRangeException errorMessages)
                {
                    Console.WriteLine(string.Format("Notice! the number you have entered is out of the range:{0} - {1}", errorMessages.MinValue, errorMessages.MaxValue));
                }
            }
        }

        private static eVehicleType convertToeVehicleType(string i_ModelName)
        {
            eVehicleType vehicleType = 0;
                if(i_ModelName == "Motorcycle")
                {
                    vehicleType = eVehicleType.Motorcycle;
                }
                else if(i_ModelName == "Car")
                {
                    vehicleType = eVehicleType.Car;
                }
                else if(i_ModelName == "Truck")
                {
                    vehicleType = eVehicleType.Truck;
                }
           
            return vehicleType;
        }

        private void showVehicleStatusInGarage()
        {
            bool isSuccess = false;
            while(!isSuccess)
            {
                try
                {
                    eVehicleStatusInGarage vehicleStatusInGarageInput = GarageInterface.GetWhichStatusToShowTheVehiclesList();
                    string vehiclesListByStatus = m_Garage.ShowVehicleStatusInGarage(vehicleStatusInGarageInput);
                    Console.WriteLine(vehiclesListByStatus);
                    isSuccess = true;
                }
                catch (FormatException errorMessages)
                {
                    Console.WriteLine(errorMessages);
                }
                catch (ValueOutOfRangeException errorMessages)
                {
                    Console.WriteLine(string.Format("Notice! the number you have entered is out of the range:{0} - {1}", errorMessages.MinValue, errorMessages.MaxValue));
                }
            }
        }

        private void updateVehicleStatusInGarage()
        {
            bool isSuccess = false;
            while(!isSuccess)
            {
                try
                {
                    string licenseNumber = GarageInterface.GetLicenseNumber();
                    eVehicleStatusInGarage vehicleNewStatus = GarageInterface.GetNewStatus();
                    m_Garage.UpdateVehicleStatusInGarage(licenseNumber, vehicleNewStatus);
                    isSuccess = true;
                }
                catch (FormatException errorMessages)
                {
                    Console.WriteLine(errorMessages);
                }
                catch (ValueOutOfRangeException errorMessages)
                {
                    Console.WriteLine(string.Format("Notice! the number you have entered is out of the range:{0} - {1}", errorMessages.MinValue, errorMessages.MaxValue));
                }
            }
        }

        private void infaltingWheelsToMaximum()
        {
            bool isSuccess = false;
            while(!isSuccess)
            {
                try
                {
                    string licenseNumber = GarageInterface.GetLicenseNumber();
                    m_Garage.InfaltingWheelsToMaximum(licenseNumber);
                    isSuccess = true;
                }
                catch(ArgumentException errorMessages)
                {
                    Console.WriteLine(errorMessages);
                }
                catch(ValueOutOfRangeException errorMessages)
                {
                    Console.WriteLine(string.Format("Notice! the number you have entered is out of the range:{0} - {1}", errorMessages.MinValue, errorMessages.MaxValue));
                }
            }
        }

        private void fuelTunkOfVehicle()
        {
            bool isSuccess = false;
            while(!isSuccess)
            {
                try
                {
                    string licenseNumber = GarageInterface.GetLicenseNumber();
                    float amountFuelToAddToTank = GarageInterface.GetFuelsLitersToAddToFuelTank();
                    m_Garage.fuelTunkOfVehicle(licenseNumber, amountFuelToAddToTank);
                    isSuccess = true;
                }
                catch(FormatException errorMessages)
                {
                    Console.WriteLine(errorMessages);
                }
                catch(ArgumentException errorMessages)
                {
                    Console.WriteLine(errorMessages);
                }
                catch(ValueOutOfRangeException errorMessages)
                {
                    Console.WriteLine(string.Format("Notice! the number you have entered is out of the range:{0} - {1}", errorMessages.MinValue, errorMessages.MaxValue));
                }
            }
        }

        private void chargeBatteryOfVehicle()
        {
            bool isSuccess = false;
            while(!isSuccess)
            {
                try
                {
                    string licenseNumber = GarageInterface.GetLicenseNumber();
                    int amountFuelToAddToTank = GarageInterface.GetMinutesToChargeBattery();
                    m_Garage.ChargeBatteryOfVehicle(licenseNumber, amountFuelToAddToTank);
                }
                catch(FormatException errorMessages)
                {
                    Console.WriteLine(errorMessages);
                }
                catch(ArgumentException errorMessages)
                {
                    Console.WriteLine(errorMessages);
                }
                catch(ValueOutOfRangeException errorMessages)
                {
                    Console.WriteLine(string.Format("Notice! the number you have entered is out of the range:{0} - {1}", errorMessages.MinValue, errorMessages.MaxValue));
                }

                isSuccess = true;
            }
        }

        private void showDetailsOfVehicle()
        {
            bool isSuccess = false;
            while(!isSuccess)
            {
                try
                {
                    string licenseNumber = GarageInterface.GetLicenseNumber();
                    string strCurrentVehicleToShowDetails = m_Garage.ShowDetailsOfVehicle(licenseNumber);
                    Console.WriteLine(strCurrentVehicleToShowDetails);
                    isSuccess = true;
                }
                catch(ArgumentException errorMessages)
                {
                    Console.WriteLine(errorMessages);
                }
            }
        }
    } 
}
