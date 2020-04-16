namespace p02.PhoneBook
{
    using System;

    public class Program
    {
        public static void Main()
        {
            HashTable<string, string> hashTable = new HashTable<string, string>();

            string input;
            while ((input = Console.ReadLine()) != "search")
            {
                string[] tokens = input.Split("-");
                string name = tokens[0];
                string phoneNumber = tokens[1];

                hashTable[name] = phoneNumber;
            }

            while ((input = Console.ReadLine()) != "end")
            {
                if (hashTable.ContainsKey(input))
                {
                    KeyValue<string, string> kvp = hashTable.Find(input);

                    Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
                }
                else
                {
                    Console.WriteLine("Contact {0} does not exist.", input);
                }
            }
        }
    }
}
