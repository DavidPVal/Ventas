using System;
using System.Collections.Generic;
using System.Text;
using Ventas.ViewModels;

namespace Ventas.Infraestructura
{
    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
    }
}
