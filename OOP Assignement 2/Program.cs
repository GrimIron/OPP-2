using System;
using System.IO;

namespace OOP_Assignement_2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool check = false;
            //loops until check = true
            do
            {
                Files f = new Files();
                string[] input = user_input();

                //checks which command the user has chosen to use
                if (input[0] == "diff")
                {
                    check = f.fileCheck(input[1], input[2]);

                }
                else
                {
                    Console.WriteLine("Invalid Command!");
                }
            }
            while (check != true);
            Console.ReadLine();
        }

        //gets the user input formats it and error checks it
        static string[] user_input()
        {
            bool check = false;
            string[] command;
            //loops untill check = true
            do
            {
                Console.Write("> ");                                                                    //shows that the users needs to input
                string user_input = Console.ReadLine().ToLower();                                       //asks the user to input a string 
                command = user_input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);   //splits the string on a space places into a string array, removes any white space
                int total = 0;                                                                          //counter to keep track of which element

                //checks to see if too many arguments have been included
                foreach (string a in command)
                {
                    total++;
                    if (total > 3)
                    {
                        Console.WriteLine("Too many arguments! should be: command file file");
                    }
                }

                //checks to see if no command was entered, and if too little arguments were given 
                if (command == null || command.Length == 0)
                {
                    Console.WriteLine("There is no command!");
                }
                else if (total < 3)
                {
                    Console.WriteLine("Too little arguments! should be: command file file");
                }
                else
                {
                    check = true;
                }
            }
            while (check != true);
            
            //returns the command and files chosen by the user
            return command;
        }
    }
}
