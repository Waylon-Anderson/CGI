using System.IO.Compression;

namespace CGI_Challenge
{
    public class FileHandler
    {
        public string[] fileHolder = new string[1000];
        public int fileCount; //Supports kartCounting method with other method

        public int userCount;

        public void textFileDisplay(string textFile){ //Counter that visually displays the list for editing or displaying
            Console.Clear();
            StreamReader lister = new StreamReader(textFile); //opens file
            string list = lister.ReadLine();
            if(textFile == "kart-inventory.txt" || textFile == "users.txt"){
                System.Console.WriteLine("{0,-10}{1,-15}{2,-15}{3,-15}", "Kart ID", "Kart Name", "Size", "Kart Availability");
                while (list != null) { //going through the file for as long as there's something on that line and displaying the whole line
                    string[] temp = list.Split('#');
                    Console.WriteLine("{0,-10}{1,-15}{2,-15}{3,-15}", temp[0], temp[1], temp[2], temp[3]);  
                    System.Console.WriteLine();
                    list = lister.ReadLine(); //update read that prevents infinite loop
                }
            }
            else if(textFile == "Results.txt"){
                System.Console.WriteLine("{0,-10}{1,-15}{2,-15}{3,-15}{4,-15}{5, -15}", "Race ID", "First Name", "Kart Used", "Race Time", "Race Date", "Kart Returned (After Race)");
                while (list != null) { 
                    string[] temp = list.Split('#');
                    Console.WriteLine("{0,-10}{1,-15}{2,-15}{3,-15}{4,-15}{5, -15}", temp[0], temp[1], temp[2], temp[3], temp[4], temp[5]);  
                    System.Console.WriteLine();
                    list = lister.ReadLine(); 
                }        
            }

            lister.Close();
        }
        public void FileGetter(string textFile){ //Gets the list off of a file for other functions
            StreamReader reader = new StreamReader(textFile, true);
            int i = 0;
            string tempReader = ""; //Literally is just used to hold the temporary string as I am removing a line
            while(tempReader != null){ //gets the entire text file and saves it to the kartHolder[]
                tempReader = reader.ReadLine();
                fileHolder[i] = tempReader;
                i++;
            }
            reader.Close();
        }
        public void FileSort(string textFile){    //Used in supporting the kart functions. Nasty code but it works...
            FileGetter(textFile); /// Gets the actual list of karts
            FileCounter(textFile); // gets the amount of karts being used for it for loop
            string[] seperatori = new string[100];
            string[] seperatorx = new string[100];

            for(int i = 0; i < fileCount ; i++){
                string tempi = fileHolder[i];
                seperatori = tempi.Split('#');
                for(int x = i + 1; x < fileCount; x++){
                    string tempx = fileHolder[x];
                    seperatorx = tempx.Split('#');
                    if(int.Parse(seperatori[0]) > int.Parse(seperatorx[0])){
                        string temp = fileHolder[x];
                        fileHolder[x] = fileHolder[i];
                        fileHolder[i] = temp;
                    }
                }
            }
            StreamWriter Sort = new StreamWriter("kart-inventory.txt");
                for(int j = 0; j < fileCount; j++){
                    Sort.WriteLine(fileHolder[j]);
                }
                Sort.Close();
        }
        public void FileCounter(string textFile){ //Counter to help other kart functions such as when you're adding
            fileCount = 0;
            StreamReader Kart = new StreamReader(textFile);
            string kartList = Kart.ReadLine();
            while (kartList != null) { //just goes through and gives the next available spot in the kart ID list
                kartList = Kart.ReadLine();
                fileCount++;
            }
            Kart.Close();
        }
        public void FileSetter(string textFile){
            StreamWriter sr = new StreamWriter(textFile);
            for(int i = 0; i < fileCount; i++ ){
                sr.WriteLine(fileHolder[i]);
            }
            sr.Close();
        }
        public void FileHolderSort(string textFile, int line){    //Used in supporting the kart functions. Nasty code but it works...
            FileGetter(textFile); /// Gets the actual list of karts
            FileCounter(textFile); // gets the amount of karts being used for it for loop
            string[] seperatori = new string[100];
            string[] seperatorx = new string[100];

            for(int i = 0; i < fileCount ; i++){
                string tempi = fileHolder[i];
                seperatori = tempi.Split('#');
                for(int x = i + 1; x < fileCount; x++){
                    string tempx = fileHolder[x];
                    seperatorx = tempx.Split('#');
                    if(int.Parse(seperatori[3]) < int.Parse(seperatorx[3])){
                        string temp = fileHolder[x];
                        fileHolder[x] = fileHolder[i];
                        fileHolder[i] = temp;
                    }
                }
            }
            for(int j = 0; j < fileCount; j++){
                Console.WriteLine(fileHolder[j]);
            }
            System.Console.WriteLine("---------------------");
        }
    }
}