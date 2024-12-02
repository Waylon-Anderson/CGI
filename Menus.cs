using System.Formats.Asn1;
using System.Reflection.Metadata;

namespace CGI_Challenge
{
    public class Menus
    {
        private string userInput;
        private string correctPassword = "1234";
        Utility Utility = new Utility();    
        User User = new User();
        Admin Admin = new Admin();
        Race Race = new Race();


        public void MainMenu(){
            while(userInput != "3"){
                System.Console.WriteLine("Select role:\n1. Admin\n2. User\n3. Exit");
                userInput = System.Console.ReadLine();
                MenuRoute();
            }
        }
        private void MenuRoute(){
            if(userInput == "1"){
                AdminAccess();
            }
            else if(userInput == "2"){
                UserMenu();
            }
            else if(userInput == "3"){
                System.Console.WriteLine("Goodbye");
                Utility.Pause();
            }
            else{
                System.Console.WriteLine("Invalid choice...");
                Utility.Pause();
            }
        }
        private void UserMenu(){
            while(userInput != "6"){
                Console.Clear();
                System.Console.WriteLine("What would you like to do?\n1. Login / Register\n2. Available Karts\n3. Race a kart\n4. Return your kart\n6. Exit");
                userInput = Console.ReadLine();
                UserRoute();
            }
        }
        private void UserRoute(){
            if(userInput == "1"){
                User.userAccountHandling();
            }
            else if(userInput == "2"){
                User.AvailableKarts();
                Utility.Pause();
            }
            else if(userInput == "3"){
                User.racekart();
            }
            else if(userInput == "4"){
                User.KartCheckin();
            }
            else if(userInput == "5"){
                System.Console.WriteLine("Goodbye!");
            }
            else{
                System.Console.WriteLine("Invalid choice please choose again");
            }
        }
        private void AdminMenu(){
            while(userInput != "5"){
                Console.Clear();
                System.Console.WriteLine("What would you like to do?\n1. Add Kart\n2. Remove Kart\n3. Edit Kart\n4. Access Report Menu\n5. Exit");
                userInput = Console.ReadLine();
                AdminRoute();
            }
        }
        private void AdminRoute(){
            if(userInput == "1"){
                Admin.AddKart();
            }
            else if(userInput == "2"){
                Admin.RemoveKart();
            }
            else if(userInput == "3"){
                Admin.EditKart();
            }
            else if(userInput == "4"){
                RaceReportsMenu();
            }
            else if(userInput == "5"){
                System.Console.WriteLine("Goodbye!");
            }
            else{
                System.Console.WriteLine("Invalid Choice, choose again");
            }
        }
        private void RaceReportsMenu(){
            Console.Clear();
            while(userInput != "5"){
                System.Console.WriteLine("1. View Daily Races?\n2. Karts In Use\n3. Exit");
                userInput = Console.ReadLine();
                RaceReportsMenuRoute();
            }
        }
        private void RaceReportsMenuRoute(){
            if(userInput == "1"){
                Admin.KartReport();
            }
            else if(userInput == "2"){
                Admin.KartsBeingUsed();
            }
            else if(userInput == "3"){
                System.Console.WriteLine("Goodbye!");
            }
            else{
                System.Console.WriteLine("Invalid choice please choose again");
            }
        }


        private void AdminAccess(){  //Forces you to give a password in order to access the Admin class
            System.Console.WriteLine("What is the password?");
            string guessedPassword = Console.ReadLine();
            if(guessedPassword == correctPassword){
                AdminMenu();
            }
            else{
                System.Console.WriteLine("Incorrect password");
                Utility.Pause();
            }
        }
    }
}