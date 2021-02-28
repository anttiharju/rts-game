namespace RtsGame.Command
{
    /// <summary>
    /// A command given by the player, for example a group of units to attack a target unit. 
    /// </summary>
    public interface ICommand
    {
        void Execute();
    }
}