namespace TextAdventureGame25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // create a framework for a text adventure game

            // game class (responsible for the game)
            // room class (the levels)
            // map class (maybe)

            //Player player1 = new Player("Jesse", 100);
            //Enemy enemy1 = new Enemy("Goblin", 10);

            //Console.WriteLine($"{player1.Name} has {player1.Health} health.");
            //Console.WriteLine($"{enemy1.Name} has {enemy1.Health} health.");
            //Console.WriteLine();
            //Console.WriteLine($"{player1.Name} is dead? {player1.IsDead()}");
            //Console.WriteLine($"{enemy1.Name} is dead? {enemy1.IsDead()}");

            // map class
            Map gameMap = new Map(25, 25);

            gameMap.PrintMap();
        }
    }
}
