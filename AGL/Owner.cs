using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using TechTalk.SpecFlow;

namespace AGL
{
    public class Owner
    {
        public string name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public List<Pet> pets { get; set; }

        public List<Pet> GetPetsByType(string type)
        {
            return this.pets.Where(p => p.type.ToLower().Equals(type.ToLower())).ToList();
        }

        public bool HasPetType(string type)
        {
            bool hasPetType = false;

            if (this.pets == null)
                return false;

            foreach (Pet p in this.pets)
                if (p.type.ToLower().Equals(type.ToLower()))
                {
                    hasPetType = true;
                    break;
                }

            return hasPetType;
        }

        [Given(@"I have a list of owners by calling '(.*)' api")]
        public List<Owner> GivenIHaveAListOfOwnersByCallingApi(string apiName)
        {
            string apiUrl = ConfigurationManager.AppSettings["ApiURL"];
            var client = new RestClient(apiUrl);
            var request = new RestRequest(apiName, Method.GET);
            List<Owner> owners = (List<Owner>)client.Execute<List<Owner>>(request).Data;
            return owners;
        }

    }
}
