using System;
using System.Collections.Generic;
using System.Windows.Input;
using ParkHelper.ViewModels;

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
            var viewModel= (ListPageViewModel) parameter;
            _command.Execute(viewModel.ListeAppliSelectionnees);
        }

        public event EventHandler CanExecuteChanged;
    }
}
