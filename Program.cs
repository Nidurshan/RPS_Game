
using RPS_Game;

var exit = false;

var weaponCodes = new List<string> { "R", "P", "S" };

var weaponMaps = new Dictionary<string, Weapon>
{
    { "R", new Weapon("rock") },
    { "P", new Weapon("paper") },
    { "S", new Weapon("scissor") }
};

while (!exit)
{
    Console.WriteLine();
    Console.WriteLine("..................................................................");
    Console.WriteLine("..................................................................");
    Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>> ROCK PAPER SCISSOR <<<<<<<<<<<<<<<<<<<<<<<");
    Console.WriteLine("..................................................................");
    Console.WriteLine("..................................................................");
    Console.WriteLine();

    Console.Write("Enter your name: ");
    var player = Console.ReadLine();
    var opponent = "Computer";

    var playerScore = 0;
    var opponentScore = 0;
    
    var scoreBoard = $"{player}   {playerScore} vs {opponentScore}   {opponent}";

    Console.WriteLine("");

    var times = 3;

    for (var i=0; i<times; i++)
    {
        Console.Write($"{player} => ");
        var playerWeaponCode = Console.ReadLine().ToUpper();
        var playerWeapon = weaponMaps[playerWeaponCode];

        var random = new Random().Next(1, 4);
        var randomWeaponCode = weaponCodes[random - 1];
        var opponentWeapon = weaponMaps[randomWeaponCode];

        var battleWinner = GuessBattleWinner(playerWeapon, opponentWeapon);


        if (battleWinner == "opponent")
        {
            opponentScore++;
            scoreBoard = $"{player}   {playerScore} vs {opponentScore}   {opponent}";
            Console.WriteLine($"{opponent}'s {opponentWeapon.Name} beats {player}'s {playerWeapon.Name} \n---------------------------------------- {scoreBoard}");
        }
        else if (battleWinner == "player")
        {
            playerScore++;
            scoreBoard = $"{player}   {playerScore} vs {opponentScore}   {opponent}";
            Console.WriteLine($"{player}'s {playerWeapon.Name} beats {opponent}'s {opponentWeapon.Name} \n---------------------------------------- {scoreBoard}");
        }
        else 
        {
            Console.WriteLine($"It's a draw \n---------------------------------------- {scoreBoard}");
        }

        Console.WriteLine();
    }

    string warWinner = GuessWarWinner(playerScore, opponentScore);
    var result = warWinner == null 
        ? "It's a draw :|" 
        : warWinner == "player" 
            ? "You won :)" : "You lose :(";

    Console.WriteLine();
    Console.WriteLine($"========================================================================>>> {result}");
    Console.WriteLine($"========================================================================>>> {scoreBoard}");

    Console.WriteLine();
    Console.Write("Play again? [Y/N]: ");
    exit = Console.ReadLine().ToUpper() == "Y" ? false : true;

}

string GuessBattleWinner(Weapon playerWeapon, Weapon opponentWeapon)
{
    if(playerWeapon.Superior == opponentWeapon.Name)
    {
        return "opponent";
    }
    else if (playerWeapon.Inferior == opponentWeapon.Name)
    {
        return "player";
    }
    else
    {
        return null;
    }
}

string GuessWarWinner(int playerScore, int opponentScore)
{
    if (playerScore < opponentScore) return "opponent";
    else if (playerScore > opponentScore) return "player";
    else return null;
}

