using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WCF_Service_1000;

namespace WCF.Labb2._1000
{
    public class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8080/WCF_Service_1000");
            using (ServiceHost selfServiceHost = new ServiceHost(typeof(Birthday1000Service), baseAddress))
            {
                try
                {
                    selfServiceHost.AddServiceEndpoint(
                        typeof(IBirthday),
                        new WSHttpBinding(),
                        "Birthday1000Service");
                    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                    smb.HttpGetEnabled = true;

                    selfServiceHost.Description.Behaviors.Add(smb);
                    selfServiceHost.Open();
                    Console.WriteLine("Nu är tjänsten öppen");

                    Console.WriteLine("Tryck på ENTER för att stänga tjänsten");
                    Console.ReadLine();
                }
                catch (CommunicationException exception)
                {
                    Console.WriteLine($"Ett fel inträffade {exception.Message}");
                    selfServiceHost.Abort();
                    Console.ReadLine();                   
                }
            }
        }
    }
}
