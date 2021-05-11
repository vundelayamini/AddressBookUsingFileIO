using System;
using System.Collections.Generic;

namespace AddressBookFileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Addressbook using FileIo");
            AddressBook addressBook = new AddressBook();//create object addressbook
            int choice, choice2;
            string bookName = "default";
            Console.WriteLine("Would You Like To \n1.Work on default AddressBook \n2.Create New AddressBook");
            choice2 = Convert.ToInt32(Console.ReadLine());//convert to integer
            switch (choice2)
            {
                case 1:
                    addressBook.AddAddressBook(bookName);
                    break;
                case 2:
                    Console.WriteLine("Enter Name Of New Addressbook You want to create : ");//create new addressbook
                    bookName = Console.ReadLine();
                    addressBook.AddAddressBook(bookName);
                    break;
            }
            do
            {
                Console.WriteLine($"Working On {bookName} AddressBook\n");
                Console.WriteLine("Choose An Option \n1.Add New Contact \n2.Edit Existing Contact \n3.Delete A Contact \n4.View A Contact \n5.View All Contacts \n6.Add New AddressBook \n7.Switch AddressBook \n8.Search Contact by city/state \n0.Exit Application\n");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter First Name :");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Enter Last Name :");
                        string lastName = Console.ReadLine();
                        Contact temp = new Contact(firstName, lastName, null, null, null, null, 0, 0);
                        if (addressBook.CheckDuplicateEntry(temp, bookName))
                        {
                            break;
                        }
                        Console.WriteLine("Enter Address :");//take iput from the user
                        string address = Console.ReadLine();//store the input for address
                        Console.WriteLine("Enter City :");//take input from the user for city
                        string city = Console.ReadLine();//store the input for city
                        Console.WriteLine("Enter State :");//take input from the user for state
                        string state = Console.ReadLine();//store the input for state
                        Console.WriteLine("Enter Email :");//take input from the user for email
                        string email = Console.ReadLine();//store input for email
                        Console.WriteLine("Enter Zip :");//take input from the user for zip
                        int zip = Convert.ToInt32(Console.ReadLine());//store iput for zip
                        Console.WriteLine("Enter Phone Number :");//take input from the user
                        long phoneNumber = long.Parse(Console.ReadLine());//store the input value
                        addressBook.AddContact(firstName, lastName, address, city, state, email, zip, phoneNumber, bookName);
                        break;
                    case 2:
                        Console.WriteLine("Enter Full Name Of Contact To Edit :");//edit the contact
                        string nameToEdit = Console.ReadLine();
                        addressBook.EditContact(nameToEdit, bookName);
                        break;
                    case 3:
                        Console.WriteLine("Enter Full Name Of Contact To Delete :");//delete contact
                        string nameToDelete = Console.ReadLine();
                        addressBook.DeleteContact(nameToDelete, bookName);
                        break;
                    case 4:
                        Console.WriteLine("Enter Full Name Of Contact To View :");//view the contact
                        string nameToView = Console.ReadLine();
                        addressBook.ViewContact(nameToView, bookName);
                        break;
                    case 5:
                        addressBook.ViewContact(bookName);
                        break;
                    case 6:
                        Console.WriteLine("Enter Name For New AddressBook");
                        string newAddressBook = Console.ReadLine();
                        addressBook.AddAddressBook(newAddressBook);
                        Console.WriteLine("Would you like to Switch to " + newAddressBook);
                        Console.WriteLine("1.Yes \n2.No");
                        int c = Convert.ToInt32(Console.ReadLine());
                        if (c == 1)
                        {
                            bookName = newAddressBook;
                        }
                        break;
                    case 7:
                        Console.WriteLine("Enter Name Of AddressBook From Below List");
                        foreach (KeyValuePair<string, AddressBook> item in addressBook.GetAddressBook())
                        {
                            Console.WriteLine(item.Key);
                        }
                        while (true)
                        {
                            bookName = Console.ReadLine();
                            if (addressBook.GetAddressBook().ContainsKey(bookName))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("No such AddressBook found. Try Again.");
                            }
                        }
                        break;
                    case 8:
                        Console.WriteLine("Would You Like To \n1.Search by city \n2.Search by state");
                        int opt = Convert.ToInt32(Console.ReadLine());
                        switch (opt)
                        {
                            case 1:
                                Console.WriteLine("Enter name of city :");
                                addressBook.SearchPersonByCity(Console.ReadLine());
                                break;
                            case 2:
                                Console.WriteLine("Enter name of state :");
                                addressBook.SearchPersonByState(Console.ReadLine());
                                break;
                            default:
                                Console.WriteLine("Invalid Input.Enter 1 or 2");
                                break;
                        }
                        break;
                    case 0:
                        Console.WriteLine("Thank You For Using Address Book System.");
                        break;
                    default:
                        Console.WriteLine("Invalid Entry. Enter value between 0 to 8");
                        break;
                }
            } while (choice != 0);
        }
    }
}
    

