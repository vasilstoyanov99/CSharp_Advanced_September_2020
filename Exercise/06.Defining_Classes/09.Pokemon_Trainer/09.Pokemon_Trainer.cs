using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Pokemon_Trainer
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> allTraines = new Dictionary<string, Trainer>();
            string input = Console.ReadLine();

            while (input != "Tournament")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                AddNewTrainer(data, allTraines);
                input = Console.ReadLine();
            }

            string secondInput = Console.ReadLine();

            while (secondInput != "End")
            {
                string pokemonElement = secondInput;
                CheckIfTrainerHasAPokemonWith(pokemonElement, allTraines);
                secondInput = Console.ReadLine();
            }

            var sorted = allTraines.OrderByDescending(x => x.Value.Badges).ToDictionary(x => x.Key, y => y.Value);

            foreach (var trainer in sorted)
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.Badges} {trainer.Value.PokemonCollection.Count}");
            }
        }

        static void AddNewTrainer(string[] data, Dictionary<string, Trainer> allTraines)
        {
            string trainerName = data[0];
            string pokemonName = data[1];
            string pokemonElement = data[2];
            int pokemonHealth = int.Parse(data[3]);

            if (!allTraines.ContainsKey(trainerName))
            {
                Trainer trainer = new Trainer(trainerName);
                allTraines.Add(trainerName, trainer);
            }

            Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
            allTraines[trainerName].PokemonCollection.Add(pokemon);
        }

        static void CheckIfTrainerHasAPokemonWith(string element, Dictionary<string, Trainer> allTraines)
        {
            foreach (var trainer in allTraines)
            {
                if (trainer.Value.PokemonCollection.Any(x => x.Element == element))
                {
                    trainer.Value.Badges++;
                }
                else
                {
                    trainer.Value.ReducePokemonHealth();
                }
            }
        }
    }
}
