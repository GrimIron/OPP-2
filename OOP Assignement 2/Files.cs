using System;
using System.IO;

namespace OOP_Assignement_2
{
    public class Files
    {
        string a_txt { get; set; }
        string b_txt { get; set; }

        public bool fileCheck(string file_1, string file_2)
        {
            a_txt = getLocation(file_1);            //gets the location for the first file          
            b_txt = getLocation(file_2);            //gets the location for the second file
            try
            {
                FileStream txt1 = new FileStream(a_txt, FileMode.Open, FileAccess.Read);
                FileStream txt2 = new FileStream(b_txt, FileMode.Open, FileAccess.Read);

                //checks if the files are different
                if (txt1.Length != txt2.Length)
                {
                    //closes the files-
                    txt1.Close();
                    txt2.Close();

                    string not_same = file_1 + " and " + file_2 + " are different";
                    Console.WriteLine(not_same);
                    return true;
                }
                else
                {
                    //closes the files
                    txt1.Close();
                    txt2.Close();

                    string same = file_1 + " and " + file_2 + " are not different";
                    Console.WriteLine(same);
                    return true;
                }
            }
            //handles if the file is not found
            catch (FileNotFoundException)
            {
                string exception = "one or both of the files do not exist!";
                Console.WriteLine(exception);
                return false;
            }
        }

        //gets the location of the file the user inputted
        private string getLocation(string file_name)
        {
            string current_dir = Directory.GetCurrentDirectory();
            string newPath = Path.GetFullPath(Path.Combine(current_dir, @"..\..\..\" + file_name));

            return newPath;
        }
    }
}
