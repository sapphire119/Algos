namespace p01.Index
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            HashTable<char, int> hashTable = new HashTable<char, int>();

            string input = Console.ReadLine();

            char[] tokens = input.ToCharArray();
            for (int i = 0; i < tokens.Length; i++)
            {
                char currentToken = tokens[i];
                if (!hashTable.ContainsKey(currentToken))
                {
                    hashTable[currentToken] = 0;
                }

                hashTable[currentToken]++;
            }

            Console.WriteLine(string.Join(Environment.NewLine, hashTable.OrderBy(x => x.Key)
                .Select(kvp => $"{kvp.Key}: {kvp.Value} time/s")));
        }
    }
}
