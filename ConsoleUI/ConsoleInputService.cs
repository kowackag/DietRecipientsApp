using System.Numerics;

namespace DietApp.ConsoleUI
{
    internal class ConsoleInputService
    {
        internal static string GetUserInputString(string name, bool isOptional = false)
        {
            string? userInput = Console.ReadLine();
            bool isCorrectInput = userInput != null && userInput.Length > 0;
            while (!isCorrectInput && !isOptional)
            {
                Console.WriteLine($"Incorrect {name}, try again");
                userInput = Console.ReadLine();
                isCorrectInput = userInput != null && userInput.Length > 0;
            }
            return userInput ?? string.Empty;
        }

        internal static T GetUserInputNumber<T>(string name) where T : INumber<T>
        {
            string? userInput = Console.ReadLine();
            bool isCorrectInput = T.TryParse(userInput, null, out T number);

            while (!isCorrectInput)
            {
                Console.WriteLine($"Incorrect {name}, try again");
                userInput = Console.ReadLine();
                isCorrectInput = T.TryParse(userInput, null, out number);
            }
            return number;
        }
    }
}
