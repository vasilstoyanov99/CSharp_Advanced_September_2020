using System;
using System.Collections.Generic;
using System.Text;

namespace _09.Pokemon_Trainer
{
    class Trainer
    {
        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> PokemonCollection { get; set; }

        public Trainer(string name)
        {
            Name = name;
            Badges = 0;
            PokemonCollection = new List<Pokemon>();
        }

        public void ReducePokemonHealth()
        {
            for (int i = 0; i < PokemonCollection.Count; i++)
            {
                PokemonCollection[i].Health -= 10;
                CheckIfAPokimonIsDeadAndRemoveIt();
            }
        }

        private void CheckIfAPokimonIsDeadAndRemoveIt()
        {
            for (int i = 0; i < PokemonCollection.Count; i++)
            {
                if (PokemonCollection[i].Health <= 0)
                {
                    PokemonCollection.Remove(PokemonCollection[i]);
                    i--;
                }
            }
        }
    }
}
