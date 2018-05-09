using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;


namespace AGL
{
    public class PetOwner
    {
        public List<Owner> owners { get; set; }

        PetOwner(List<Owner> owners)
        {
            this.owners = owners;
        }

        public PetOwner()
        {
            this.owners = owners;
        }

        [When(@"I find the list of only owners with pet as '(.*)' as Pet by calling '(.*)' api")]
        public List<Owner> WhenIFindTheListOfOnlyOwnersWithPetAsAsPetByCallingApi(string petType, string apiName)
        {
            List<Owner> allOwners = new Owner().GivenIHaveAListOfOwnersByCallingApi(apiName);
            List<Owner> ownerswithPets = allOwners.Where(o => o.HasPetType(petType)).ToList();
            return ownerswithPets;
        }

        [When(@"I find a list of '(.*)' owners of pet as '(.*)' by calling '(.*)' api")]
        public List<Owner> WhenIFindAListOfOwnersOfPetAsByCallingApi(string gender, string petType, string api)
        {

            List<Owner> catOwners = WhenIFindTheListOfOnlyOwnersWithPetAsAsPetByCallingApi(petType, api);
            List<Owner> ownersWithGender = catOwners.Where(o => o.gender.ToLower().Equals(gender)).ToList();
            return ownersWithGender;
        }

        [When(@"I find the name of pet as '(.*)' for '(.*)' owners by calling '(.*)' api")]
        public List<string> WhenIFindTheNameOfPetAsForOwnersByCallingApi(string petType, string gender, string api)
        {
            List<Owner> ownersByGender = WhenIFindAListOfOwnersOfPetAsByCallingApi(gender, petType, api);
            List<string> petName = new List<string>();
            foreach (Owner o in ownersByGender)
            {
                petName.AddRange(o.pets.Select(p => p.name).ToList());
            }
            return petName;
        }

    }
}
