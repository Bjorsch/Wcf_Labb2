using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Service_1000
{
    [ServiceContract(Namespace = "WCF_Service_1000")]
    public interface IBirthday
    {
        [OperationContract]
        double To1000(int year, int month, int day);
    }

    public class Birthday1000Service :IBirthday
    {
        public double To1000(int year, int month, int day)
        {
            Console.WriteLine("Mottaget");
            var today = DateTime.Now;
            var birthday = new DateTime(year, month, day);
            var calc = 1000 - (today - birthday).Days % 1000;
            return calc;
        }
    }
}
