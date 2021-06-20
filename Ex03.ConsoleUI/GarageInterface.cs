using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class GarageInterface
    {
        private static string m_QuitSymbol = "Q";

        private static string getInputFromUserOfTheSystem()
        {
            string inputFromUser = Console.ReadLine();
            while(inputFromUser == string.Empty)
            {
                Console.WriteLine("Notice! your input is invalid!");
                inputFromUser = Console.ReadLine();
            }

            CheckIfToQuitSystem(inputFromUser);
            ClearTheConsole();
            return inputFromUser;
        }

        internal static void WelcomeToGarage() 
        {
            Console.WriteLine("Welcome to the best garage system in the world!!!");
            Console.WriteLine("This system will help you to manage your garage in the best and eazy way");
            ClearTheConsole();
        }

        internal static int GetGarageOperationFromUser()
        {
            int operationFromUserToInt;

            Console.WriteLine("In our system you can choose from list of opertions:");
            Console.WriteLine("1. Enter new vehicle.");
            Console.WriteLine("2. Show list of the vehicles in the garage by license number and status.");
            Console.WriteLine("3. Change status of vehicle.");
            Console.WriteLine("4. Infalting the Wheels to maximum.");
            Console.WriteLine("5. Fuel the tank of the vehicle.");
            Console.WriteLine("6. Charge the battery of the vehicle.");
            Console.WriteLine("7. Show all the details of the vehicle by license number.");
            Console.WriteLine("Which opertion do you want to preform? Please Enter the number of operation");

            bool goodInput = int.TryParse(getInputFromUserOfTheSystem(), out operationFromUserToInt);
            if(!goodInput)
            {
                throw new FormatException("Parsing error please check your input");
            }
            else if(operationFromUserToInt < 1 || operationFromUserToInt > 7)
            {
                throw new ValueOutOfRangeException(7f, 1f);
            }

            return operationFromUserToInt;
        }

        internal static string GetOwnerName()
        {
            Console.WriteLine("Please enter the name of the owner?");
            string ownerNameFromUser = getInputFromUserOfTheSystem();
            return ownerNameFromUser;
        }

        internal static string GetOwnerPhoneNumber()
        {
            Console.WriteLine("What is the phone number of the vehicle owner?");
            string validPhoneNumberFromUser;
            string errorMassages;
            if(!checkIfPhoneNumberValid(getInputFromUserOfTheSystem(), out validPhoneNumberFromUser, out errorMassages))
            {
                throw new ArgumentException(errorMassages);
            }

            return validPhoneNumberFromUser;
        }

        internal static string GetLicenseNumber()
        {
            Console.WriteLine("What is the license number of the vehicle?");
            string validLicenseNumberFromUser;
            string errorMassages;
            if (!checkIfLicenseNumberValid(getInputFromUserOfTheSystem(), out validLicenseNumberFromUser, out errorMassages))
            {
                throw new ArgumentException(errorMassages);
            }

            return validLicenseNumberFromUser;
        }

        private static bool checkIfLicenseNumberValid(string i_StrFromUser, out string validLicense, out string errorMassages)
        {
            bool inputValid = true;
            errorMassages = " ";
            if(!checkIfInputIsSizeSevenOrEight(i_StrFromUser))
            {
                inputValid = false;
                validLicense = string.Empty;
                errorMassages = "Notice! your input is invalid! Please enter a new string of size 7 or 8!";
            }

            if(!checkIfInputIsOnlyNumbers(i_StrFromUser))
            {
                inputValid = false;
                validLicense = string.Empty;
                errorMassages = "Notice! your input is invalid! Please enter a new string which consist only letters!";
            }

            validLicense = i_StrFromUser;

            return inputValid;
        }

        private static bool checkIfPhoneNumberValid(string i_StrFromUser, out string validPhoneNumber, out string errorMassages)
        {
            bool inputValid = true;
            errorMassages = " ";
            if (!checkIfInputIsSizeTen(i_StrFromUser))
            {
                inputValid = false;
                validPhoneNumber = string.Empty;
                errorMassages = "Notice! your input is invalid! Please enter a new string of size 10!";
            }

            if (!checkIfInputIsOnlyNumbers(i_StrFromUser))
            {
                inputValid = false;
                validPhoneNumber = string.Empty;
                errorMassages = "Notice! your input is invalid! Please enter a new string which consist only letters!";
            }

            validPhoneNumber = i_StrFromUser;

            return inputValid;
        }

        private static bool checkIfInputIsSizeSevenOrEight(string i_StrFromUser)
        {
            bool isSizeSevenOrEight = true;
            int lengthOfInputStr = i_StrFromUser.Length;
            if(lengthOfInputStr != 7 && lengthOfInputStr != 8)
            {
                isSizeSevenOrEight = false;
            }

            return isSizeSevenOrEight;
        }

        private static bool checkIfInputIsOnlyNumbers(string i_StrFromUser)
        {
            bool isInputOnlyNumbers = true;
            for(int i = 0; i < i_StrFromUser.Length; i++)
            {
                if(!char.IsDigit(i_StrFromUser[i]))
                {
                    isInputOnlyNumbers = false;
                    break;
                }
            }

            return isInputOnlyNumbers;
        }

        private static bool checkIfInputIsSizeTen(string i_StrFromUser)
        {
            bool isSizeTen = true;
            int lengthOfInputStr = i_StrFromUser.Length;
            if(lengthOfInputStr != 10)
            {
                isSizeTen = false;
            }

            return isSizeTen;
        }

        internal static string GetModelName()
        {
            Console.WriteLine("Please enter the model name of the vehicle?  1 - Motorcycle or 2 - Car or 3 - Truck!");
            int numOfVehicleType;
            string vehicleType;
            bool vehicleTypeGoodInput = int.TryParse(getInputFromUserOfTheSystem(), out numOfVehicleType);
            if(!vehicleTypeGoodInput)
            {
                throw new FormatException("Parsing error please check your input");
            }
            else if (numOfVehicleType < 1 || numOfVehicleType > 3)
            {
                throw new ValueOutOfRangeException(3f, 1f);
            }
            else if ((int)eVehicleType.Car == numOfVehicleType)
            {
                vehicleType = "Car";
            }
            else if ((int)eVehicleType.Motorcycle == numOfVehicleType)
            {
                vehicleType = "Motorcycle";
            }
            else
            {
                vehicleType = "Truck";
            }

            return vehicleType;
        }

        internal static bool GetIfVehicleIsElectric() 
        {
            bool vehicleIsElectric = false;

            Console.WriteLine("Please enter YES if your vehicle is electric, otherwise enter NO");
            string InputFromUserIfElectric = getInputFromUserOfTheSystem();
            if(!"YES".Equals(InputFromUserIfElectric, StringComparison.CurrentCultureIgnoreCase) && !"NO".Equals(InputFromUserIfElectric, StringComparison.CurrentCultureIgnoreCase))
            {
                throw new ArgumentException("Try Again! please enter only YES or No");
            }
            else if("YES".Equals(InputFromUserIfElectric, StringComparison.CurrentCultureIgnoreCase))
            {
                vehicleIsElectric = true;
            }

            return vehicleIsElectric;
        }

        internal static float GetBatteryStateWhenVehicleEntred()
        {
            float batteryStateWhenVehicleEntred = 0f;

            Console.WriteLine("Please enter the battery state, how much battery(in hours) left in the vehicle?");
            bool goodInput = float.TryParse(getInputFromUserOfTheSystem(), out batteryStateWhenVehicleEntred);
            if(!goodInput)
            {
                throw new FormatException("Try Again! please enter battery state in hours");
            }

            return batteryStateWhenVehicleEntred;
        }

        internal static float GetFuelTankStateWhenVehicleEntred()
        {
            float fuelTankStateWhenVehicleEntred = 0f;

            Console.WriteLine("Please enter the fuel tank state, how much fuel(in litters) left in the vehicle?");
            bool goodInput = float.TryParse(getInputFromUserOfTheSystem(), out fuelTankStateWhenVehicleEntred);
            if(!goodInput)
            {
                throw new FormatException("Try Again! please enter fuel tank state in litters");
            }

            return fuelTankStateWhenVehicleEntred;
        }

        internal static int GetMinutesToChargeBattery()
        {
            int minutesToChargeBattery = 0;

            Console.WriteLine("Please enter how much time(in hours) do you want to charge the vehicle?");
            bool goodInput = int.TryParse(getInputFromUserOfTheSystem(), out minutesToChargeBattery);
            if (!goodInput)
            {
                throw new FormatException("Try Again! please enter in hours the time to charge the vehicle");
            }

            return minutesToChargeBattery;
        }

        internal static float GetFuelsLitersToAddToFuelTank()
        {
            float fuelsLitersToAddToFuelTank = 0f;

            Console.WriteLine("Please enter how many liters do you want to fuel the tank?");
            bool goodInput = float.TryParse(getInputFromUserOfTheSystem(), out fuelsLitersToAddToFuelTank);
            if (!goodInput)
            {
                throw new FormatException("Try Again! please enter in liters the amount to fuel the tank");
            }

            return fuelsLitersToAddToFuelTank;
        }

        internal static eFuelType GetFuelType()
        {
            Console.WriteLine("Please enter the fuel type of the vehicle?  1 - Soler or 2 - Octan95 or 3 - Octan96 or 4 - Octan98!");
            int numOfFuelType;
            eFuelType fuelType;
            bool fuelTypeGoodInput = int.TryParse(getInputFromUserOfTheSystem(), out numOfFuelType);
            if(!fuelTypeGoodInput)
            {
                throw new FormatException("Parsing error please check your input");
            }
            else if(numOfFuelType < 1 || numOfFuelType > 4)
            {
                throw new ValueOutOfRangeException(4f, 1f);
            }
            else if((int)eFuelType.Soler == numOfFuelType)
            {
                fuelType = eFuelType.Soler;
            }
            else if((int)eFuelType.Octan95 == numOfFuelType)
            {
                fuelType = eFuelType.Octan95;
            }
            else if((int)eFuelType.Octan96 == numOfFuelType)
            {
                fuelType = eFuelType.Octan96;
            }
            else
            {
                fuelType = eFuelType.Octan98;
            }

            return fuelType;
        }

        internal static string GetWheelManufacturerName()
        {
            Console.WriteLine("Please enter the manufacturer Name of the wheels?");
            string wheelManufacturerNameFromUser = getInputFromUserOfTheSystem();
            return wheelManufacturerNameFromUser;
        }

        internal static float GetWheelAirPressureWhenEnterd()
        {
            float wheelAirPressureWhenVehicleEntred = 0f;

            Console.WriteLine("Please enter the wheel air pressure.");
            bool goodInput = float.TryParse(getInputFromUserOfTheSystem(), out wheelAirPressureWhenVehicleEntred);
            if(!goodInput)
            {
                throw new FormatException("Try Again! please enter the wheel air pressure");
            }

            return wheelAirPressureWhenVehicleEntred;
        }

        internal static eMotorcycleLicenseType GetMotorcycleSpecialFeatures(out int MotorcycleEngineVolCC)
        {
            Console.WriteLine("Please enter the motorcycle license type.  1 - A or 2 - B1 or 3 - AA or 4 - BB!");
            int numOfMotorcycleLicenseType;
            eMotorcycleLicenseType motorcycleLicenseType;
            bool motorcycleLicenseTypeGoodInput = int.TryParse(getInputFromUserOfTheSystem(), out numOfMotorcycleLicenseType);
            if(!motorcycleLicenseTypeGoodInput)
            {
                throw new FormatException("Parsing error please check your input");
            }
            else if(numOfMotorcycleLicenseType < 1 || numOfMotorcycleLicenseType > 4)
            {
                throw new ValueOutOfRangeException(4f, 1f);
            }
            else if((int)eMotorcycleLicenseType.AA == numOfMotorcycleLicenseType)
            {
                motorcycleLicenseType = eMotorcycleLicenseType.AA;
            }
            else if((int)eMotorcycleLicenseType.B1 == numOfMotorcycleLicenseType)
            {
                motorcycleLicenseType = eMotorcycleLicenseType.B1;
            }
            else if((int)eMotorcycleLicenseType.AA == numOfMotorcycleLicenseType)
            {
                motorcycleLicenseType = eMotorcycleLicenseType.AA;
            }
            else
            {
                motorcycleLicenseType = eMotorcycleLicenseType.BB;
            }

            Console.WriteLine("Please enter the motorcycle engine volume in CC!");
            bool motorcycleEngineVolGoodInput = int.TryParse(getInputFromUserOfTheSystem(), out MotorcycleEngineVolCC);
            if (!motorcycleLicenseTypeGoodInput)
            {
                throw new FormatException("Try Again! please enter the motorcycle engine volume in CC");
            } 

            return motorcycleLicenseType;
        }

        internal static eCarDoorQuantity GetCarSpecialFeatures(out eCarColor colorOfCar)
        {
            Console.WriteLine("Please enter how much doors the car have.  between 2-5 doors");
            int numOfCarDoorsQuantity;
            eCarDoorQuantity CarDoorsQuantityType;
            bool CarDoorsQuantityTypeGoodInput = int.TryParse(getInputFromUserOfTheSystem(), out numOfCarDoorsQuantity);
            if(!CarDoorsQuantityTypeGoodInput)
            {
                throw new FormatException("Parsing error please check your input");
            }
            else if(numOfCarDoorsQuantity < 2 || numOfCarDoorsQuantity > 5)
            {
                throw new ValueOutOfRangeException(5f, 2f);
            }
            else if((int)eCarDoorQuantity.Two == numOfCarDoorsQuantity)
            {
                CarDoorsQuantityType = eCarDoorQuantity.Two;
            }
            else if((int)eCarDoorQuantity.Three == numOfCarDoorsQuantity)
            {
                CarDoorsQuantityType = eCarDoorQuantity.Three;
            }
            else if((int)eCarDoorQuantity.Four == numOfCarDoorsQuantity)
            {
                CarDoorsQuantityType = eCarDoorQuantity.Four;
            }
            else
            {
                CarDoorsQuantityType = eCarDoorQuantity.Five;
            }

            Console.WriteLine("Please enter the color of the car.  1 - Red or 2 - Silver or 3 -  White or 4 - Black!");
            int numOfCarColorType;
            bool carColorTypeGoodInput = int.TryParse(getInputFromUserOfTheSystem(), out numOfCarColorType);
            if (!carColorTypeGoodInput)
            {
                throw new FormatException("Parsing error please check your input");
            }
            else if (numOfCarColorType < 1 || numOfCarColorType > 4)
            {
                throw new ValueOutOfRangeException(4f, 1f);
            }
            else if ((int)eCarColor.Red == numOfCarColorType)
            {
                colorOfCar = eCarColor.Red;
            }
            else if ((int)eCarColor.Silver == numOfCarColorType)
            {
                colorOfCar = eCarColor.Silver;
            }
            else if ((int)eCarColor.White == numOfCarColorType)
            {
                colorOfCar = eCarColor.White;
            }
            else
            {
                colorOfCar = eCarColor.Black;
            }

            return CarDoorsQuantityType;
        }

        internal static float GetTruckSpecialFeatures(out bool isContainHazardousMaterials)
        {
            float truckMaxCarryingWeight = 0f;

            Console.WriteLine("Please enter the truck maximum carrying weight.");
            bool goodInput = float.TryParse(getInputFromUserOfTheSystem(), out truckMaxCarryingWeight);
            if(!goodInput)
            {
                throw new FormatException("Try Again! please enter the truck maximum carrying weight");
            }

            Console.WriteLine("Please enter YES if your truck is contain hazardous materials, otherwise enter NO");
            string InputFromUserIfContainHazardousMaterials = getInputFromUserOfTheSystem();
            if(!"YES".Equals(InputFromUserIfContainHazardousMaterials, StringComparison.CurrentCultureIgnoreCase) && !"NO".Equals(InputFromUserIfContainHazardousMaterials, StringComparison.CurrentCultureIgnoreCase))
            {
                throw new ArgumentException("Try Again! please enter only YES or No");
            }
            else if("YES".Equals(InputFromUserIfContainHazardousMaterials, StringComparison.CurrentCultureIgnoreCase))
            {
                isContainHazardousMaterials = true;
            }
            else 
            {
                isContainHazardousMaterials = false;
            }

            return truckMaxCarryingWeight;
        }

        internal static eVehicleStatusInGarage GetWhichStatusToShowTheVehiclesList()
        {
            Console.WriteLine("Please enter for which status of the vehicle do you want to see the list,  1 - InRepair or 2 - Repaired or 3 - Paid");
            int numOfStatus;
            eVehicleStatusInGarage vehicleStatusInGarage;
            bool vehicleStatusInGarageGoodInput = int.TryParse(getInputFromUserOfTheSystem(), out numOfStatus);
            if(!vehicleStatusInGarageGoodInput)
            {
                throw new FormatException("Parsing error please check your input");
            }
            else if(numOfStatus < 1 || numOfStatus > 3)
            {
                throw new ValueOutOfRangeException(3, 1);
            }
            else if((int)eVehicleStatusInGarage.InRepair == numOfStatus)
            {
                vehicleStatusInGarage = eVehicleStatusInGarage.InRepair;
            }
            else if((int)eVehicleStatusInGarage.Repaired == numOfStatus)
            {
                vehicleStatusInGarage = eVehicleStatusInGarage.Repaired;
            }
            else 
            {
                vehicleStatusInGarage = eVehicleStatusInGarage.Paid;
            }

            return vehicleStatusInGarage;
        }

        internal static eVehicleStatusInGarage GetNewStatus()
        {
            Console.WriteLine("Please enter for which status do you to change,  1 - InRepair or 2 - Repaired or 3 - Paid");
            int numOfStatus;
            eVehicleStatusInGarage vehicleStatusInGarage;
            bool vehicleStatusInGarageGoodInput = int.TryParse(getInputFromUserOfTheSystem(), out numOfStatus);
            if (!vehicleStatusInGarageGoodInput)
            {
                throw new FormatException("Parsing error please check your input");
            }
            else if (numOfStatus < 1 || numOfStatus > 3)
            {
                throw new ValueOutOfRangeException(3, 1);
            }
            else if ((int)eVehicleStatusInGarage.InRepair == numOfStatus)
            {
                vehicleStatusInGarage = eVehicleStatusInGarage.InRepair;
            }
            else if ((int)eVehicleStatusInGarage.Repaired == numOfStatus)
            {
                vehicleStatusInGarage = eVehicleStatusInGarage.Repaired;
            }
            else
            {
                vehicleStatusInGarage = eVehicleStatusInGarage.Paid;
            }

            return vehicleStatusInGarage;
        }

        internal static void ClearTheConsole()
        {
            System.Threading.Thread.Sleep(4000);
            Console.Clear();
        }

        internal static void CheckIfToQuitSystem(string i_FromUser)
        {
            if(i_FromUser.Equals(m_QuitSymbol))
            {
                ClearTheConsole();
                Console.WriteLine("We understand you want to quit the garage manager.");
                Console.WriteLine("Thank you! we hope to see you agian in the best garage manager!");
                System.Threading.Thread.Sleep(4000);
                Environment.Exit(0);
            }
        }
    }
}
