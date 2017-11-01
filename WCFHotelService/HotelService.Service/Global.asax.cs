using System;
using Autofac.Integration.Wcf;

namespace HotelService.Service
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(Object sender, EventArgs e)
        {
          var container = Bootstraper.BuildContainer();
          AutofacHostFactory.Container = container;
        }
    }
}
