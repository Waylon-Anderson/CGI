using System.Xml.Schema;

namespace CGI_Challenge
{
    public class User
    {
        private string currUser;
        private bool userSelected = false;
        private string currKart = null;
        private bool kartReturn;

        FileHandler FileHandler = new FileHandler();
        Utility Utility = new Utility();
        Race Race = new Race();
        public void userAccountHandling(){
            System.Console.WriteLine("Do you have an account or would you like to make one?\n1. Login\n2. Register");
            string userInput = Console.ReadLine().ToLower();
            if(userInput == "1" || userInput == "login"){ //logins to an account 
                Console.Clear();
                System.Console.WriteLine("Type your email in: ");
                userInput = Console.ReadLine();
                FileHandler.FileGetter("users.txt");
                FileHandler.FileCounter("users.txt");
                for(int i = 0; i < FileHandler.fileCount; i++){
                    string temp = FileHandler.fileHolder[i];
                    string[] tempSplitter = temp.Split('#');
                    if(tempSplitter[3] == userInput){
                        currUser = tempSplitter[1];
                        System.Console.WriteLine($"Welcome back, {tempSplitter[1]}!");
                        Utility.Pause();
                    }
                }
                userSelected = true;
            }
            else if(userInput == "2" || userInput == "register"){ //This option will make you register a new account
                System.Console.WriteLine("Please type your first name");
                string firstName = Console.ReadLine();
                System.Console.WriteLine("Please type you last name");
                string lastName = Console.ReadLine();
                System.Console.WriteLine("Please type in the email that you would like to register: ");
                string email = Console.ReadLine();
                FileHandler.FileCounter("users.txt");
                
                StreamWriter sw = new StreamWriter("users.txt", true);
                sw.WriteLine($"{FileHandler.fileCount + 1}#{firstName}#{lastName}#{email}");
                sw.Close();

                System.Console.WriteLine("You have successfully registered an account and have been logged in");
                Utility.Pause();
                userSelected = true;
            }
        }

        public void AvailableKarts(){
            FileHandler.FileGetter("kart-inventory.txt");
            FileHandler.FileCounter("kart-inventory.txt");
            System.Console.WriteLine("{0,-10}{1,-15}{2,-15}", "Kart ID", "Kart Name", "Size");

            for(int i = 0; i < FileHandler.fileCount; i++){
                string temp = FileHandler.fileHolder[i];
                string[] tempSplitter = temp.Split('#');
                if(tempSplitter[3] == "True"){
                    Console.WriteLine("{0,-10}{1,-15}{2,-15}", tempSplitter[0], tempSplitter[1], tempSplitter[2]);  
                }
            }
        }
        public void racekart(){
            if(userSelected == false){
                System.Console.WriteLine("Please come back whenever you have logged in!");
                Utility.Pause();
            }
            else if(userSelected == true){
                if(currKart == null){
                    KartCheckout();
                }
                RaceTrackSelecter(); // change it to where you can return it whenver you'd like not just after every race
            }
            System.Console.WriteLine("Would you like to check in your cart?\n1. Yes\n2. No");
            string kart = Console.ReadLine().ToLower();
            if(kart == "yes" || kart == "1"){
                kartReturn = true;
                ResultFileInput();
                KartCheckin();
            }
            else if(kart == "no" || kart == "2"){
                kartReturn = false;
                ResultFileInput();
            }

        }
        private void KartCheckout(){
            if(userSelected == true){
                System.Console.WriteLine("What kart would you like to race in?");  
                AvailableKarts();
                string userInput = Console.ReadLine();
                for(int i = 0; i < FileHandler.fileCount; i++){
                    string temp = FileHandler.fileHolder[i];
                    string[] tempSplitter = temp.Split('#');
                    if(tempSplitter[0] == userInput){
                        currKart = tempSplitter[1];
                        FileHandler.fileHolder[i] = ($"{tempSplitter[0]}#{tempSplitter[1]}#{tempSplitter[2]}#False");
                        FileHandler.FileSetter("kart-inventory.txt");
                    }
                }
                System.Console.WriteLine($"You have selected {currKart} as your kart to race in");
                Utility.Pause();
            }
            else{
                Console.Clear();
                System.Console.WriteLine("Please log into an account before you race a kart!");
                Utility.Pause();
            }
        }
        public void KartCheckin(){
            FileHandler.FileCounter("kart-inventory.txt");
            FileHandler.FileGetter("kart-inventory.txt");
            for(int i = 0; i < FileHandler.fileCount; i++){
                string temp = FileHandler.fileHolder[i];
                string[] tempSplitter = temp.Split('#');
                if(currKart == tempSplitter[1]){
                    System.Console.WriteLine($"You have successfully returned {currKart}!");
                    currKart = null;
                    FileHandler.fileHolder[i] = ($"{tempSplitter[0]}#{tempSplitter[1]}#{tempSplitter[2]}#True");
                }
            }
            FileHandler.FileSetter("kart-inventory.txt");
        }
        public void RaceHistory(){ 

        }
        private void RaceTrackSelecter(){
            Race.DragRace();
        }
        private void ResultFileInput(){
            DateTime today = DateTime.Today;
            FileHandler.FileGetter("Results.txt"); //gets the file
            FileHandler.FileCounter("Results.txt"); //counts all of the items in the file
            System.Console.WriteLine("kartReturn" + kartReturn);
            StreamWriter sw = new StreamWriter("Results.txt", true);
            sw.WriteLine($"{FileHandler.fileCount + 1}#{currUser}#{currKart}#{Race.raceTime}#{today.ToString("MM/dd/yyyy")}#{kartReturn}"); 
            sw.Close();
        }
    }
}