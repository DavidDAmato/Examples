using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Threading.Tasks.Dataflow;

namespace PasswordGuesser
{
    class Program
    {
		// This is the start of an experiment in multi threading. 
        private const string GnuMsg =
            "This program is free software: you can redistribute it and/or modify\r\n    it under the terms of the GNU General Public License as published by\r\n    the Free Software Foundation, either version 3 of the License, or\r\n    (at your option) any later version.\r\n\r\n    This program is distributed in the hope that it will be useful,\r\n    but WITHOUT ANY WARRANTY; without even the implied warranty of\r\n    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the\r\n    GNU General Public License for more details.\r\n\r\n    You should have received a copy of the GNU General Public License\r\n    along with this program.  If not, see <http://www.gnu.org/licenses/>.";
        private const string Welcome = "Created by David D'Amato in 2017.";

        static void Main(string[] args)
        {
            Console.WriteLine($"{GnuMsg} \r\n {Welcome}");
            try
            {
                Console.WriteLine("This program explores passwords and how hard they are to guess using a brute force method. It is in no way efficent.");
                while (true)
                {
                    Console.WriteLine("Input the password to check the complexity of: \r\n");
                    var password = Console.ReadLine();
                    var pwInfo = new PasswordInfo(password);
                    pwInfo.Validate();

                    var startTime = DateTime.Now;
                    pwInfo.GuessFromFiles();
                    var fileCheckTime = Math.Abs((startTime - DateTime.Now).TotalSeconds);
                    Console.WriteLine($"Total Elapsed seconds from guessing from files {fileCheckTime}\r\n");

                    startTime = DateTime.Now;
                    Console.WriteLine("Starting brute force check... \r\nthis may take a long time, hours for 7-8 characters, days+ for 9+ depending on computer performance. \r\n\r\nUse brute force to guess password? Enter 'Y' for yes or any other key to exit");

					//TODO: it would be cool to take known data from say a facebook account and generate smart combos of what to guess first.

	                var guessBruteForce = Console.ReadKey().Key;
	                if (guessBruteForce != ConsoleKey.Y)
	                {
		                Environment.Exit(0);
	                }

					pwInfo.BruteForceCheckSameLength(password.Length);
                    var bruteForceTime = Math.Abs((startTime - pwInfo.BruteForceEndTime).TotalSeconds);
                    Console.WriteLine($"Total Elapsed seconds from brute force check: {bruteForceTime}");

                    Console.WriteLine($"\r\n*****Summary***** \r\nTime to find from ~200k most common passwords: {fileCheckTime} seconds\r\nPassword In 200k most common passwords: {pwInfo.ContainedInFiles}");
                    Console.WriteLine($"Time to check using brute force: {fileCheckTime} seconds \r\n ");
                    Console.WriteLine($"Brute Force Tries: {pwInfo.BruteTries} \r\nCommon Password Tries: {pwInfo.FileTries}");
                    Console.Write("Press C to contiue or any other key to exit...");

                    var exit = Console.ReadKey().Key;
                    if (exit != ConsoleKey.C)
                    {
                        Environment.Exit(0);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }


}
