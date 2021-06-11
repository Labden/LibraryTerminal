using System;

namespace LibraryTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            bool goOn = true;
            while (goOn == true)
            {



            }
            goOn = GetContinue();

        }

        public static void PrintWholeList(List<string> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {items[i]}");
            }
        }

        public static int GetuserInput(string inputType)
        {
            int input;
            Console.WriteLine(inputType);
            input = int.Parse(Console.ReadLine());
            return input;
        }

        static bool GetContinue()
        {
            Console.WriteLine("Would you like to check out another book? (y/n)");
            string answer = Console.ReadLine().ToUpper();

            if (answer == "Y" || answer == "YES")
            {
                return true;
            }
            else if (answer == "N" || answer == "NO")
            {
                Console.WriteLine("Goodbye!");
                return false;
            }
            else
            {
                Console.WriteLine("I didn't understand that, please try again");
                return GetContinue();

            }
        }
        public static bool IsValidIndex(int collectionLength, int index)
        {
            if (index >= 0 && index < collectionLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
