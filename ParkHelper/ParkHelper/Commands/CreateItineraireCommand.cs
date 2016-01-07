﻿using System;
using System.Collections.Generic;
using System.Windows.Input;
using ParkHelper.Model;
using ParkHelper.ViewModels;

namespace ParkHelper.Commands
{
    public class CreateItineraireCommand : ICommand
    {
        readonly ICommand _command;
        private List<Categorie> _lieux;

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
            var viewModel= (ListPageViewModel) parameter;
            _command.Execute(viewModel.ListeAppliSelectionnees);
        }

        public event EventHandler CanExecuteChanged;

        public void SetSourceLieux(List<Categorie> lieux)
        {
            _lieux = lieux;
        }
    }
}
