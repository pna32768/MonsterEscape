namespace MonsterEscape
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialise game variables
            int maxPlayerStrength = 50;
            int playerStrength = maxPlayerStrength;

            // When stepsTaken reaches maxSteps, the player wins the game
            int stepsTaken = 0;
            int maxSteps = 10;

            Random monsterGenerator = new Random();

            bool gameRunning = true;

            // Main game loop
            while (gameRunning) // short for while (gameRunning == true)
            {
                int monsterLevel = monsterGenerator.Next(0, 10); // Generates a random monster level between 0 and 9

                // Selection - if the monsterLevel is 0, no monster appears.  If the monsterLevel is greater than 0, a monster appears and attacks the player
                if (monsterLevel == 0)
                {
                    Console.WriteLine("No monster appeared. Phew");

                    // Increment steps taken and check if the player has reached the maximum number of steps

                    stepsTaken++;
                    float percenteComplete = (float)stepsTaken / (float)maxSteps * 100.0f;
                    Console.WriteLine($"You have taken {stepsTaken} steps.  You're {percenteComplete}% complete.");

                    if (stepsTaken >= maxSteps)
                    {
                        Console.WriteLine("You have reached the end!!!.  You win!");
                        gameRunning = false;
                    }
                }
                else
                {
                    Console.WriteLine($"A level {monsterLevel} monster appeared!");
                    playerStrength -= monsterLevel; // Decrease player strength by monster level

                    // Selection - if the playerStrength is greater than 0, the player survives the attack.  If the playerStrength is 0 or less, the player dies and the game ends
                    if (playerStrength > 0)
                    {
                        Console.WriteLine($"You were attacked by the monster - you now have {playerStrength} strength remaining.");

                        // Increment steps taken and check if the player has reached the maximum number of steps

                        stepsTaken++;
                        float percenteComplete = (float)stepsTaken / (float)maxSteps * 100.0f;
                        Console.WriteLine($"You have taken {stepsTaken} steps.  You're {percenteComplete:F0}% complete.");

                        if (stepsTaken >= maxSteps)
                        {
                            Console.WriteLine("You have reached the end!!!.  You win!");
                            gameRunning = false;
                        }
                    }
                    else // playerStrength is 0 or less, player dies
                    {
                        Console.WriteLine($"You were attacked by the monster and died!  Game Over!!!");
                        gameRunning = false;
                    }
                }
            }

            Console.WriteLine("Thanks for playing!");
        }
    }
}
