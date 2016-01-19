using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Service_Day
{
    [ServiceContract(Namespace = "WCF_Service_Day")]

    public interface IDays
    {
        [OperationContract]
        double Day(int year, int month, int day);
    }
    

    class DayService : IDays
    {
        public double Day(int year, int month, int day)
        {
            Console.WriteLine("Mottaget");
            var today = new DateTime();
            var birthday = new DateTime(year,month,day);
            var calc = (today - birthday).TotalDays;
            return calc;
        }
    }
}
