using System;

namespace Ex03.ConsoleUI
{
    internal class Messages
    {
        internal static void PrintIfSuccessfully(int i_OperationFromUser)
        {
            string isSuccess = string.Format("The opertion: {0} handeld successfully.{1}", i_OperationFromUser, System.Environment.NewLine); 
            Console.WriteLine(isSuccess);
        }
    }
}
