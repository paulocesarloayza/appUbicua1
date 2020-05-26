using appUbicua1.Helpers;
using appUbicua1.Models;
using System.Collections.ObjectModel;

namespace appUbicua1.ViewModels
{
    public class MainViewModel
    {

        #region ViewModels
        private PagosViewModel Pagos;
        #endregion

        #region Constructor
        public MainViewModel()
        {
            instance = this;
            this.Pagos = new PagosViewModel();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance==null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion
    }
}
