using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    class PokemonFactory
    {
        public static Pokemon Create(string specie, int level)
        {
            switch ( specie )
            {
                case "Charmander":
                    return new Charmander(level);
                    
                case "Bulbasaur":
                    return new Bulbasaur(level);
                    
                case "Squirtle":
                    return new Squirtle(level);
                    
                default:
                    return null;
            }
        }
        public static Pokemon CreateRandomLevel(string specie)
        {
            Random rand = new Random();
            return Create(specie , rand.Next(10)); 
            //returns a pokemon of the specified species, with a random level between 0 and 9

        }
    }
}
