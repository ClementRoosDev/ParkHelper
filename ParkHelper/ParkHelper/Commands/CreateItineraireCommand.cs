using System;
using System.Windows.Input;

namespace ParkHelper.Commands
{
    public class CreateItineraireCommand : ICommand
    {
        readonly ICommand _command;

        public CreateItineraireCommand(ICommand command)
        {
            _command = command;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _command.Execute(null);
        }

        public event EventHandler CanExecuteChanged;
    }
}
