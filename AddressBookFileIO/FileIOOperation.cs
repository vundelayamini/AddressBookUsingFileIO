using Cake.Core.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AddressBookFileIO
{
    class FileIOOperation
    {
        
    
        public void WriteToFile(Dictionary<string, AddressBook> addressBookDictionary)//constructor
        {
            string FilePath = @"C:\Users\mahesh\source\repos\AddressBookFileIO\AddressBookFileIO\AddressBookRecord.txt";//path
            StreamWriter writer = new StreamWriter(FilePath, true);
            foreach (AddressBook addressBookobj in addressBookDictionary.Values)
            {
                foreach (Contact contact in addressBookobj.addressBook.Values)
                {
                    writer.WriteLine(contact.ToString());
                }
            }
            Console.WriteLine("\nSuccessfully added to Text file.");
            writer.Close();
        }
        public void ReadFromFile()
        {
            Console.WriteLine("Below are Contents of Text File");
            string lines = File.ReadAllText(FilePath);
            Console.WriteLine(lines);
        }
    }
}


