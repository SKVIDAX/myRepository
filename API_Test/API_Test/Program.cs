using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace API_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string URL = "https://reqres.in/api/users/1";

            var request = (HttpWebRequest)WebRequest.Create(URL);

            request.Method = "GET";

            request.Proxy.Credentials = new NetworkCredential("student", "student");

            var response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());

            string Text = reader.ReadToEnd();

            Console.WriteLine(response);

            Console.ReadLine();

            
            
        }
    }
   
}
