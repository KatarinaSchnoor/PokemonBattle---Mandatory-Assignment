﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    /// <summary>
    /// The possible elemental types
    /// </summary>
    public enum Elements
    {
        Fire,
        Water,
        Grass
    }

    public abstract class Pokemon
    {
        //fields
        //int level;
        protected int baseAttack;
        protected int baseDefence;
        protected int hp;
        protected int maxHp;
        //Elements element;

        //properties, imagine them as private fields with a possible get/set property (accessors)
        //in this case used to allow other objects to read (get) but not write (no set) these variables
        public string Name; /* { get; }*/
        //example of how to make the string Name readable AND writable  
        //  public string Name { get; set; }
        public List<Move> Moves; /* { get; }*/
        //can also be used to get/set other private fields
        public int Hp; /* { get => hp; }*/

        public int Level; /* { get; }*/

        public Elements Element; /* { get; }*/

        /// <summary>
        /// Constructor for a Pokemon, the arguments are fairly self-explanatory
        /// </summary>
        /// <param name="name"></param>
        /// <param name="level"></param>
        /// <param name="baseAttack"></param>
        /// <param name="baseDefence"></param>
        /// <param name="hp"></param>
        /// <param name="element"></param>
        /// <param name="moves">This needs to be a List of Move objects</param>
        /*public Pokemon(int level, int baseAttack,
            int baseDefence, int hp, Elements element,
            List<Move> moves)
        {
            this.Level = level;
            this.baseAttack = baseAttack;
            this.baseDefence = baseDefence;
            this.Name = name;
            this.hp = hp;
            this.maxHp = hp;
            this.Element = element;
            this.Moves = moves;
        }*/

        public Pokemon()
        {

        }

        /// <summary>
        /// performs an attack and returns total damage, check the slides for how to calculate the damage
        /// IMPORTANT: should also apply the damage to the enemy pokemon
        /// </summary>
        /// <param name="enemy">This is the enemy pokemon that we are attacking</param>
        /// <returns>The amount of damage that was applied so we can print it for the user</returns>
        public int Attack(Pokemon enemy)
        {
            int totalDamage = (this.baseAttack * this.Level) * this.CalculateElementalEffects(/*baseAttack,*/ enemy.Element) - enemy.CalculateDefence();

            if ( totalDamage < 0 )
            {
                totalDamage = 0;
            }

            enemy.ApplyDamage(totalDamage);
            return totalDamage;
        }

        /// <summary>
        /// calculate the current amount of defence points
        /// </summary>
        /// <returns> returns the amount of defence points considering the level as well</returns>
        public int CalculateDefence()
        {
            int defence = this.baseDefence * this.Level;
            return defence;
        }

        /// <summary>
        /// Calculates elemental effect, check table at https://bulbapedia.bulbagarden.net/wiki/Type#Type_chart for a reference
        /// </summary>
        /// <param name="damage">The amount of pre elemental-effect damage</param>
        /// <param name="enemyType">The elemental type of the enemy</param>
        /// <returns>The damage post elemental-effect</returns>
        public int CalculateElementalEffects(/*int damage,*/ Elements enemyType)
        {
            
            if ( Element == Elements.Fire && enemyType == Elements.Water || Element == Elements.Water && enemyType == Elements.Grass ||
                Element == Elements.Grass && enemyType == Elements.Fire )
            {
                int elementalEffectNegative = 1 / 2;
                return elementalEffectNegative;
            }
            else if ( Element == Elements.Fire && enemyType == Elements.Grass || Element == Elements.Water && enemyType == Elements.Fire || 
                Element == Elements.Grass && enemyType == Elements.Water)
            {
                int elementalEffectPositive = 2;
                return elementalEffectPositive;
            }
            else
            {
                return 0;
            }
            
        }

        /// <summary>
        /// Applies damage to the pokemon
        /// </summary>
        /// <param name="damage"></param>
        public void ApplyDamage(int damage)
        {
            this.hp = this.hp - damage;
            if ( this.hp < 0 )
            {
                hp = 0;
            }
        }

        /// <summary>
        /// Heals the pokemon by resetting the HP to the max
        /// </summary>
        public void Restore()
        {
            this.hp = this.maxHp;
        }
    }
}
