using ACLHandy.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ACLHandy.Basic
{
    public class RelayCommand : System.Windows.Input.ICommand
    {
        private BasicViewModel mvm;
        private Action execute;
        private Func<bool> canExecute;
        public RelayCommand(BasicViewModel viewmodel, Action ex, Func<bool> canEx)
        {
            mvm = viewmodel;
            this.execute = ex;
            this.canExecute = canEx;
        }
        public bool CanExecute(object parameter)
        {
            return canExecute();
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            this.execute();
            
        }

        internal void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }
    }
}
