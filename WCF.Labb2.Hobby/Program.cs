using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WSF_Service_Hobby;

namespace WCF.Labb2.Hobby
{
    public class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8080/WCF_Service_Hobby");
            using (ServiceHost selfServiceHost = new ServiceHost(typeof(HobbyService), baseAddress ))
            {
                try
                {
                    selfServiceHost.AddServiceEndpoint(
                        typeof (IHobby),
                        new WSHttpBinding(),
                        "HobbyService");
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
