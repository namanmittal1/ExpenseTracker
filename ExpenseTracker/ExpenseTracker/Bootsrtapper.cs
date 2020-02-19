using System;
using System.ComponentModel.Composition.Hosting;
using System.Windows;
using Microsoft.Practices.Prism.MefExtensions;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

namespace ExpenseTracker
{
    class Bootsrtapper : MefBootstrapper
    {
        protected override System.Windows.DependencyObject CreateShell()
        {
            return Container.GetExportedValue<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();

            InitializeHomeView initHomeView = new InitializeHomeView();
            initHomeView.InitHomeViews();
            //ServiceLocator.Current.GetInstance<IRegionManager>().RequestNavigate(RegionNames.NavigationRegion, new Uri("/LoginPanelView", UriKind.Relative));
            //ServiceLocator.Current.GetInstance<IRegionManager>().RequestNavigate(RegionNames.MainRegion, new Uri("/LoginView", UriKind.Relative));
            //ServiceLocator.Current.GetInstance<IRegionManager>().RequestNavigate(RegionNames.StatusBarRegion, new Uri("/StatusBarView", UriKind.Relative));
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            //this.Container.GetExportedValue<IServiceLocator>("Container");
           // this.Container.GetExportedValue<Object>("User");
        }

        protected override CompositionContainer CreateContainer()
        {
            return base.CreateContainer();            
        }

        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Bootsrtapper).Assembly));
        }

       
       
    }
}
