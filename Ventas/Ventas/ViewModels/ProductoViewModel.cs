namespace Ventas.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Ventas.Common.Models;
    using Ventas.Services;
    using Xamarin.Forms;

    public class ProductoViewModel : BaseViewModel
    {
        private APIService apiService;

        private ObservableCollection<Producto> productos;

        public ObservableCollection<Producto> Productos
        {
            get { return this.productos; }
            set { this.SetValue(ref this.productos, value); }
        }

        public ProductoViewModel()
        {
            this.apiService = new APIService();
            this.CargarProductos();
        }

        private async void CargarProductos()
        {
            var response = await this.apiService.GetList<Producto>("http://localhost:54039", "/api","/Producto");

            if (!response.isSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Mensaje, "Aceptar");
                return;
            }

            var lista = (List<Producto>)response.Resultado;
            this.Productos = new ObservableCollection<Producto>(lista);
        }
    }
}
