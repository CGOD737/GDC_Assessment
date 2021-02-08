//Written by Christopher Godfrey for GDCIT Assessment
using System;
using System.IO;
using System.Collections.Generic;

namespace GDC_Assessment {
    class Program {

        //global list variables within the scope of the class
        static List<string> valid = new List<string>();
        static List<string> invalid = new List<string>();
        static void Main(string[] args){ //Prompts User for a filename and stores it in a variable which will be used for a search
            
            Console.WriteLine("\nPlease enter the name of the .csv file");
            
            string filename = Console.ReadLine(); //reads the filename from the console line
            string file = "";

            //if the .csv was written by the user, add that to the file
            string[] check = filename.Split('.');
            if ( check.Length == 1)
                file = filename +".csv";
            else
                file = filename;
  

            if ( searchDirectory(file) ){ //if the file was found parse the CSV file
                parseFile(file);
                printList();
            }
            else //if the file was not found, print error message
                Console.WriteLine("\nCould not find the specified file");
        }
        static Boolean searchDirectory(string file){ //Searchs for the filename in the base directory based on a single filename in the current directory
            try {
                return File.Exists(Directory.GetCurrentDirectory() + @"\" + file);
            }
            catch (Exception e){
                Console.WriteLine("Failed to Search Directory ", e.ToString());
                return false;
            }
        }
        static void parseFile(string file){ //parses the CSV file and adds emails to the corresponding valid/invalid list
           string[] lines = System.IO.File.ReadAllLines(Directory.GetCurrentDirectory() + @"\" + file);

           string[] parsed;
           string[] emailAddress;

           foreach (string line in lines){ 
               if ( line == lines[0]) //skips the header line
                continue;
               parsed = line.Split('@');

               if ( parsed[1] == "gdcit.com"){ //adds to valid list
                   emailAddress = line.Split(',');
                   valid.Add(emailAddress[2]);
               }
               else { //adds to invalid list
                   emailAddress = line.Split(',');
                   invalid.Add(emailAddress[2]);
               }
               
           }
        }
        static void printList(){ //prints the list separated by valid email addresses and invalid email address
            Console.WriteLine("\n -----Valid Email Addresses----- ");
            foreach (string email in valid ){
                Console.WriteLine(email);
            }
                        Console.WriteLine("\n -----InValid Email Addresses----- ");
            foreach (string email in invalid ){
                Console.WriteLine(email);
            }
        }
    }
}
