using BettyConsoleApp.Interfaces;

namespace BettyConsoleApp
{
    public class Engine : IEngine
    {
        public void Run(ICommander commander)
        {
            var isRunning = true;
            var player = new Player();
            var game = new Game();

            while (isRunning)
            {
                ConsoleInteractor.WriteMessage(Constants.PromptUserMessage);
                var command = ConsoleInteractor.ReadMessage();

                isRunning = commander.ExecuteCommand(command, player, game);
            }
        }
    }
}
