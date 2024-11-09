namespace ProjectFirst
{
    internal class Program
    {
        //private static object playerCharacter;

        static void Main(string[] args)
        {

            string name;

            Random random = new Random();

            List<Character> enemies = new List<Character> { new Sorcerer(), new Skeleton(), new Goblin(), new Zombie() };

            Character dragon = new Dragon();

            Console.WriteLine("Input name:");
            do { name = Console.ReadLine(); }while (name == null);

            Console.WriteLine("Choose character: 1 - Wizard, 2 - Warrior, 3 - Thief: ");
            int characterChoice;

            do
            {
                characterChoice = Convert.ToInt32(Console.ReadLine());
            } while (characterChoice < 1 || characterChoice > 3);

            Character playerCharacter;

            if (characterChoice == 1)
            {
                playerCharacter = new Wizard(name);
            }
            else if (characterChoice == 2)
            {
                playerCharacter = new Warrior(name);
            }
            else
            {
                playerCharacter = new Thief(name);
            }

            Console.WriteLine($"Welcome {name} the {playerCharacter.GetType().Name}");

            int defeatedEnemies = 0;

            while (playerCharacter.GetHp() > 0)
            {
                Character CurrentEnemy;
                if (defeatedEnemies >= 2) 
                {
                    CurrentEnemy = dragon;
                    Console.WriteLine("A dragon appeared.");
                }
                else
                {
                    int enemyIndex = random.Next(0, enemies.Count);
                    CurrentEnemy = enemies[enemyIndex];
                }

                bool battleResult = Game.Battle(CurrentEnemy, playerCharacter);

                if (battleResult && CurrentEnemy is Dragon)
                {
                    Console.WriteLine("Victory!");
                    break;
                }
                else if (!battleResult) 
                {
                    Console.Write("Defeat!");
                }
                else if(battleResult)
                {
                    Console.WriteLine($"You have defeated {CurrentEnemy}! One step closer to the dragon!");
                    defeatedEnemies++;
                }
            }

        }
    }
}
