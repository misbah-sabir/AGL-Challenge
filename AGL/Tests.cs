using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using TechTalk.SpecFlow;


namespace AGL
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void DisplayCatNamesWithOwnerGenderSorted()
        {
            //Find all owners of pets from api
            List<Owner> owners = new Owner().GivenIHaveAListOfOwnersByCallingApi("people.json");

            // We can find Owners with any pet type
            List<Owner> ownersWithPetType = new PetOwner().WhenIFindTheListOfOnlyOwnersWithPetAsAsPetByCallingApi("Cat", "people.json");

            // List of all male owners of Cats
            List<Owner> maleOwnersWithPetType = new PetOwner().WhenIFindAListOfOwnersOfPetAsByCallingApi("male", "Cat", "people.json");

            //List of all female owners of Cats
            List<Owner> femaleOwnersWithPetType = new PetOwner().WhenIFindAListOfOwnersOfPetAsByCallingApi("female", "Cat",
                "people.json");

            //Find the names of the cats for male owners
            List<string> maleOwnerCatNames = new PetOwner().WhenIFindTheNameOfPetAsForOwnersByCallingApi("Cat", "male", "people.json");

            //Find the names of the cats for male owners
            List<string> femaleOwnerCatNames = new PetOwner().WhenIFindTheNameOfPetAsForOwnersByCallingApi("Cat", "female", "people.json");

            //Print cat names under Male owners
            Console.WriteLine("Male");
            var orderedmaleCats = maleOwnerCatNames.OrderBy(n => n);
            Console.WriteLine(string.Join(System.Environment.NewLine, orderedmaleCats));

            //Print cat names under female owners
            Console.WriteLine("Female");
            var orderedfemaleCats = femaleOwnerCatNames.OrderBy(n => n);
            Console.WriteLine(string.Join(System.Environment.NewLine, orderedfemaleCats));
        }

        [TestMethod]
        public void DisplayMaleOwnersWithDogs()
        {
            //display the names of male owners of dogs
            List<Owner> maleOwners = new PetOwner().WhenIFindAListOfOwnersOfPetAsByCallingApi("male", "Dog", "people.json");
            foreach (var o in maleOwners)
            {
                Console.WriteLine(o.name);
            }
        }

        [TestMethod]
        public void VerifyCorrectNumberOfExpectedMaleCatOwners()
        {
            //Verify the correct number of male cat owners from the API
            List<Owner> maleOwners = new PetOwner().WhenIFindAListOfOwnersOfPetAsByCallingApi("male", "Cat", "people.json");
            int expected = 2;
            Assert.AreEqual(expected, maleOwners.Count, $"Expected male owners of cats were '{expected}', but were '{maleOwners.Count}'");
        }

        [TestMethod]
        public void VerifyCorrectNumberOfExpectedFeMaleCatOwners()
        {
            //Verify the correct number of Female Cat owners from the API
            List<Owner> femaleOwners = new PetOwner().WhenIFindAListOfOwnersOfPetAsByCallingApi("female", "Cat", "people.json");
            int expected = 3;
            Assert.AreEqual(expected, femaleOwners.Count, $"Expected female owners of cats were '{expected}', but were '{femaleOwners.Count}'");
        }

        [TestMethod]
        public void VerifyCorrectNumberOfExpectedFeMaleDogOwners()
        {
            //Verify the correct number of Male dog owners from the API
            List<Owner> femaleOwners = new PetOwner().WhenIFindAListOfOwnersOfPetAsByCallingApi("female", "Dog", "people.json");
            int expected = 0;
            Assert.AreEqual(expected, femaleOwners.Count, $"Expected female owners of dogs were '{expected}', but were '{femaleOwners.Count}'");
        }

    }
}
