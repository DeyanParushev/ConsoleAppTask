namespace BettyConsoleApp.Interfaces
{
    public interface ICommander
    {
        bool ExecuteCommand(string command, IPlayer player, IGame game);
    }
}