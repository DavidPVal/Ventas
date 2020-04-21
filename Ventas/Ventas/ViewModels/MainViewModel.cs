namespace Ventas.ViewModels
{
    public class MainViewModel
    {
        public ProductoViewModel Producto { get; set; }

        public MainViewModel()
        {
            this.Producto = new ProductoViewModel();
        }
    }
}
