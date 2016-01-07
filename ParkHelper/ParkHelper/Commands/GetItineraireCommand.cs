using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace ParkHelper.Commands
{
    public class GetItineraireCommand : ICommand
    {
        readonly ICommand _command;

        public GetItineraireCommand(ICommand command)
        {
            _command = command;
        }

        public bool CanExecute(object parameter)
        {
            var liste = parameter as List<int>;
            return liste.Count
                >
                0;
        }

        public void Execute(object parameter)
        {
            _command.Execute(null);
        }

        public event EventHandler CanExecuteChanged;
    }
}
