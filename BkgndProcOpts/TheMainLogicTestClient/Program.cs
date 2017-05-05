using System;
using System.Collections.Generic;
using TheMainLogic;

namespace TheMainLogicTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceDirectory = @"C:\Yogesh\temp\bkgndprocopts\xmldir";
            string destinationDirectory = @"C:\Yogesh\temp\bkgndprocopts\jsondir";
            var process = new TheMainProcess();
            process.Configure(new Dictionary<string, dynamic>()
            {
                {TheMainProcess.KEY_SOURCE_DIRECTORY, sourceDirectory },
                {TheMainProcess.KEY_DESTINATION_DIRECTORY, destinationDirectory }
            });
            process.LongProcess();

            Console.WriteLine("Press any key to continue!!!");
            Console.ReadKey(true);
        }
    }
}
