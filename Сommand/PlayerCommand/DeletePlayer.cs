using System;
using OOP_lab4.Command.Base;
using OOP_lab4.Service.Base;

namespace OOP_lab4.Command.PlayerCommand
{
    public class DeletePlayer : ICommand
    {
        private IPlayerService _playerService;

        public DeletePlayer(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public void Execute()
        {
            Console.WriteLine("Введіть ID гравця");
            var answer = Console.ReadLine();

            if (!int.TryParse(answer, out var id) || _playerService.GetPlayerById(id) == default)
            {
                Console.WriteLine("Гравець з таким ID не існує");
            }

            _playerService.DeletePlayer(id);
            Console.WriteLine("Гравця успішно видалено");
        }

        public string GetCommandInfo()
        {
            return "Видалення гравця";
        }
    }
}