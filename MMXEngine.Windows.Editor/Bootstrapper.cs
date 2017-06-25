using System;
using System.Reflection;
using System.Windows;
using Autofac;
using Microsoft.Practices.ServiceLocation;
using MMXEngine.Windows.Editor.Views.ApplicationRootView;
using Prism.Autofac;
using Prism.Mvvm;

namespace MMXEngine.Windows.Editor
{
    public class Bootstrapper : AutofacBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<ApplicationRoot>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            {
                var assemblyPath = $"{Assembly.GetExecutingAssembly().GetName().Name}.Views.{viewType.Name}View.{viewType.Name}ViewModel";
                var type = Type.GetType(assemblyPath);

                return type;
            });
        }

        protected override void ConfigureContainerBuilder(ContainerBuilder builder)
        {
            base.ConfigureContainerBuilder(builder);
            EditorIOCContainer.Register(builder);
        }
    }
}
