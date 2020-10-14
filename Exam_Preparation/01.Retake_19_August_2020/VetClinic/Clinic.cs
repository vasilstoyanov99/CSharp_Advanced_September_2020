using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return allPets.Count;
            }
        }
        private Dictionary<string, Pet> allPets;

        public Clinic(int capacity)
        {
            Capacity = capacity;
            allPets = new Dictionary<string, Pet>(capacity);
        }

        public void Add(Pet pet)
        {
            if (allPets.Count <= 20)
            {
                allPets.Add(pet.Name, pet);
            }
        }

        public bool Remove(string name)
        {
            if (allPets.ContainsKey(name))
            {
                allPets.Remove(name);
                return true;
            }

            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            if (allPets.ContainsKey(name))
            {
                if (allPets[name].Owner == owner)
                {
                    return allPets[name];
                }
            }

            return null;
        }

        public Pet GetOldestPet()
        {
            foreach (var oldestPet in allPets.Values.OrderByDescending(x => x.Age))
            {
                return oldestPet;
            }

            return null;
        }

        public string GetStatistics()
        {
            StringBuilder result = new StringBuilder();
            result.Append("The clinic has the following patients:");
            result.AppendLine();

            foreach (var pet in allPets.Values)
            {
                result.Append($"Pet {pet.Name} with owner: {pet.Owner}");
                result.AppendLine();
            }

            return result.ToString().TrimEnd();
        }
    }
}
