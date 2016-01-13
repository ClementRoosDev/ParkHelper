using System;
using System.Collections.Generic;
using System.Windows.Input;
using ParkHelper.Common.Models.ListeLieux;
using ParkHelper.ViewModels;

namespace ParkHelper.Commands
{
    public class CreateItineraireCommand : ICommand
    {
        readonly ICommand _command;
        public List<Categorie> Lieux { get; private set; }

        public CreateItineraireCommand(ICommand command)
        {
            _command = command;
            CanBeExecuted = false;
        }

        public bool CanBeExecuted { get; set; }

        public bool CanExecute(object parameter)
        {
            if(parameter != null)
            {
                var liste = parameter as List<int>;
                CanBeExecuted = liste != null && liste.Count > 0;
            }
            else
            {
                CanBeExecuted = false;
            }
            return CanBeExecuted;
        }

        public void Execute(object parameter)
        {
            var viewModel = (ListPageViewModel) parameter;
            viewModel.Context.ListeAppliSelectionnees = viewModel.ListeAppliSelectionnees;
            _command.Execute(viewModel.Context);
        }

        public event EventHandler CanExecuteChanged;

        public void SetSourceLieux(List<Categorie> lieux)
        {
            Lieux = lieux;
        }
    }
}
