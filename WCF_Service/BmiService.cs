using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Service
{
    [ServiceContract(Namespace = "EC.WCF_Service")]
    public interface IBMI
    {
        [OperationContract]
        decimal BMI(decimal height, decimal weight);
    }

    public class BmiService : IBMI
    {
        public decimal BMI(decimal height, decimal weight)
        {
            Console.WriteLine("Mottaget");
            return weight / ((height / 100)* (height / 100));
        }
    }
}
