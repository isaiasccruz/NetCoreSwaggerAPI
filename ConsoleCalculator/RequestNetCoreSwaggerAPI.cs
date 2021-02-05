using RestSharp;
using System;

namespace ConsoleCalculator
{
    class RequestNetCoreSwaggerAPI
    {
        public string ExecutaRequestAPIProcessadoraDeNumeros(string metodo, double num1, Nullable<double> num2)
        {
            try
            {
                RestClient client;

                if (num2 != null)
                {
                    client = new RestClient("https://localhost:44370/APIProcessadoraDeNumeros/api/" + metodo + "/" + num1 + "/" + num2);
                }
                else
                {
                    client = new RestClient("https://localhost:44370/APIProcessadoraDeNumeros/api/" + metodo + "/" + num1);
                }
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);

                IRestResponse response = client.Execute(request);
                Console.WriteLine("\n O retorno desta operação é: ");
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
