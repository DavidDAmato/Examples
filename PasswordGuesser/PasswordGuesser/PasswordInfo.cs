using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace PasswordGuesser
{
    public class PasswordInfo
    {
        private string password = null;
        // more chars if we want ~!@#$%^&*()_-+=.<.>?|{}[]/*-+
        private readonly char[] PossibleChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
        private bool FoundInFile = false;
        private int MaxLength = 10;
        private const string ExceptionMsg = "Invalid password please try again.";
        private const string FileNames = "10kMostCommonEnglishWords.txt,100kMostCommonEnglishWords.txt,100kMostCommonPasswords.txt";

        public bool ContainedInFiles = false;
        public int FileTries = 0;

        public int BruteTries = 0;
        public DateTime BruteForceEndTime = DateTime.MinValue;
        
        public PasswordInfo(string password)
        {
            this.password = password;
        }

        public void Validate()
        {
            if (password == null)
            {
                throw new Exception(ExceptionMsg);
            }

            if (password.Length > MaxLength)
            {
                Console.WriteLine($"Come on man that ones too hard. Use {MaxLength} or less chracters");
                throw new Exception(ExceptionMsg);
            }
            if (this.password.Contains(" "))
            {
                Console.Write($"Pass phrase cracker is version 2.0, don't enter a password with spaces");
                throw new Exception(ExceptionMsg);
            }
            var illegalChars = false;
            foreach (var c in password)
            {
                if (PossibleChars.All(chars => chars != c))
                {
                    Console.WriteLine($"Invalid character detected: {c}");
                    illegalChars = true;
                }
            }

            if (illegalChars)
            {
                throw new Exception(ExceptionMsg);
            }
        }

        /// <summary>
        /// BruteForceCheckSameLength
        /// </summary>
        /// <param name="maxLength"></param>
        /// <param name="position"></param>
        /// <param name="startString"></param>
        public void BruteForceCheckSameLength(int maxLength, int position = 0, string startString = "")
        {
			// This needs to change for multi threading so we can guess all items for a certain length, then for say a-n, n-z for starting and iterate until we reach max cores.
            for (var count = 0; count < PossibleChars.Length; count++)
            {
                if (position < maxLength - 1)
                {
                    // recurse. TODO: theres got to be some way to bail on the first correct check, but break doesn't work. return an object maybe?
                    BruteForceCheckSameLength(maxLength, position + 1, startString + PossibleChars[count]);
                }
                /* Commented out for performance, uncomment the line if you want to see the output, it drastically slows down performance.
                 var check = startString + possibleChars[count];
                 Console.WriteLine($"Checking {check}"); */
                if (startString + PossibleChars[count] == this.password)
                {
                    Console.WriteLine($"Cracked! Password is: { this.password}");
                    BruteForceEndTime = DateTime.Now;
                }

                // also has a performance implication
                BruteTries++;
            }
        }

        //TODO: check all password lengths for a more accurate time compare.
            public void BruteForceCheckAll(int position = 0, string testString = "")
        {
            throw new NotImplementedException("TODO");
        }

        /// <summary>
        /// loads about 200k common passwords and checks against the input 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="testString"></param>
        public void GuessFromFiles(int position = 0, string testString = "")
        {
            // TODO add as content and use directly instead of loading from file.
            foreach (var file in FileNames.Split(','))
            {
                var dir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                var path = Path.Combine($@"{dir}\Resources", file);
                Console.WriteLine($"Checking contents of file: {path} ");
                var content = File.ReadAllLines(path);
                foreach (var line in content)
                {
                    if (password.ToLower().Equals(line.ToLower()))
                    {
                        Console.Write($"Your password was: {password} line was: {line}");
                        ContainedInFiles = true;
                        //TODO figure out case
                        FoundInFile = true;
                        break;
                    }
                    FileTries++;
                }

                if (FoundInFile)
                {
                    //TODO: refine files so they only contain unique content.
                    Console.WriteLine($"Found match in resource file: {file}");
                    break;
                }

            }

        }

    }


}