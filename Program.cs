using System;

class Program
{
    static Random random = new();
    static void Main()
    {
        Console.WriteLine("Welcome to Finger Cricket Game!!!!");

        int numberOfPlayers = GetNumberOfPlayers(); 
        bool battingFirst = ConductToss();
        System.Console.WriteLine(battingFirst);
    }

    static int GetNumberOfPlayers(){
        System.Console.WriteLine("Enter the number of players in your team: ");
        return Convert.ToInt32(Console.ReadLine());
    }

    static bool ConductToss(){
        System.Console.WriteLine("Its Toss Time. \"heads\" or \"tails\"?");
        string playerCall = Console.ReadLine().ToLower();
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
}