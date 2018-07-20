using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Deserializers;

namespace ConsoleApp
{
    public class StateData
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }
        public string Area { get; set; }
        public string LargestCity { get; set; }
        public string Capital { get; set; }
    }

    public class StateResponse
    {
        public List<string> messages { get; set;  }
        public List<StateData> result { get; set; }
    }

    public class StateService
    {
        private const string URL = "http://services.groupkt.com/state/get/USA/all";

        public StateData GetStateData(string input)
        {
            var client = new RestClient(URL);
            var response = client.Execute<Dictionary<string, StateResponse>>(new RestRequest());
            var stateRes = response.Data["RestResponse"];
            foreach (var st in stateRes.result)
            {
                if (string.Equals(st.Abbr, input, StringComparison.CurrentCultureIgnoreCase) || 
                    string.Equals(st.Name, input, StringComparison.CurrentCultureIgnoreCase))
                    return st;
            }

            return null;

        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            StateService svc = new StateService();

            while (true)
            {
                Console.Write("Enter State name or abbreviation: ");
                String input = Console.ReadLine();
                if (string.Equals("quit", input, StringComparison.CurrentCultureIgnoreCase))
                    break;

                StateData res = svc.GetStateData(input);
                if(res != null)
                {
                    Console.WriteLine("Largest City: {0}", res.LargestCity);
                    Console.WriteLine("Capital: {0}", res.Capital);
                }
                else
                    Console.WriteLine("{0} not found", input);
            }
        }
    }
}
