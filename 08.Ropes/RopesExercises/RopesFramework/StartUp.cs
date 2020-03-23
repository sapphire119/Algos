namespace RopesFramework
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class StartUp
    {
        public static void Main()
        {
            var userCommands = new UserCommands();

            var engine = new Engine(userCommands);
            string input;
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                engine.Run(input);
            }
        }
    }
}
