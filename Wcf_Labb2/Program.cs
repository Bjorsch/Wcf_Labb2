using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WCF_Service;

namespace Wcf_Labb2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8080/WCF_Service");
            ServiceHost selfServiceHost = new ServiceHost(typeof(BmiService), baseAddress);

            try
            {
                selfServiceHost.AddServiceEndpoint(
                    typeof(IBMI), //c
                    new WSHttpBinding(), // b
                    "BmiService" //a
                    );
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;

                selfServiceHost.Description.Behaviors.Add(smb);

                selfServiceHost.Open(); // Nu är tjänsten öppen
                Console.WriteLine("Nu är tjänsten öppen");


            }
            finally 
            {               
                Console.WriteLine("Tryck på ENTER för att stänga tjänsten");
                Console.ReadLine();
                selfServiceHost.Close();
            }
        }
    }
}
