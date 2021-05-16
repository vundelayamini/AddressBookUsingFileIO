using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AddressBookFileIO
{
    class JsonOperation
    {
        public void WriteToFile(Dictionary<string, AddressBook> addressBookDictionary)//Constructor
        {
            string filePath = @"C:\Users\mahesh\source\repos\AddressBookFileIO\AddressBookFileIO\Utility\Addressbook.json";//path for storing the date in json

            string json = "";
            foreach (AddressBook obj in addressBookDictionary.Values)
            {
                foreach (Contact contact in obj.addressBook.Values)
                {
                    json = JsonConvert.SerializeObject(contact);
                    File.WriteAllText(filePath, json);
                }
            }
            Console.WriteLine("\nSuccessfully added to JSON file.");
        }
        public void ReadFromFile()
        {
            Console.WriteLine("Below are Contents of JSON File");
            object filePath = null;
            var json = File.ReadAllText((string)filePath);
            Contact contact = JsonConvert.DeserializeObject<Contact>(json);
            Console.WriteLine(contact.ToString());
        }
    }
}
}
