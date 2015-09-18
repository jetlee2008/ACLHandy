using ACLHandy.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ACLHandy.ViewModel
{
    public class MainViewModel : BasicViewModel
    {
        public bool SignalA
        {
            get;
            set;
        }

        public bool SignalB { get; set; }
        public bool SignalC { get; set; }

        public ICommand AddRecordCommand { get; set; }

        public ICommand ExecuteCommand { get; set; }

        public MainViewModel()
        {
            AddRecordCommand = new RelayCommand(this, AddRecordCommandExecute, AddRecordCommandCanExecute);
            ExecuteCommand = new RelayCommand(this, ExecuteCommandExecute, ExecuteCommandCanExecute);
        }

        #region Command
        public void AddRecordCommandExecute()
        {

        }

        public bool AddRecordCommandCanExecute()
        {
            return SignalA;
        }

        public void ExecuteCommandExecute()
        {
            SignalA = !SignalA;
            base.OnPropertyChanged("SignalA");
        }

        public bool ExecuteCommandCanExecute()
        {
            return true;
        }
        #endregion
    }
}
