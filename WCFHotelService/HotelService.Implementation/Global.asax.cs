using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Contracts.Implementation
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(Object sender, EventArgs e)
        {
          Bootstraper.BuildContainer();
        }
    }
}
