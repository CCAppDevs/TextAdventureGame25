namespace TextAdventureGame25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // create a framework for a text adventure game

            // player class (responsible for the player)
            // game class (responsible for the game)
            // enemy class (varied enemies)
            // room class (the levels)
            // map class (maybe)

            Player player1 = new Player("Jesse", 100);
            Enemy enemy1 = new Enemy("Goblin", 10);

            Console.WriteLine($"{player1.Name} has {player1.Health} health.");
            Console.WriteLine($"{enemy1.Name} has {enemy1.Health} health.");
        }
    }
}
