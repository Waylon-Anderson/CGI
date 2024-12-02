using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace CGI_Challenge
{
    public class Race
    {   
        Utility Utility = new Utility();
        public double raceTime;
        public void DragRace(){
            raceTime = 0;
            StartingScreen();
            Random rnd = new Random();
            int playerRaceSpot = 0;  
            int oppponentRaceSpot = 0;
            Console.Clear();      
            for(int i = 0; i < 100; i++){ //For the players
                int playerRaceGap = rnd.Next(1,6);
                playerRaceSpot = playerRaceSpot + playerRaceGap;

                int opponentOneRaceGap = rnd.Next(1,6);
                oppponentRaceSpot = oppponentRaceSpot + opponentOneRaceGap;
                Console.Clear();

                Console.WriteLine("-----------------------------------------------------------------------------------*\n");
                
                for(int x = 0; x < playerRaceSpot; x++){ // Determines how many times it needs to go out for your spot
                    Console.Write("~");
                }
                Console.Write("0---0>"); // Writes where you are after the previous console.writes

                System.Console.WriteLine(""); //Divider for each player

                for(int y = 0; y < oppponentRaceSpot;y++){
                    System.Console.Write("~");
                }
                System.Console.Write("o---0D"); // Write for the opponent below player

                Console.WriteLine("\n-----------------------------------------------------------------------------------*");
                if(playerRaceSpot > oppponentRaceSpot){
                    System.Console.WriteLine("First: You");
                    System.Console.WriteLine("Second: Opponent");
                }
                else if(playerRaceSpot < oppponentRaceSpot){
                    System.Console.WriteLine("First: Opponent");
                    System.Console.WriteLine("Second: You");
                }
                else if(playerRaceSpot == oppponentRaceSpot){
                    System.Console.WriteLine("TIED!!");
                }
                Thread.Sleep(350);
                raceTime += 5;

                if(playerRaceSpot > 80){ //Determines the "finish line" that will be displayed 
                    if(playerRaceSpot > oppponentRaceSpot){
                        WinningScreen();
                    }
                    else if(playerRaceSpot < opponentOneRaceGap){
                        System.Console.WriteLine("You unfortunately lost...");
                    }
                    else if(playerRaceSpot == opponentOneRaceGap){
                        System.Console.WriteLine("You guys have tied!");
                    }
                    System.Console.WriteLine($"You passed the finish line with a time of: {raceTime} Seconds");
                    Utility.Pause();
                    break;
                }
            }
        }
    private void WinningScreen(){
        for (int i = 0; i < 5; i++){
            // Set the blue background and clear the console to fill the screen
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine(@" __      __                          __       __                      __ ");
            Console.WriteLine(@"|  \    /  \                        |  \  _  |  \                    |  \");
            Console.WriteLine(@" \$$\  /  $$______   __    __       | $$ / \ | $$  ______   _______  | $$");
            Console.WriteLine(@"  \$$\/  $$/      \ |  \  |  \      | $$/  $\| $$ /      \ |       \ | $$");
            Console.WriteLine(@"   \$$  $$|  $$$$$$\| $$  | $$      | $$  $$$\ $$|  $$$$$$\| $$$$$$$\| $$");
            Console.WriteLine(@"    \$$$$ | $$  | $$| $$  | $$      | $$ $$\$$\$$| $$  | $$| $$  | $$ \$$");
            Console.WriteLine(@"    | $$  | $$__/ $$| $$__/ $$      | $$$$  \$$$$| $$__/ $$| $$  | $$ __ ");
            Console.WriteLine(@"    | $$   \$$    $$ \$$    $$      | $$$    \$$$ \$$    $$| $$  | $$|  \");
            Console.WriteLine(@"     \$$    \$$$$$$   \$$$$$$        \$$      \$$  \$$$$$$  \$$   \$$ \$$");
            Thread.Sleep(500);

            // Set the green background and clear the console to fill the screen
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            Console.WriteLine(@" __      __                         __       __                      __ ");
            Console.WriteLine(@"/  \    /  |                       /  |  _  /  |                    /  |");
            Console.WriteLine(@"$$  \  /$$/______   __    __       $$ | / \ $$ |  ______   _______  $$ |");
            Console.WriteLine(@" $$  \/$$//      \ /  |  /  |      $$ |/$  \$$ | /      \ /       \ $$ |");
            Console.WriteLine(@"  $$  $$//$$$$$$  |$$ |  $$ |      $$ /$$$  $$ |/$$$$$$  |$$$$$$$  |$$ |");
            Console.WriteLine(@"   $$$$/ $$ |  $$ |$$ |  $$ |      $$ $$/$$ $$ |$$ |  $$ |$$ |  $$ |$$/ ");
            Console.WriteLine(@"    $$ | $$ \__$$ |$$ \__$$ |      $$$$/  $$$$ |$$ \__$$ |$$ |  $$ | __ ");
            Console.WriteLine(@"    $$ | $$    $$/ $$    $$/       $$$/    $$$ |$$    $$/ $$ |  $$ |/  |");
            Console.WriteLine(@"    $$/   $$$$$$/   $$$$$$/        $$/      $$/  $$$$$$/  $$/   $$/ $$/ ");
            Thread.Sleep(500);
        }
        // Reset the console background and clear it
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();
    }
        private void StartingScreen(){
            Console.Clear();    
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Clear();
            System.Console.WriteLine(@"  _____                _              ");
            System.Console.WriteLine(@" |  __ \              | |            ");
            System.Console.WriteLine(@" | |__) |___  __ _  __| |_   _       ");
            System.Console.WriteLine(@" |  _  // _ \/ _` |/ _` | | | |      ");
            System.Console.WriteLine(@" | | \ \  __/ (_| | (_| | |_| |_ _ _ ");
            System.Console.WriteLine(@" |_|  \_\___|\__,_|\__,_|\__, (_|_|_)");
            System.Console.WriteLine(@"                          __/ |      ");
            System.Console.WriteLine(@"                         |___/       ");
            Thread.Sleep(2000);  

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Clear();
            System.Console.WriteLine(@"   _____      _         ");
            System.Console.WriteLine(@"  / ____|    | |        ");
            System.Console.WriteLine(@" | (___   ___| |_       ");
            System.Console.WriteLine(@"  \___ \ / _ \ __|      ");
            System.Console.WriteLine(@"  ____) |  __/ |_ _ _ _ ");
            System.Console.WriteLine(@" |_____/ \___|\__(_|_|_)");
            Console.BackgroundColor = ConsoleColor.Black;
            Thread.Sleep(2000);

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            System.Console.WriteLine(@"   _____  ____  _ _ _ ");
            System.Console.WriteLine(@"  / ____|/ __ \| | | |");
            System.Console.WriteLine(@" | |  __| |  | | | | |");
            System.Console.WriteLine(@" | | |_ | |  | | | | |");
            System.Console.WriteLine(@" | |__| | |__| |_|_|_|");
            System.Console.WriteLine(@"  \_____|\____/(_|_|_)");
            Console.BackgroundColor = ConsoleColor.Black;
            Thread.Sleep(2000);            
        }
    }
}