using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TheMainLogic;

namespace IisHosted
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Task t = new Task(BackgroundProcessCaller);
            t.Start();
        }

        private void BackgroundProcessCaller()
        {
            var mainProc = new TheMainProcess();
            string jsonDir = @"C:\Yogesh\temp\bkgndprocopts\jsondir";
            string xmlDir = @"C:\Yogesh\temp\bkgndprocopts\xmldir";
            mainProc.Configure(new Dictionary<string, dynamic>()
            {
                {TheMainProcess.KEY_DESTINATION_DIRECTORY, jsonDir },
                {TheMainProcess.KEY_SOURCE_DIRECTORY, xmlDir }
            });
            mainProc.LongProcess();
        }
    }
}
