//System to store, retrieve and update teacher data for "Rainbow School".

/* 
 * By: Minhal Kamel Al Bo-Hassan
 * Email: mkb90000@gmail.com
 * Via: Simplilearn
 */


using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Project1
{
    class Teacher
    {
        //Class fields
        public int teacher_ID;
        public string teacher_Name;
        public string teacher_Section;

        //The path of the file 
        public string filePath = @"C:\User\Desktop\Project1Solution\Records.txt";
        List<string> lines;     //Declare an object (lines) for the file
        public Teacher()    //Constructor for the Teacher class
        {
            lines = File.ReadAllLines(filePath).ToList();   //Initialize the file object
        }

        //Method to add new record
        static void Add()
        {
            Teacher records = new Teacher();    //Class object

            Console.WriteLine("\t -------------------- ");
            Console.WriteLine("\t|   Add new Record   |");
            Console.WriteLine("\t -------------------- \n");

            //Specifying how many record to add
            Console.WriteLine("How many records do you want to add: ");
            int number = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                /*The user will only enter the name and the section for the teacher
                 *The ID will be generated randomly
                 */
                Console.WriteLine("Number #" + i + ": ");
                Console.WriteLine("Enter the teacher name: ");
                records.teacher_Name = Console.ReadLine();

                Console.WriteLine("Enter his/her section: ");
                records.teacher_Section = Console.ReadLine();

                //Random function with range 1 to 10000
                Random random = new Random();
                records.teacher_ID = random.Next(10000);

                //Specifying the format of how the data stored in the file
                string record = records.teacher_ID.ToString() + ',' + records.teacher_Name + ',' + records.teacher_Section;
                records.lines.Add(record);  //Add the new data in a new line
                records.lines.Sort();   //Sort the lines
                File.WriteAllLines(records.filePath, records.lines);    //Export the record to the file

                Console.WriteLine(" ");
            }
            Console.WriteLine("Added successfully!\n");
        }

        //Method to change and update some records
        static void Update()
        {
            Teacher records = new Teacher();    //Class object
            bool found = false;

            Console.WriteLine("\t --------------------- ");
            Console.WriteLine("\t|   Update a Record   |");
            Console.WriteLine("\t --------------------- \n");

            //Ask for the ID to search for the record
            Console.WriteLine("Enter the ID of the record you want to update: ");
            string id = Console.ReadLine();
            foreach (var line in records.lines)     //Loop to pass every line in the file
            {
                //Split the string into substring and ignoring the comma 
                string[] array = line.Split(',');
                if (array[0] == id)
                {
                    found = true;

                    Console.WriteLine("Record to update: ");
                    Console.WriteLine("ID: " + array[0] + " \t\tName: " + array[1] + " \t\tSection: " + array[2]);
                    int choice;
                    Console.WriteLine("Are you sure you want to update this record? (Enter 1 to continue/ any number to exit): ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                    {
                        records.lines.Remove(array[0] + ',' + array[1] + ',' + array[2]);   //Remove the line we want to update

                        //User input to update the name and the section
                        Console.WriteLine("Enter the new name:");
                        records.teacher_Name = Console.ReadLine();
                        Console.WriteLine("Enter the new section:");
                        records.teacher_Section = Console.ReadLine();

                        //Update the new data
                        array[1] = records.teacher_Name;
                        array[2] = records.teacher_Section;

                        //Specifying the format of how the data stored in the file
                        string record = id + ',' + array[1] + ',' + array[2];
                        records.lines.Add(record);  //Add the updated data in a new line
                        records.lines.Sort();   //Sort the lines
                        File.WriteAllLines(records.filePath, records.lines);    //Export the updated record to the file
                        Console.WriteLine("Updated successfully!");
                        Console.WriteLine("ID: " + array[0] + "\t\tNew Name: " + array[1] + "\t\tNew Section: " + array[2] + "\n");
                        break;
                    }
                    else if (choice < 1 || choice > 1)
                    {
                        Console.WriteLine("Operation canceled!\n");
                    }
                }
            }
            if (!found)
            {
                Console.WriteLine("*Not found!\n");
            }
        }

        //Method to view all the records stored in the file
        static void View()  
        {
            Teacher records = new Teacher();    //Class object
            bool found = false;

            Console.WriteLine("\t -------------------- ");
            Console.WriteLine("\t|        VIEW        |");
            Console.WriteLine("\t -------------------- \n");

            //Specifying the columns
            Console.WriteLine("ID \t\tName \t\tSection");
            foreach (string line in records.lines)     //Loop to pass every line in the file
            {
                found = true;
                //Split the string into substring and ignoring the comma
                string[] array = line.Split(',');
                Console.WriteLine(array[0] + " \t\t" + array[1] + " \t\t" + array[2]);
            }
            if (!found)
            {
                Console.WriteLine("*File is empty!");
            }
            Console.WriteLine("\n");
        }

        //Method to search for a specific record
        static void Search()
        {
            Teacher records = new Teacher();    //Class object
            bool found = false;

            Console.WriteLine("\t -------------------- ");
            Console.WriteLine("\t|       Search       |");
            Console.WriteLine("\t -------------------- \n");

            //Ask for the ID to search for the record
            Console.WriteLine("Enter the ID for the record you want to view: ");
            string id = Console.ReadLine();

            //Specifying the columns
            Console.WriteLine("ID \t\tName \t\tSection");
            foreach (var line in records.lines)     //Loop to pass every line in the file
            {
                //Split the string into substring and ignoring the comma
                string[] array = line.Split(',');
                if (array[0] == id)
                {
                    found = true;
                    Console.WriteLine(array[0] + " \t\t" + array[1] + " \t\t" + array[2]);
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("*Not found!");
            }
            Console.WriteLine("\n");
        }

        //Method to delete a specific record
        static void Delete()
        {
            Teacher records = new Teacher();    //Class object
            bool found = false;

            Console.WriteLine("\t --------------------- ");
            Console.WriteLine("\t|   Delete a Record   |");
            Console.WriteLine("\t --------------------- \n");

            //Ask for the ID to search for the record
            Console.WriteLine("Enter the ID of the record you want to delete: ");
            string id = Console.ReadLine();
            foreach (var line in records.lines)     //Loop to pass every line in the file
            {
                //Split the string into substring and ignoring the comma
                string[] array = line.Split(',');
                if (array[0] == id)
                {
                    found = true;
                    Console.WriteLine("Record to delete: ");
                    Console.WriteLine("ID: " + array[0] + " \t\tName: " + array[1] + " \t\tSection: " + array[2]);
                    int choice;
                    Console.WriteLine("Are you sure you want to delete this record? (Enter 1 to continue/ any number to exit): ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                    {
                        string record = id + ',' + array[1] + ',' + array[2];     //The chosen record to delete
                        records.lines.Remove(record);   //Remove the record
                        records.lines.Sort();   //Sort the lines
                        File.WriteAllLines(records.filePath, records.lines);    //Export the changes to the file
                        Console.WriteLine("Deleted successfully!\n");
                        break;
                    }
                    else if (choice < 1 || choice > 1)
                    {
                        Console.WriteLine("Operation canceled!\n");
                    }
                }
            }
            if (!found)
            {
                Console.WriteLine("*Not found!\n");
            }
        }

        //Main method
        static void Main(string[] args)
        {

            //Main System:

            int cho = 0;
            //Do While loop that will continue executing until the user choose to exit
            do
            {
                //The menu and the main program
                Console.WriteLine("\t------------------------------------------------\n"
                            + "\t|   *** Rainbow School - Teacher Records ***   |\n"
                            + "\t------------------------------------------------\n\n"
                            + "Choose from the list below: \n"
                            + "  1 - View all records.\n"
                            + "  2 - Add a new record.\n"
                            + "  3 - Update a record.\n"
                            + "  4 - Search for a record.\n"
                            + "  5 - Delete a record.\n"
                            + "  6 - Exit.\n");
                Console.WriteLine("Your choice: ");
                cho = Convert.ToInt32(Console.ReadLine());

                //Switch loop contains six cases depends on the menu options
                switch (cho)
                {
                    case 1:
                        //Calling the view method
                        View();
                        break;

                    case 2:
                        //Calling the add method
                        Add();
                        break;

                    case 3:
                        //Calling the update method
                        Update();
                        break;

                    case 4:
                        //Calling the search method
                        Search();
                        break;

                    case 5:
                        //Calling the delete method
                        Delete();
                        break;

                    case 6:
                        //Exit from the program
                        Console.WriteLine("Goodbye!\n");
                        break;

                    default:
                        //An error message will appear if the user enters a wrong choice.
                        Console.WriteLine("*You should choose from the list above!\n");
                        break;

                }

            }
            while (cho != 6);

        }
    }
}
//Done ❤!
