namespace OOP_lab4.Command.Base
{
    public interface ICommand
    {
        void Execute();
        string GetCommandInfo();
    }
}