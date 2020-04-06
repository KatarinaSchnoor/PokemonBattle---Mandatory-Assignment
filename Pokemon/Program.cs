using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pokemon> roster = new List<Pokemon>();

            //creating the pokemons and adding them to the list
            roster.Add(PokemonFactory.Create("Charmander", 3));
            roster.Add(PokemonFactory.Create("Bulbasaur" , 3));
            roster.Add(PokemonFactory.Create("Squirtle" , 2));

            // INITIALIZE YOUR THREE POKEMONS HERE
            //roster.Add(new Pokemon("Charmander" , 3 , 52 , 43 , 39 , Elements.Fire , CharmanderMoves));
            //roster.Add(new Pokemon("Squirtle" , 2 , 48 , 65 , 44 , Elements.Water , SquirtleMoves));
            //roster.Add(new Pokemon("Bulbasaur" , 3 , 49 , 49 , 45 , Elements.Grass , BulbasaurMoves));

            Console.WriteLine("Welcome to the world of Pokemon!\nThe available commands are list/fight/heal/quit");

            while (true)
            {
                Console.WriteLine("\nPlease enter a command");
                switch (Console.ReadLine())
                {
                    case "list":
                        // PRINT THE POKEMONS IN THE ROSTER HERE
                        for ( int i=0 ;i<roster.Count ;i++ )
                        {
                            Console.WriteLine(roster[i].Name + " - Level " + roster[i].Level + " / HP " + roster[i].Hp + " / Element: " + roster[i].Element);
                        }
                        
                        break;

                    case "fight":

                        //PRINT INSTRUCTIONS AND POSSIBLE POKEMONS (SEE SLIDES FOR EXAMPLE OF EXECUTION)
                        //Should I delete some text?
                        Console.WriteLine("Choose who should fight! (Charmander, Bulbasaur, or Squirtle) \nWrite the names of the two Pokemons you want to fight, only seperated by 'space'.");
                        Console.WriteLine("The first Pokemon you choose will be your Pokemon, the next will be the one you fight!");

                        //READ INPUT, REMEMBER IT SHOULD BE TWO POKEMON NAMES
                        string input = Console.ReadLine();
                        //split the input into to two, so we know if there are two Pokemons entered
                        string[] chosenPokemons = input.Split(' ');
                                                
                        //BE SURE TO CHECK THE POKEMON NAMES THE USER WROTE ARE VALID (IN THE ROSTER) AND IF THEY ARE IN FACT 2!
                        Pokemon player = null;
                        Pokemon enemy = null;

                        //Checking if they put in two names
                        if ( chosenPokemons.Length < 2 )
                        {
                            Console.WriteLine("You have to choose two Pokemons to fight, seperated with 'space' (Charmander, Squirtle, or Bulbasaur)");
                        }
                        else
                        {
                            for ( int i = 0 ; i < roster.Count ; i++ )
                            {
                                //Check if first name exist
                                if ( chosenPokemons[0] == roster[i].Name.ToString() )
                                {
                                    player = roster[i];
                                    
                                }
                                
                            }
                            for ( int i = 0 ; i < roster.Count ; i++ )
                            {
                                //Check if second name exist
                                if ( chosenPokemons[1] == roster[i].Name.ToString() )
                                {
                                    enemy = roster[i];
                                }
                            }
                        }

                        //if everything is fine and we have 2 pokemons let's make them fight
                        if ( player != null && enemy != null && player != enemy )
                        {
                            if ( player.Hp <= 0 )
                            {
                                Console.WriteLine(player.Name + " is fainted, and cannot fight. You have to heal them to be able to fight.");
                            }
                            else if ( enemy.Hp <= 0 )
                            {
                                Console.WriteLine(enemy.Name + " is fainted, and cannot fight. You have to be heal them to be able to fight.");
                            }
                            else
                            {
                                Console.WriteLine("A wild " + enemy.Name + " appears!");
                                Console.WriteLine(player.Name + " I choose you! ");


                                //BEGIN FIGHT LOOP
                                while ( player.Hp > 0 && enemy.Hp > 0 )
                                {
                                    //PRINT POSSIBLE MOVES
                                    Console.Write("What move should we use?  ");

                                    foreach ( Move moves in player.Moves )
                                    {
                                        Console.Write("/ {0} " , moves.Name);

                                    }

                                    Console.WriteLine(" ");

                                    //GET USER ANSWER, BE SURE TO CHECK IF IT'S A VALID MOVE, OTHERWISE ASK AGAIN
                                    string chosenMove = Console.ReadLine();
                                    string move = null;
                                    bool possibleMove = false;
                                    bool enemyAttack = false;
                                    bool printOnce = false;

                                    foreach ( Move moves in player.Moves )
                                    {
                                        if ( chosenMove == moves.Name )
                                        {
                                            move = chosenMove;
                                            possibleMove = true;
                                            printOnce = true;
                                        }
                                        else if ( possibleMove == false )
                                        {
                                            enemyAttack = false;
                                            printOnce = false;
                                        }

                                    }

                                    if ( possibleMove == false && printOnce == false )
                                    {
                                        Console.WriteLine("Please choose one of " + player.Name + " moves");
                                    }

                                    if ( possibleMove == true )
                                    {
                                        //int move = -1;

                                        //CALCULATE AND APPLY DAMAGE
                                        int damage = player.Attack(enemy);

                                        //print the move and damage
                                        Console.WriteLine(player.Name + " uses " + move + ". " + enemy.Name + " loses " + damage + " HP");
                                        possibleMove = false;
                                        enemyAttack = true;
                                    }

                                    //if the enemy is not dead yet, it attacks
                                    if ( enemy.Hp > 0 && enemyAttack == true )
                                    {
                                        //CHOOSE A RANDOM MOVE BETWEEN THE ENEMY MOVES AND USE IT TO ATTACK THE PLAYER
                                        Random rand = new Random();
                                        /*the C# random is a bit different than the Unity random
                                         * you can ask for a number between [0,X) (X not included) by writing
                                         * rand.Next(X) 
                                         * where X is a number 
                                         */
                                        int enemyMove = rand.Next(enemy.Moves.Count);

                                        int enemyDamage = enemy.Attack(player);

                                        //print the move and damage
                                        Console.WriteLine(enemy.Name + " uses " + enemy.Moves[enemyMove].Name + ". " + player.Name + " loses " + enemyDamage + " HP");

                                        enemyAttack = false;
                                    }
                                }
                                //The loop is over, so either we won or lost
                                if ( enemy.Hp <= 0 )
                                {
                                    Console.WriteLine(enemy.Name + " faints, you won!");
                                }
                                else
                                {
                                    Console.WriteLine(player.Name + " faints, you lost...");
                                }

                            }


                        }
                        //otherwise let's print an error message
                        else
                        {
                            Console.WriteLine("Invalid Pokemons.");
                        }
                        break;

                    case "heal":
                        //RESTORE ALL POKEMONS IN THE ROSTER
                        for ( int i = 0 ; i < roster.Count ; i++ )
                        {
                            roster[i].Restore();
                            Console.WriteLine(roster[i].Name + " - HP " + roster[i].Hp);

                        }

                        
                        Console.WriteLine("All pokemons have been healed");
                        break;

                    case "quit":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
    }
}
