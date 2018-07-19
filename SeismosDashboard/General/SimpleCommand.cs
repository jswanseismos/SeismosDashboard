using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SeismosDashboard
{
    public class SimpleCommand : ICommand
    {
        private Action myAction;

        public SimpleCommand(Action myAction)
        {
            this.myAction = myAction;
        }

        //        private event EventHandler canExecuteChangedInternal;
        private bool canExecute = true;

        public bool CanExecute(object parameter)
        {
            return canExecute;
        }

        public void Execute(object parameter)
        {
            this.myAction();
        }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

    }
}
