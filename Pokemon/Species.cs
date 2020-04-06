using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    class Charmander : Pokemon
    {
        
        public Charmander(int level)
        {
            //set some values inside Charmander/Pokemon?
            
            //Making list for Charmander moves
            List<Move> CharmanderMoves = new List<Move>();

            CharmanderMoves.Add(new Move("Ember"));
            CharmanderMoves.Add(new Move("Fire Blast"));

            //setting the name, level, etc. to their values
            this.Name = "Charmander";
            this.Level = level;
            this.baseAttack = 52;
            this.baseDefence = 43;
            this.Hp = 39;
            this.maxHp = Hp;
            this.Element = Elements.Fire;
            this.Moves = CharmanderMoves;

        }
    }

    class Bulbasaur : Pokemon
    {
        public Bulbasaur(int level)
        {
            //Making list for Bulbasaur moves
            List<Move> BulbasaurMoves = new List<Move>();

            BulbasaurMoves.Add(new Move("Cut"));
            BulbasaurMoves.Add(new Move("Mega Drain"));
            BulbasaurMoves.Add(new Move("Razor Leaf"));

            //setting the name, level, etc. to their values
            this.Name = "Bulbasaur";
            this.Level = level;
            this.baseAttack = 49;
            this.baseDefence = 49;
            this.Hp = 45;
            this.maxHp = Hp;
            this.Element = Elements.Grass;
            this.Moves = BulbasaurMoves;
        }

    }

    class Squirtle : Pokemon
    {
        public Squirtle( int level )
        {
            //Making list for Squirtle moves
            List<Move> SquirtleMoves = new List<Move>();

            SquirtleMoves.Add(new Move("Bubble"));
            SquirtleMoves.Add(new Move("Bite"));
            
            //setting the name, level, etc. to their values
            this.Name = "Squirtle";
            this.Level = level;
            this.baseAttack = 48;
            this.baseDefence = 65;
            this.Hp = 44;
            this.maxHp = Hp;
            this.Element = Elements.Water;
            this.Moves = SquirtleMoves;
        }
    }
}
