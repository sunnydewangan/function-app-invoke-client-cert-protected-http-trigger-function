using System;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace C_Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string _result = HttpGet("https://functiondeleteblobdev-mssupport.azurewebsites.net/api/HttpTrigger1");

            Console.WriteLine(_result);
            Console.ReadLine();
        }
        public static string HttpGet(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            X509Certificate cert = new X509Certificate(@"C:\Users\sadewa\Desktop\FunctionDeleteBlobDEV\FunctionDeleteBlobDEV-Cert.pfx", "123456");
            request.ClientCertificates.Add(cert);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            return sr.ReadToEnd();
        }
    }
}