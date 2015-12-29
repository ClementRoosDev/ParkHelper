using System;
using System.Windows.Input;

namespace ParkHelper.Commands
{
    public class GetItineraireCommand : ICommand
    {
        readonly ICommand command;

        public GetItineraireCommand(ICommand command)
        {
            this.command = command;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            command.Execute(null);
        }

        public event EventHandler CanExecuteChanged;
    }
}
