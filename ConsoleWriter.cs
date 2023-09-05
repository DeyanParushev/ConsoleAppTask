namespace BettyConsoleApp
{
    public static class ConsoleInteractor
    {
        public static void WriteMessage(string message) => Console.WriteLine(message);

        public static string ReadMessage() => Console.ReadLine();
    }
}
