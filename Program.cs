using System;

class Program
{
    static Random random = new();
    static void Main()
    {
        Console.WriteLine("Welcome to Finger Cricket Game!!!!");

        int numberOfPlayers = GetNumberOfPlayers(); 
        bool playerBattingFirst = ConductToss();
        int playerScore, pcScore;
        if (playerBattingFirst){
            playerScore = PlayInnings("Player", numberOfPlayers);
            System.Console.WriteLine($"Target is {playerScore}");
            pcScore = PlayInnings("PC", numberOfPlayers, playerScore);
        }else{
            pcScore = PlayInnings("PC", numberOfPlayers);
            System.Console.WriteLine($"Target is {pcScore}");
            playerScore = PlayInnings("Player", numberOfPlayers,pcScore);
        }

        DetermineWinner(playerScore, pcScore);
    }

    static int GetNumberOfPlayers(){
        System.Console.WriteLine("Enter the number of players in your team: ");
        return Convert.ToInt32(Console.ReadLine());
    }

    static bool ConductToss(){
        string playerCall;
        System.Console.WriteLine("Its Toss Time. \"heads\" or \"tails\"?");
        while(true){
            playerCall = Console.ReadLine().ToLower();
            if(playerCall == "heads" || playerCall ==  "tails"){
                break;
            }else{
                System.Console.WriteLine("Invalid choice. Please enter \"heads\" or \"tails\".");
            }

        }
        string[] tossOptions = { "heads", "tails" };
        System.Console.WriteLine("Spinning the Coin!!!!!!!");
        string tossResult = tossOptions[random.Next(2)];
        System.Console.WriteLine($"Toss Result: {tossResult}");
        if(playerCall == tossResult){
            System.Console.WriteLine(@"Congratulations.You have won the toss. Choose!!
1. Batting
2. Balling");
            while(true){
                string choice = Console.ReadLine();
                if (choice == "1") return true;
                else if (choice == "2") return false;
                else {
                    Console.WriteLine("Invalid choice. Please enter 1 for Batting or 2 for Balling.");
                }
                
            }
        }else{
            System.Console.WriteLine("You have lost the toss!!");
            System.Console.WriteLine("PC will decide now!!");
            string[] choices = { "bat", "ball"};
            string pcDecision = choices[random.Next(2)];
            
            if (pcDecision == "bat"){
                System.Console.WriteLine($"PC has decided to {pcDecision}. You will bowl Now!");
                return false;
            } 
            else{
                System.Console.WriteLine($"PC has decided to {pcDecision}. You will bat Now!");
                return true;
            };
        }
    }

    static int PlayInnings(string team, int numberOfPlayers, int target = -1){
        int teamScore = 0;
        System.Console.WriteLine($"{team} is Batting...");

        for (int i = 1; i <= numberOfPlayers ; i++ ){
            teamScore += PlayPlayerInnings(team, i, teamScore, target-teamScore);
            if (target > 0 && teamScore >= target) {
                break; 
            }
        }
        return teamScore;        
    }

    static int PlayPlayerInnings(string team, int playerNumber, int teamScore, int runsNeeded = -1)
    {
        int playerRun = 0;
        Console.WriteLine($"Player number {playerNumber} of {team} is batting....");
        while (true)
        {
            if (team == "Player")
            {
                int bat;
                while (true)
                {
                    Console.WriteLine("Enter your turn (0-6):");
                    bat = Convert.ToInt32(Console.ReadLine());
                    if (bat >= 0 && bat <= 6) break;
                    else Console.WriteLine("Invalid input. Please enter a number between 0 and 6.");
                }

                int ball = random.Next(7);
                Console.WriteLine($"Bowler bowled {ball}");
                if (bat == ball)
                {
                    Console.WriteLine($"Player number {playerNumber} of {team} is out");
                    break;
                }
                else
                {
                    playerRun += bat;
                    Console.WriteLine($"Player number {playerNumber} scored {bat} runs. Team Score: {playerRun + teamScore}");
                }
                if (runsNeeded > 0 && playerRun > runsNeeded)
                {
                    break;
                }
            }
            else
            {
                int ball;
                while (true)
                {
                    Console.WriteLine("Enter your turn (0-6):");
                    ball = Convert.ToInt32(Console.ReadLine());
                    if (ball >= 0 && ball <= 6) break;
                    else Console.WriteLine("Invalid input. Please enter a number between 0 and 6.");
                }

                int bat = random.Next(7);
                Console.WriteLine($"Bowler bowled {ball}");
                if (bat == ball)
                {
                    Console.WriteLine($"Player number {playerNumber} of {team} is out");
                    break;
                }
                else
                {
                    playerRun += bat;
                    Console.WriteLine($"Player number {playerNumber} scored {bat} runs. Team Score: {playerRun + teamScore}");
                }
                if (runsNeeded > 0 && playerRun > runsNeeded)
                {
                    break;
                }
            }
        }
        return playerRun;
    }


    static void DetermineWinner(int playerScore, int pcScore)
    {
        if (playerScore > pcScore)
        {
            Console.WriteLine($"Congratulations! You won by {playerScore - pcScore} runs.");
        }
        else if (pcScore > playerScore)
        {
            Console.WriteLine($"PC won by {pcScore - playerScore} runs.");
        }
        else
        {
            Console.WriteLine("It's a tie!");
        }
    }
}