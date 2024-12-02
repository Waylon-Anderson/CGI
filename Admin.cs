using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Win32.SafeHandles;


namespace CGI_Challenge
{
    public class Admin
    {
        Utility Utility = new Utility();
        FileHandler FileHandler = new FileHandler();
        FileHandler existingKarts = new FileHandler();
        public void AddKart(){ //Full method responsible for adding a new kart to the 
            Console.Clear();
            FileHandler.FileSort("kart-inventory.txt");
            FileHandler.FileCounter("kart-inventory.txt");
            StreamWriter kartAdder = new StreamWriter ("kart-inventory.txt",  true);
            System.Console.WriteLine("What would you like the kart name to be?");
            string kartName = Console.ReadLine();
            System.Console.WriteLine("What size? You have the options between small, medium, large");
            string kartSize= Console.ReadLine();
            kartAdder.WriteLine($"{FileHandler.fileCount + 1}#{kartName}#{kartSize}#True");
            System.Console.WriteLine("It has been edited");
            kartAdder.Close();
        }

        public void RemoveKart(){ // Work on removeKart and removing it from the specific ID not the actual line in the text. Everything else works so far
            FileHandler.FileSort("kart-inventory.txt");
            FileHandler.textFileDisplay("kart-inventory.txt");
            System.Console.WriteLine("Type in the Kart ID of the cart that you would like removed");
            int userInput = int.Parse(Console.ReadLine());

            Console.Clear();
            FileHandler.FileCounter("kart-inventory.txt");
            FileHandler.FileGetter("kart-inventory.txt");
            FileHandler.fileHolder[userInput - 1] = "";     
            StreamWriter kartRemove = new StreamWriter("kart-inventory.txt"); // Remove the selected ID of the file
            for(int a = 0; a < FileHandler.fileCount; a++){
                    if (!string.IsNullOrEmpty(FileHandler.fileHolder[a])) {
                        kartRemove.WriteLine(FileHandler.fileHolder[a]);
                    }
            }
            kartRemove.Close(); 
            Utility.Pause();
        }
        public void EditKart(){ //edit kart doesnt change it to the new kart id. Change that. >:(
            FileHandler.textFileDisplay("kart-inventory.txt");
            FileHandler.FileGetter("kart-inventory.txt");
            FileHandler.FileCounter("kart-inventory.txt");
            System.Console.WriteLine("Type the ID of which kart would you like to edit?");
            string userInput = Console.ReadLine();
            System.Console.WriteLine("Would you like to change the name or size?");
            string selectedField = Console.ReadLine();
            System.Console.WriteLine("What would you like to change it to?");
            string newInformation = Console.ReadLine();
            string[] temp = new string[1000];
            string reader;
            string newEntry = null;
            for(int i = 0; i < FileHandler.fileCount; i++){ // going through the whole array
                reader = FileHandler.fileHolder[i];
                for(int x = 0; x < 4; x++){
                    temp = reader.Split('#'); // Splits the whole array into separate parts 
                }
               if(userInput == temp[0]){ // if it finds the correct field then it will edit it
                    Utility.Pause();
                    if(selectedField == "2" || selectedField == "name"){
                        temp[1] = newInformation;
                        newEntry = ($"{temp[0]}#{temp[1]}#{temp[2]}#{temp[3]}");


                    }
                    else if(selectedField == "3" || selectedField == "size"){
                        temp[2] = newInformation;
                        newEntry = ($"{temp[0]}#{temp[1]}#{temp[2]}#{temp[3]}");
                    }
                    for(int x = 0; x < FileHandler.fileCount; x++){

                        if(x == int.Parse(userInput) - 1){
                            FileHandler.fileHolder[x] = newEntry;
                            System.Console.WriteLine("test");
                        }
                    }
               }
            }
            StreamWriter sw = new StreamWriter("kart-inventory.txt");
            for(int i = 0; i < FileHandler.fileCount; i++){ //Just to see the new list of karts
                sw.WriteLine(FileHandler.fileHolder[i]);
            }
            sw.Close();
        }
        public void KartReport(){
            FileHandler.FileGetter("Results.txt");
            FileHandler.FileCounter("Results.txt");
            FileHandler.textFileDisplay("Results.txt");
            Utility.Pause();
        }
        public void KartsBeingUsed(){
            FileHandler.FileGetter("kart-inventory.txt");
            FileHandler.FileCounter("kart-inventory.txt");
            Console.Clear();
            System.Console.WriteLine("{0,-10}{1,-15}{2,-15}{3,-15}{4,-15}", "Race ID", "", "", "", "");
            for(int i = 0; i < FileHandler.fileCount; i++){
                string temp = FileHandler.fileHolder[i];
                string[] tempSplitter = temp.Split('#');
                if(tempSplitter[3] == "False"){
                    Console.WriteLine("{0,-10}{1,-15}{2,-15}{3,-15}", tempSplitter[0], tempSplitter[1], tempSplitter[2], tempSplitter[3]);  
                }
            }
            Utility.Pause();
        }
        public void ResultsBySize(){ //Make it to where it compares the name of the kart then find its size.
            Console.Clear();
            FileHandler.FileGetter("Results.txt");
            FileHandler.FileCounter("Results.txt");
            System.Console.WriteLine(FileHandler.fileCount);
            for(int i = 0; i < FileHandler.fileCount; i++){
                string temp = FileHandler.fileHolder[i];
                string[] tempSplitter = temp.Split('#');
                System.Console.WriteLine(temp);
            }
            Utility.Pause();
        }
        public void TopKarts(){ // do two for loops because it will go through and make sure there's no duplicates of anything of the kart that gets caught out
            FileHandler.FileGetter("Results.txt");
            FileHandler.FileCounter("Results.txt");
            existingKarts.FileGetter("kart-inventory.txt");
            existingKarts.FileCounter("kart-inventory.txt");

            int holder = 0;
            for(int i = 0; i < FileHandler.fileCount; i++){
                string temp = FileHandler.fileHolder[i];
                string[] tempHolder = temp.Split('#');
                string tempExisting = existingKarts.fileHolder[i];
                string[] tempHolderExisting = temp.Split('#');
                    for(int x = 0; x < FileHandler.fileCount; x++){
                        if(tempHolder[2] == tempHolderExisting[2]){
                        holder++;
                    }        
                }

            }
            System.Console.WriteLine(holder);
            Utility.Pause();
        }
    }
}  