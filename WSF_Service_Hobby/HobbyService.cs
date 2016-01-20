using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WSF_Service_Hobby
{
    [ServiceContract (Namespace = "WSF_Service_Hobby")]
    public interface IHobby
    {
        [OperationContract]
        string MovieFromYear(string textBox);

        string ButtonFromYear(string value);
    }
    public class HobbyService : IHobby
    {
        public string MovieFromYear(string textBox)
        {
            Console.WriteLine("Mottaget");
            var textFile = System.IO.File.ReadAllLines(@"C:\Skola\WCF\GitHub\Wcf_Labb2\WSF_Service_Hobby\Movies.txt");
            var text = "";
            var theTrim = textBox.Replace(" ", "");
            for (int i = 0; i < textFile.Length; i++)
            {
                var movie = textFile[i].Replace(" ", "").Split(',');
                if (movie.Contains(theTrim))
                {
                    text = movie[0];
                }
            }
            return text;
        }
        public string ButtonFromYear(string value)
        {
            Console.WriteLine("Mottaget");
            var textFile = System.IO.File.ReadAllLines(@"C:\Skola\WCF\GitHub\Labb1\MyWeather\Movies.txt");
            var text = "";

            for (int i = 0; i < textFile.Length; i++)
            {
                var movie = textFile[i].Split(',');
                if (movie.Contains(value))
                {
                    text += movie[1] + "\r\n";
                }
            }
            return text;
        }
    }
}
