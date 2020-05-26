namespace appUbicua1.ViewModels
{
    using appUbicua1.Helpers;
    using appUbicua1.Models;
    using GalaSoft.MvvmLight.Command;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    public class PagosViewModel:BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<Pagos> listPagos;
        private bool isRefreshing;
        #endregion

        #region Properties
        public ObservableCollection<Pagos> ListPagos 
        {
            get { return this.listPagos; }
            set { SetValue(ref this.listPagos, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); } 
        }
        #endregion

        #region Constructor
        public PagosViewModel()
        {
            this.apiService = new ApiService();
            this.LoadPagos();
        }
        #endregion

        #region Methods
        private async void LoadPagos()
        {
            var lista = await this.apiService.Get<Pagos>(
                 "https://consultarpago.azurewebsites.net/",
                 "api/",
                 "ConsultarPago/1"
                );
            this.ListPagos = new ObservableCollection<Pagos>(
                lista);
            
        }
        #endregion

        #region Commands
        public ICommand RefreshCommand 
        { 
            get
            {
                return new RelayCommand(
                    LoadPagos);
            }
        }

        public ICommand newCommand 
        {
            get
            {
                return new RelayCommand(
                    LoadPagos);
            } 
        }
        #endregion
    }
}
