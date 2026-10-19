using LibreriaApp2026.Ioc;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace LibreriaApp2026.Windows
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //cultura fija (pesos argentinos) para no depender de la configuración regional de Windows
            var cultura = new CultureInfo("es-AR");
            CultureInfo.DefaultThreadCurrentCulture = cultura;
            CultureInfo.DefaultThreadCurrentUICulture = cultura;
            Thread.CurrentThread.CurrentCulture = cultura;
            Thread.CurrentThread.CurrentUICulture = cultura;

            var services = new ServiceCollection();
            services.AddApplicationServices();

            //registro todos los formularios del proyecto
            var formularios = typeof(Program).Assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Form)) && !t.IsAbstract).ToList();
            foreach (var frm in formularios)
            {
                services.AddTransient(frm);
            }
            var provider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();
            Application.Run(provider.GetRequiredService<frmPrincipal>());
        }
    }
}
