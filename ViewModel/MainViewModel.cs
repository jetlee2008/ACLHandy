using ACLHandy.Basic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ACLHandy.ViewModel
{
    public class MainViewModel : BasicViewModel
    {
        public bool SignalA { get; set; }
        public bool SignalB { get; set; }
        public bool SignalC { get; set; }

        public ICommand AddRecordCommand { get; set; }

        public ICommand ExecuteCommand { get; set; }

        public ObservableCollection<RecordListViewModel> RecordList { get; set; }

        public String FooterInfo
        {
            get
            {
                return SignalReady() ? string.Format("There are {0} records will be checked", RecordList.Count) : "Not ready for checking.";
            }
        }

        public MainViewModel()
        {
            AddRecordCommand = new RelayCommand(this, AddRecordCommandExecute, AddRecordCommandCanExecute);
            AddRecordCommand.CanExecuteChanged += ExecuteCommand_CanExecuteChanged;
            ExecuteCommand = new RelayCommand(this, ExecuteCommandExecute, ExecuteCommandCanExecute);
            ExecuteCommand.CanExecuteChanged += ExecuteCommand_CanExecuteChanged;
            this.PropertyChanged += MainViewModel_PropertyChanged;

            RecordList = new ObservableCollection<RecordListViewModel>();
            RecordList.CollectionChanged += RecordList_CollectionChanged;
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
            SignalB = !SignalB;
            SignalC = !SignalC;
            base.OnPropertyChanged("SignalA");
            base.OnPropertyChanged("SignalB");
            base.OnPropertyChanged("SignalC");
            base.OnPropertyChanged("FooterInfo");
        }
        public bool ExecuteCommandCanExecute()
        {
            return true;
        }

        void ExecuteCommand_CanExecuteChanged(object sender, EventArgs e)
        {
            CommandManager.InvalidateRequerySuggested();
        }

        void MainViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            ((RelayCommand)AddRecordCommand).RaiseCanExecuteChanged();
        }

        void RecordList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            base.OnPropertyChanged("FooterInfo");
        }
        #endregion

        private bool SignalReady()
        {
            return SignalA & SignalB & SignalC;
        }
    }
}
