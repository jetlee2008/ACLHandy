using ACLHandy.Basic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ACLHandy.ViewModel
{
    public class MainViewModel : BasicViewModel
    {
        public bool SignalA { get; set; }
        public bool SignalB { get; set; }
        public bool SignalC { get; set; }

        public ICommand ExecuteCommand { get; set; }

        public ICommand ExportCommand { get; set; }

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
            #region Command Init
            ExecuteCommand = new RelayCommand(this, ExecuteCommandExecute, ExecuteCommandCanExecute);
            ExecuteCommand.CanExecuteChanged += RefreshCanExecuteChanged;
            ExportCommand = new RelayCommand(this, ExportCommandExecute, ExportCommandCanExecute);
            ExportCommand.CanExecuteChanged += RefreshCanExecuteChanged;
            #endregion


            #region Property Init
            
            #region Common Property Init
            this.PropertyChanged += MainViewModel_PropertyChanged;
            #endregion


            #region List Property Init
            RecordList = new ObservableCollection<RecordListViewModel>();
            RecordList.CollectionChanged += RecordList_CollectionChanged;
            #endregion
           
            #endregion
        }

        

        #region Command
        private void ExecuteCommandExecute()
        {
            List<Task> Tasks = new List<Task>();
            var rad = new Random();
            foreach (var item in RecordList)
            {
                Tasks.Add(Task.Factory.StartNew(() => item.SearchCurrentState(rad.Next(500, 10000))));
            }
        }
        private bool ExecuteCommandCanExecute()
        {
            return true;
        }

        private void ExportCommandExecute()
        {
            Console.WriteLine("123");
        }

        private bool ExportCommandCanExecute()
        {
            return true;
        }

        void RefreshCanExecuteChanged(object sender, EventArgs e)
        {
            CommandManager.InvalidateRequerySuggested();
        }

        void MainViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //((RelayCommand)AddRecordCommand).RaiseCanExecuteChanged();
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
