using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace CGI_Challenge
{
    public class Utility
    {
        public void Pause(){
            System.Console.WriteLine("Press any button to continue...");
            System.Console.ReadKey();
        }
        public void MainScreen(){ 
            System.Console.WriteLine(@"   _  __        _         ____       _____          ____         _         ____  U _____ u    ____       _    ");
            System.Console.WriteLine(@"  |'|/ /    U  /'\  u  U |  _'\ u   |_ ' _|      U |  _'\ u  U  /'\  u  U /'___| \| ___'|/ U |  _'\ u  U|'|u  ");
            System.Console.WriteLine(@"  | ' /      \/ _ \/    \| |_) |/     | |         \| |_) |/   \/ _ \/   \| | u    |  _|'    \| |_) |/  \| |/  ");
            System.Console.WriteLine(@"U/| . \\u    / ___ \     |  _ <      /| |\         |  _ <     / ___ \    | |/__   | |___     |  _ <     |_|   ");
            System.Console.WriteLine(@"  |_|\_\    /_/   \_\    |_| \_\    u |_|U         |_| \_\   /_/   \_\    \____|  |_____|    |_| \_\    (_)   ");
            System.Console.WriteLine(@",-,>> \\,-.  \\    >>    //   \\_   _// \\_        //   \\_   \\    >>   _// \\   <<   >>    //   \\_   |||_  ");
            System.Console.WriteLine(@" \.)   (_/  (__)  (__)  (__)  (__) (__) (__)      (__)  (__) (__)  (__) (__)(__) (__) (__)  (__)  (__) (__)_)  ");
        }
    }
}